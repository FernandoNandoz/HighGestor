namespace High_Gestor.Forms.Produtos
{
    partial class FormEstoque
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstoque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxSaldoAnterior = new System.Windows.Forms.GroupBox();
            this.labelSandoAnterior = new System.Windows.Forms.Label();
            this.groupBoxEntradas = new System.Windows.Forms.GroupBox();
            this.labelEntradas = new System.Windows.Forms.Label();
            this.groupBoxSaidas = new System.Windows.Forms.GroupBox();
            this.labelSaidas = new System.Windows.Forms.Label();
            this.groupBoxSaldo = new System.Windows.Forms.GroupBox();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.buttonMovimentarEstoque = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelNomeProduto = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.panelDadosProduto = new System.Windows.Forms.Panel();
            this.labelTipoUnitario = new System.Windows.Forms.Label();
            this.labelEstoqueMinimo = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTotais = new System.Windows.Forms.Panel();
            this.labelTotalSaidas = new System.Windows.Forms.Label();
            this.labelTotalEntradas = new System.Windows.Forms.Label();
            this.labelMedioSaidas = new System.Windows.Forms.Label();
            this.labelMedioEntradas = new System.Windows.Forms.Label();
            this.dateTimePeriodoIncial = new System.Windows.Forms.DateTimePicker();
            this.dateTimePeriodoFinal = new System.Windows.Forms.DateTimePicker();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.groupBoxSaldoAnterior.SuspendLayout();
            this.groupBoxEntradas.SuspendLayout();
            this.groupBoxSaidas.SuspendLayout();
            this.groupBoxSaldo.SuspendLayout();
            this.panelDadosProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.panelTotais.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label3.Location = new System.Drawing.Point(27, 98);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 20);
            label3.TabIndex = 121;
            label3.Text = "Resumo";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(14, 8);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(61, 20);
            label8.TabIndex = 19;
            label8.Text = "Codigo:";
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(203, 8);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 20);
            label10.TabIndex = 21;
            label10.Text = "Categoria:";
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(496, 8);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(54, 20);
            label12.TabIndex = 26;
            label12.Text = "Marca:";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(942, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(122, 20);
            label1.TabIndex = 27;
            label1.Text = "Estoque mínimo:";
            // 
            // label13
            // 
            label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(90, 13);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(104, 20);
            label13.TabIndex = 20;
            label13.Text = "Saldo anterior";
            // 
            // label15
            // 
            label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(107, 13);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(67, 20);
            label15.TabIndex = 21;
            label15.Text = "Entradas";
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.Location = new System.Drawing.Point(114, 13);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(52, 20);
            label14.TabIndex = 21;
            label14.Text = "Saídas";
            // 
            // label16
            // 
            label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label16.Location = new System.Drawing.Point(117, 13);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(47, 20);
            label16.TabIndex = 22;
            label16.Text = "Saldo";
            // 
            // label25
            // 
            label25.Anchor = System.Windows.Forms.AnchorStyles.None;
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label25.Location = new System.Drawing.Point(854, 10);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(132, 18);
            label25.TabIndex = 28;
            label25.Text = "Valor Total Saídas:";
            // 
            // label26
            // 
            label26.Anchor = System.Windows.Forms.AnchorStyles.None;
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label26.Location = new System.Drawing.Point(559, 10);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(146, 18);
            label26.TabIndex = 27;
            label26.Text = "Valor Total Entradas:";
            // 
            // label27
            // 
            label27.Anchor = System.Windows.Forms.AnchorStyles.None;
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label27.Location = new System.Drawing.Point(293, 10);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(140, 18);
            label27.TabIndex = 26;
            label27.Text = "Valor Médio Saídas:";
            // 
            // label30
            // 
            label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label30.Location = new System.Drawing.Point(10, 10);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(154, 18);
            label30.TabIndex = 19;
            label30.Text = "Valor Médio Entradas:";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(768, 8);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 20);
            label5.TabIndex = 33;
            label5.Text = "Unidade:";
            // 
            // groupBoxSaldoAnterior
            // 
            this.groupBoxSaldoAnterior.AutoSize = true;
            this.groupBoxSaldoAnterior.Controls.Add(this.labelSandoAnterior);
            this.groupBoxSaldoAnterior.Controls.Add(label13);
            this.groupBoxSaldoAnterior.Location = new System.Drawing.Point(31, 117);
            this.groupBoxSaldoAnterior.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoAnterior.Name = "groupBoxSaldoAnterior";
            this.groupBoxSaldoAnterior.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoAnterior.Size = new System.Drawing.Size(280, 75);
            this.groupBoxSaldoAnterior.TabIndex = 141;
            this.groupBoxSaldoAnterior.TabStop = false;
            // 
            // labelSandoAnterior
            // 
            this.labelSandoAnterior.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSandoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSandoAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelSandoAnterior.Location = new System.Drawing.Point(18, 41);
            this.labelSandoAnterior.Name = "labelSandoAnterior";
            this.labelSandoAnterior.Size = new System.Drawing.Size(242, 20);
            this.labelSandoAnterior.TabIndex = 21;
            this.labelSandoAnterior.Text = "0,00";
            this.labelSandoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxEntradas
            // 
            this.groupBoxEntradas.Controls.Add(this.labelEntradas);
            this.groupBoxEntradas.Controls.Add(label15);
            this.groupBoxEntradas.Location = new System.Drawing.Point(320, 117);
            this.groupBoxEntradas.Name = "groupBoxEntradas";
            this.groupBoxEntradas.Size = new System.Drawing.Size(280, 75);
            this.groupBoxEntradas.TabIndex = 142;
            this.groupBoxEntradas.TabStop = false;
            // 
            // labelEntradas
            // 
            this.labelEntradas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelEntradas.Location = new System.Drawing.Point(19, 41);
            this.labelEntradas.Name = "labelEntradas";
            this.labelEntradas.Size = new System.Drawing.Size(242, 20);
            this.labelEntradas.TabIndex = 22;
            this.labelEntradas.Text = "0,00";
            this.labelEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxSaidas
            // 
            this.groupBoxSaidas.Controls.Add(this.labelSaidas);
            this.groupBoxSaidas.Controls.Add(label14);
            this.groupBoxSaidas.Location = new System.Drawing.Point(609, 117);
            this.groupBoxSaidas.Name = "groupBoxSaidas";
            this.groupBoxSaidas.Size = new System.Drawing.Size(280, 75);
            this.groupBoxSaidas.TabIndex = 142;
            this.groupBoxSaidas.TabStop = false;
            // 
            // labelSaidas
            // 
            this.labelSaidas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSaidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaidas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSaidas.Location = new System.Drawing.Point(19, 41);
            this.labelSaidas.Name = "labelSaidas";
            this.labelSaidas.Size = new System.Drawing.Size(242, 20);
            this.labelSaidas.TabIndex = 23;
            this.labelSaidas.Text = "0,00";
            this.labelSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxSaldo
            // 
            this.groupBoxSaldo.Controls.Add(this.labelSaldo);
            this.groupBoxSaldo.Controls.Add(label16);
            this.groupBoxSaldo.Location = new System.Drawing.Point(897, 118);
            this.groupBoxSaldo.Name = "groupBoxSaldo";
            this.groupBoxSaldo.Size = new System.Drawing.Size(280, 75);
            this.groupBoxSaldo.TabIndex = 142;
            this.groupBoxSaldo.TabStop = false;
            // 
            // labelSaldo
            // 
            this.labelSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldo.ForeColor = System.Drawing.Color.Red;
            this.labelSaldo.Location = new System.Drawing.Point(19, 41);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(242, 20);
            this.labelSaldo.TabIndex = 24;
            this.labelSaldo.Text = "0,00";
            this.labelSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMovimentarEstoque
            // 
            this.buttonMovimentarEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMovimentarEstoque.Image = ((System.Drawing.Image)(resources.GetObject("buttonMovimentarEstoque.Image")));
            this.buttonMovimentarEstoque.Location = new System.Drawing.Point(31, 206);
            this.buttonMovimentarEstoque.Name = "buttonMovimentarEstoque";
            this.buttonMovimentarEstoque.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonMovimentarEstoque.Size = new System.Drawing.Size(194, 35);
            this.buttonMovimentarEstoque.TabIndex = 139;
            this.buttonMovimentarEstoque.Text = " Movimentar estoque";
            this.buttonMovimentarEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMovimentarEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMovimentarEstoque.UseVisualStyleBackColor = true;
            this.buttonMovimentarEstoque.Click += new System.EventHandler(this.buttonMovimentarEstoque_Click);
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
            this.buttonVoltar.Location = new System.Drawing.Point(1101, 0);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(105, 30);
            this.buttonVoltar.TabIndex = 140;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // labelNomeProduto
            // 
            this.labelNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelNomeProduto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNomeProduto.Location = new System.Drawing.Point(31, 18);
            this.labelNomeProduto.Name = "labelNomeProduto";
            this.labelNomeProduto.Size = new System.Drawing.Size(1059, 25);
            this.labelNomeProduto.TabIndex = 18;
            this.labelNomeProduto.Text = "N/D";
            this.labelNomeProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCodigo
            // 
            this.labelCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCodigo.Location = new System.Drawing.Point(73, 9);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(32, 17);
            this.labelCodigo.TabIndex = 20;
            this.labelCodigo.Text = "N/D";
            // 
            // panelDadosProduto
            // 
            this.panelDadosProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDadosProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelDadosProduto.Controls.Add(this.labelTipoUnitario);
            this.panelDadosProduto.Controls.Add(label5);
            this.panelDadosProduto.Controls.Add(this.labelEstoqueMinimo);
            this.panelDadosProduto.Controls.Add(this.labelMarca);
            this.panelDadosProduto.Controls.Add(this.labelCategoria);
            this.panelDadosProduto.Controls.Add(label1);
            this.panelDadosProduto.Controls.Add(label12);
            this.panelDadosProduto.Controls.Add(label10);
            this.panelDadosProduto.Controls.Add(this.labelCodigo);
            this.panelDadosProduto.Controls.Add(label8);
            this.panelDadosProduto.Location = new System.Drawing.Point(31, 54);
            this.panelDadosProduto.Name = "panelDadosProduto";
            this.panelDadosProduto.Size = new System.Drawing.Size(1147, 35);
            this.panelDadosProduto.TabIndex = 93;
            this.panelDadosProduto.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // labelTipoUnitario
            // 
            this.labelTipoUnitario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTipoUnitario.AutoSize = true;
            this.labelTipoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoUnitario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTipoUnitario.Location = new System.Drawing.Point(835, 9);
            this.labelTipoUnitario.Name = "labelTipoUnitario";
            this.labelTipoUnitario.Size = new System.Drawing.Size(32, 17);
            this.labelTipoUnitario.TabIndex = 34;
            this.labelTipoUnitario.Text = "N/D";
            // 
            // labelEstoqueMinimo
            // 
            this.labelEstoqueMinimo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEstoqueMinimo.AutoSize = true;
            this.labelEstoqueMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstoqueMinimo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelEstoqueMinimo.Location = new System.Drawing.Point(1066, 9);
            this.labelEstoqueMinimo.Name = "labelEstoqueMinimo";
            this.labelEstoqueMinimo.Size = new System.Drawing.Size(36, 17);
            this.labelEstoqueMinimo.TabIndex = 31;
            this.labelEstoqueMinimo.Text = "0,00";
            // 
            // labelMarca
            // 
            this.labelMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMarca.AutoSize = true;
            this.labelMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMarca.Location = new System.Drawing.Point(550, 9);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(32, 17);
            this.labelMarca.TabIndex = 30;
            this.labelMarca.Text = "N/D";
            // 
            // labelCategoria
            // 
            this.labelCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCategoria.Location = new System.Drawing.Point(281, 9);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(32, 17);
            this.labelCategoria.TabIndex = 29;
            this.labelCategoria.Text = "N/D";
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
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContent.ColumnHeadersHeight = 30;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
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
            this.dataGridViewContent.Location = new System.Drawing.Point(31, 250);
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
            this.dataGridViewContent.RowHeadersWidth = 50;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 40;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1147, 329);
            this.dataGridViewContent.TabIndex = 143;
            this.dataGridViewContent.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridViewContent_Paint);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "idProduto";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Data";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Entrada";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Saída";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Descrição";
            this.Column4.MinimumWidth = 350;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Valor unitário (R$)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Saldo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // panelTotais
            // 
            this.panelTotais.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTotais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTotais.Controls.Add(this.labelTotalSaidas);
            this.panelTotais.Controls.Add(this.labelTotalEntradas);
            this.panelTotais.Controls.Add(this.labelMedioSaidas);
            this.panelTotais.Controls.Add(label25);
            this.panelTotais.Controls.Add(label26);
            this.panelTotais.Controls.Add(label27);
            this.panelTotais.Controls.Add(this.labelMedioEntradas);
            this.panelTotais.Controls.Add(label30);
            this.panelTotais.Location = new System.Drawing.Point(31, 590);
            this.panelTotais.Name = "panelTotais";
            this.panelTotais.Size = new System.Drawing.Size(1147, 40);
            this.panelTotais.TabIndex = 144;
            this.panelTotais.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // labelTotalSaidas
            // 
            this.labelTotalSaidas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalSaidas.AutoSize = true;
            this.labelTotalSaidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSaidas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTotalSaidas.Location = new System.Drawing.Point(985, 11);
            this.labelTotalSaidas.Name = "labelTotalSaidas";
            this.labelTotalSaidas.Size = new System.Drawing.Size(40, 18);
            this.labelTotalSaidas.TabIndex = 32;
            this.labelTotalSaidas.Text = "0,00";
            // 
            // labelTotalEntradas
            // 
            this.labelTotalEntradas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalEntradas.AutoSize = true;
            this.labelTotalEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalEntradas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTotalEntradas.Location = new System.Drawing.Point(704, 11);
            this.labelTotalEntradas.Name = "labelTotalEntradas";
            this.labelTotalEntradas.Size = new System.Drawing.Size(40, 18);
            this.labelTotalEntradas.TabIndex = 31;
            this.labelTotalEntradas.Text = "0,00";
            // 
            // labelMedioSaidas
            // 
            this.labelMedioSaidas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMedioSaidas.AutoSize = true;
            this.labelMedioSaidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedioSaidas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMedioSaidas.Location = new System.Drawing.Point(432, 11);
            this.labelMedioSaidas.Name = "labelMedioSaidas";
            this.labelMedioSaidas.Size = new System.Drawing.Size(40, 18);
            this.labelMedioSaidas.TabIndex = 30;
            this.labelMedioSaidas.Text = "0,00";
            // 
            // labelMedioEntradas
            // 
            this.labelMedioEntradas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMedioEntradas.AutoSize = true;
            this.labelMedioEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedioEntradas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMedioEntradas.Location = new System.Drawing.Point(163, 11);
            this.labelMedioEntradas.Name = "labelMedioEntradas";
            this.labelMedioEntradas.Size = new System.Drawing.Size(40, 18);
            this.labelMedioEntradas.TabIndex = 20;
            this.labelMedioEntradas.Text = "0,00";
            // 
            // dateTimePeriodoIncial
            // 
            this.dateTimePeriodoIncial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePeriodoIncial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePeriodoIncial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePeriodoIncial.Location = new System.Drawing.Point(827, 212);
            this.dateTimePeriodoIncial.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePeriodoIncial.Name = "dateTimePeriodoIncial";
            this.dateTimePeriodoIncial.Size = new System.Drawing.Size(109, 26);
            this.dateTimePeriodoIncial.TabIndex = 145;
            // 
            // dateTimePeriodoFinal
            // 
            this.dateTimePeriodoFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePeriodoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePeriodoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePeriodoFinal.Location = new System.Drawing.Point(948, 212);
            this.dateTimePeriodoFinal.Name = "dateTimePeriodoFinal";
            this.dateTimePeriodoFinal.Size = new System.Drawing.Size(104, 26);
            this.dateTimePeriodoFinal.TabIndex = 147;
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
            this.buttonPesquisar.Location = new System.Drawing.Point(1063, 211);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(115, 28);
            this.buttonPesquisar.TabIndex = 148;
            this.buttonPesquisar.TabStop = false;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPesquisar.UseVisualStyleBackColor = false;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            this.buttonPesquisar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // FormEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.dateTimePeriodoFinal);
            this.Controls.Add(this.dateTimePeriodoIncial);
            this.Controls.Add(this.panelTotais);
            this.Controls.Add(this.dataGridViewContent);
            this.Controls.Add(this.groupBoxSaldo);
            this.Controls.Add(this.groupBoxSaidas);
            this.Controls.Add(this.groupBoxEntradas);
            this.Controls.Add(this.groupBoxSaldoAnterior);
            this.Controls.Add(label3);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.buttonMovimentarEstoque);
            this.Controls.Add(this.panelDadosProduto);
            this.Controls.Add(this.labelNomeProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEstoque";
            this.Load += new System.EventHandler(this.FormEstoque_Load);
            this.groupBoxSaldoAnterior.ResumeLayout(false);
            this.groupBoxSaldoAnterior.PerformLayout();
            this.groupBoxEntradas.ResumeLayout(false);
            this.groupBoxEntradas.PerformLayout();
            this.groupBoxSaidas.ResumeLayout(false);
            this.groupBoxSaidas.PerformLayout();
            this.groupBoxSaldo.ResumeLayout(false);
            this.groupBoxSaldo.PerformLayout();
            this.panelDadosProduto.ResumeLayout(false);
            this.panelDadosProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.panelTotais.ResumeLayout(false);
            this.panelTotais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonMovimentarEstoque;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelNomeProduto;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Panel panelDadosProduto;
        private System.Windows.Forms.Label labelEstoqueMinimo;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.Label labelSandoAnterior;
        private System.Windows.Forms.Label labelEntradas;
        private System.Windows.Forms.Label labelSaidas;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.Panel panelTotais;
        private System.Windows.Forms.Label labelTotalSaidas;
        private System.Windows.Forms.Label labelTotalEntradas;
        private System.Windows.Forms.Label labelMedioSaidas;
        private System.Windows.Forms.Label labelMedioEntradas;
        private System.Windows.Forms.DateTimePicker dateTimePeriodoIncial;
        private System.Windows.Forms.DateTimePicker dateTimePeriodoFinal;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Label labelTipoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBoxSaldoAnterior;
        private System.Windows.Forms.GroupBox groupBoxEntradas;
        private System.Windows.Forms.GroupBox groupBoxSaidas;
        private System.Windows.Forms.GroupBox groupBoxSaldo;
    }
}