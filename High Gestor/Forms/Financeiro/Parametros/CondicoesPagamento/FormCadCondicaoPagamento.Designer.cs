namespace High_Gestor.Forms.Financeiro.Parametros.CondicoesPagamento
{
    partial class FormCadCondicaoPagamento
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxNomeCondicao = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.textBoxIntervalo = new System.Windows.Forms.TextBox();
            this.textBoxPrimeiraParcela = new System.Windows.Forms.TextBox();
            this.textBoxQuantidadeParcelas = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(312, 64);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 16);
            label5.TabIndex = 126;
            label5.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(35, 62);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 17);
            label1.TabIndex = 123;
            label1.Text = "Codigo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label2.Location = new System.Drawing.Point(35, 133);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 17);
            label2.TabIndex = 122;
            label2.Text = "Nome da condição *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(588, 132);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(137, 16);
            label3.TabIndex = 128;
            label3.Text = "Forma de pagamento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label4.Location = new System.Drawing.Point(34, 203);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 17);
            label4.TabIndex = 130;
            label4.Text = "Intervalo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label6.Location = new System.Drawing.Point(311, 203);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(111, 17);
            label6.TabIndex = 132;
            label6.Text = "Primeira parcela";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label7.Location = new System.Drawing.Point(588, 203);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(169, 17);
            label7.TabIndex = 134;
            label7.Text = "Quantidade de parcelas *";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.Color.White;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.comboBoxStatus.Location = new System.Drawing.Point(315, 83);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(266, 26);
            this.comboBoxStatus.TabIndex = 0;
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigo.Enabled = false;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCodigo.Location = new System.Drawing.Point(39, 85);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(266, 23);
            this.textBoxCodigo.TabIndex = 117;
            // 
            // textBoxNomeCondicao
            // 
            this.textBoxNomeCondicao.BackColor = System.Drawing.Color.White;
            this.textBoxNomeCondicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeCondicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeCondicao.Location = new System.Drawing.Point(39, 153);
            this.textBoxNomeCondicao.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeCondicao.Name = "textBoxNomeCondicao";
            this.textBoxNomeCondicao.Size = new System.Drawing.Size(543, 23);
            this.textBoxNomeCondicao.TabIndex = 1;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(20, 16);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(302, 24);
            this.labelContagem.TabIndex = 121;
            this.labelContagem.Text = "Cadastrar Condição de pagamento";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(491, 580);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(109, 37);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(376, 580);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(109, 37);
            this.buttonSalvar.TabIndex = 6;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.BackColor = System.Drawing.Color.White;
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(591, 151);
            this.comboBoxFormaPagamento.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(268, 26);
            this.comboBoxFormaPagamento.TabIndex = 2;
            // 
            // textBoxIntervalo
            // 
            this.textBoxIntervalo.BackColor = System.Drawing.Color.White;
            this.textBoxIntervalo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIntervalo.Location = new System.Drawing.Point(38, 223);
            this.textBoxIntervalo.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxIntervalo.Name = "textBoxIntervalo";
            this.textBoxIntervalo.Size = new System.Drawing.Size(267, 23);
            this.textBoxIntervalo.TabIndex = 3;
            this.textBoxIntervalo.Text = "0";
            this.textBoxIntervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // textBoxPrimeiraParcela
            // 
            this.textBoxPrimeiraParcela.BackColor = System.Drawing.Color.White;
            this.textBoxPrimeiraParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPrimeiraParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrimeiraParcela.Location = new System.Drawing.Point(315, 223);
            this.textBoxPrimeiraParcela.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxPrimeiraParcela.Name = "textBoxPrimeiraParcela";
            this.textBoxPrimeiraParcela.Size = new System.Drawing.Size(267, 23);
            this.textBoxPrimeiraParcela.TabIndex = 4;
            this.textBoxPrimeiraParcela.Text = "0";
            this.textBoxPrimeiraParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // textBoxQuantidadeParcelas
            // 
            this.textBoxQuantidadeParcelas.BackColor = System.Drawing.Color.White;
            this.textBoxQuantidadeParcelas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxQuantidadeParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidadeParcelas.Location = new System.Drawing.Point(592, 223);
            this.textBoxQuantidadeParcelas.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxQuantidadeParcelas.Name = "textBoxQuantidadeParcelas";
            this.textBoxQuantidadeParcelas.Size = new System.Drawing.Size(267, 23);
            this.textBoxQuantidadeParcelas.TabIndex = 5;
            this.textBoxQuantidadeParcelas.Text = "0";
            this.textBoxQuantidadeParcelas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // FormCadCondicaoPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(977, 640);
            this.Controls.Add(label7);
            this.Controls.Add(this.textBoxQuantidadeParcelas);
            this.Controls.Add(label6);
            this.Controls.Add(this.textBoxPrimeiraParcela);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxIntervalo);
            this.Controls.Add(this.comboBoxFormaPagamento);
            this.Controls.Add(label3);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label5);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxNomeCondicao);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadCondicaoPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadCondicaoPagamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadCondicaoPagamento_FormClosing);
            this.Load += new System.EventHandler(this.FormCadCondicaoPagamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxNomeCondicao;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        private System.Windows.Forms.TextBox textBoxIntervalo;
        private System.Windows.Forms.TextBox textBoxPrimeiraParcela;
        private System.Windows.Forms.TextBox textBoxQuantidadeParcelas;
    }
}