# 🎓 SolutionAlunos — Sistema de Cadastro de Alunos

Sistema desktop de gerenciamento de alunos desenvolvido em **C#** com **Windows Forms**, seguindo a arquitetura em camadas (N-Tier). Conectado ao **SQL Server** via stored procedures.

---

## 📋 Sobre o projeto

Aplicação CRUD completa para cadastro, consulta, alteração e exclusão de alunos, com interface gráfica e acesso seguro ao banco de dados. Projeto desenvolvido para consolidar conhecimentos em C#, SQL Server e boas práticas de arquitetura de software.

---

## 🏗️ Arquitetura

O projeto segue o padrão de **arquitetura em camadas (N-Tier)**, separando responsabilidades em três projetos distintos:

```
SolutionAlunosSabado/
├── Apresentacao/          # Camada de apresentação — Windows Forms (UI)
│   ├── FrmAluno.cs        # Formulário principal de listagem
│   └── FrmInsAltExcAlunos.cs  # Formulário de inserção, alteração e exclusão
│
├── Negocios/              # Camada de negócios — regras e lógica da aplicação
│   └── NegAluno.cs        # Operações de negócio do aluno
│
├── AcessoDados/           # Camada de dados — comunicação com o banco
│   └── ConexaoSqlServer.cs # Classe genérica de conexão com SQL Server
│
└── ObjetoTransferencia/   # DTOs — objetos de transferência de dados
    └── Aluno.cs           # Entidade Aluno
```

---

## ✨ Funcionalidades

- ✅ Cadastrar novo aluno
- ✅ Buscar aluno por nome
- ✅ Alterar dados do aluno
- ✅ Excluir aluno
- ✅ Listar alunos em DataGridView
- ✅ Execução de stored procedures parametrizadas
- ✅ Métodos síncronos e assíncronos para acesso ao banco

---

## 🛠️ Tecnologias utilizadas

| Tecnologia | Versão | Uso |
|---|---|---|
| C# | .NET 10 | Linguagem principal |
| Windows Forms | .NET 10 | Interface gráfica |
| SQL Server | — | Banco de dados |
| Microsoft.Data.SqlClient | 7.0.0 | Conexão com banco |
| User Secrets | 10.0.0 | Gerenciamento seguro de credenciais |

---

## 🚀 Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (local ou remoto)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou superior

### Passos

1. **Clone o repositório**
```bash
git clone https://github.com/guilhermemorelidev/SolutionAlunos.git
cd SolutionAlunos
```

2. **Configure a string de conexão via User Secrets**
```bash
cd SolutionAlunosSabado/AcessoDados
dotnet user-secrets set "ConnectionStrings:strConexao" "Server=SEU_SERVIDOR;Database=SUA_BASE;User Id=SEU_USUARIO;Password=SUA_SENHA;"
```

3. **Execute as stored procedures no SQL Server**

```sql
-- Criar a tabela de alunos
CREATE TABLE tblAluno (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL
);

-- Stored procedure: inserir aluno
CREATE PROCEDURE uspInserirAluno
    @Nome VARCHAR(100)
AS
BEGIN
    INSERT INTO tblAluno (Nome) VALUES (@Nome);
    SELECT SCOPE_IDENTITY();
END;

-- Stored procedure: buscar aluno por nome
CREATE PROCEDURE uspBuscarAlunoPorNome
    @Nome VARCHAR(100)
AS
BEGIN
    SELECT Id, Nome FROM tblAluno
    WHERE Nome LIKE '%' + @Nome + '%';
END;

-- Stored procedure: excluir aluno
CREATE PROCEDURE uspExcluirAluno
    @Id INT
AS
BEGIN
    DELETE FROM tblAluno WHERE Id = @Id;
    SELECT @@ROWCOUNT;
END;
```

4. **Abra a solução no Visual Studio**
```
SolutionAlunosSabado.sln
```

5. **Defina `Apresentacao` como projeto de inicialização e pressione F5**

---

## 🔒 Boas práticas implementadas

- **User Secrets** — credenciais nunca vão para o repositório
- **IDisposable** — liberação adequada de recursos de conexão
- **Parametrização SQL** — prevenção contra SQL Injection
- **Métodos assíncronos** — versões `Async` disponíveis para todas as operações
- **Fail-fast** — exceções lançadas cedo para facilitar diagnóstico

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.

---

<p align="center">
  Desenvolvido por <a href="https://github.com/guilhermemorelidev">Guilherme Moreli</a>
</p>
