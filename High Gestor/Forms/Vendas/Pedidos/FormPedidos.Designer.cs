namespace High_Gestor.Forms.Vendas.Pedidos
{
    partial class FormPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBack = new System.Windows.Forms.Panel();
            this.linkLabelBuscaAvancada = new System.Windows.Forms.LinkLabel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelContagem = new System.Windows.Forms.Label();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonExcluirCadastro = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.buttonNovoCadastro = new System.Windows.Forms.Button();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocorrencias = new System.Windows.Forms.DataGridViewImageColumn();
            this.Acao = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            label1 = new System.Windows.Forms.Label();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(22, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 26);
            label1.TabIndex = 218;
            label1.Text = "Pedidos";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelBack.Controls.Add(this.linkLabelBuscaAvancada);
            this.panelBack.Controls.Add(this.buttonVoltar);
            this.panelBack.Controls.Add(this.labelContagem);
            this.panelBack.Controls.Add(label1);
            this.panelBack.Controls.Add(this.textBoxPesquisar);
            this.panelBack.Controls.Add(this.buttonPesquisar);
            this.panelBack.Controls.Add(this.buttonExcluirCadastro);
            this.panelBack.Controls.Add(this.buttonRelatorio);
            this.panelBack.Controls.Add(this.buttonNovoCadastro);
            this.panelBack.Controls.Add(this.dataGridViewContent);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Margin = new System.Windows.Forms.Padding(0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(1208, 640);
            this.panelBack.TabIndex = 1;
            // 
            // linkLabelBuscaAvancada
            // 
            this.linkLabelBuscaAvancada.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabelBuscaAvancada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelBuscaAvancada.AutoSize = true;
            this.linkLabelBuscaAvancada.Image = ((System.Drawing.Image)(resources.GetObject("linkLabelBuscaAvancada.Image")));
            this.linkLabelBuscaAvancada.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.linkLabelBuscaAvancada.LinkColor = System.Drawing.Color.Gray;
            this.linkLabelBuscaAvancada.Location = new System.Drawing.Point(699, 71);
            this.linkLabelBuscaAvancada.Name = "linkLabelBuscaAvancada";
            this.linkLabelBuscaAvancada.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.linkLabelBuscaAvancada.Size = new System.Drawing.Size(101, 13);
            this.linkLabelBuscaAvancada.TabIndex = 220;
            this.linkLabelBuscaAvancada.TabStop = true;
            this.linkLabelBuscaAvancada.Text = "Busca avançada";
            this.linkLabelBuscaAvancada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.buttonVoltar.Location = new System.Drawing.Point(1105, 3);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 219;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(919, 617);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(264, 17);
            this.labelContagem.TabIndex = 125;
            this.labelContagem.Text = "Total: N Registros";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxPesquisar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPesquisar.Location = new System.Drawing.Point(817, 63);
            this.textBoxPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(250, 26);
            this.textBoxPesquisar.TabIndex = 155;
            this.textBoxPesquisar.Tag = "Fornecedor";
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
            this.buttonPesquisar.Location = new System.Drawing.Point(1077, 63);
            this.buttonPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(100, 26);
            this.buttonPesquisar.TabIndex = 154;
            this.buttonPesquisar.TabStop = false;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPesquisar.UseVisualStyleBackColor = false;
            this.buttonPesquisar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonExcluirCadastro
            // 
            this.buttonExcluirCadastro.BackColor = System.Drawing.Color.White;
            this.buttonExcluirCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirCadastro.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirCadastro.Image")));
            this.buttonExcluirCadastro.Location = new System.Drawing.Point(360, 61);
            this.buttonExcluirCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExcluirCadastro.Name = "buttonExcluirCadastro";
            this.buttonExcluirCadastro.Size = new System.Drawing.Size(153, 32);
            this.buttonExcluirCadastro.TabIndex = 135;
            this.buttonExcluirCadastro.Text = " Excluir cadastro";
            this.buttonExcluirCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExcluirCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExcluirCadastro.UseVisualStyleBackColor = false;
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.BackColor = System.Drawing.Color.White;
            this.buttonRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.Image")));
            this.buttonRelatorio.Location = new System.Drawing.Point(179, 61);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(171, 32);
            this.buttonRelatorio.TabIndex = 133;
            this.buttonRelatorio.Text = " Relação de pedidos";
            this.buttonRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRelatorio.UseVisualStyleBackColor = false;
            // 
            // buttonNovoCadastro
            // 
            this.buttonNovoCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonNovoCadastro.FlatAppearance.BorderSize = 0;
            this.buttonNovoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNovoCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNovoCadastro.ForeColor = System.Drawing.Color.White;
            this.buttonNovoCadastro.Location = new System.Drawing.Point(26, 61);
            this.buttonNovoCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonNovoCadastro.Name = "buttonNovoCadastro";
            this.buttonNovoCadastro.Size = new System.Drawing.Size(143, 32);
            this.buttonNovoCadastro.TabIndex = 132;
            this.buttonNovoCadastro.Text = "Novo pedido";
            this.buttonNovoCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNovoCadastro.UseVisualStyleBackColor = false;
            this.buttonNovoCadastro.Click += new System.EventHandler(this.buttonNovoCadastro_Click);
            this.buttonNovoCadastro.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // dataGridViewContent
            // 
            this.dataGridViewContent.AllowUserToAddRows = false;
            this.dataGridViewContent.AllowUserToDeleteRows = false;
            this.dataGridViewContent.AllowUserToResizeColumns = false;
            this.dataGridViewContent.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dataGridViewContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.dataGridViewContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewContent.ColumnHeadersHeight = 30;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.cliente,
            this.Column2,
            this.Column4,
            this.Column1,
            this.Column3,
            this.Ocorrencias,
            this.Acao});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(26, 106);
            this.dataGridViewContent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1157, 507);
            this.dataGridViewContent.TabIndex = 130;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nº";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Nome do cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CPF/CNPJ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nº Produtor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Situação";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tipo de Pessoa";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Ocorrencias
            // 
            this.Ocorrencias.Description = "Ocorrencia";
            this.Ocorrencias.HeaderText = "";
            this.Ocorrencias.Image = ((System.Drawing.Image)(resources.GetObject("Ocorrencias.Image")));
            this.Ocorrencias.Name = "Ocorrencias";
            this.Ocorrencias.ReadOnly = true;
            this.Ocorrencias.ToolTipText = "Ocorrencia";
            this.Ocorrencias.Width = 40;
            // 
            // Acao
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle10.NullValue")));
            this.Acao.DefaultCellStyle = dataGridViewCellStyle10;
            this.Acao.Description = "Acões";
            this.Acao.HeaderText = "";
            this.Acao.Image = ((System.Drawing.Image)(resources.GetObject("Acao.Image")));
            this.Acao.Name = "Acao";
            this.Acao.ReadOnly = true;
            this.Acao.ToolTipText = "Acões";
            this.Acao.Width = 60;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Description = "Ocorrencia";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Ocorrencia";
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle14.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewImageColumn2.Description = "Acões";
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Acões";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.panelBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPedidos";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonExcluirCadastro;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonNovoCadastro;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Ocorrencias;
        private System.Windows.Forms.DataGridViewImageColumn Acao;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.LinkLabel linkLabelBuscaAvancada;
    }
}