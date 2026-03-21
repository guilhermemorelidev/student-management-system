using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AcessoDados
{
    /// <summary>
    /// Classe responsável por gerenciar conexões e executar comandos no SQL Server.
    /// Implementa IDisposable para garantir a liberação adequada de recursos.
    /// </summary>
    public class ConexaoSqlServer : IDisposable
    {
        /// <summary>
        /// String de conexão com o banco de dados SQL Server.
        /// Armazenada como readonly para garantir imutabilidade após a inicialização.
        /// </summary>
        private readonly string _strConexao;

        /// <summary>
        /// Flag que indica se o objeto já foi descartado (disposed).
        /// Utilizada para evitar múltiplas chamadas ao método Dispose.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Define a maneira com que o objeto ConexaoSqlServer será inicializado.
        /// Construtor padrão que carrega a string de conexão do secrets.json.
        /// </summary>
        /// <remarks>
        /// Foi adicionado a Properties → Dependências do serviço como banco de dados local.
        /// O uso de User Secrets garante que credenciais sensíveis não sejam
        /// commitadas no controle de versão.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Lançada quando a string de conexão não é encontrada no secrets.json.
        /// </exception>
        public ConexaoSqlServer()
        {
            // Configura o builder para ler configurações do secrets.json.
            // SetBasePath: define o diretório base onde os arquivos de configuração serão buscados.
            // AddUserSecrets: adiciona o secrets.json específico do desenvolvedor (não versionado).
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddUserSecrets<ConexaoSqlServer>() // <--- Aqui você acessa o secrets.json
                .Build();

            // Obtém a string de conexão da configuração.
            // Caso não exista, lança exceção para falhar rapidamente (fail-fast pattern).
            _strConexao = config["ConnectionStrings:strConexao"]
                ?? throw new InvalidOperationException(
                    "String de conexão 'strConexao' não encontrada no secrets.json. " +
                    "Verifique se o User Secret foi configurado corretamente.");

            // Inicializa-se a listaParametros.
            // Utiliza List<SqlParameter> em vez de SqlParameterCollection para evitar
            // a criação desnecessária de um SqlCommand apenas para obter a coleção.
            this._listaParametros = new List<SqlParameter>();
        }

        /// <summary>
        /// Construtor alternativo que permite injeção de dependência da string de conexão.
        /// Útil para testes unitários e cenários onde a configuração vem de outra fonte.
        /// </summary>
        /// <param name="connectionString">String de conexão com o banco de dados.</param>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando a string de conexão fornecida é nula.
        /// </exception>
        public ConexaoSqlServer(string connectionString)
        {
            _strConexao = connectionString
                ?? throw new ArgumentNullException(nameof(connectionString),
                    "A string de conexão não pode ser nula.");

            // Inicializa-se a listaParametros.
            this._listaParametros = new List<SqlParameter>();
        }

        /// <summary>
        /// A classe representa um conjunto de parâmetros SQL (nome do parâmetro, valor).
        /// Exemplo de uso:
        /// @Nome = "Fabio Henrique";
        /// @Sobrenome = "Trevezane"
        /// </summary>
        /// <remarks>
        /// Utiliza List em vez de SqlParameterCollection para melhor performance
        /// e evitar acoplamento desnecessário com SqlCommand.
        /// </remarks>
        private List<SqlParameter> _listaParametros;

        /// <summary>
        /// Adiciona à listaParametros um novo elemento (item).
        /// Versão simplificada que aceita nome e valor diretamente.
        /// </summary>
        /// <param name="nome">Nome do parâmetro (ex: "@Nome", "@Id").</param>
        /// <param name="valor">Valor do parâmetro. Valores nulos são convertidos para DBNull.Value.</param>
        /// <remarks>
        /// Este método facilita o uso, eliminando a necessidade de criar
        /// um SqlParameter externamente.
        /// </remarks>
        public void AdicionarParametro(string nome, object? valor)
        {
            try
            {
                // Converte valores nulos para DBNull.Value, que é o padrão esperado pelo SQL Server.
                // É adicionado à lista um novo elemento.
                this._listaParametros.Add(new SqlParameter(nome, valor ?? DBNull.Value));
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao adicionar parâmetro. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Adiciona à listaParametros um novo elemento (item).
        /// </summary>
        /// <param name="parametro">
        /// Objeto SqlParameter contendo nome, valor e opcionalmente tipo, tamanho, etc.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o parâmetro fornecido é nulo.
        /// </exception>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha ao adicionar o parâmetro à lista.
        /// </exception>
        public void AdicionarParametro(SqlParameter parametro)
        {
            try
            {
                // Validação de entrada para evitar NullReferenceException posteriormente.
                ArgumentNullException.ThrowIfNull(parametro, nameof(parametro));

                // É adicionado à lista um novo elemento.
                this._listaParametros.Add(parametro);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao adicionar parâmetro. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Limpa todos os elementos contidos dentro da listaParametros.
        /// Deve ser chamado antes de executar um novo comando com parâmetros diferentes.
        /// </summary>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha ao limpar a lista de parâmetros.
        /// </exception>
        public void LimparParametros()
        {
            try
            {
                // Remove todos os elementos da coleção.
                this._listaParametros.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao limpar parâmetros. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// A classe SqlConnection representa a conexão aberta.
        /// Cria e retorna uma nova instância de conexão com o banco de dados.
        /// </summary>
        /// <returns>Nova instância de SqlConnection configurada com a string de conexão.</returns>
        /// <remarks>
        /// A conexão retornada NÃO está aberta. O chamador deve abrir a conexão
        /// usando Open() ou OpenAsync() e garantir seu fechamento com using/Dispose.
        /// </remarks>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha ao criar a conexão com o banco de dados.
        /// </exception>
        private SqlConnection CriarConexao()
        {
            try
            {
                // Na linha abaixo está sendo inicializada uma nova conexão com o BD.
                // Esta conexão deve receber os parâmetros de conexão: nome do servidor,
                // nome do banco de dados, usuário e senha.
                return new SqlConnection(_strConexao); // Adicionar ao projeto serviço conectado → vem do construtor
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao criar conexão com o BD. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Este método adiciona os parâmetros contidos na listaParametros ao comando que 
        /// será executado (SqlCommand).
        /// </summary>
        /// <param name="comando">Comando SQL que receberá os parâmetros.</param>
        /// <remarks>
        /// Os parâmetros são clonados para evitar o erro "The SqlParameter is already 
        /// contained by another SqlParameterCollection" caso o mesmo parâmetro seja
        /// reutilizado em múltiplos comandos.
        /// </remarks>
        private void SetarParametros(SqlCommand comando)
        {
            // Limpa os parâmetros do comando (somente para garantir)
            comando.Parameters.Clear();

            // Percorre todos os elementos (SqlParameter) contidos na listaParametros.
            foreach (SqlParameter parametro in this._listaParametros)
            {
                // Adiciona um novo parâmetro ao comando (Nome, Valor).
                // Cria uma nova instância para evitar conflitos de ownership.
                comando.Parameters.Add(new SqlParameter(parametro.ParameterName, parametro.Value));
            }
        }

        /// <summary>
        /// Cria e configura um SqlCommand com todos os parâmetros necessários.
        /// Método auxiliar que centraliza a criação de comandos.
        /// </summary>
        /// <param name="conexao">Conexão SQL aberta.</param>
        /// <param name="textoComando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <returns>SqlCommand configurado e pronto para execução.</returns>
        private SqlCommand CriarComando(
            SqlConnection conexao,
            string textoComando,
            CommandType tipoComando,
            int timeoutSegundos = 30)
        {
            // Adiciona à conexão um comando SQL (SqlCommand).
            SqlCommand comandoSql = conexao.CreateCommand();

            // Define qual o texto do comando. Ex: INSERT INTO tblCliente ...
            comandoSql.CommandText = textoComando;

            // Define qual o tipo do comando. Ex.: texto e stored procedure.
            comandoSql.CommandType = tipoComando;

            // Define o tempo máximo para execução do comando em segundos.
            // Valor padrão de 30 segundos é adequado para a maioria das operações.
            // Para operações longas, passe um valor maior como parâmetro.
            comandoSql.CommandTimeout = timeoutSegundos;

            // Adiciona os parâmetros ao comandoSql.
            SetarParametros(comandoSql);

            return comandoSql;
        }

        /// <summary>
        /// Método que envia ao banco de dados comandos de INSERT, UPDATE e DELETE.
        /// Retorna o primeiro valor da primeira linha do resultado (útil para SCOPE_IDENTITY).
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <returns>
        /// Primeiro valor da primeira linha do resultado, ou null se não houver resultado.
        /// </returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha na execução do comando.
        /// </exception>
        public object? ExecutarScalar(string comando, CommandType tipoComando, int timeoutSegundos = 30)
        {
            try
            {
                // Using: garante que a conexão será fechada e os recursos liberados
                // ao final do bloco, mesmo que ocorra uma exceção.
                // Isso é fundamental para evitar vazamento de conexões (connection leak).
                using (SqlConnection conexao = CriarConexao())
                {
                    // Abre a conexão com o banco de dados.
                    conexao.Open();

                    // Cria e configura o comando SQL.
                    using (SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos))
                    {
                        // Envia o comandoSql ao banco de dados e aguarda a execução do mesmo.
                        // Caso o comando retorne valor, o mesmo será enviado à camada de negócios.
                        return comandoSql.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar comando. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Método que envia ao banco de dados comandos de INSERT, UPDATE e DELETE.
        /// Retorna o número de linhas afetadas pela operação.
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <returns>Número de linhas afetadas pelo comando.</returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha na execução do comando.
        /// </exception>
        public int ExecutarNonQuery(string comando, CommandType tipoComando, int timeoutSegundos = 30)
        {
            try
            {
                // Using: garante que a conexão será fechada e os recursos liberados
                // ao final do bloco, mesmo que ocorra uma exceção.
                using (SqlConnection conexao = CriarConexao())
                {
                    // Abre a conexão com o banco de dados.
                    conexao.Open();

                    // Cria e configura o comando SQL.
                    using (SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos))
                    {
                        // Executa o comando e retorna o número de linhas afetadas.
                        // Útil para validar se a operação teve efeito no banco.
                        return comandoSql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar comando. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Método que envia comandos de consulta ao banco de dados (SELECT).
        /// Este método retorna uma tabela (DataTable).
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <returns>DataTable contendo o resultado da consulta.</returns>
        /// <exception cref="Exception">
        /// Lançada quando ocorre falha na execução da consulta.
        /// </exception>
        public DataTable ExecutarConsulta(string comando, CommandType tipoComando, int timeoutSegundos = 30)
        {
            try
            {
                // Using: garante que a conexão será fechada e os recursos liberados
                // ao final do bloco, mesmo que ocorra uma exceção.
                using (SqlConnection conexao = CriarConexao())
                {
                    // Abre a conexão com o banco de dados.
                    conexao.Open();

                    // Cria e configura o comando SQL.
                    using (SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos))
                    {
                        // SqlDataAdapter é a classe responsável por enviar um comando de consulta
                        // ao banco de dados.
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(comandoSql))
                        {
                            // DataTable: representa uma única tabela de dados em memória.
                            // Mais eficiente que DataSet quando se espera apenas uma tabela.
                            DataTable dataTable = new DataTable();

                            // Método Fill preenche o dataTable com o resultado da execução da consulta.
                            sqlDataAdapter.Fill(dataTable);

                            // Retorna a tabela preenchida com os dados.
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar consulta. Motivo: " + ex.Message, ex);
            }
        }

        #region Métodos Assíncronos

        /// <summary>
        /// Versão assíncrona do ExecutarScalar.
        /// Método que envia ao banco de dados comandos de INSERT, UPDATE e DELETE de forma assíncrona.
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>
        /// Task contendo o primeiro valor da primeira linha do resultado, 
        /// ou null se não houver resultado.
        /// </returns>
        /// <remarks>
        /// Use este método em aplicações que requerem alta responsividade,
        /// como aplicações web ou interfaces gráficas.
        /// </remarks>
        public async Task<object?> ExecutarScalarAsync(
            string comando,
            CommandType tipoComando,
            int timeoutSegundos = 30,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // await using: versão assíncrona do using para IAsyncDisposable.
                // Garante liberação adequada de recursos em contexto assíncrono.
                await using SqlConnection conexao = CriarConexao();

                // Abre a conexão de forma assíncrona, não bloqueando a thread.
                await conexao.OpenAsync(cancellationToken);

                await using SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos);

                // Envia o comandoSql ao banco de dados de forma assíncrona.
                return await comandoSql.ExecuteScalarAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar comando assíncrono. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Versão assíncrona do ExecutarNonQuery.
        /// Método que envia ao banco de dados comandos de INSERT, UPDATE e DELETE de forma assíncrona.
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>Task contendo o número de linhas afetadas pelo comando.</returns>
        public async Task<int> ExecutarNonQueryAsync(
            string comando,
            CommandType tipoComando,
            int timeoutSegundos = 30,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await using SqlConnection conexao = CriarConexao();
                await conexao.OpenAsync(cancellationToken);

                await using SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos);

                // Executa o comando de forma assíncrona e retorna linhas afetadas.
                return await comandoSql.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar comando assíncrono. Motivo: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Versão assíncrona do ExecutarConsulta.
        /// Método que envia comandos de consulta ao banco de dados (SELECT) de forma assíncrona.
        /// Este método retorna uma tabela (DataTable).
        /// </summary>
        /// <param name="comando">Texto do comando SQL ou nome da Stored Procedure.</param>
        /// <param name="tipoComando">Tipo do comando (Text ou StoredProcedure).</param>
        /// <param name="timeoutSegundos">Tempo máximo de execução em segundos (padrão: 30).</param>
        /// <param name="cancellationToken">Token para cancelamento da operação.</param>
        /// <returns>Task contendo DataTable com o resultado da consulta.</returns>
        /// <remarks>
        /// Utiliza ExecuteReaderAsync + DataTable.Load() que é mais eficiente
        /// em cenários assíncronos do que SqlDataAdapter.
        /// </remarks>
        public async Task<DataTable> ExecutarConsultaAsync(
            string comando,
            CommandType tipoComando,
            int timeoutSegundos = 30,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await using SqlConnection conexao = CriarConexao();
                await conexao.OpenAsync(cancellationToken);

                await using SqlCommand comandoSql = CriarComando(conexao, comando, tipoComando, timeoutSegundos);

                // ExecuteReaderAsync retorna um SqlDataReader para leitura assíncrona.
                // Mais eficiente que SqlDataAdapter em cenário async.
                using SqlDataReader reader = await comandoSql.ExecuteReaderAsync(cancellationToken);

                // DataTable: representa uma única tabela de dados em memória.
                DataTable dataTable = new DataTable();

                // Load carrega os dados do reader para o DataTable.
                dataTable.Load(reader);

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao executar consulta assíncrona. Motivo: " + ex.Message, ex);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Libera os recursos utilizados pela instância.
        /// Implementação do padrão IDisposable.
        /// </summary>
        /// <remarks>
        /// Limpa a lista de parâmetros e marca o objeto como descartado.
        /// Deve ser chamado quando o objeto não for mais necessário,
        /// preferencialmente através de um bloco using.
        /// </remarks>
        public void Dispose()
        {
            // Verifica se já foi descartado para evitar operações duplicadas.
            if (!_disposed)
            {
                // Limpa a lista de parâmetros para liberar referências.
                _listaParametros.Clear();

                // Marca como descartado.
                _disposed = true;
            }

            // Informa ao GC que não precisa chamar o finalizador,
            // pois os recursos já foram liberados.
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}