using AcessoDados;
using Microsoft.Data.SqlClient;
using ObjetoTransferencia;
using System.ComponentModel;
using System.Data;

namespace Negocios
{
    public class NegAluno
    {


        ConexaoSqlServer conexaoSql = new ConexaoSqlServer();


        //cadastro
        public bool InserirAluno(Aluno aluno)
        {
            try
            {
                conexaoSql.LimparParametros();
                conexaoSql.AdicionarParametro(new SqlParameter("@Nome", aluno.Nome));

                string comandoSql = "exec uspInserirAluno @nome";

                object result = conexaoSql.ExecutarScalar(comandoSql, CommandType.StoredProcedure);

                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir aluno: " + ex.Message);
            }
        }
        //alteração
        public bool AlterarAluno(Aluno aluno)
        {
            try
            {
                conexaoSql.AdicionarParametro(new SqlParameter("@Id", aluno.Id));
                conexaoSql.LimparParametros();
                conexaoSql.AdicionarParametro(new SqlParameter("@Nome", aluno.Nome));

                string comandoSql = "exec uspInserirAluno @nome";

                object result = conexaoSql.ExecutarScalar(comandoSql, CommandType.StoredProcedure);

                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar aluno: " + ex.Message);
            }
        }

        //Exclusão
        public bool ExcluirAluno(int id)
        {
            try
            {
                conexaoSql.LimparParametros();
                conexaoSql.AdicionarParametro(new SqlParameter("@Id", id));

                string comandoSql = "exec uspExcluirAluno";

                object result = conexaoSql.ExecutarScalar(comandoSql, CommandType.StoredProcedure);

                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir aluno: " + ex.Message);
            }
        }


        //busca por nome 
        public BindingList<Aluno> BuscarCursoPorNome(string nome)
        {
            try
            {
                DataTable tabelaResultado;
                BindingList<Aluno> alunos = new BindingList<Aluno>();

                conexaoSql.LimparParametros();
                conexaoSql.AdicionarParametro(new SqlParameter("@Nome", nome));

                string comando = "exec uspBuscarAlunoPorNome";

                tabelaResultado = conexaoSql.ExecutarConsulta(comando, CommandType.StoredProcedure);

                foreach (DataRow registro in tabelaResultado.Rows)
                {
                    Aluno aluno = new Aluno(
                        Convert.ToInt32(registro["Id"]),
                        registro["NomeCurso"].ToString()
                    );

                    alunos.Add(aluno);
                }

                return alunos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar cursos. Motivo: " + ex.Message);
            }
        }


    }
}
