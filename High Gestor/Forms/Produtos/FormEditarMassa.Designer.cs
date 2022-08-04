namespace High_Gestor.Forms.Produtos
{
    partial class FormEditarMassa
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label labelSelecioneProduto;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarMassa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonLimparFiltros = new System.Windows.Forms.Button();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxFornecedor = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxPesquisarNome = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.buttonSair = new System.Windows.Forms.Button();
            this.comboBoxCampoEditar = new System.Windows.Forms.ComboBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.dataGridViewContent = new System.Windows.Forms.DataGridView();
            this.ColumnIdProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnTipoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFornecedor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnCategoria = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnEstoqueMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValorCusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMargemLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            labelSelecioneProduto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(543, 28);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 16);
            label5.TabIndex = 122;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(765, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 16);
            label4.TabIndex = 120;
            label4.Text = "Fornecedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(379, 28);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 16);
            label7.TabIndex = 118;
            label7.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
            label1.Location = new System.Drawing.Point(25, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(173, 16);
            label1.TabIndex = 116;
            label1.Text = "Pesquisar Nome ou Codigo";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            label8.ForeColor = System.Drawing.SystemColors.ControlText;
            label8.Location = new System.Drawing.Point(982, 105);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(21, 31);
            label8.TabIndex = 138;
            label8.Text = "|";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(25, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(225, 18);
            label2.TabIndex = 141;
            label2.Text = "Selecione o campo a ser editado";
            // 
            // labelSelecioneProduto
            // 
            labelSelecioneProduto.AutoSize = true;
            labelSelecioneProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            labelSelecioneProduto.ForeColor = System.Drawing.SystemColors.ControlText;
            labelSelecioneProduto.Location = new System.Drawing.Point(27, 155);
            labelSelecioneProduto.Name = "labelSelecioneProduto";
            labelSelecioneProduto.Size = new System.Drawing.Size(227, 18);
            labelSelecioneProduto.TabIndex = 145;
            labelSelecioneProduto.Text = "Selecione um campo para Editar:";
            labelSelecioneProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLimparFiltros
            // 
            this.buttonLimparFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimparFiltros.Location = new System.Drawing.Point(1006, 45);
            this.buttonLimparFiltros.Name = "buttonLimparFiltros";
            this.buttonLimparFiltros.Size = new System.Drawing.Size(113, 30);
            this.buttonLimparFiltros.TabIndex = 123;
            this.buttonLimparFiltros.Text = "Limpar filtros";
            this.buttonLimparFiltros.UseVisualStyleBackColor = true;
            this.buttonLimparFiltros.Click += new System.EventHandler(this.buttonLimparFiltros_Click);
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(546, 47);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(216, 26);
            this.comboBoxCategoria.TabIndex = 121;
            this.comboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoria_SelectedIndexChanged);
            // 
            // comboBoxFornecedor
            // 
            this.comboBoxFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFornecedor.FormattingEnabled = true;
            this.comboBoxFornecedor.Location = new System.Drawing.Point(768, 47);
            this.comboBoxFornecedor.Name = "comboBoxFornecedor";
            this.comboBoxFornecedor.Size = new System.Drawing.Size(232, 26);
            this.comboBoxFornecedor.TabIndex = 119;
            this.comboBoxFornecedor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "TODOS",
            "ATIVO",
            "INATIVO"});
            this.comboBoxStatus.Location = new System.Drawing.Point(382, 47);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(158, 26);
            this.comboBoxStatus.TabIndex = 117;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // textBoxPesquisarNome
            // 
            this.textBoxPesquisarNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxPesquisarNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPesquisarNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.textBoxPesquisarNome.Location = new System.Drawing.Point(28, 47);
            this.textBoxPesquisarNome.Name = "textBoxPesquisarNome";
            this.textBoxPesquisarNome.Size = new System.Drawing.Size(345, 27);
            this.textBoxPesquisarNome.TabIndex = 115;
            this.textBoxPesquisarNome.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPesquisarNome_KeyUp);
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(1068, 4);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(135, 20);
            this.labelContagem.TabIndex = 124;
            this.labelContagem.Text = "Total: N Registros";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonSair
            // 
            this.buttonSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSair.FlatAppearance.BorderSize = 0;
            this.buttonSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonSair.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSair.Image = ((System.Drawing.Image)(resources.GetObject("buttonSair.Image")));
            this.buttonSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSair.Location = new System.Drawing.Point(1006, 106);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonSair.Size = new System.Drawing.Size(168, 35);
            this.buttonSair.TabIndex = 139;
            this.buttonSair.TabStop = false;
            this.buttonSair.Text = " Voltar";
            this.buttonSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSair.UseVisualStyleBackColor = false;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            this.buttonSair.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSair_Paint);
            // 
            // comboBoxCampoEditar
            // 
            this.comboBoxCampoEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCampoEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxCampoEditar.FormattingEnabled = true;
            this.comboBoxCampoEditar.Items.AddRange(new object[] {
            "STATUS",
            "TIPO UNITARIO",
            "MARCA",
            "FORNECEDOR",
            "CATEGORIA",
            "ESTOQUE MINIMO",
            "VALIDADE",
            "VALOR DE CUSTO",
            "VALOR DE VENDA"});
            this.comboBoxCampoEditar.Location = new System.Drawing.Point(28, 114);
            this.comboBoxCampoEditar.Name = "comboBoxCampoEditar";
            this.comboBoxCampoEditar.Size = new System.Drawing.Size(345, 28);
            this.comboBoxCampoEditar.TabIndex = 140;
            this.comboBoxCampoEditar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCampoEditar_SelectedIndexChanged);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(808, 106);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(168, 35);
            this.buttonSalvar.TabIndex = 146;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
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
            this.dataGridViewContent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewContent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContent.ColumnHeadersHeight = 30;
            this.dataGridViewContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdProduto,
            this.ColumnNomeProduto,
            this.ColumnCodigo,
            this.ColumnStatus,
            this.ColumnTipoUnitario,
            this.ColumnMarca,
            this.ColumnFornecedor,
            this.ColumnCategoria,
            this.ColumnEstoqueMinimo,
            this.ColumnValidade,
            this.ColumnValorCusto,
            this.ColumnMargemLucro,
            this.ColumnValorVenda});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewContent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewContent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewContent.EnableHeadersVisualStyles = false;
            this.dataGridViewContent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.dataGridViewContent.Location = new System.Drawing.Point(30, 181);
            this.dataGridViewContent.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewContent.MultiSelect = false;
            this.dataGridViewContent.Name = "dataGridViewContent";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewContent.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewContent.RowHeadersVisible = false;
            this.dataGridViewContent.RowHeadersWidth = 51;
            this.dataGridViewContent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dataGridViewContent.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewContent.RowTemplate.DividerHeight = 1;
            this.dataGridViewContent.RowTemplate.Height = 45;
            this.dataGridViewContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContent.Size = new System.Drawing.Size(1144, 459);
            this.dataGridViewContent.TabIndex = 147;
            this.dataGridViewContent.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewContent_EditingControlShowing);
            // 
            // ColumnIdProduto
            // 
            this.ColumnIdProduto.DataPropertyName = "IdProduto";
            this.ColumnIdProduto.HeaderText = "idProduto";
            this.ColumnIdProduto.Name = "ColumnIdProduto";
            this.ColumnIdProduto.Visible = false;
            // 
            // ColumnNomeProduto
            // 
            this.ColumnNomeProduto.DataPropertyName = "NomeProduto";
            this.ColumnNomeProduto.HeaderText = "Nome do Produto";
            this.ColumnNomeProduto.MinimumWidth = 700;
            this.ColumnNomeProduto.Name = "ColumnNomeProduto";
            this.ColumnNomeProduto.Width = 700;
            // 
            // ColumnCodigo
            // 
            this.ColumnCodigo.DataPropertyName = "Codigo";
            this.ColumnCodigo.HeaderText = "Codigo";
            this.ColumnCodigo.MinimumWidth = 150;
            this.ColumnCodigo.Name = "ColumnCodigo";
            this.ColumnCodigo.Width = 150;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Status";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnStatus.Visible = false;
            // 
            // ColumnTipoUnitario
            // 
            this.ColumnTipoUnitario.DataPropertyName = "TipoUnitario";
            this.ColumnTipoUnitario.HeaderText = "Tipo unitário";
            this.ColumnTipoUnitario.Name = "ColumnTipoUnitario";
            this.ColumnTipoUnitario.Visible = false;
            // 
            // ColumnMarca
            // 
            this.ColumnMarca.DataPropertyName = "Marca";
            this.ColumnMarca.HeaderText = "Marca";
            this.ColumnMarca.Name = "ColumnMarca";
            this.ColumnMarca.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMarca.Visible = false;
            // 
            // ColumnFornecedor
            // 
            this.ColumnFornecedor.DataPropertyName = "Fornecedor";
            this.ColumnFornecedor.HeaderText = "Fornecedor";
            this.ColumnFornecedor.Name = "ColumnFornecedor";
            this.ColumnFornecedor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFornecedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnFornecedor.Visible = false;
            // 
            // ColumnCategoria
            // 
            this.ColumnCategoria.DataPropertyName = "Categoria";
            this.ColumnCategoria.HeaderText = "Categoria";
            this.ColumnCategoria.Name = "ColumnCategoria";
            this.ColumnCategoria.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCategoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCategoria.Visible = false;
            // 
            // ColumnEstoqueMinimo
            // 
            this.ColumnEstoqueMinimo.DataPropertyName = "EstoqueMinimo";
            this.ColumnEstoqueMinimo.HeaderText = "Estoque minimo";
            this.ColumnEstoqueMinimo.Name = "ColumnEstoqueMinimo";
            this.ColumnEstoqueMinimo.Visible = false;
            // 
            // ColumnValidade
            // 
            this.ColumnValidade.DataPropertyName = "Validade";
            this.ColumnValidade.HeaderText = "Validade";
            this.ColumnValidade.Name = "ColumnValidade";
            this.ColumnValidade.Visible = false;
            // 
            // ColumnValorCusto
            // 
            this.ColumnValorCusto.DataPropertyName = "ValorCusto";
            this.ColumnValorCusto.HeaderText = "Valor de custo (R$)";
            this.ColumnValorCusto.Name = "ColumnValorCusto";
            this.ColumnValorCusto.Visible = false;
            // 
            // ColumnMargemLucro
            // 
            this.ColumnMargemLucro.DataPropertyName = "MargemLucro";
            this.ColumnMargemLucro.HeaderText = "Margem de lucro (%)";
            this.ColumnMargemLucro.Name = "ColumnMargemLucro";
            this.ColumnMargemLucro.Visible = false;
            // 
            // ColumnValorVenda
            // 
            this.ColumnValorVenda.DataPropertyName = "ValorVenda";
            this.ColumnValorVenda.HeaderText = "Preço de venda (R$)";
            this.ColumnValorVenda.Name = "ColumnValorVenda";
            this.ColumnValorVenda.Visible = false;
            // 
            // FormEditarMassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.dataGridViewContent);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(labelSelecioneProduto);
            this.Controls.Add(label2);
            this.Controls.Add(this.comboBoxCampoEditar);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(label8);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.buttonLimparFiltros);
            this.Controls.Add(label5);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(label4);
            this.Controls.Add(this.comboBoxFornecedor);
            this.Controls.Add(label7);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxPesquisarNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEditarMassa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditarMassa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditarMassa_FormClosing);
            this.Load += new System.EventHandler(this.FormEditarMassa_Load);
            this.Click += new System.EventHandler(this.FormEditarMassa_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLimparFiltros;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxFornecedor;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxPesquisarNome;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.ComboBox comboBoxCampoEditar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.DataGridView dataGridViewContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCodigo;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMarca;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFornecedor;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEstoqueMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValorCusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMargemLucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValorVenda;
    }
}