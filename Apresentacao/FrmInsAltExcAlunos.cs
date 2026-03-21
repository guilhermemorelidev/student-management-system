using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmInsAltExcAlunos : Form
    {
        //instancia o obj aluno 
        Aluno objAluno = new Aluno();


        public FrmInsAltExcAlunos(Aluno aluno)
        {
            InitializeComponent();

            objAluno = aluno ?? new Aluno();
        }

        private void MetodoPreencherFormulario()
        {
            // Lógica para preencher o formulário com os dados do aluno selecionado
            // Exemplo:
            // txtId.Text = aluno.Id.ToString();
            // txtNome.Text = aluno.Nome;

            if (objAluno.Id != 0)
            {
                txtNome.Text = objAluno.Nome;
                txtId.Text = objAluno.Id.ToString();

                lbId.Visible = true;
                txtId.Visible = true;
                txtId.Enabled = false;


                btnCadastrar.Visible = false;
                btnExcluir.Visible = true;
                btnAlterar.Visible = true;

            }
            else
            {
                lbId.Visible = false;
                txtId.Visible = false;
                btnAlterar.Visible = false;
                btnExcluir.Visible = false;
                btnCadastrar.Visible = true;
            }

        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            return true;
        }


        private void FrmInsAltExcAlunos_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
