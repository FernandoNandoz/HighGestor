namespace High_Gestor.Forms.Relatorios.Vendas.Comissao
{
    partial class FormRelatorioComissao
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
            System.Windows.Forms.Label labelContagem;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorioComissao));
            this.panelContent = new System.Windows.Forms.Panel();
            this.textBoxDataMes = new System.Windows.Forms.TextBox();
            this.panelDetalhesVenda = new System.Windows.Forms.Panel();
            this.labelLabelValueBaseCalculo = new System.Windows.Forms.Label();
            this.labelValueSaldo = new System.Windows.Forms.Label();
            this.labelValuePagamentos = new System.Windows.Forms.Label();
            this.labelValueTotalDebito = new System.Windows.Forms.Label();
            this.labelValueTotalCredito = new System.Windows.Forms.Label();
            this.labelValueTotalComissao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDataVoltar = new System.Windows.Forms.Button();
            this.buttonDataProximo = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonImprimir = new System.Windows.Forms.Button();
            labelContagem = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.panelDetalhesVenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // labelContagem
            // 
            labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelContagem.AutoSize = true;
            labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelContagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            labelContagem.Location = new System.Drawing.Point(35, 18);
            labelContagem.Name = "labelContagem";
            labelContagem.Size = new System.Drawing.Size(196, 24);
            labelContagem.TabIndex = 256;
            labelContagem.Text = "Relatório de comissão";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.SystemColors.ControlText;
            label8.Location = new System.Drawing.Point(19, 12);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(49, 18);
            label8.TabIndex = 2;
            label8.Text = "Totais";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.buttonImprimir);
            this.panelContent.Controls.Add(this.textBoxDataMes);
            this.panelContent.Controls.Add(this.panelDetalhesVenda);
            this.panelContent.Controls.Add(this.dataGridViewContent);
            this.panelContent.Controls.Add(this.buttonDataVoltar);
            this.panelContent.Controls.Add(this.buttonDataProximo);
            this.panelContent.Controls.Add(this.buttonVoltar);
            this.panelContent.Controls.Add(labelContagem);
            this.panelContent.Controls.Add(this.panel1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1208, 640);
            this.panelContent.TabIndex = 258;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // textBoxDataMes
            // 
            this.textBoxDataMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataMes.Location = new System.Drawing.Point(69, 81);
            this.textBoxDataMes.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDataMes.Name = "textBoxDataMes";
            this.textBoxDataMes.Size = new System.Drawing.Size(100, 26);
            this.textBoxDataMes.TabIndex = 264;
            this.textBoxDataMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelDetalhesVenda
            // 
            this.panelDetalhesVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalhesVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panelDetalhesVenda.Controls.Add(this.labelLabelValueBaseCalculo);
            this.panelDetalhesVenda.Controls.Add(this.labelValueSaldo);
            this.panelDetalhesVenda.Controls.Add(this.labelValuePagamentos);
            this.panelDetalhesVenda.Controls.Add(this.labelValueTotalDebito);
            this.panelDetalhesVenda.Controls.Add(this.labelValueTotalCredito);
            this.panelDetalhesVenda.Controls.Add(this.labelValueTotalComissao);
            this.panelDetalhesVenda.Controls.Add(this.label1);
            this.panelDetalhesVenda.Controls.Add(label8);
            this.panelDetalhesVenda.Location = new System.Drawing.Point(39, 568);
            this.panelDetalhesVenda.Margin = new System.Windows.Forms.Padding(0);
            this.panelDetalhesVenda.Name = "panelDetalhesVenda";
            this.panelDetalhesVenda.Size = new System.Drawing.Size(1129, 42);
            this.panelDetalhesVenda.TabIndex = 262;
            // 
            // labelLabelValueBaseCalculo
            // 
            this.labelLabelValueBaseCalculo.AutoSize = true;
            this.labelLabelValueBaseCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabelValueBaseCalculo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLabelValueBaseCalculo.Location = new System.Drawing.Point(135, 12);
            this.labelLabelValueBaseCalculo.Name = "labelLabelValueBaseCalculo";
            this.labelLabelValueBaseCalculo.Size = new System.Drawing.Size(59, 18);
            this.labelLabelValueBaseCalculo.TabIndex = 9;
            this.labelLabelValueBaseCalculo.Text = "R$ 0,00";
            // 
            // labelValueSaldo
            // 
            this.labelValueSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValueSaldo.AutoSize = true;
            this.labelValueSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueSaldo.ForeColor = System.Drawing.Color.Green;
            this.labelValueSaldo.Location = new System.Drawing.Point(967, 12);
            this.labelValueSaldo.Name = "labelValueSaldo";
            this.labelValueSaldo.Size = new System.Drawing.Size(66, 18);
            this.labelValueSaldo.TabIndex = 7;
            this.labelValueSaldo.Text = "R$ 0,00";
            // 
            // labelValuePagamentos
            // 
            this.labelValuePagamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValuePagamentos.AutoSize = true;
            this.labelValuePagamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValuePagamentos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValuePagamentos.Location = new System.Drawing.Point(830, 12);
            this.labelValuePagamentos.Name = "labelValuePagamentos";
            this.labelValuePagamentos.Size = new System.Drawing.Size(59, 18);
            this.labelValuePagamentos.TabIndex = 6;
            this.labelValuePagamentos.Text = "R$ 0,00";
            // 
            // labelValueTotalDebito
            // 
            this.labelValueTotalDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValueTotalDebito.AutoSize = true;
            this.labelValueTotalDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueTotalDebito.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValueTotalDebito.Location = new System.Drawing.Point(678, 12);
            this.labelValueTotalDebito.Name = "labelValueTotalDebito";
            this.labelValueTotalDebito.Size = new System.Drawing.Size(59, 18);
            this.labelValueTotalDebito.TabIndex = 5;
            this.labelValueTotalDebito.Text = "R$ 0,00";
            // 
            // labelValueTotalCredito
            // 
            this.labelValueTotalCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValueTotalCredito.AutoSize = true;
            this.labelValueTotalCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueTotalCredito.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValueTotalCredito.Location = new System.Drawing.Point(525, 12);
            this.labelValueTotalCredito.Name = "labelValueTotalCredito";
            this.labelValueTotalCredito.Size = new System.Drawing.Size(59, 18);
            this.labelValueTotalCredito.TabIndex = 4;
            this.labelValueTotalCredito.Text = "R$ 0,00";
            // 
            // labelValueTotalComissao
            // 
            this.labelValueTotalComissao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValueTotalComissao.AutoSize = true;
            this.labelValueTotalComissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueTotalComissao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelValueTotalComissao.Location = new System.Drawing.Point(361, 12);
            this.labelValueTotalComissao.Name = "labelValueTotalComissao";
            this.labelValueTotalComissao.Size = new System.Drawing.Size(59, 18);
            this.labelValueTotalComissao.TabIndex = 3;
            this.labelValueTotalComissao.Text = "R$ 0,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Base de calculo:";
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContent.ColumnHeadersHeight = 30;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.dataGridViewTextBoxColumn6,
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridViewContent.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.GhostWhite;
            this.dataGridViewContent.Location = new System.Drawing.Point(39, 124);
            this.dataGridViewContent.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidth = 46;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewContent.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1129, 444);
            this.dataGridViewContent.TabIndex = 261;
            this.dataGridViewContent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContent_CellDoubleClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "IdFuncionario";
            this.Column6.HeaderText = "idFuncionario";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Vendedor";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "Vendedor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ValorComissao";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "(+) Comissão";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 168;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ValorCredito";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "(+) Créditos";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ValorDebito";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "(-) Débitos";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ValorPagamentos";
            dataGridViewCellStyle6.Format = "C2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "(-) Pagamentos";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ValorSaldo";
            dataGridViewCellStyle7.Format = "C2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "(=) Saldo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 160;
            // 
            // buttonDataVoltar
            // 
            this.buttonDataVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonDataVoltar.FlatAppearance.BorderSize = 0;
            this.buttonDataVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataVoltar.Image = ((System.Drawing.Image)(resources.GetObject("buttonDataVoltar.Image")));
            this.buttonDataVoltar.Location = new System.Drawing.Point(39, 82);
            this.buttonDataVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDataVoltar.Name = "buttonDataVoltar";
            this.buttonDataVoltar.Size = new System.Drawing.Size(30, 25);
            this.buttonDataVoltar.TabIndex = 260;
            this.buttonDataVoltar.UseVisualStyleBackColor = false;
            this.buttonDataVoltar.Click += new System.EventHandler(this.buttonDataVoltar_Click);
            this.buttonDataVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonDataProximo
            // 
            this.buttonDataProximo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonDataProximo.FlatAppearance.BorderSize = 0;
            this.buttonDataProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDataProximo.Image = ((System.Drawing.Image)(resources.GetObject("buttonDataProximo.Image")));
            this.buttonDataProximo.Location = new System.Drawing.Point(169, 83);
            this.buttonDataProximo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDataProximo.Name = "buttonDataProximo";
            this.buttonDataProximo.Size = new System.Drawing.Size(30, 25);
            this.buttonDataProximo.TabIndex = 259;
            this.buttonDataProximo.UseVisualStyleBackColor = false;
            this.buttonDataProximo.Click += new System.EventHandler(this.buttonDataProximo_Click);
            this.buttonDataProximo.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
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
            this.buttonVoltar.Location = new System.Drawing.Point(1083, 12);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 257;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panel1.Location = new System.Drawing.Point(38, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 485);
            this.panel1.TabIndex = 263;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.BackColor = System.Drawing.Color.White;
            this.buttonImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.Image")));
            this.buttonImprimir.Location = new System.Drawing.Point(216, 80);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonImprimir.Size = new System.Drawing.Size(127, 30);
            this.buttonImprimir.TabIndex = 276;
            this.buttonImprimir.Text = "  Imprimir";
            this.buttonImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonImprimir.UseVisualStyleBackColor = false;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // FormRelatorioComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRelatorioComissao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRelatorioComissao";
            this.Load += new System.EventHandler(this.FormRelatorioComissao_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelDetalhesVenda.ResumeLayout(false);
            this.panelDetalhesVenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonDataVoltar;
        private System.Windows.Forms.Button buttonDataProximo;
        public System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.Panel panelDetalhesVenda;
        private System.Windows.Forms.Label labelValueSaldo;
        private System.Windows.Forms.Label labelValuePagamentos;
        private System.Windows.Forms.Label labelValueTotalDebito;
        private System.Windows.Forms.Label labelValueTotalCredito;
        private System.Windows.Forms.Label labelValueTotalComissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDataMes;
        private System.Windows.Forms.Label labelLabelValueBaseCalculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonImprimir;
    }
}