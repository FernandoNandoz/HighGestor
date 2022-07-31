namespace High_Gestor.Forms.Financeiro
{
    partial class FormContasPagar
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
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label labelMovimentoCaixa;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.PictureBox pictureBoxContasReceber;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContasPagar));
            System.Windows.Forms.Label label5;
            System.Windows.Forms.PictureBox pictureBoxContasPagar;
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonPagarConta = new System.Windows.Forms.Button();
            this.dateTimeDataFinal = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTipoConta = new System.Windows.Forms.ComboBox();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.dateTimeDateInicial = new System.Windows.Forms.DateTimePicker();
            this.panelTotalContas = new System.Windows.Forms.Panel();
            this.labelTotalContasValue = new System.Windows.Forms.Label();
            this.panelTotalContasPagas = new System.Windows.Forms.Panel();
            this.labelTotalContasPagasValue = new System.Windows.Forms.Label();
            this.panelSaldoAtual = new System.Windows.Forms.Panel();
            this.labelSaldoAtualValue = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonExcluirLancamento = new System.Windows.Forms.Button();
            this.buttonEditarLancamento = new System.Windows.Forms.Button();
            this.buttonGerarRelatorio = new System.Windows.Forms.Button();
            this.buttonLancaManualmente = new System.Windows.Forms.Button();
            this.buttonSairContasPagar = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            labelMovimentoCaixa = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            pictureBoxContasReceber = new System.Windows.Forms.PictureBox();
            label5 = new System.Windows.Forms.Label();
            pictureBoxContasPagar = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.panelTotalContas.SuspendLayout();
            this.panelTotalContasPagas.SuspendLayout();
            this.panelSaldoAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label9.Location = new System.Drawing.Point(880, 20);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(110, 18);
            label9.TabIndex = 133;
            label9.Text = "Periodo de final";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label7.Location = new System.Drawing.Point(517, 20);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(98, 18);
            label7.TabIndex = 131;
            label7.Text = "Tipo de conta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label2.Location = new System.Drawing.Point(25, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(118, 18);
            label2.TabIndex = 129;
            label2.Text = "Pesquisar Conta";
            // 
            // labelMovimentoCaixa
            // 
            labelMovimentoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelMovimentoCaixa.AutoSize = true;
            labelMovimentoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            labelMovimentoCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            labelMovimentoCaixa.Location = new System.Drawing.Point(25, 132);
            labelMovimentoCaixa.Name = "labelMovimentoCaixa";
            labelMovimentoCaixa.Size = new System.Drawing.Size(179, 20);
            labelMovimentoCaixa.TabIndex = 127;
            labelMovimentoCaixa.Text = "Lista de Contas a Pagar";
            labelMovimentoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label6.Location = new System.Drawing.Point(739, 20);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(100, 18);
            label6.TabIndex = 126;
            label6.Text = "Periodo inicial";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label3.Location = new System.Drawing.Point(12, 57);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(133, 18);
            label3.TabIndex = 61;
            label3.Text = "Total de Contas";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxContasReceber
            // 
            pictureBoxContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxContasReceber.Image")));
            pictureBoxContasReceber.Location = new System.Drawing.Point(229, 3);
            pictureBoxContasReceber.Name = "pictureBoxContasReceber";
            pictureBoxContasReceber.Size = new System.Drawing.Size(38, 33);
            pictureBoxContasReceber.TabIndex = 12;
            pictureBoxContasReceber.TabStop = false;
            // 
            // label5
            // 
            label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label5.Location = new System.Drawing.Point(12, 57);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(187, 18);
            label5.TabIndex = 62;
            label5.Text = "Total de Contas Pagas";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxContasPagar
            // 
            pictureBoxContasPagar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxContasPagar.Image")));
            pictureBoxContasPagar.Location = new System.Drawing.Point(229, 3);
            pictureBoxContasPagar.Name = "pictureBoxContasPagar";
            pictureBoxContasPagar.Size = new System.Drawing.Size(38, 33);
            pictureBoxContasPagar.TabIndex = 13;
            pictureBoxContasPagar.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(229, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(38, 33);
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label4.Location = new System.Drawing.Point(13, 57);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(99, 18);
            label4.TabIndex = 62;
            label4.Text = "Saldo Atual";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            label8.ForeColor = System.Drawing.SystemColors.ControlText;
            label8.Location = new System.Drawing.Point(1001, 84);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(21, 31);
            label8.TabIndex = 148;
            label8.Text = "|";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPagarConta
            // 
            this.buttonPagarConta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPagarConta.BackColor = System.Drawing.Color.Firebrick;
            this.buttonPagarConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPagarConta.FlatAppearance.BorderSize = 0;
            this.buttonPagarConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPagarConta.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F);
            this.buttonPagarConta.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPagarConta.Image = ((System.Drawing.Image)(resources.GetObject("buttonPagarConta.Image")));
            this.buttonPagarConta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPagarConta.Location = new System.Drawing.Point(901, 547);
            this.buttonPagarConta.Name = "buttonPagarConta";
            this.buttonPagarConta.Size = new System.Drawing.Size(278, 84);
            this.buttonPagarConta.TabIndex = 134;
            this.buttonPagarConta.Text = "  Pagar Conta";
            this.buttonPagarConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPagarConta.UseVisualStyleBackColor = false;
            this.buttonPagarConta.Click += new System.EventHandler(this.buttonPagarConta_Click);
            this.buttonPagarConta.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonPagarConta_Paint);
            // 
            // dateTimeDataFinal
            // 
            this.dateTimeDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDataFinal.Location = new System.Drawing.Point(884, 43);
            this.dateTimeDataFinal.Name = "dateTimeDataFinal";
            this.dateTimeDataFinal.Size = new System.Drawing.Size(135, 26);
            this.dateTimeDataFinal.TabIndex = 132;
            // 
            // comboBoxTipoConta
            // 
            this.comboBoxTipoConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoConta.FormattingEnabled = true;
            this.comboBoxTipoConta.Items.AddRange(new object[] {
            "TODOS",
            "ABERTOS",
            "QUITADOS"});
            this.comboBoxTipoConta.Location = new System.Drawing.Point(521, 43);
            this.comboBoxTipoConta.Name = "comboBoxTipoConta";
            this.comboBoxTipoConta.Size = new System.Drawing.Size(216, 26);
            this.comboBoxTipoConta.TabIndex = 130;
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisar.Location = new System.Drawing.Point(29, 43);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(485, 26);
            this.textBoxPesquisar.TabIndex = 128;
            // 
            // dateTimeDateInicial
            // 
            this.dateTimeDateInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDateInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDateInicial.Location = new System.Drawing.Point(743, 43);
            this.dateTimeDateInicial.Name = "dateTimeDateInicial";
            this.dateTimeDateInicial.Size = new System.Drawing.Size(135, 26);
            this.dateTimeDateInicial.TabIndex = 125;
            // 
            // panelTotalContas
            // 
            this.panelTotalContas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTotalContas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTotalContas.Controls.Add(label3);
            this.panelTotalContas.Controls.Add(pictureBoxContasReceber);
            this.panelTotalContas.Controls.Add(this.labelTotalContasValue);
            this.panelTotalContas.Location = new System.Drawing.Point(29, 547);
            this.panelTotalContas.Name = "panelTotalContas";
            this.panelTotalContas.Size = new System.Drawing.Size(270, 84);
            this.panelTotalContas.TabIndex = 123;
            this.panelTotalContas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTotalContas_Paint);
            // 
            // labelTotalContasValue
            // 
            this.labelTotalContasValue.AutoSize = true;
            this.labelTotalContasValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalContasValue.ForeColor = System.Drawing.Color.Red;
            this.labelTotalContasValue.Location = new System.Drawing.Point(8, 6);
            this.labelTotalContasValue.Name = "labelTotalContasValue";
            this.labelTotalContasValue.Size = new System.Drawing.Size(84, 37);
            this.labelTotalContasValue.TabIndex = 4;
            this.labelTotalContasValue.Text = "0,00";
            // 
            // panelTotalContasPagas
            // 
            this.panelTotalContasPagas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTotalContasPagas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTotalContasPagas.Controls.Add(label5);
            this.panelTotalContasPagas.Controls.Add(pictureBoxContasPagar);
            this.panelTotalContasPagas.Controls.Add(this.labelTotalContasPagasValue);
            this.panelTotalContasPagas.Location = new System.Drawing.Point(311, 547);
            this.panelTotalContasPagas.Name = "panelTotalContasPagas";
            this.panelTotalContasPagas.Size = new System.Drawing.Size(270, 84);
            this.panelTotalContasPagas.TabIndex = 124;
            this.panelTotalContasPagas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTotalContasPagas_Paint);
            // 
            // labelTotalContasPagasValue
            // 
            this.labelTotalContasPagasValue.AutoSize = true;
            this.labelTotalContasPagasValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalContasPagasValue.ForeColor = System.Drawing.Color.Green;
            this.labelTotalContasPagasValue.Location = new System.Drawing.Point(8, 6);
            this.labelTotalContasPagasValue.Name = "labelTotalContasPagasValue";
            this.labelTotalContasPagasValue.Size = new System.Drawing.Size(84, 37);
            this.labelTotalContasPagasValue.TabIndex = 3;
            this.labelTotalContasPagasValue.Text = "0,00";
            // 
            // panelSaldoAtual
            // 
            this.panelSaldoAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSaldoAtual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSaldoAtual.Controls.Add(pictureBox1);
            this.panelSaldoAtual.Controls.Add(this.labelSaldoAtualValue);
            this.panelSaldoAtual.Controls.Add(label4);
            this.panelSaldoAtual.Location = new System.Drawing.Point(592, 547);
            this.panelSaldoAtual.Name = "panelSaldoAtual";
            this.panelSaldoAtual.Size = new System.Drawing.Size(270, 84);
            this.panelSaldoAtual.TabIndex = 122;
            this.panelSaldoAtual.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSaldoAtual_Paint);
            // 
            // labelSaldoAtualValue
            // 
            this.labelSaldoAtualValue.AutoSize = true;
            this.labelSaldoAtualValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldoAtualValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelSaldoAtualValue.Location = new System.Drawing.Point(9, 6);
            this.labelSaldoAtualValue.Name = "labelSaldoAtualValue";
            this.labelSaldoAtualValue.Size = new System.Drawing.Size(84, 37);
            this.labelSaldoAtualValue.TabIndex = 63;
            this.labelSaldoAtualValue.Text = "0,00";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContent.ColumnHeadersHeight = 35;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.cliente,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(29, 159);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            this.dataGridViewContent.ReadOnly = true;
            this.dataGridViewContent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidth = 45;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1149, 375);
            this.dataGridViewContent.TabIndex = 121;
            this.dataGridViewContent.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewContent_Paint);
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.cliente.HeaderText = "Descrição/Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Valor (R$)";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Juros (R$)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ver Recibo";
            this.Column3.Image = ((System.Drawing.Image)(resources.GetObject("Column3.Image")));
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // buttonExcluirLancamento
            // 
            this.buttonExcluirLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirLancamento.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirLancamento.Image")));
            this.buttonExcluirLancamento.Location = new System.Drawing.Point(410, 85);
            this.buttonExcluirLancamento.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExcluirLancamento.Name = "buttonExcluirLancamento";
            this.buttonExcluirLancamento.Size = new System.Drawing.Size(196, 35);
            this.buttonExcluirLancamento.TabIndex = 153;
            this.buttonExcluirLancamento.Text = " Excluir lançamento";
            this.buttonExcluirLancamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExcluirLancamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExcluirLancamento.UseVisualStyleBackColor = true;
            this.buttonExcluirLancamento.Click += new System.EventHandler(this.buttonExcluirLancamento_Click);
            // 
            // buttonEditarLancamento
            // 
            this.buttonEditarLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarLancamento.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditarLancamento.Image")));
            this.buttonEditarLancamento.Location = new System.Drawing.Point(226, 85);
            this.buttonEditarLancamento.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditarLancamento.Name = "buttonEditarLancamento";
            this.buttonEditarLancamento.Size = new System.Drawing.Size(177, 35);
            this.buttonEditarLancamento.TabIndex = 152;
            this.buttonEditarLancamento.Text = " Editar lançamento";
            this.buttonEditarLancamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditarLancamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEditarLancamento.UseVisualStyleBackColor = true;
            this.buttonEditarLancamento.Click += new System.EventHandler(this.buttonEditarLancamento_Click);
            // 
            // buttonGerarRelatorio
            // 
            this.buttonGerarRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGerarRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("buttonGerarRelatorio.Image")));
            this.buttonGerarRelatorio.Location = new System.Drawing.Point(613, 85);
            this.buttonGerarRelatorio.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGerarRelatorio.Name = "buttonGerarRelatorio";
            this.buttonGerarRelatorio.Size = new System.Drawing.Size(280, 35);
            this.buttonGerarRelatorio.TabIndex = 151;
            this.buttonGerarRelatorio.Text = " Gerar relatorio de Contas a Pagar";
            this.buttonGerarRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGerarRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGerarRelatorio.UseVisualStyleBackColor = true;
            this.buttonGerarRelatorio.Click += new System.EventHandler(this.buttonGerarRelatorio_Click);
            // 
            // buttonLancaManualmente
            // 
            this.buttonLancaManualmente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLancaManualmente.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancaManualmente.Image")));
            this.buttonLancaManualmente.Location = new System.Drawing.Point(28, 85);
            this.buttonLancaManualmente.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLancaManualmente.Name = "buttonLancaManualmente";
            this.buttonLancaManualmente.Size = new System.Drawing.Size(192, 35);
            this.buttonLancaManualmente.TabIndex = 150;
            this.buttonLancaManualmente.Text = " Lançar manualmente";
            this.buttonLancaManualmente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLancaManualmente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLancaManualmente.UseVisualStyleBackColor = true;
            this.buttonLancaManualmente.Click += new System.EventHandler(this.buttonLancaManualmente_Click);
            // 
            // buttonSairContasPagar
            // 
            this.buttonSairContasPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSairContasPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSairContasPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSairContasPagar.FlatAppearance.BorderSize = 0;
            this.buttonSairContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSairContasPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonSairContasPagar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSairContasPagar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSairContasPagar.Image")));
            this.buttonSairContasPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSairContasPagar.Location = new System.Drawing.Point(1025, 85);
            this.buttonSairContasPagar.Name = "buttonSairContasPagar";
            this.buttonSairContasPagar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonSairContasPagar.Size = new System.Drawing.Size(153, 35);
            this.buttonSairContasPagar.TabIndex = 149;
            this.buttonSairContasPagar.TabStop = false;
            this.buttonSairContasPagar.Text = " Voltar";
            this.buttonSairContasPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSairContasPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSairContasPagar.UseVisualStyleBackColor = false;
            this.buttonSairContasPagar.Click += new System.EventHandler(this.buttonSairContasPagar_Click);
            this.buttonSairContasPagar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSairContasPagar_Paint);
            // 
            // FormContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 648);
            this.Controls.Add(this.buttonExcluirLancamento);
            this.Controls.Add(this.buttonEditarLancamento);
            this.Controls.Add(this.buttonGerarRelatorio);
            this.Controls.Add(this.buttonLancaManualmente);
            this.Controls.Add(this.buttonSairContasPagar);
            this.Controls.Add(label8);
            this.Controls.Add(this.buttonPagarConta);
            this.Controls.Add(label9);
            this.Controls.Add(this.dateTimeDataFinal);
            this.Controls.Add(label7);
            this.Controls.Add(this.comboBoxTipoConta);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxPesquisar);
            this.Controls.Add(labelMovimentoCaixa);
            this.Controls.Add(label6);
            this.Controls.Add(this.dateTimeDateInicial);
            this.Controls.Add(this.panelTotalContas);
            this.Controls.Add(this.panelTotalContasPagas);
            this.Controls.Add(this.panelSaldoAtual);
            this.Controls.Add(this.dataGridViewContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormContasPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormContasPagar";
            this.Load += new System.EventHandler(this.FormContasPagar_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.panelTotalContas.ResumeLayout(false);
            this.panelTotalContas.PerformLayout();
            this.panelTotalContasPagas.ResumeLayout(false);
            this.panelTotalContasPagas.PerformLayout();
            this.panelSaldoAtual.ResumeLayout(false);
            this.panelSaldoAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPagarConta;
        private System.Windows.Forms.DateTimePicker dateTimeDataFinal;
        private System.Windows.Forms.ComboBox comboBoxTipoConta;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.DateTimePicker dateTimeDateInicial;
        private System.Windows.Forms.Panel panelTotalContas;
        private System.Windows.Forms.Label labelTotalContasValue;
        private System.Windows.Forms.Panel panelTotalContasPagas;
        private System.Windows.Forms.Label labelTotalContasPagasValue;
        private System.Windows.Forms.Panel panelSaldoAtual;
        private System.Windows.Forms.Label labelSaldoAtualValue;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.Button buttonExcluirLancamento;
        private System.Windows.Forms.Button buttonEditarLancamento;
        private System.Windows.Forms.Button buttonGerarRelatorio;
        private System.Windows.Forms.Button buttonLancaManualmente;
        private System.Windows.Forms.Button buttonSairContasPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
    }
}