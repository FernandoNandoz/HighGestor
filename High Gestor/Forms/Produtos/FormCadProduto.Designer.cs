namespace High_Gestor.Forms.Produtos
{
    partial class FormCadProduto
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
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.checkBoxGerarCodigoAutomaticamente = new System.Windows.Forms.CheckBox();
            this.textBoxTipoUnitario = new System.Windows.Forms.TextBox();
            this.linkLimparFornecedor = new System.Windows.Forms.LinkLabel();
            this.linkLimparCategoria = new System.Windows.Forms.LinkLabel();
            this.labelContagem = new System.Windows.Forms.Label();
            this.linkLabelCadCategoria = new System.Windows.Forms.LinkLabel();
            this.linkLabelCadFornecedor = new System.Windows.Forms.LinkLabel();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxFornecedor = new System.Windows.Forms.ComboBox();
            this.maskedValidade = new System.Windows.Forms.MaskedTextBox();
            this.textBoxPrecoVenda = new System.Windows.Forms.TextBox();
            this.textBoxMargemLucro = new System.Windows.Forms.TextBox();
            this.textBoxValorCusto = new System.Windows.Forms.TextBox();
            this.textBoxEstoqueMinimo = new System.Windows.Forms.TextBox();
            this.textBoxEstoqueAtual = new System.Windows.Forms.TextBox();
            this.textBoxNomeProduto = new System.Windows.Forms.TextBox();
            this.textBoxCodigoProduto = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.comboBoxStatus.Location = new System.Drawing.Point(46, 82);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(117, 30);
            this.comboBoxStatus.TabIndex = 127;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(43, 63);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(44, 16);
            label12.TabIndex = 128;
            label12.Text = "Status";
            // 
            // checkBoxGerarCodigoAutomaticamente
            // 
            this.checkBoxGerarCodigoAutomaticamente.AutoSize = true;
            this.checkBoxGerarCodigoAutomaticamente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGerarCodigoAutomaticamente.Location = new System.Drawing.Point(407, 83);
            this.checkBoxGerarCodigoAutomaticamente.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGerarCodigoAutomaticamente.Name = "checkBoxGerarCodigoAutomaticamente";
            this.checkBoxGerarCodigoAutomaticamente.Size = new System.Drawing.Size(248, 24);
            this.checkBoxGerarCodigoAutomaticamente.TabIndex = 126;
            this.checkBoxGerarCodigoAutomaticamente.TabStop = false;
            this.checkBoxGerarCodigoAutomaticamente.Text = "Gerar codigo automaticamente";
            this.checkBoxGerarCodigoAutomaticamente.UseVisualStyleBackColor = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckedChanged += new System.EventHandler(this.checkBoxGerarCodigoAutomaticamente_CheckedChanged);
            // 
            // textBoxTipoUnitario
            // 
            this.textBoxTipoUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxTipoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTipoUnitario.Location = new System.Drawing.Point(564, 149);
            this.textBoxTipoUnitario.Name = "textBoxTipoUnitario";
            this.textBoxTipoUnitario.Size = new System.Drawing.Size(97, 29);
            this.textBoxTipoUnitario.TabIndex = 99;
            // 
            // linkLimparFornecedor
            // 
            this.linkLimparFornecedor.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLimparFornecedor.AutoSize = true;
            this.linkLimparFornecedor.LinkColor = System.Drawing.Color.Black;
            this.linkLimparFornecedor.Location = new System.Drawing.Point(43, 247);
            this.linkLimparFornecedor.Name = "linkLimparFornecedor";
            this.linkLimparFornecedor.Size = new System.Drawing.Size(95, 13);
            this.linkLimparFornecedor.TabIndex = 125;
            this.linkLimparFornecedor.TabStop = true;
            this.linkLimparFornecedor.Text = "Limpar Fornecedor";
            this.linkLimparFornecedor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLimparFornecedor_LinkClicked);
            // 
            // linkLimparCategoria
            // 
            this.linkLimparCategoria.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLimparCategoria.AutoSize = true;
            this.linkLimparCategoria.LinkColor = System.Drawing.Color.Black;
            this.linkLimparCategoria.Location = new System.Drawing.Point(43, 333);
            this.linkLimparCategoria.Name = "linkLimparCategoria";
            this.linkLimparCategoria.Size = new System.Drawing.Size(86, 13);
            this.linkLimparCategoria.TabIndex = 124;
            this.linkLimparCategoria.TabStop = true;
            this.linkLimparCategoria.Text = "Limpar Categoria";
            this.linkLimparCategoria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLimparCategoria_LinkClicked);
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(20, 13);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(191, 24);
            this.labelContagem.TabIndex = 123;
            this.labelContagem.Text = "Cadastro de Produtos";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabelCadCategoria
            // 
            this.linkLabelCadCategoria.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLabelCadCategoria.AutoSize = true;
            this.linkLabelCadCategoria.LinkColor = System.Drawing.Color.Black;
            this.linkLabelCadCategoria.Location = new System.Drawing.Point(561, 333);
            this.linkLabelCadCategoria.Name = "linkLabelCadCategoria";
            this.linkLabelCadCategoria.Size = new System.Drawing.Size(100, 13);
            this.linkLabelCadCategoria.TabIndex = 122;
            this.linkLabelCadCategoria.TabStop = true;
            this.linkLabelCadCategoria.Text = "Cadastrar Categoria";
            this.linkLabelCadCategoria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCadCategoria_LinkClicked);
            // 
            // linkLabelCadFornecedor
            // 
            this.linkLabelCadFornecedor.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLabelCadFornecedor.AutoSize = true;
            this.linkLabelCadFornecedor.LinkColor = System.Drawing.Color.Black;
            this.linkLabelCadFornecedor.Location = new System.Drawing.Point(552, 247);
            this.linkLabelCadFornecedor.Name = "linkLabelCadFornecedor";
            this.linkLabelCadFornecedor.Size = new System.Drawing.Size(109, 13);
            this.linkLabelCadFornecedor.TabIndex = 121;
            this.linkLabelCadFornecedor.TabStop = true;
            this.linkLabelCadFornecedor.Text = "Cadastrar Fornecedor";
            this.linkLabelCadFornecedor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCadFornecedor_LinkClicked);
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(449, 449);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(130, 16);
            label11.TabIndex = 120;
            label11.Text = "Preço de venda - R$";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(264, 449);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(130, 16);
            label10.TabIndex = 119;
            label10.Text = "Margem de lucro - %";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(43, 449);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(120, 16);
            label9.TabIndex = 118;
            label9.Text = "Valor de custo - R$";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(485, 373);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(114, 16);
            label8.TabIndex = 117;
            label8.Text = "Valida do produto";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(264, 373);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(89, 16);
            label7.TabIndex = 116;
            label7.Text = "Estoque atual";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(43, 373);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(103, 16);
            label6.TabIndex = 115;
            label6.Text = "Estoque minimo";
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(46, 302);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(615, 28);
            this.comboBoxCategoria.TabIndex = 101;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(43, 283);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(134, 16);
            label5.TabIndex = 114;
            label5.Text = "Categoria do produto";
            // 
            // comboBoxFornecedor
            // 
            this.comboBoxFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFornecedor.FormattingEnabled = true;
            this.comboBoxFornecedor.Location = new System.Drawing.Point(46, 216);
            this.comboBoxFornecedor.Name = "comboBoxFornecedor";
            this.comboBoxFornecedor.Size = new System.Drawing.Size(615, 28);
            this.comboBoxFornecedor.TabIndex = 100;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(43, 197);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 16);
            label4.TabIndex = 113;
            label4.Text = "Fornecedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(561, 132);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 16);
            label3.TabIndex = 112;
            label3.Text = "Tipo Unitário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(43, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(112, 16);
            label2.TabIndex = 111;
            label2.Text = "Nome do produto";
            // 
            // maskedValidade
            // 
            this.maskedValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedValidade.Location = new System.Drawing.Point(488, 392);
            this.maskedValidade.Mask = "00/00/0000";
            this.maskedValidade.Name = "maskedValidade";
            this.maskedValidade.Size = new System.Drawing.Size(173, 29);
            this.maskedValidade.TabIndex = 104;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(166, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(120, 16);
            label1.TabIndex = 110;
            label1.Text = "Codigo do Produto";
            // 
            // textBoxPrecoVenda
            // 
            this.textBoxPrecoVenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPrecoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrecoVenda.Location = new System.Drawing.Point(452, 468);
            this.textBoxPrecoVenda.Name = "textBoxPrecoVenda";
            this.textBoxPrecoVenda.Size = new System.Drawing.Size(209, 29);
            this.textBoxPrecoVenda.TabIndex = 107;
            this.textBoxPrecoVenda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPrecoVenda_KeyUp);
            // 
            // textBoxMargemLucro
            // 
            this.textBoxMargemLucro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxMargemLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMargemLucro.Location = new System.Drawing.Point(267, 468);
            this.textBoxMargemLucro.Name = "textBoxMargemLucro";
            this.textBoxMargemLucro.Size = new System.Drawing.Size(179, 29);
            this.textBoxMargemLucro.TabIndex = 106;
            this.textBoxMargemLucro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMargemLucro_KeyUp);
            // 
            // textBoxValorCusto
            // 
            this.textBoxValorCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValorCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorCusto.Location = new System.Drawing.Point(46, 468);
            this.textBoxValorCusto.Name = "textBoxValorCusto";
            this.textBoxValorCusto.Size = new System.Drawing.Size(215, 29);
            this.textBoxValorCusto.TabIndex = 105;
            this.textBoxValorCusto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValorCusto_KeyUp);
            // 
            // textBoxEstoqueMinimo
            // 
            this.textBoxEstoqueMinimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEstoqueMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEstoqueMinimo.Location = new System.Drawing.Point(46, 392);
            this.textBoxEstoqueMinimo.Name = "textBoxEstoqueMinimo";
            this.textBoxEstoqueMinimo.Size = new System.Drawing.Size(215, 29);
            this.textBoxEstoqueMinimo.TabIndex = 102;
            // 
            // textBoxEstoqueAtual
            // 
            this.textBoxEstoqueAtual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEstoqueAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEstoqueAtual.Location = new System.Drawing.Point(267, 392);
            this.textBoxEstoqueAtual.Name = "textBoxEstoqueAtual";
            this.textBoxEstoqueAtual.Size = new System.Drawing.Size(215, 29);
            this.textBoxEstoqueAtual.TabIndex = 103;
            // 
            // textBoxNomeProduto
            // 
            this.textBoxNomeProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeProduto.Location = new System.Drawing.Point(46, 149);
            this.textBoxNomeProduto.Name = "textBoxNomeProduto";
            this.textBoxNomeProduto.Size = new System.Drawing.Size(512, 29);
            this.textBoxNomeProduto.TabIndex = 98;
            // 
            // textBoxCodigoProduto
            // 
            this.textBoxCodigoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigoProduto.Location = new System.Drawing.Point(169, 83);
            this.textBoxCodigoProduto.Name = "textBoxCodigoProduto";
            this.textBoxCodigoProduto.Size = new System.Drawing.Size(215, 29);
            this.textBoxCodigoProduto.TabIndex = 97;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(607, 587);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 109;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(481, 587);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 108;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormCadProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 648);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label12);
            this.Controls.Add(this.checkBoxGerarCodigoAutomaticamente);
            this.Controls.Add(this.textBoxTipoUnitario);
            this.Controls.Add(this.linkLimparFornecedor);
            this.Controls.Add(this.linkLimparCategoria);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.linkLabelCadCategoria);
            this.Controls.Add(this.linkLabelCadFornecedor);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(label5);
            this.Controls.Add(this.comboBoxFornecedor);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.maskedValidade);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxPrecoVenda);
            this.Controls.Add(this.textBoxMargemLucro);
            this.Controls.Add(this.textBoxValorCusto);
            this.Controls.Add(this.textBoxEstoqueMinimo);
            this.Controls.Add(this.textBoxEstoqueAtual);
            this.Controls.Add(this.textBoxNomeProduto);
            this.Controls.Add(this.textBoxCodigoProduto);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadProduto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadProduto_FormClosing);
            this.Load += new System.EventHandler(this.FormCadProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.CheckBox checkBoxGerarCodigoAutomaticamente;
        private System.Windows.Forms.TextBox textBoxTipoUnitario;
        private System.Windows.Forms.LinkLabel linkLimparFornecedor;
        private System.Windows.Forms.LinkLabel linkLimparCategoria;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.LinkLabel linkLabelCadCategoria;
        private System.Windows.Forms.LinkLabel linkLabelCadFornecedor;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.ComboBox comboBoxFornecedor;
        private System.Windows.Forms.MaskedTextBox maskedValidade;
        private System.Windows.Forms.TextBox textBoxPrecoVenda;
        private System.Windows.Forms.TextBox textBoxMargemLucro;
        private System.Windows.Forms.TextBox textBoxValorCusto;
        private System.Windows.Forms.TextBox textBoxEstoqueMinimo;
        private System.Windows.Forms.TextBox textBoxEstoqueAtual;
        private System.Windows.Forms.TextBox textBoxNomeProduto;
        private System.Windows.Forms.TextBox textBoxCodigoProduto;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
    }
}