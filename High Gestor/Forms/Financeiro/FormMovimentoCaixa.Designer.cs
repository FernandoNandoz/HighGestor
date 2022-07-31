namespace High_Gestor.Forms.Financeiro
{
    partial class FormMovimentoCaixa
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.PictureBox pictureBoxMovimentoCaixa;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMovimentoCaixa));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.PictureBox pictureBoxContasReceber;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.PictureBox pictureBoxContasPagar;
            System.Windows.Forms.PictureBox pictureBox1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label labelContagem;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePeriodo = new System.Windows.Forms.DateTimePicker();
            this.panelSaldoAnterior = new System.Windows.Forms.Panel();
            this.labelSaldoAnteriorValue = new System.Windows.Forms.Label();
            this.panelTotalEntradas = new System.Windows.Forms.Panel();
            this.labelTotalEntradasValue = new System.Windows.Forms.Label();
            this.panelTotalSaidas = new System.Windows.Forms.Panel();
            this.labelTotalSaidasValue = new System.Windows.Forms.Label();
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
            this.buttonSairCaixa = new System.Windows.Forms.Button();
            labelMovimentoCaixa = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            pictureBoxMovimentoCaixa = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            pictureBoxContasReceber = new System.Windows.Forms.PictureBox();
            label5 = new System.Windows.Forms.Label();
            pictureBoxContasPagar = new System.Windows.Forms.PictureBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            labelContagem = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMovimentoCaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.panelSaldoAnterior.SuspendLayout();
            this.panelTotalEntradas.SuspendLayout();
            this.panelTotalSaidas.SuspendLayout();
            this.panelSaldoAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMovimentoCaixa
            // 
            labelMovimentoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelMovimentoCaixa.AutoSize = true;
            labelMovimentoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            labelMovimentoCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            labelMovimentoCaixa.Location = new System.Drawing.Point(30, 100);
            labelMovimentoCaixa.Name = "labelMovimentoCaixa";
            labelMovimentoCaixa.Size = new System.Drawing.Size(148, 20);
            labelMovimentoCaixa.TabIndex = 86;
            labelMovimentoCaixa.Text = "Movimento de caixa";
            labelMovimentoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(882, 9);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(151, 20);
            label6.TabIndex = 85;
            label6.Text = "Data de movimento:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label2.Location = new System.Drawing.Point(10, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 20);
            label2.TabIndex = 60;
            label2.Text = "Saldo Anterior";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxMovimentoCaixa
            // 
            pictureBoxMovimentoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxMovimentoCaixa.Image")));
            pictureBoxMovimentoCaixa.Location = new System.Drawing.Point(229, 4);
            pictureBoxMovimentoCaixa.Name = "pictureBoxMovimentoCaixa";
            pictureBoxMovimentoCaixa.Size = new System.Drawing.Size(38, 33);
            pictureBoxMovimentoCaixa.TabIndex = 13;
            pictureBoxMovimentoCaixa.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label3.Location = new System.Drawing.Point(8, 45);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(135, 20);
            label3.TabIndex = 61;
            label3.Text = "Total de Entradas";
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
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label5.Location = new System.Drawing.Point(8, 45);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(119, 20);
            label5.TabIndex = 62;
            label5.Text = "Total de Saídas";
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
            pictureBox1.Location = new System.Drawing.Point(233, 3);
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
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label4.Location = new System.Drawing.Point(10, 45);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 20);
            label4.TabIndex = 62;
            label4.Text = "Saldo Atual";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelContagem
            // 
            labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelContagem.AutoSize = true;
            labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            labelContagem.Location = new System.Drawing.Point(28, 9);
            labelContagem.Name = "labelContagem";
            labelContagem.Size = new System.Drawing.Size(73, 29);
            labelContagem.TabIndex = 78;
            labelContagem.Text = "Caixa";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            label8.ForeColor = System.Drawing.SystemColors.ControlText;
            label8.Location = new System.Drawing.Point(997, 50);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(21, 31);
            label8.TabIndex = 136;
            label8.Text = "|";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePeriodo
            // 
            this.dateTimePeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePeriodo.Location = new System.Drawing.Point(1039, 8);
            this.dateTimePeriodo.Name = "dateTimePeriodo";
            this.dateTimePeriodo.Size = new System.Drawing.Size(135, 26);
            this.dateTimePeriodo.TabIndex = 84;
            this.dateTimePeriodo.ValueChanged += new System.EventHandler(this.dateTimePeriodo_ValueChanged);
            // 
            // panelSaldoAnterior
            // 
            this.panelSaldoAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSaldoAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSaldoAnterior.Controls.Add(label2);
            this.panelSaldoAnterior.Controls.Add(pictureBoxMovimentoCaixa);
            this.panelSaldoAnterior.Controls.Add(this.labelSaldoAnteriorValue);
            this.panelSaldoAnterior.Location = new System.Drawing.Point(31, 559);
            this.panelSaldoAnterior.Name = "panelSaldoAnterior";
            this.panelSaldoAnterior.Size = new System.Drawing.Size(270, 70);
            this.panelSaldoAnterior.TabIndex = 81;
            this.panelSaldoAnterior.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSaldoAnterior_Paint);
            // 
            // labelSaldoAnteriorValue
            // 
            this.labelSaldoAnteriorValue.AutoSize = true;
            this.labelSaldoAnteriorValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.labelSaldoAnteriorValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSaldoAnteriorValue.Location = new System.Drawing.Point(7, 6);
            this.labelSaldoAnteriorValue.Name = "labelSaldoAnteriorValue";
            this.labelSaldoAnteriorValue.Size = new System.Drawing.Size(70, 32);
            this.labelSaldoAnteriorValue.TabIndex = 5;
            this.labelSaldoAnteriorValue.Text = "0,00";
            // 
            // panelTotalEntradas
            // 
            this.panelTotalEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTotalEntradas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTotalEntradas.Controls.Add(label3);
            this.panelTotalEntradas.Controls.Add(pictureBoxContasReceber);
            this.panelTotalEntradas.Controls.Add(this.labelTotalEntradasValue);
            this.panelTotalEntradas.Location = new System.Drawing.Point(315, 559);
            this.panelTotalEntradas.Name = "panelTotalEntradas";
            this.panelTotalEntradas.Size = new System.Drawing.Size(270, 70);
            this.panelTotalEntradas.TabIndex = 82;
            this.panelTotalEntradas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTotalEntradas_Paint);
            // 
            // labelTotalEntradasValue
            // 
            this.labelTotalEntradasValue.AutoSize = true;
            this.labelTotalEntradasValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.labelTotalEntradasValue.ForeColor = System.Drawing.Color.Green;
            this.labelTotalEntradasValue.Location = new System.Drawing.Point(6, 6);
            this.labelTotalEntradasValue.Name = "labelTotalEntradasValue";
            this.labelTotalEntradasValue.Size = new System.Drawing.Size(70, 32);
            this.labelTotalEntradasValue.TabIndex = 4;
            this.labelTotalEntradasValue.Text = "0,00";
            // 
            // panelTotalSaidas
            // 
            this.panelTotalSaidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTotalSaidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTotalSaidas.Controls.Add(label5);
            this.panelTotalSaidas.Controls.Add(pictureBoxContasPagar);
            this.panelTotalSaidas.Controls.Add(this.labelTotalSaidasValue);
            this.panelTotalSaidas.Location = new System.Drawing.Point(600, 559);
            this.panelTotalSaidas.Name = "panelTotalSaidas";
            this.panelTotalSaidas.Size = new System.Drawing.Size(270, 70);
            this.panelTotalSaidas.TabIndex = 83;
            this.panelTotalSaidas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTotalSaidas_Paint);
            // 
            // labelTotalSaidasValue
            // 
            this.labelTotalSaidasValue.AutoSize = true;
            this.labelTotalSaidasValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.labelTotalSaidasValue.ForeColor = System.Drawing.Color.Red;
            this.labelTotalSaidasValue.Location = new System.Drawing.Point(6, 6);
            this.labelTotalSaidasValue.Name = "labelTotalSaidasValue";
            this.labelTotalSaidasValue.Size = new System.Drawing.Size(70, 32);
            this.labelTotalSaidasValue.TabIndex = 3;
            this.labelTotalSaidasValue.Text = "0,00";
            // 
            // panelSaldoAtual
            // 
            this.panelSaldoAtual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSaldoAtual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSaldoAtual.Controls.Add(pictureBox1);
            this.panelSaldoAtual.Controls.Add(this.labelSaldoAtualValue);
            this.panelSaldoAtual.Controls.Add(label4);
            this.panelSaldoAtual.Location = new System.Drawing.Point(903, 559);
            this.panelSaldoAtual.Name = "panelSaldoAtual";
            this.panelSaldoAtual.Size = new System.Drawing.Size(273, 70);
            this.panelSaldoAtual.TabIndex = 80;
            this.panelSaldoAtual.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSaldoAtual_Paint);
            // 
            // labelSaldoAtualValue
            // 
            this.labelSaldoAtualValue.AutoSize = true;
            this.labelSaldoAtualValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.labelSaldoAtualValue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelSaldoAtualValue.Location = new System.Drawing.Point(8, 6);
            this.labelSaldoAtualValue.Name = "labelSaldoAtualValue";
            this.labelSaldoAtualValue.Size = new System.Drawing.Size(70, 32);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(34, 123);
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
            this.dataGridViewContent.RowHeadersWidth = 46;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1139, 425);
            this.dataGridViewContent.TabIndex = 79;
            this.dataGridViewContent.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContent_CellContentDoubleClick);
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
            // Column3
            // 
            this.Column3.HeaderText = "Ver Recibo";
            this.Column3.Image = ((System.Drawing.Image)(resources.GetObject("Column3.Image")));
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonExcluirLancamento
            // 
            this.buttonExcluirLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluirLancamento.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluirLancamento.Image")));
            this.buttonExcluirLancamento.Location = new System.Drawing.Point(414, 51);
            this.buttonExcluirLancamento.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExcluirLancamento.Name = "buttonExcluirLancamento";
            this.buttonExcluirLancamento.Size = new System.Drawing.Size(196, 35);
            this.buttonExcluirLancamento.TabIndex = 141;
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
            this.buttonEditarLancamento.Location = new System.Drawing.Point(230, 51);
            this.buttonEditarLancamento.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditarLancamento.Name = "buttonEditarLancamento";
            this.buttonEditarLancamento.Size = new System.Drawing.Size(177, 35);
            this.buttonEditarLancamento.TabIndex = 140;
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
            this.buttonGerarRelatorio.Location = new System.Drawing.Point(617, 51);
            this.buttonGerarRelatorio.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGerarRelatorio.Name = "buttonGerarRelatorio";
            this.buttonGerarRelatorio.Size = new System.Drawing.Size(211, 35);
            this.buttonGerarRelatorio.TabIndex = 139;
            this.buttonGerarRelatorio.Text = " Gerar relatorio de Caixa";
            this.buttonGerarRelatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGerarRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGerarRelatorio.UseVisualStyleBackColor = true;
            this.buttonGerarRelatorio.Click += new System.EventHandler(this.buttonGerarRelatorio_Click);
            // 
            // buttonLancaManualmente
            // 
            this.buttonLancaManualmente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLancaManualmente.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancaManualmente.Image")));
            this.buttonLancaManualmente.Location = new System.Drawing.Point(32, 51);
            this.buttonLancaManualmente.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLancaManualmente.Name = "buttonLancaManualmente";
            this.buttonLancaManualmente.Size = new System.Drawing.Size(192, 35);
            this.buttonLancaManualmente.TabIndex = 138;
            this.buttonLancaManualmente.Text = " Lançar manualmente";
            this.buttonLancaManualmente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLancaManualmente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLancaManualmente.UseVisualStyleBackColor = true;
            this.buttonLancaManualmente.Click += new System.EventHandler(this.buttonLancaManualmente_Click);
            // 
            // buttonSairCaixa
            // 
            this.buttonSairCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSairCaixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSairCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSairCaixa.FlatAppearance.BorderSize = 0;
            this.buttonSairCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSairCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonSairCaixa.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSairCaixa.Image = ((System.Drawing.Image)(resources.GetObject("buttonSairCaixa.Image")));
            this.buttonSairCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSairCaixa.Location = new System.Drawing.Point(1021, 51);
            this.buttonSairCaixa.Name = "buttonSairCaixa";
            this.buttonSairCaixa.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonSairCaixa.Size = new System.Drawing.Size(153, 35);
            this.buttonSairCaixa.TabIndex = 137;
            this.buttonSairCaixa.TabStop = false;
            this.buttonSairCaixa.Text = " Voltar";
            this.buttonSairCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSairCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSairCaixa.UseVisualStyleBackColor = false;
            this.buttonSairCaixa.Click += new System.EventHandler(this.buttonSairCaixa_Click);
            this.buttonSairCaixa.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSairCaixa_Paint);
            // 
            // FormMovimentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.buttonExcluirLancamento);
            this.Controls.Add(this.buttonEditarLancamento);
            this.Controls.Add(this.buttonGerarRelatorio);
            this.Controls.Add(this.buttonLancaManualmente);
            this.Controls.Add(this.buttonSairCaixa);
            this.Controls.Add(label8);
            this.Controls.Add(labelMovimentoCaixa);
            this.Controls.Add(label6);
            this.Controls.Add(this.dateTimePeriodo);
            this.Controls.Add(this.panelSaldoAnterior);
            this.Controls.Add(this.panelTotalEntradas);
            this.Controls.Add(this.panelTotalSaidas);
            this.Controls.Add(this.panelSaldoAtual);
            this.Controls.Add(this.dataGridViewContent);
            this.Controls.Add(labelContagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMovimentoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMovimentoCaixa";
            this.Load += new System.EventHandler(this.FormMovimentoCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBoxMovimentoCaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxContasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.panelSaldoAnterior.ResumeLayout(false);
            this.panelSaldoAnterior.PerformLayout();
            this.panelTotalEntradas.ResumeLayout(false);
            this.panelTotalEntradas.PerformLayout();
            this.panelTotalSaidas.ResumeLayout(false);
            this.panelTotalSaidas.PerformLayout();
            this.panelSaldoAtual.ResumeLayout(false);
            this.panelSaldoAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePeriodo;
        private System.Windows.Forms.Panel panelSaldoAnterior;
        private System.Windows.Forms.Label labelSaldoAnteriorValue;
        private System.Windows.Forms.Panel panelTotalEntradas;
        private System.Windows.Forms.Label labelTotalEntradasValue;
        private System.Windows.Forms.Panel panelTotalSaidas;
        private System.Windows.Forms.Label labelTotalSaidasValue;
        private System.Windows.Forms.Panel panelSaldoAtual;
        private System.Windows.Forms.Label labelSaldoAtualValue;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.Button buttonExcluirLancamento;
        private System.Windows.Forms.Button buttonEditarLancamento;
        private System.Windows.Forms.Button buttonGerarRelatorio;
        private System.Windows.Forms.Button buttonLancaManualmente;
        private System.Windows.Forms.Button buttonSairCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
    }
}