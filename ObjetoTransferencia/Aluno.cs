using System.Runtime.CompilerServices;

namespace ObjetoTransferencia
{
    public class Aluno
    {
    public int Id {  get; set; }
    public string Nome { get; set; } = string.Empty;

    public Aluno (int id, string nome ) {
          Id = id;
          Nome = nome;
        }
    public Aluno()
        {

        }
    public class AlunoColecao : List<Aluno>
        {

        }
    
    }
}
