namespace High_Gestor.Forms.Relatorios.Vendas.Comissao
{
    partial class FormIncluirLancamento
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.dateTimeData = new System.Windows.Forms.DateTimePicker();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxTipoMovimentacao = new System.Windows.Forms.ComboBox();
            this.comboBoxContaBancaria = new System.Windows.Forms.ComboBox();
            this.labelContaBancaria = new System.Windows.Forms.Label();
            this.checkBoxLancarContas = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(28, 196);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 16);
            label6.TabIndex = 168;
            label6.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(369, 129);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(93, 16);
            label3.TabIndex = 166;
            label3.Text = "Valor unitário *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(28, 129);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 165;
            label1.Text = "Data *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(27, 64);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(135, 16);
            label4.TabIndex = 160;
            label4.Text = "Tipo de lançamento *";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(31, 215);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(671, 27);
            this.textBoxDescricao.TabIndex = 159;
            // 
            // textBoxValor
            // 
            this.textBoxValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.Location = new System.Drawing.Point(372, 148);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(330, 27);
            this.textBoxValor.TabIndex = 158;
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // dateTimeData
            // 
            this.dateTimeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeData.Location = new System.Drawing.Point(31, 148);
            this.dateTimeData.Name = "dateTimeData";
            this.dateTimeData.Size = new System.Drawing.Size(330, 26);
            this.dateTimeData.TabIndex = 156;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTitulo.Location = new System.Drawing.Point(23, 12);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(169, 24);
            this.labelTitulo.TabIndex = 164;
            this.labelTitulo.Text = "Incluir Lançamento";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(372, 299);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 163;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(246, 299);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 162;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // comboBoxTipoMovimentacao
            // 
            this.comboBoxTipoMovimentacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoMovimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoMovimentacao.FormattingEnabled = true;
            this.comboBoxTipoMovimentacao.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO",
            "PAGAMENTO"});
            this.comboBoxTipoMovimentacao.Location = new System.Drawing.Point(31, 83);
            this.comboBoxTipoMovimentacao.Name = "comboBoxTipoMovimentacao";
            this.comboBoxTipoMovimentacao.Size = new System.Drawing.Size(330, 28);
            this.comboBoxTipoMovimentacao.TabIndex = 155;
            this.comboBoxTipoMovimentacao.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoMovimentacao_SelectedIndexChanged);
            // 
            // comboBoxContaBancaria
            // 
            this.comboBoxContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContaBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContaBancaria.FormattingEnabled = true;
            this.comboBoxContaBancaria.Items.AddRange(new object[] {
            "ENTRADA",
            "SAIDA"});
            this.comboBoxContaBancaria.Location = new System.Drawing.Point(372, 83);
            this.comboBoxContaBancaria.Name = "comboBoxContaBancaria";
            this.comboBoxContaBancaria.Size = new System.Drawing.Size(330, 28);
            this.comboBoxContaBancaria.TabIndex = 169;
            // 
            // labelContaBancaria
            // 
            this.labelContaBancaria.AutoSize = true;
            this.labelContaBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContaBancaria.Location = new System.Drawing.Point(368, 64);
            this.labelContaBancaria.Name = "labelContaBancaria";
            this.labelContaBancaria.Size = new System.Drawing.Size(107, 16);
            this.labelContaBancaria.TabIndex = 170;
            this.labelContaBancaria.Text = "Conta Bancária *";
            // 
            // checkBoxLancarContas
            // 
            this.checkBoxLancarContas.AutoSize = true;
            this.checkBoxLancarContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxLancarContas.Location = new System.Drawing.Point(31, 256);
            this.checkBoxLancarContas.Name = "checkBoxLancarContas";
            this.checkBoxLancarContas.Size = new System.Drawing.Size(195, 22);
            this.checkBoxLancarContas.TabIndex = 176;
            this.checkBoxLancarContas.Text = "Lançar no contas à pagar";
            this.checkBoxLancarContas.UseVisualStyleBackColor = true;
            // 
            // FormIncluirLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 359);
            this.Controls.Add(this.checkBoxLancarContas);
            this.Controls.Add(this.comboBoxContaBancaria);
            this.Controls.Add(this.labelContaBancaria);
            this.Controls.Add(label6);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(label1);
            this.Controls.Add(this.dateTimeData);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.comboBoxTipoMovimentacao);
            this.Controls.Add(label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIncluirLancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High gestor - Incluir Lançamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIncluirLancamento_FormClosing);
            this.Load += new System.EventHandler(this.FormIncluirLancamento_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormIncluirLancamento_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.DateTimePicker dateTimeData;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxTipoMovimentacao;
        private System.Windows.Forms.ComboBox comboBoxContaBancaria;
        private System.Windows.Forms.Label labelContaBancaria;
        private System.Windows.Forms.CheckBox checkBoxLancarContas;
    }
}