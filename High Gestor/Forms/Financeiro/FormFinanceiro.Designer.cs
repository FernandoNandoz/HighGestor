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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFinanceiro));
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelStatusCaixa = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDemonstrativo = new System.Windows.Forms.Panel();
            this.panelDemonstrativoBorder = new System.Windows.Forms.Panel();
            this.panelMenuVendas = new System.Windows.Forms.Panel();
            this.buttonContasPagar = new System.Windows.Forms.Button();
            this.buttonContasReceber = new System.Windows.Forms.Button();
            this.buttonExtrato = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.panelMenuVendasBorder = new System.Windows.Forms.Panel();
            this.buttonFluxoCaixa = new System.Windows.Forms.Button();
            this.buttonParametros = new System.Windows.Forms.Button();
            labelMovimentoCaixa = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.panelDemonstrativo.SuspendLayout();
            this.panelMenuVendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMovimentoCaixa
            // 
            labelMovimentoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelMovimentoCaixa.AutoSize = true;
            labelMovimentoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            labelMovimentoCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            labelMovimentoCaixa.Location = new System.Drawing.Point(16, 10);
            labelMovimentoCaixa.Name = "labelMovimentoCaixa";
            labelMovimentoCaixa.Size = new System.Drawing.Size(161, 20);
            labelMovimentoCaixa.TabIndex = 97;
            labelMovimentoCaixa.Text = "Movimento de caixa  -";
            labelMovimentoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelContent.Controls.Add(this.panelMenuVendas);
            this.panelContent.Controls.Add(this.panelMenuVendasBorder);
            this.panelContent.Controls.Add(this.panelDemonstrativo);
            this.panelContent.Controls.Add(this.panelDemonstrativoBorder);
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
            this.buttonVoltar.Location = new System.Drawing.Point(1073, 3);
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
            this.labelStatusCaixa.Location = new System.Drawing.Point(175, 10);
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
            this.dataGridViewContent.ColumnHeadersHeight = 30;
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
            this.dataGridViewContent.Location = new System.Drawing.Point(16, 35);
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
            this.dataGridViewContent.Size = new System.Drawing.Size(1149, 427);
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
            // panelDemonstrativo
            // 
            this.panelDemonstrativo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDemonstrativo.BackColor = System.Drawing.Color.White;
            this.panelDemonstrativo.Controls.Add(this.dataGridViewContent);
            this.panelDemonstrativo.Controls.Add(labelMovimentoCaixa);
            this.panelDemonstrativo.Controls.Add(this.labelStatusCaixa);
            this.panelDemonstrativo.Location = new System.Drawing.Point(14, 157);
            this.panelDemonstrativo.Margin = new System.Windows.Forms.Padding(5);
            this.panelDemonstrativo.Name = "panelDemonstrativo";
            this.panelDemonstrativo.Size = new System.Drawing.Size(1180, 469);
            this.panelDemonstrativo.TabIndex = 243;
            this.panelDemonstrativo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panelDemonstrativoBorder
            // 
            this.panelDemonstrativoBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDemonstrativoBorder.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelDemonstrativoBorder.Location = new System.Drawing.Point(13, 156);
            this.panelDemonstrativoBorder.Margin = new System.Windows.Forms.Padding(5);
            this.panelDemonstrativoBorder.Name = "panelDemonstrativoBorder";
            this.panelDemonstrativoBorder.Size = new System.Drawing.Size(1182, 471);
            this.panelDemonstrativoBorder.TabIndex = 244;
            this.panelDemonstrativoBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panelMenuVendas
            // 
            this.panelMenuVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenuVendas.BackColor = System.Drawing.Color.White;
            this.panelMenuVendas.Controls.Add(this.buttonParametros);
            this.panelMenuVendas.Controls.Add(this.buttonFluxoCaixa);
            this.panelMenuVendas.Controls.Add(this.buttonContasPagar);
            this.panelMenuVendas.Controls.Add(this.buttonContasReceber);
            this.panelMenuVendas.Controls.Add(this.buttonExtrato);
            this.panelMenuVendas.Controls.Add(this.buttonRelatorio);
            this.panelMenuVendas.Controls.Add(this.buttonVoltar);
            this.panelMenuVendas.Controls.Add(label1);
            this.panelMenuVendas.Location = new System.Drawing.Point(14, 14);
            this.panelMenuVendas.Margin = new System.Windows.Forms.Padding(5);
            this.panelMenuVendas.Name = "panelMenuVendas";
            this.panelMenuVendas.Size = new System.Drawing.Size(1180, 133);
            this.panelMenuVendas.TabIndex = 245;
            this.panelMenuVendas.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // buttonContasPagar
            // 
            this.buttonContasPagar.FlatAppearance.BorderSize = 0;
            this.buttonContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContasPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContasPagar.Image = ((System.Drawing.Image)(resources.GetObject("buttonContasPagar.Image")));
            this.buttonContasPagar.Location = new System.Drawing.Point(18, 39);
            this.buttonContasPagar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonContasPagar.Name = "buttonContasPagar";
            this.buttonContasPagar.Size = new System.Drawing.Size(140, 82);
            this.buttonContasPagar.TabIndex = 239;
            this.buttonContasPagar.Text = "Contas a pagar";
            this.buttonContasPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonContasPagar.UseVisualStyleBackColor = true;
            this.buttonContasPagar.Click += new System.EventHandler(this.buttonContasPagar_Click);
            this.buttonContasPagar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonContasReceber
            // 
            this.buttonContasReceber.FlatAppearance.BorderSize = 0;
            this.buttonContasReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContasReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("buttonContasReceber.Image")));
            this.buttonContasReceber.Location = new System.Drawing.Point(168, 39);
            this.buttonContasReceber.Margin = new System.Windows.Forms.Padding(5);
            this.buttonContasReceber.Name = "buttonContasReceber";
            this.buttonContasReceber.Size = new System.Drawing.Size(150, 82);
            this.buttonContasReceber.TabIndex = 238;
            this.buttonContasReceber.Text = "Contas a receber";
            this.buttonContasReceber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonContasReceber.UseVisualStyleBackColor = true;
            this.buttonContasReceber.Click += new System.EventHandler(this.buttonContasReceber_Click);
            this.buttonContasReceber.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonExtrato
            // 
            this.buttonExtrato.FlatAppearance.BorderSize = 0;
            this.buttonExtrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtrato.Image = ((System.Drawing.Image)(resources.GetObject("buttonExtrato.Image")));
            this.buttonExtrato.Location = new System.Drawing.Point(328, 39);
            this.buttonExtrato.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExtrato.Name = "buttonExtrato";
            this.buttonExtrato.Size = new System.Drawing.Size(101, 82);
            this.buttonExtrato.TabIndex = 237;
            this.buttonExtrato.Text = "Extrato";
            this.buttonExtrato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExtrato.UseVisualStyleBackColor = true;
            this.buttonExtrato.Click += new System.EventHandler(this.buttonExtrato_Click);
            this.buttonExtrato.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.FlatAppearance.BorderSize = 0;
            this.buttonRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonRelatorio.Image")));
            this.buttonRelatorio.Location = new System.Drawing.Point(705, 39);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(102, 82);
            this.buttonRelatorio.TabIndex = 236;
            this.buttonRelatorio.Text = "Relatório";
            this.buttonRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonRelatorio.UseVisualStyleBackColor = true;
            this.buttonRelatorio.Click += new System.EventHandler(this.buttonRelatorio_Click);
            this.buttonRelatorio.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
            label1.Location = new System.Drawing.Point(14, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 20);
            label1.TabIndex = 235;
            label1.Text = "Financeiro";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelMenuVendasBorder
            // 
            this.panelMenuVendasBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenuVendasBorder.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelMenuVendasBorder.Location = new System.Drawing.Point(13, 13);
            this.panelMenuVendasBorder.Margin = new System.Windows.Forms.Padding(5);
            this.panelMenuVendasBorder.Name = "panelMenuVendasBorder";
            this.panelMenuVendasBorder.Size = new System.Drawing.Size(1182, 135);
            this.panelMenuVendasBorder.TabIndex = 246;
            this.panelMenuVendasBorder.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // buttonFluxoCaixa
            // 
            this.buttonFluxoCaixa.FlatAppearance.BorderSize = 0;
            this.buttonFluxoCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFluxoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFluxoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("buttonFluxoCaixa.Image")));
            this.buttonFluxoCaixa.Location = new System.Drawing.Point(439, 39);
            this.buttonFluxoCaixa.Margin = new System.Windows.Forms.Padding(5);
            this.buttonFluxoCaixa.Name = "buttonFluxoCaixa";
            this.buttonFluxoCaixa.Size = new System.Drawing.Size(130, 82);
            this.buttonFluxoCaixa.TabIndex = 240;
            this.buttonFluxoCaixa.Text = "Fluxo de caixa";
            this.buttonFluxoCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonFluxoCaixa.UseVisualStyleBackColor = true;
            this.buttonFluxoCaixa.Click += new System.EventHandler(this.buttonFluxoCaixa_Click);
            this.buttonFluxoCaixa.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonParametros
            // 
            this.buttonParametros.FlatAppearance.BorderSize = 0;
            this.buttonParametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParametros.Image = ((System.Drawing.Image)(resources.GetObject("buttonParametros.Image")));
            this.buttonParametros.Location = new System.Drawing.Point(579, 39);
            this.buttonParametros.Margin = new System.Windows.Forms.Padding(5);
            this.buttonParametros.Name = "buttonParametros";
            this.buttonParametros.Size = new System.Drawing.Size(116, 82);
            this.buttonParametros.TabIndex = 241;
            this.buttonParametros.Text = "Parâmetros";
            this.buttonParametros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonParametros.UseVisualStyleBackColor = true;
            this.buttonParametros.Click += new System.EventHandler(this.buttonParametros_Click);
            this.buttonParametros.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
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
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.panelDemonstrativo.ResumeLayout(false);
            this.panelDemonstrativo.PerformLayout();
            this.panelMenuVendas.ResumeLayout(false);
            this.panelMenuVendas.PerformLayout();
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
        private System.Windows.Forms.Panel panelDemonstrativo;
        private System.Windows.Forms.Panel panelDemonstrativoBorder;
        private System.Windows.Forms.Panel panelMenuVendas;
        private System.Windows.Forms.Button buttonContasPagar;
        private System.Windows.Forms.Button buttonContasReceber;
        private System.Windows.Forms.Button buttonExtrato;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Panel panelMenuVendasBorder;
        private System.Windows.Forms.Button buttonParametros;
        private System.Windows.Forms.Button buttonFluxoCaixa;
    }
}