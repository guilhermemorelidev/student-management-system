namespace Apresentacao
{
    partial class FrmInsAltExcAlunos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsAltExcAlunos));
            btnAlterar = new Button();
            imageList1 = new ImageList(components);
            btnCadastrar = new Button();
            btnSair = new Button();
            btnExcluir = new Button();
            pbLogoAluno = new PictureBox();
            lbId = new Label();
            lbNome = new Label();
            txtNome = new TextBox();
            txtId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbLogoAluno).BeginInit();
            SuspendLayout();
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.Gold;
            btnAlterar.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlterar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAlterar.ImageKey = "systemsoftwareupdate_94333.png";
            btnAlterar.ImageList = imageList1;
            btnAlterar.Location = new Point(107, 107);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(83, 33);
            btnAlterar.TabIndex = 10;
            btnAlterar.Text = "Alterar";
            btnAlterar.TextAlign = ContentAlignment.MiddleRight;
            btnAlterar.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "3844432-magnifier-search-zoom_110300.png");
            imageList1.Images.SetKeyName(1, "save_file_disk_open_searsh_loading_clipboard_1513.png");
            imageList1.Images.SetKeyName(2, "waste_bin_delete_remove_recycle_icon_123840.png");
            imageList1.Images.SetKeyName(3, "remove_delete_exit_close_1545.png");
            imageList1.Images.SetKeyName(4, "systemsoftwareupdate_94333.png");
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.SpringGreen;
            btnCadastrar.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCadastrar.ImageKey = "save_file_disk_open_searsh_loading_clipboard_1513.png";
            btnCadastrar.ImageList = imageList1;
            btnCadastrar.Location = new Point(12, 107);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(89, 33);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Inserir";
            btnCadastrar.TextAlign = ContentAlignment.MiddleRight;
            btnCadastrar.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.DarkRed;
            btnSair.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnSair.FlatAppearance.MouseOverBackColor = Color.Red;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSair.ForeColor = SystemColors.MenuBar;
            btnSair.ImageAlign = ContentAlignment.MiddleLeft;
            btnSair.ImageKey = "remove_delete_exit_close_1545.png";
            btnSair.ImageList = imageList1;
            btnSair.Location = new Point(285, 107);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(83, 33);
            btnSair.TabIndex = 8;
            btnSair.Text = "Sair";
            btnSair.TextAlign = ContentAlignment.MiddleRight;
            btnSair.UseVisualStyleBackColor = false;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.OrangeRed;
            btnExcluir.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Candara", 11F, FontStyle.Bold);
            btnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluir.ImageKey = "waste_bin_delete_remove_recycle_icon_123840.png";
            btnExcluir.ImageList = imageList1;
            btnExcluir.Location = new Point(196, 107);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(83, 33);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = false;
            // 
            // pbLogoAluno
            // 
            pbLogoAluno.Image = (Image)resources.GetObject("pbLogoAluno.Image");
            pbLogoAluno.Location = new Point(12, 12);
            pbLogoAluno.Name = "pbLogoAluno";
            pbLogoAluno.Size = new Size(64, 64);
            pbLogoAluno.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogoAluno.TabIndex = 11;
            pbLogoAluno.TabStop = false;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.ForeColor = Color.White;
            lbId.Location = new Point(81, 25);
            lbId.Name = "lbId";
            lbId.Size = new Size(20, 15);
            lbId.TabIndex = 12;
            lbId.Text = "Id:";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.ForeColor = Color.White;
            lbNome.Location = new Point(82, 61);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(43, 15);
            lbNome.TabIndex = 13;
            lbNome.Text = "Nome:";
            lbNome.Click += label1_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(131, 61);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.Location = new Point(108, 22);
            txtId.MaxLength = 255;
            txtId.Name = "txtId";
            txtId.Size = new Size(58, 23);
            txtId.TabIndex = 16;
            // 
            // FrmInsAltExcAlunos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(383, 158);
            Controls.Add(txtId);
            Controls.Add(txtNome);
            Controls.Add(lbNome);
            Controls.Add(lbId);
            Controls.Add(pbLogoAluno);
            Controls.Add(btnAlterar);
            Controls.Add(btnCadastrar);
            Controls.Add(btnSair);
            Controls.Add(btnExcluir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmInsAltExcAlunos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInsAltExcAlunos";
            Load += FrmInsAltExcAlunos_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogoAluno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAlterar;
        private ImageList imageList1;
        private Button btnCadastrar;
        private Button btnSair;
        private Button btnExcluir;
        private PictureBox pbLogoAluno;
        private Label lbId;
        private Label lbNome;
        private TextBox txtNome;
        private TextBox txtId;
    }
}