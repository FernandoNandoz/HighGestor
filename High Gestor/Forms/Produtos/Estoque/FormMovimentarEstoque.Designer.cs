namespace High_Gestor.Forms.Produtos
{
    partial class FormMovimentarEstoque
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.comboBoxTipoMovimentacao = new System.Windows.Forms.ComboBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dateTimeData = new System.Windows.Forms.DateTimePicker();
            this.textBoxValorUnitario = new System.Windows.Forms.TextBox();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(16, 54);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(154, 16);
            label4.TabIndex = 115;
            label4.Text = "Tipo de movimentação *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(17, 119);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 16);
            label2.TabIndex = 117;
            label2.Text = "Quantidade *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(353, 54);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 149;
            label1.Text = "Data *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(353, 119);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 16);
            label3.TabIndex = 151;
            label3.Text = "Valor unitário";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(502, 171);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(184, 16);
            label5.TabIndex = 152;
            label5.Text = "Este campo não é obrigatorio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(17, 186);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 16);
            label6.TabIndex = 154;
            label6.Text = "Descrição";
            // 
            // comboBoxTipoMovimentacao
            // 
            this.comboBoxTipoMovimentacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoMovimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoMovimentacao.FormattingEnabled = true;
            this.comboBoxTipoMovimentacao.Items.AddRange(new object[] {
            "ENTRADA",
            "SAIDA"});
            this.comboBoxTipoMovimentacao.Location = new System.Drawing.Point(20, 73);
            this.comboBoxTipoMovimentacao.Name = "comboBoxTipoMovimentacao";
            this.comboBoxTipoMovimentacao.Size = new System.Drawing.Size(330, 28);
            this.comboBoxTipoMovimentacao.TabIndex = 0;
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.Location = new System.Drawing.Point(20, 138);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(330, 29);
            this.textBoxQuantidade.TabIndex = 2;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(354, 259);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 119;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(228, 259);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 118;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTitulo.Location = new System.Drawing.Point(12, 11);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(181, 24);
            this.labelTitulo.TabIndex = 121;
            this.labelTitulo.Text = "Movimentar estoque";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimeData
            // 
            this.dateTimeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeData.Location = new System.Drawing.Point(356, 73);
            this.dateTimeData.Name = "dateTimeData";
            this.dateTimeData.Size = new System.Drawing.Size(330, 26);
            this.dateTimeData.TabIndex = 1;
            // 
            // textBoxValorUnitario
            // 
            this.textBoxValorUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorUnitario.Location = new System.Drawing.Point(356, 138);
            this.textBoxValorUnitario.Name = "textBoxValorUnitario";
            this.textBoxValorUnitario.Size = new System.Drawing.Size(330, 29);
            this.textBoxValorUnitario.TabIndex = 3;
            this.textBoxValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(20, 205);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(666, 29);
            this.textBoxDescricao.TabIndex = 4;
            // 
            // FormMovimentarEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(703, 314);
            this.Controls.Add(label6);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(label5);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBoxValorUnitario);
            this.Controls.Add(label1);
            this.Controls.Add(this.dateTimeData);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.comboBoxTipoMovimentacao);
            this.Controls.Add(label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMovimentarEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor - Movimentar Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMovimentarCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FormMovimentarCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTipoMovimentacao;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DateTimePicker dateTimeData;
        private System.Windows.Forms.TextBox textBoxValorUnitario;
        private System.Windows.Forms.TextBox textBoxDescricao;
    }
}