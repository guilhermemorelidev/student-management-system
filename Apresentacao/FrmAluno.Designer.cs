namespace Apresentacao
{
    partial class FrmAluno
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAluno));
            txtBuscarAluno = new TextBox();
            btnBuscarAluno = new Button();
            dgvAluno = new DataGridView();
            pbFoto = new PictureBox();
            imageListAluno = new ImageList(components);
            btnSair = new Button();
            btnCadastrar = new Button();
            btnAlterar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAluno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // txtBuscarAluno
            // 
            txtBuscarAluno.Location = new Point(104, 75);
            txtBuscarAluno.MaxLength = 120;
            txtBuscarAluno.Name = "txtBuscarAluno";
            txtBuscarAluno.PlaceholderText = "Digite um nome para buscar";
            txtBuscarAluno.Size = new Size(163, 23);
            txtBuscarAluno.TabIndex = 0;
            // 
            // btnBuscarAluno
            // 
            btnBuscarAluno.BackColor = Color.LightSkyBlue;
            btnBuscarAluno.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnBuscarAluno.FlatStyle = FlatStyle.Flat;
            btnBuscarAluno.Font = new Font("Candara", 11F, FontStyle.Bold);
            btnBuscarAluno.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscarAluno.ImageKey = "3844432-magnifier-search-zoom_110300.png";
            btnBuscarAluno.ImageList = imageListAluno;
            btnBuscarAluno.Location = new Point(273, 65);
            btnBuscarAluno.Name = "btnBuscarAluno";
            btnBuscarAluno.Size = new Size(83, 33);
            btnBuscarAluno.TabIndex = 1;
            btnBuscarAluno.Text = "   Buscar";
            btnBuscarAluno.TextAlign = ContentAlignment.MiddleRight;
            btnBuscarAluno.UseVisualStyleBackColor = false;
            // 
            // dgvAluno
            // 
            dgvAluno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAluno.Location = new Point(12, 104);
            dgvAluno.Name = "dgvAluno";
            dgvAluno.Size = new Size(344, 274);
            dgvAluno.TabIndex = 2;
            // 
            // pbFoto
            // 
            pbFoto.Image = (Image)resources.GetObject("pbFoto.Image");
            pbFoto.InitialImage = (Image)resources.GetObject("pbFoto.InitialImage");
            pbFoto.Location = new Point(12, 12);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(86, 86);
            pbFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFoto.TabIndex = 3;
            pbFoto.TabStop = false;
            // 
            // imageListAluno
            // 
            imageListAluno.ColorDepth = ColorDepth.Depth32Bit;
            imageListAluno.ImageStream = (ImageListStreamer)resources.GetObject("imageListAluno.ImageStream");
            imageListAluno.TransparentColor = Color.Transparent;
            imageListAluno.Images.SetKeyName(0, "waste_bin_delete_remove_recycle_icon_123840.png");
            imageListAluno.Images.SetKeyName(1, "remove_delete_exit_close_1545.png");
            imageListAluno.Images.SetKeyName(2, "systemsoftwareupdate_94333.png");
            imageListAluno.Images.SetKeyName(3, "3844432-magnifier-search-zoom_110300.png");
            imageListAluno.Images.SetKeyName(4, "save_file_disk_open_searsh_loading_clipboard_1513.png");
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.DarkRed;
            btnSair.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Font = new Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSair.ForeColor = SystemColors.MenuBar;
            btnSair.ImageAlign = ContentAlignment.MiddleLeft;
            btnSair.ImageKey = "remove_delete_exit_close_1545.png";
            btnSair.ImageList = imageListAluno;
            btnSair.Location = new Point(273, 384);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(83, 33);
            btnSair.TabIndex = 4;
            btnSair.Text = "Sair";
            btnSair.TextAlign = ContentAlignment.MiddleRight;
            btnSair.UseVisualStyleBackColor = false;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.SpringGreen;
            btnCadastrar.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCadastrar.ImageKey = "save_file_disk_open_searsh_loading_clipboard_1513.png";
            btnCadastrar.ImageList = imageListAluno;
            btnCadastrar.Location = new Point(12, 384);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(89, 33);
            btnCadastrar.TabIndex = 5;
            btnCadastrar.Text = "   Cadastrar";
            btnCadastrar.TextAlign = ContentAlignment.MiddleRight;
            btnCadastrar.UseVisualStyleBackColor = false;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.Gold;
            btnAlterar.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlterar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAlterar.ImageKey = "systemsoftwareupdate_94333.png";
            btnAlterar.ImageList = imageListAluno;
            btnAlterar.Location = new Point(107, 384);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(83, 33);
            btnAlterar.TabIndex = 6;
            btnAlterar.Text = "Alterar";
            btnAlterar.TextAlign = ContentAlignment.MiddleRight;
            btnAlterar.UseVisualStyleBackColor = false;
            // 
            // FrmAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(367, 421);
            Controls.Add(btnAlterar);
            Controls.Add(btnCadastrar);
            Controls.Add(btnSair);
            Controls.Add(pbFoto);
            Controls.Add(dgvAluno);
            Controls.Add(btnBuscarAluno);
            Controls.Add(txtBuscarAluno);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmAluno";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alunos Controle";
            ((System.ComponentModel.ISupportInitialize)dgvAluno).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscarAluno;
        private Button btnBuscarAluno;
        private DataGridView dgvAluno;
        private PictureBox pbFoto;
        private ImageList imageListAluno;
        private Button btnSair;
        private Button btnCadastrar;
        private Button btnAlterar;
    }
}
