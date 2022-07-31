namespace High_Gestor.Forms.Financeiro
{
    partial class FormFinanceiro
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
            System.Windows.Forms.Label labelMovimentoCaixa;
            System.Windows.Forms.PictureBox pictureBoxMovimentoCaixa;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFinanceiro));
            System.Windows.Forms.PictureBox pictureBoxContasReceber;
            System.Windows.Forms.PictureBox pictureBoxContasPagar;
            System.Windows.Forms.PictureBox pictureBoxConfiguracao;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelStatusCaixa = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMovimentoCaixa = new System.Windows.Forms.Panel();
            this.labelMovimentoCaixaValue = new System.Windows.Forms.Label();
            this.buttonMovimentoCaixa = new System.Windows.Forms.Button();
            this.panelContasReceber = new System.Windows.Forms.Panel();
            this.buttonContasReceber = new System.Windows.Forms.Button();
            this.labelContasReceberValue = new System.Windows.Forms.Label();
            this.panelContasPagar = new System.Windows.Forms.Panel();
            this.buttonContasPagar = new System.Windows.Forms.Button();
            this.labelContasPagarValue = new System.Windows.Forms.Label();
            this.panelConfiguracao = new System.Windows.Forms.Panel();
            this.buttonConfiguracao = new System.Windows.Forms.Button();
            labelMovimentoCaixa = new System.Windows.Forms.Label();
            pictureBoxMovimentoCaixa = new System.Windows.Forms.PictureBox();
            pictureBoxContasReceber = new System.Windows.Forms.PictureBox();
            pictureBoxContasPagar = new System.Windows.Forms.PictureBox();
            pictureBoxConfiguracao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMovimentoCaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxConfiguracao)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.panelMovimentoCaixa.SuspendLayout();
            this.panelContasReceber.SuspendLayout();
            this.panelContasPagar.SuspendLayout();
            this.panelConfiguracao.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMovimentoCaixa
            // 
            labelMovimentoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelMovimentoCaixa.AutoSize = true;
            labelMovimentoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            labelMovimentoCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            labelMovimentoCaixa.Location = new System.Drawing.Point(30, 141);
            labelMovimentoCaixa.Name = "labelMovimentoCaixa";
            labelMovimentoCaixa.Size = new System.Drawing.Size(161, 20);
            labelMovimentoCaixa.TabIndex = 97;
            labelMovimentoCaixa.Text = "Movimento de caixa  -";
            labelMovimentoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxMovimentoCaixa
            // 
            pictureBoxMovimentoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMovimentoCaixa.Image")));
            pictureBoxMovimentoCaixa.Location = new System.Drawing.Point(229, 7);
            pictureBoxMovimentoCaixa.Name = "pictureBoxMovimentoCaixa";
            pictureBoxMovimentoCaixa.Size = new System.Drawing.Size(38, 33);
            pictureBoxMovimentoCaixa.TabIndex = 13;
            pictureBoxMovimentoCaixa.TabStop = false;
            // 
            // pictureBoxContasReceber
            // 
            pictureBoxContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxContasReceber.Image")));
            pictureBoxContasReceber.Location = new System.Drawing.Point(229, 6);
            pictureBoxContasReceber.Name = "pictureBoxContasReceber";
            pictureBoxContasReceber.Size = new System.Drawing.Size(38, 33);
            pictureBoxContasReceber.TabIndex = 12;
            pictureBoxContasReceber.TabStop = false;
            // 
            // pictureBoxContasPagar
            // 
            pictureBoxContasPagar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxContasPagar.Image")));
            pictureBoxContasPagar.Location = new System.Drawing.Point(229, 6);
            pictureBoxContasPagar.Name = "pictureBoxContasPagar";
            pictureBoxContasPagar.Size = new System.Drawing.Size(38, 33);
            pictureBoxContasPagar.TabIndex = 13;
            pictureBoxContasPagar.TabStop = false;
            // 
            // pictureBoxConfiguracao
            // 
            pictureBoxConfiguracao.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxConfiguracao.Image")));
            pictureBoxConfiguracao.Location = new System.Drawing.Point(10, 3);
            pictureBoxConfiguracao.Name = "pictureBoxConfiguracao";
            pictureBoxConfiguracao.Size = new System.Drawing.Size(55, 45);
            pictureBoxConfiguracao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxConfiguracao.TabIndex = 10;
            pictureBoxConfiguracao.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.buttonVoltar);
            this.panelContent.Controls.Add(this.labelStatusCaixa);
            this.panelContent.Controls.Add(labelMovimentoCaixa);
            this.panelContent.Controls.Add(this.dataGridViewContent);
            this.panelContent.Controls.Add(this.panelMovimentoCaixa);
            this.panelContent.Controls.Add(this.panelContasReceber);
            this.panelContent.Controls.Add(this.panelContasPagar);
            this.panelContent.Controls.Add(this.panelConfiguracao);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1208, 640);
            this.panelContent.TabIndex = 0;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVoltar.BackColor = System.Drawing.Color.Transparent;
            this.buttonVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonVoltar.FlatAppearance.BorderSize = 0;
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonVoltar.Image = ((System.Drawing.Image)(resources.GetObject("buttonVoltar.Image")));
            this.buttonVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonVoltar.Location = new System.Drawing.Point(1099, 0);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(105, 30);
            this.buttonVoltar.TabIndex = 99;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // labelStatusCaixa
            // 
            this.labelStatusCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatusCaixa.AutoSize = true;
            this.labelStatusCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatusCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelStatusCaixa.Location = new System.Drawing.Point(189, 141);
            this.labelStatusCaixa.Name = "labelStatusCaixa";
            this.labelStatusCaixa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelStatusCaixa.Size = new System.Drawing.Size(118, 20);
            this.labelStatusCaixa.TabIndex = 98;
            this.labelStatusCaixa.Text = "Status do caixa";
            this.labelStatusCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGridViewContent.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewContent.ColumnHeadersHeight = 35;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.cliente,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(34, 171);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidth = 46;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1150, 467);
            this.dataGridViewContent.TabIndex = 96;
            this.dataGridViewContent.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewContent_Paint);
            // 
            // Column4
            // 
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Titulo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.HeaderText = "Descrição";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Entradas (R$)";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Saídas (R$)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // panelMovimentoCaixa
            // 
            this.panelMovimentoCaixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMovimentoCaixa.Controls.Add(pictureBoxMovimentoCaixa);
            this.panelMovimentoCaixa.Controls.Add(this.labelMovimentoCaixaValue);
            this.panelMovimentoCaixa.Controls.Add(this.buttonMovimentoCaixa);
            this.panelMovimentoCaixa.Location = new System.Drawing.Point(34, 31);
            this.panelMovimentoCaixa.Name = "panelMovimentoCaixa";
            this.panelMovimentoCaixa.Size = new System.Drawing.Size(270, 90);
            this.panelMovimentoCaixa.TabIndex = 93;
            this.panelMovimentoCaixa.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMovimentoCaixa_Paint);
            // 
            // labelMovimentoCaixaValue
            // 
            this.labelMovimentoCaixaValue.AutoSize = true;
            this.labelMovimentoCaixaValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F);
            this.labelMovimentoCaixaValue.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelMovimentoCaixaValue.Location = new System.Drawing.Point(12, 7);
            this.labelMovimentoCaixaValue.Name = "labelMovimentoCaixaValue";
            this.labelMovimentoCaixaValue.Size = new System.Drawing.Size(91, 40);
            this.labelMovimentoCaixaValue.TabIndex = 5;
            this.labelMovimentoCaixaValue.Text = "0,00";
            // 
            // buttonMovimentoCaixa
            // 
            this.buttonMovimentoCaixa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMovimentoCaixa.FlatAppearance.BorderSize = 0;
            this.buttonMovimentoCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMovimentoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonMovimentoCaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMovimentoCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonMovimentoCaixa.Location = new System.Drawing.Point(0, 60);
            this.buttonMovimentoCaixa.Name = "buttonMovimentoCaixa";
            this.buttonMovimentoCaixa.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.buttonMovimentoCaixa.Size = new System.Drawing.Size(270, 30);
            this.buttonMovimentoCaixa.TabIndex = 6;
            this.buttonMovimentoCaixa.Text = "   Movimento de Caixa";
            this.buttonMovimentoCaixa.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonMovimentoCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonMovimentoCaixa.UseVisualStyleBackColor = true;
            this.buttonMovimentoCaixa.Click += new System.EventHandler(this.buttonMovimentoCaixa_Click);
            // 
            // panelContasReceber
            // 
            this.panelContasReceber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContasReceber.Controls.Add(pictureBoxContasReceber);
            this.panelContasReceber.Controls.Add(this.buttonContasReceber);
            this.panelContasReceber.Controls.Add(this.labelContasReceberValue);
            this.panelContasReceber.Location = new System.Drawing.Point(318, 32);
            this.panelContasReceber.Name = "panelContasReceber";
            this.panelContasReceber.Size = new System.Drawing.Size(270, 90);
            this.panelContasReceber.TabIndex = 94;
            this.panelContasReceber.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContasReceber_Paint);
            // 
            // buttonContasReceber
            // 
            this.buttonContasReceber.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonContasReceber.FlatAppearance.BorderSize = 0;
            this.buttonContasReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContasReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonContasReceber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonContasReceber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonContasReceber.Location = new System.Drawing.Point(0, 60);
            this.buttonContasReceber.Name = "buttonContasReceber";
            this.buttonContasReceber.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.buttonContasReceber.Size = new System.Drawing.Size(270, 30);
            this.buttonContasReceber.TabIndex = 7;
            this.buttonContasReceber.Text = "  Contas a Receber";
            this.buttonContasReceber.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonContasReceber.UseVisualStyleBackColor = true;
            this.buttonContasReceber.Click += new System.EventHandler(this.buttonContasReceber_Click);
            // 
            // labelContasReceberValue
            // 
            this.labelContasReceberValue.AutoSize = true;
            this.labelContasReceberValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F);
            this.labelContasReceberValue.ForeColor = System.Drawing.Color.Green;
            this.labelContasReceberValue.Location = new System.Drawing.Point(8, 7);
            this.labelContasReceberValue.Name = "labelContasReceberValue";
            this.labelContasReceberValue.Size = new System.Drawing.Size(91, 40);
            this.labelContasReceberValue.TabIndex = 4;
            this.labelContasReceberValue.Text = "0,00";
            // 
            // panelContasPagar
            // 
            this.panelContasPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContasPagar.Controls.Add(pictureBoxContasPagar);
            this.panelContasPagar.Controls.Add(this.buttonContasPagar);
            this.panelContasPagar.Controls.Add(this.labelContasPagarValue);
            this.panelContasPagar.Location = new System.Drawing.Point(603, 32);
            this.panelContasPagar.Name = "panelContasPagar";
            this.panelContasPagar.Size = new System.Drawing.Size(270, 90);
            this.panelContasPagar.TabIndex = 95;
            this.panelContasPagar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContasPagar_Paint);
            // 
            // buttonContasPagar
            // 
            this.buttonContasPagar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonContasPagar.FlatAppearance.BorderSize = 0;
            this.buttonContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContasPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonContasPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonContasPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonContasPagar.Location = new System.Drawing.Point(0, 60);
            this.buttonContasPagar.Name = "buttonContasPagar";
            this.buttonContasPagar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.buttonContasPagar.Size = new System.Drawing.Size(270, 30);
            this.buttonContasPagar.TabIndex = 8;
            this.buttonContasPagar.Text = "  Contas a Pagar";
            this.buttonContasPagar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonContasPagar.UseVisualStyleBackColor = true;
            this.buttonContasPagar.Click += new System.EventHandler(this.buttonContasPagar_Click);
            // 
            // labelContasPagarValue
            // 
            this.labelContasPagarValue.AutoSize = true;
            this.labelContasPagarValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26F);
            this.labelContasPagarValue.ForeColor = System.Drawing.Color.Red;
            this.labelContasPagarValue.Location = new System.Drawing.Point(8, 7);
            this.labelContasPagarValue.Name = "labelContasPagarValue";
            this.labelContasPagarValue.Size = new System.Drawing.Size(91, 40);
            this.labelContasPagarValue.TabIndex = 3;
            this.labelContasPagarValue.Text = "0,00";
            // 
            // panelConfiguracao
            // 
            this.panelConfiguracao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelConfiguracao.Controls.Add(pictureBoxConfiguracao);
            this.panelConfiguracao.Controls.Add(this.buttonConfiguracao);
            this.panelConfiguracao.Location = new System.Drawing.Point(889, 32);
            this.panelConfiguracao.Name = "panelConfiguracao";
            this.panelConfiguracao.Size = new System.Drawing.Size(270, 90);
            this.panelConfiguracao.TabIndex = 92;
            this.panelConfiguracao.Paint += new System.Windows.Forms.PaintEventHandler(this.panelConfiguracao_Paint);
            // 
            // buttonConfiguracao
            // 
            this.buttonConfiguracao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonConfiguracao.FlatAppearance.BorderSize = 0;
            this.buttonConfiguracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfiguracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonConfiguracao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonConfiguracao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonConfiguracao.Location = new System.Drawing.Point(0, 60);
            this.buttonConfiguracao.Name = "buttonConfiguracao";
            this.buttonConfiguracao.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.buttonConfiguracao.Size = new System.Drawing.Size(270, 30);
            this.buttonConfiguracao.TabIndex = 9;
            this.buttonConfiguracao.Text = "  Outras opções";
            this.buttonConfiguracao.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonConfiguracao.UseVisualStyleBackColor = true;
            this.buttonConfiguracao.Click += new System.EventHandler(this.buttonConfiguracao_Click);
            // 
            // FormFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFinanceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFinanceiro";
            this.Load += new System.EventHandler(this.FormFinanceiro_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMovimentoCaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxConfiguracao)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.panelMovimentoCaixa.ResumeLayout(false);
            this.panelMovimentoCaixa.PerformLayout();
            this.panelContasReceber.ResumeLayout(false);
            this.panelContasReceber.PerformLayout();
            this.panelContasPagar.ResumeLayout(false);
            this.panelContasPagar.PerformLayout();
            this.panelConfiguracao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelStatusCaixa;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panelMovimentoCaixa;
        private System.Windows.Forms.Label labelMovimentoCaixaValue;
        private System.Windows.Forms.Button buttonMovimentoCaixa;
        private System.Windows.Forms.Panel panelContasReceber;
        private System.Windows.Forms.Button buttonContasReceber;
        private System.Windows.Forms.Label labelContasReceberValue;
        private System.Windows.Forms.Panel panelContasPagar;
        private System.Windows.Forms.Button buttonContasPagar;
        private System.Windows.Forms.Label labelContasPagarValue;
        private System.Windows.Forms.Panel panelConfiguracao;
        private System.Windows.Forms.Button buttonConfiguracao;
    }
}