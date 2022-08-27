namespace High_Gestor.Forms.Financeiro.Parametros.CategoriaContas
{
    partial class FormCategoriaContas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoriaContas));
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControlContent = new System.Windows.Forms.TabControl();
            this.tabPageReceitas = new System.Windows.Forms.TabPage();
            this.dataGridViewContentReceitas = new System.Windows.Forms.DataGridView();
            this.labelContagem = new System.Windows.Forms.Label();
            this.tabPageDespesas = new System.Windows.Forms.TabPage();
            this.dataGridViewContentDespesas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonExcluirCadastro = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.buttonAdicionarNovo = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.tabControlContent.SuspendLayout();
            this.tabPageReceitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentReceitas)).BeginInit();
            this.tabPageDespesas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentDespesas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(11, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(176, 24);
            label1.TabIndex = 154;
            label1.Text = "Categoria financeira";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelContent.Controls.Add(this.tabControlContent);
            this.panelContent.Controls.Add(this.buttonVoltar);
            this.panelContent.Controls.Add(this.textBoxPesquisar);
            this.panelContent.Controls.Add(this.buttonPesquisar);
            this.panelContent.Controls.Add(this.buttonExcluirCadastro);
            this.panelContent.Controls.Add(this.buttonRelatorio);
            this.panelContent.Controls.Add(this.buttonAdicionarNovo);
            this.panelContent.Controls.Add(label1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(977, 640);
            this.panelContent.TabIndex = 3;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            // 
            // tabControlContent
            // 
            this.tabControlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlContent.Controls.Add(this.tabPageReceitas);
            this.tabControlContent.Controls.Add(this.tabPageDespesas);
            this.tabControlContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlContent.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControlContent.Location = new System.Drawing.Point(15, 113);
            this.tabControlContent.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlContent.Name = "tabControlContent";
            this.tabControlContent.Padding = new System.Drawing.Point(50, 5);
            this.tabControlContent.SelectedIndex = 0;
            this.tabControlContent.Size = new System.Drawing.Size(949, 524);
            this.tabControlContent.TabIndex = 221;
            this.tabControlContent.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlContent_Selected);
            // 
            // tabPageReceitas
            // 
            this.tabPageReceitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tabPageReceitas.Controls.Add(this.dataGridViewContentReceitas);
            this.tabPageReceitas.Controls.Add(this.labelContagem);
            this.tabPageReceitas.Location = new System.Drawing.Point(4, 29);
            this.tabPageReceitas.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageReceitas.Name = "tabPageReceitas";
            this.tabPageReceitas.Size = new System.Drawing.Size(941, 491);
            this.tabPageReceitas.TabIndex = 0;
            this.tabPageReceitas.Text = "RECEITAS";
            // 
            // dataGridViewContentReceitas
            // 
            this.dataGridViewContentReceitas.AllowUserToAddRows = false;
            this.dataGridViewContentReceitas.AllowUserToDeleteRows = false;
            this.dataGridViewContentReceitas.AllowUserToResizeColumns = false;
            this.dataGridViewContentReceitas.AllowUserToResizeRows = false;
            this.dataGridViewContentReceitas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.dataGridViewContentReceitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContentReceitas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContentReceitas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContentReceitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContentReceitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContentReceitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1});
            this.dataGridViewContentReceitas.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContentReceitas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewContentReceitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewContentReceitas.EnableHeadersVisualStyles = false;
            this.dataGridViewContentReceitas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContentReceitas.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewContentReceitas.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewContentReceitas.MultiSelect = false;
            this.dataGridViewContentReceitas.Name = "dataGridViewContentReceitas";
            this.dataGridViewContentReceitas.ReadOnly = true;
            this.dataGridViewContentReceitas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContentReceitas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContentReceitas.RowHeadersVisible = false;
            this.dataGridViewContentReceitas.RowHeadersWidth = 51;
            this.dataGridViewContentReceitas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContentReceitas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewContentReceitas.RowTemplate.DividerHeight = 1;
            this.dataGridViewContentReceitas.RowTemplate.Height = 35;
            this.dataGridViewContentReceitas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContentReceitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContentReceitas.Size = new System.Drawing.Size(941, 474);
            this.dataGridViewContentReceitas.TabIndex = 143;
            this.dataGridViewContentReceitas.TabStop = false;
            this.dataGridViewContentReceitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContentReceitas_CellDoubleClick);
            // 
            // labelContagem
            // 
            this.labelContagem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(0, 474);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(941, 17);
            this.labelContagem.TabIndex = 161;
            this.labelContagem.Text = "Total: N Registros";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageDespesas
            // 
            this.tabPageDespesas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.tabPageDespesas.Controls.Add(this.dataGridViewContentDespesas);
            this.tabPageDespesas.Controls.Add(this.label2);
            this.tabPageDespesas.Location = new System.Drawing.Point(4, 29);
            this.tabPageDespesas.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageDespesas.Name = "tabPageDespesas";
            this.tabPageDespesas.Size = new System.Drawing.Size(941, 491);
            this.tabPageDespesas.TabIndex = 1;
            this.tabPageDespesas.Text = "DESPESAS";
            // 
            // dataGridViewContentDespesas
            // 
            this.dataGridViewContentDespesas.AllowUserToAddRows = false;
            this.dataGridViewContentDespesas.AllowUserToDeleteRows = false;
            this.dataGridViewContentDespesas.AllowUserToResizeColumns = false;
            this.dataGridViewContentDespesas.AllowUserToResizeRows = false;
            this.dataGridViewContentDespesas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.dataGridViewContentDespesas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContentDespesas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewContentDespesas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContentDespesas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewContentDespesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContentDespesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.dataGridViewTextBoxColumn1});
            this.dataGridViewContentDespesas.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContentDespesas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewContentDespesas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewContentDespesas.EnableHeadersVisualStyles = false;
            this.dataGridViewContentDespesas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContentDespesas.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewContentDespesas.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewContentDespesas.MultiSelect = false;
            this.dataGridViewContentDespesas.Name = "dataGridViewContentDespesas";
            this.dataGridViewContentDespesas.ReadOnly = true;
            this.dataGridViewContentDespesas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContentDespesas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewContentDespesas.RowHeadersVisible = false;
            this.dataGridViewContentDespesas.RowHeadersWidth = 51;
            this.dataGridViewContentDespesas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContentDespesas.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewContentDespesas.RowTemplate.DividerHeight = 1;
            this.dataGridViewContentDespesas.RowTemplate.Height = 35;
            this.dataGridViewContentDespesas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContentDespesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContentDespesas.Size = new System.Drawing.Size(941, 474);
            this.dataGridViewContentDespesas.TabIndex = 162;
            this.dataGridViewContentDespesas.TabStop = false;
            this.dataGridViewContentDespesas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContentDespesas_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(941, 17);
            this.label2.TabIndex = 163;
            this.label2.Text = "Total: N Registros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.buttonVoltar.Location = new System.Drawing.Point(865, 5);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 220;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxPesquisar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPesquisar.Location = new System.Drawing.Point(604, 66);
            this.textBoxPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(250, 26);
            this.textBoxPesquisar.TabIndex = 160;
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
            this.buttonPesquisar.Location = new System.Drawing.Point(864, 66);
            this.buttonPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(100, 26);
            this.buttonPesquisar.TabIndex = 159;
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
            this.buttonExcluirCadastro.Location = new System.Drawing.Point(368, 66);
            this.buttonExcluirCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExcluirCadastro.Name = "buttonExcluirCadastro";
            this.buttonExcluirCadastro.Size = new System.Drawing.Size(153, 30);
            this.buttonExcluirCadastro.TabIndex = 158;
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
            this.buttonRelatorio.Location = new System.Drawing.Point(168, 66);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(190, 30);
            this.buttonRelatorio.TabIndex = 157;
            this.buttonRelatorio.Text = " Relação de categorias";
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
            this.buttonAdicionarNovo.Location = new System.Drawing.Point(15, 66);
            this.buttonAdicionarNovo.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAdicionarNovo.Name = "buttonAdicionarNovo";
            this.buttonAdicionarNovo.Size = new System.Drawing.Size(143, 30);
            this.buttonAdicionarNovo.TabIndex = 156;
            this.buttonAdicionarNovo.Text = "Nova Categoria";
            this.buttonAdicionarNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdicionarNovo.UseVisualStyleBackColor = false;
            this.buttonAdicionarNovo.Click += new System.EventHandler(this.buttonAdicionarNovo_Click);
            this.buttonAdicionarNovo.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "idCategoriaFinanceiro";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "idCategoriaFinanceiro";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // FormCategoriaContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(977, 640);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCategoriaContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCategoriaContas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCategoriaContas_FormClosing);
            this.Load += new System.EventHandler(this.FormCategoriaContas_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.tabControlContent.ResumeLayout(false);
            this.tabPageReceitas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentReceitas)).EndInit();
            this.tabPageDespesas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentDespesas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonExcluirCadastro;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonAdicionarNovo;
        private System.Windows.Forms.DataGridView dataGridViewContentReceitas;
        private System.Windows.Forms.TabControl tabControlContent;
        private System.Windows.Forms.TabPage tabPageReceitas;
        private System.Windows.Forms.TabPage tabPageDespesas;
        private System.Windows.Forms.DataGridView dataGridViewContentDespesas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}