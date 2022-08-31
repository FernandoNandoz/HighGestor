namespace High_Gestor.Forms.Configuracoes.Funcionarios
{
    partial class FormFuncionarios
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFuncionarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonExcluirCadastro = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.buttonAdicionarNovo = new System.Windows.Forms.Button();
            this.labelContagem = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            label1 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(10, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 24);
            label1.TabIndex = 228;
            label1.Text = "Vendedores";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelContent.Controls.Add(this.buttonVoltar);
            this.panelContent.Controls.Add(this.textBoxPesquisar);
            this.panelContent.Controls.Add(this.buttonPesquisar);
            this.panelContent.Controls.Add(this.buttonExcluirCadastro);
            this.panelContent.Controls.Add(this.buttonRelatorio);
            this.panelContent.Controls.Add(this.buttonAdicionarNovo);
            this.panelContent.Controls.Add(label1);
            this.panelContent.Controls.Add(this.labelContagem);
            this.panelContent.Controls.Add(this.dataGridViewContent);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1008, 640);
            this.panelContent.TabIndex = 0;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVoltar.BackColor = System.Drawing.Color.Transparent;
            this.buttonVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonVoltar.FlatAppearance.BorderSize = 0;
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonVoltar.Image = ((System.Drawing.Image)(resources.GetObject("buttonVoltar.Image")));
            this.buttonVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonVoltar.Location = new System.Drawing.Point(895, 6);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 234;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonSair_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxPesquisar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPesquisar.Location = new System.Drawing.Point(634, 60);
            this.textBoxPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(250, 26);
            this.textBoxPesquisar.TabIndex = 233;
            this.textBoxPesquisar.Tag = "Fornecedor";
            this.textBoxPesquisar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPesquisar_KeyUp);
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPesquisar.FlatAppearance.BorderSize = 0;
            this.buttonPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonPesquisar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPesquisar.Location = new System.Drawing.Point(894, 60);
            this.buttonPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(100, 26);
            this.buttonPesquisar.TabIndex = 232;
            this.buttonPesquisar.TabStop = false;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPesquisar.UseVisualStyleBackColor = false;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            this.buttonPesquisar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonExcluirCadastro
            // 
            this.buttonExcluirCadastro.BackColor = System.Drawing.Color.White;
            this.buttonExcluirCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirCadastro.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirCadastro.Image")));
            this.buttonExcluirCadastro.Location = new System.Drawing.Point(400, 60);
            this.buttonExcluirCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExcluirCadastro.Name = "buttonExcluirCadastro";
            this.buttonExcluirCadastro.Size = new System.Drawing.Size(153, 30);
            this.buttonExcluirCadastro.TabIndex = 231;
            this.buttonExcluirCadastro.Text = " Excluir cadastro";
            this.buttonExcluirCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExcluirCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExcluirCadastro.UseVisualStyleBackColor = false;
            this.buttonExcluirCadastro.Click += new System.EventHandler(this.buttonExcluirCadastro_Click);
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.BackColor = System.Drawing.Color.White;
            this.buttonRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.Image")));
            this.buttonRelatorio.Location = new System.Drawing.Point(178, 60);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(212, 30);
            this.buttonRelatorio.TabIndex = 230;
            this.buttonRelatorio.Text = " Relação dos vendedores";
            this.buttonRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelatorio.UseVisualStyleBackColor = false;
            this.buttonRelatorio.Click += new System.EventHandler(this.buttonRelatorio_Click);
            // 
            // buttonAdicionarNovo
            // 
            this.buttonAdicionarNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonAdicionarNovo.FlatAppearance.BorderSize = 0;
            this.buttonAdicionarNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdicionarNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionarNovo.ForeColor = System.Drawing.Color.White;
            this.buttonAdicionarNovo.Location = new System.Drawing.Point(14, 60);
            this.buttonAdicionarNovo.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAdicionarNovo.Name = "buttonAdicionarNovo";
            this.buttonAdicionarNovo.Size = new System.Drawing.Size(154, 30);
            this.buttonAdicionarNovo.TabIndex = 229;
            this.buttonAdicionarNovo.Text = "Novo vendedor";
            this.buttonAdicionarNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdicionarNovo.UseVisualStyleBackColor = false;
            this.buttonAdicionarNovo.Click += new System.EventHandler(this.buttonNovoCadastro_Click);
            this.buttonAdicionarNovo.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(591, 618);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(405, 20);
            this.labelContagem.TabIndex = 40;
            this.labelContagem.Text = "Total: N Registros";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewContent
            // 
            this.dataGridViewContent.AllowUserToAddRows = false;
            this.dataGridViewContent.AllowUserToDeleteRows = false;
            this.dataGridViewContent.AllowUserToResizeColumns = false;
            this.dataGridViewContent.AllowUserToResizeRows = false;
            this.dataGridViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.dataGridViewContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.cliente,
            this.Column1,
            this.Column5,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(14, 109);
            this.dataGridViewContent.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 35;
            this.dataGridViewContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(980, 509);
            this.dataGridViewContent.TabIndex = 166;
            this.dataGridViewContent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContent_CellDoubleClick);
            this.dataGridViewContent.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewContent_Paint);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "idFuncionario";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Codigo";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Nome completo";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Perfil de usuário";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 215;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Situação";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Image = ((System.Drawing.Image)(resources.GetObject("Column3.Image")));
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FormFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 640);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFuncionarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFuncionarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFuncionarios_FormClosing);
            this.Load += new System.EventHandler(this.FormFuncionarios_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonExcluirCadastro;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonAdicionarNovo;
    }
}