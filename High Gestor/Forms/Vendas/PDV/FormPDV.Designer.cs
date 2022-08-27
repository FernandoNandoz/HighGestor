namespace High_Gestor.Forms.Vendas.PDV
{
    partial class FormPDV
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
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDV));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelStatusCaixa = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBoxSaldoCaixa = new System.Windows.Forms.GroupBox();
            this.labelSandoAnterior = new System.Windows.Forms.Label();
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
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ocorrencias = new System.Windows.Forms.DataGridViewImageColumn();
            this.Acao = new System.Windows.Forms.DataGridViewImageColumn();
            label13 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBoxSaldoCaixa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStatusCaixa
            // 
            this.labelStatusCaixa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatusCaixa.AutoSize = true;
            this.labelStatusCaixa.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusCaixa.Location = new System.Drawing.Point(102, 69);
            this.labelStatusCaixa.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatusCaixa.Name = "labelStatusCaixa";
            this.labelStatusCaixa.Size = new System.Drawing.Size(76, 20);
            this.labelStatusCaixa.TabIndex = 22;
            this.labelStatusCaixa.Text = "FECHADO";
            // 
            // label13
            // 
            label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(92, 14);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(97, 20);
            label13.TabIndex = 20;
            label13.Text = "Caixa padrão";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(23, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 24);
            label1.TabIndex = 229;
            label1.Text = "PDV";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImageColumn2.Description = "Acões";
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ToolTipText = "Acões";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // groupBoxSaldoCaixa
            // 
            this.groupBoxSaldoCaixa.AutoSize = true;
            this.groupBoxSaldoCaixa.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSaldoCaixa.Controls.Add(this.labelStatusCaixa);
            this.groupBoxSaldoCaixa.Controls.Add(this.labelSandoAnterior);
            this.groupBoxSaldoCaixa.Controls.Add(label13);
            this.groupBoxSaldoCaixa.Location = new System.Drawing.Point(46, 41);
            this.groupBoxSaldoCaixa.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoCaixa.Name = "groupBoxSaldoCaixa";
            this.groupBoxSaldoCaixa.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoCaixa.Size = new System.Drawing.Size(280, 102);
            this.groupBoxSaldoCaixa.TabIndex = 232;
            this.groupBoxSaldoCaixa.TabStop = false;
            // 
            // labelSandoAnterior
            // 
            this.labelSandoAnterior.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSandoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSandoAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelSandoAnterior.Location = new System.Drawing.Point(18, 42);
            this.labelSandoAnterior.Name = "labelSandoAnterior";
            this.labelSandoAnterior.Size = new System.Drawing.Size(242, 20);
            this.labelSandoAnterior.TabIndex = 21;
            this.labelSandoAnterior.Text = "R$ 0,00";
            this.labelSandoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelBuscaAvancada
            // 
            this.linkLabelBuscaAvancada.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabelBuscaAvancada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelBuscaAvancada.AutoSize = true;
            this.linkLabelBuscaAvancada.Image = ((System.Drawing.Image)(resources.GetObject("linkLabelBuscaAvancada.Image")));
            this.linkLabelBuscaAvancada.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.linkLabelBuscaAvancada.LinkColor = System.Drawing.Color.Gray;
            this.linkLabelBuscaAvancada.Location = new System.Drawing.Point(702, 173);
            this.linkLabelBuscaAvancada.Name = "linkLabelBuscaAvancada";
            this.linkLabelBuscaAvancada.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.linkLabelBuscaAvancada.Size = new System.Drawing.Size(101, 13);
            this.linkLabelBuscaAvancada.TabIndex = 231;
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
            this.buttonVoltar.Location = new System.Drawing.Point(1105, 5);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 230;
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
            this.labelContagem.Location = new System.Drawing.Point(920, 619);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(264, 17);
            this.labelContagem.TabIndex = 222;
            this.labelContagem.Text = "Total: N Registros";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxPesquisar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPesquisar.Location = new System.Drawing.Point(820, 165);
            this.textBoxPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(250, 26);
            this.textBoxPesquisar.TabIndex = 228;
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
            this.buttonPesquisar.Location = new System.Drawing.Point(1080, 165);
            this.buttonPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(100, 26);
            this.buttonPesquisar.TabIndex = 227;
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
            this.buttonExcluirCadastro.Location = new System.Drawing.Point(363, 163);
            this.buttonExcluirCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExcluirCadastro.Name = "buttonExcluirCadastro";
            this.buttonExcluirCadastro.Size = new System.Drawing.Size(153, 32);
            this.buttonExcluirCadastro.TabIndex = 226;
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
            this.buttonRelatorio.Location = new System.Drawing.Point(182, 163);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(171, 32);
            this.buttonRelatorio.TabIndex = 225;
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
            this.buttonNovoCadastro.Location = new System.Drawing.Point(29, 163);
            this.buttonNovoCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonNovoCadastro.Name = "buttonNovoCadastro";
            this.buttonNovoCadastro.Size = new System.Drawing.Size(143, 32);
            this.buttonNovoCadastro.TabIndex = 224;
            this.buttonNovoCadastro.Text = "Abrir PDV";
            this.buttonNovoCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNovoCadastro.UseVisualStyleBackColor = false;
            this.buttonNovoCadastro.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // dataGridViewContent
            // 
            this.dataGridViewContent.AllowUserToAddRows = false;
            this.dataGridViewContent.AllowUserToDeleteRows = false;
            this.dataGridViewContent.AllowUserToResizeColumns = false;
            this.dataGridViewContent.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dataGridViewContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.dataGridViewContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContent.ColumnHeadersHeight = 30;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column2,
            this.Column4,
            this.cliente,
            this.Column1,
            this.Column3,
            this.Column7,
            this.Column6,
            this.Ocorrencias,
            this.Acao});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(27, 213);
            this.dataGridViewContent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1157, 402);
            this.dataGridViewContent.TabIndex = 223;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nº";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Operador";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Valor total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Situação";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Situação";
            this.Column7.Image = global::High_Gestor.Properties.Resources.cinza;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Image = ((System.Drawing.Image)(resources.GetObject("Column6.Image")));
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 30;
            // 
            // Ocorrencias
            // 
            this.Ocorrencias.Description = "Ocorrencia";
            this.Ocorrencias.HeaderText = "";
            this.Ocorrencias.Image = ((System.Drawing.Image)(resources.GetObject("Ocorrencias.Image")));
            this.Ocorrencias.Name = "Ocorrencias";
            this.Ocorrencias.ReadOnly = true;
            this.Ocorrencias.ToolTipText = "Ocorrencia";
            this.Ocorrencias.Width = 30;
            // 
            // Acao
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            this.Acao.DefaultCellStyle = dataGridViewCellStyle4;
            this.Acao.Description = "Acões";
            this.Acao.HeaderText = "";
            this.Acao.Image = ((System.Drawing.Image)(resources.GetObject("Acao.Image")));
            this.Acao.Name = "Acao";
            this.Acao.ReadOnly = true;
            this.Acao.ToolTipText = "Acões";
            this.Acao.Width = 60;
            // 
            // FormPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.groupBoxSaldoCaixa);
            this.Controls.Add(this.linkLabelBuscaAvancada);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxPesquisar);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.buttonExcluirCadastro);
            this.Controls.Add(this.buttonRelatorio);
            this.Controls.Add(this.buttonNovoCadastro);
            this.Controls.Add(this.dataGridViewContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPDV";
            this.Load += new System.EventHandler(this.FormPDV_Load);
            this.groupBoxSaldoCaixa.ResumeLayout(false);
            this.groupBoxSaldoCaixa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.GroupBox groupBoxSaldoCaixa;
        private System.Windows.Forms.Label labelSandoAnterior;
        private System.Windows.Forms.LinkLabel linkLabelBuscaAvancada;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonExcluirCadastro;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonNovoCadastro;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn Ocorrencias;
        private System.Windows.Forms.DataGridViewImageColumn Acao;
        private System.Windows.Forms.Label labelStatusCaixa;
    }
}