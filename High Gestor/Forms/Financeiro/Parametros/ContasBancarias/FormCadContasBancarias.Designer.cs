namespace High_Gestor.Forms.Financeiro.Parametros.ContasBancarias
{
    partial class FormCadContasBancarias
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            this.comboBoxSituacao = new System.Windows.Forms.ComboBox();
            this.textBoxNomeConta = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxBanco = new System.Windows.Forms.ComboBox();
            this.textBoxSaldoInicial = new System.Windows.Forms.TextBox();
            this.dateTimeDataInicial = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPadraoReceitas = new System.Windows.Forms.ComboBox();
            this.comboBoxPadraoDespesas = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(28, 133);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(60, 16);
            label5.TabIndex = 147;
            label5.Text = "Situação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label2.Location = new System.Drawing.Point(235, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 17);
            label2.TabIndex = 145;
            label2.Text = "Nome da conta *";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(28, 59);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(46, 16);
            label8.TabIndex = 153;
            label8.Text = "Banco";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(467, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 17);
            label1.TabIndex = 155;
            label1.Text = "Saldo inicial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(593, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 16);
            label3.TabIndex = 234;
            label3.Text = "Data inicial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(236, 133);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(171, 16);
            label4.TabIndex = 236;
            label4.Text = "Conta padrão para receitas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(467, 133);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(184, 16);
            label6.TabIndex = 238;
            label6.Text = "Conta padrão para despesas";
            // 
            // comboBoxSituacao
            // 
            this.comboBoxSituacao.BackColor = System.Drawing.Color.White;
            this.comboBoxSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxSituacao.FormattingEnabled = true;
            this.comboBoxSituacao.Items.AddRange(new object[] {
            "ATIVO",
            "INATIVO"});
            this.comboBoxSituacao.Location = new System.Drawing.Point(31, 152);
            this.comboBoxSituacao.Name = "comboBoxSituacao";
            this.comboBoxSituacao.Size = new System.Drawing.Size(200, 26);
            this.comboBoxSituacao.TabIndex = 4;
            // 
            // textBoxNomeConta
            // 
            this.textBoxNomeConta.BackColor = System.Drawing.Color.White;
            this.textBoxNomeConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeConta.Location = new System.Drawing.Point(239, 80);
            this.textBoxNomeConta.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeConta.Name = "textBoxNomeConta";
            this.textBoxNomeConta.Size = new System.Drawing.Size(222, 23);
            this.textBoxNomeConta.TabIndex = 1;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelContagem.Location = new System.Drawing.Point(20, 10);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(220, 24);
            this.labelContagem.TabIndex = 144;
            this.labelContagem.Text = "Cadastrar Conta bancária";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(367, 211);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(109, 37);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(252, 211);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(109, 37);
            this.buttonSalvar.TabIndex = 7;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // comboBoxBanco
            // 
            this.comboBoxBanco.BackColor = System.Drawing.Color.White;
            this.comboBoxBanco.DropDownHeight = 200;
            this.comboBoxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxBanco.FormattingEnabled = true;
            this.comboBoxBanco.IntegralHeight = false;
            this.comboBoxBanco.Items.AddRange(new object[] {
            "BRADESCO",
            "SANTANDER",
            "BANCO DO BRASIL",
            "CAIXA",
            "ITAU",
            "SICREDI",
            "BANCO INTER",
            "NUBANK",
            "UNICRED",
            "BANESTES",
            "HSBC",
            "SUDAMERIS",
            "NAO E UM BANCO (CARTAO, CAIXINHA, ETC)",
            "MERCANTIL DO BRASIL",
            "BANCOOB",
            "OUTROS",
            "CECRED",
            "BANCO DA AMAZONIA",
            "BANCO DO NORDESTE",
            "BANK OF AMERICA",
            "BANCO DE BRASILIA",
            "SAFRA",
            "STONE PAGAMENTOS S.A",
            "BANCO ORIGINAL",
            "BANCO PAN",
            "HIPERCARD BANCO",
            "MERCADO PAGO",
            "BANCO C6",
            "BANCO RURAL"});
            this.comboBoxBanco.Location = new System.Drawing.Point(31, 78);
            this.comboBoxBanco.MaxDropDownItems = 10;
            this.comboBoxBanco.Name = "comboBoxBanco";
            this.comboBoxBanco.Size = new System.Drawing.Size(200, 26);
            this.comboBoxBanco.TabIndex = 0;
            // 
            // textBoxSaldoInicial
            // 
            this.textBoxSaldoInicial.BackColor = System.Drawing.Color.White;
            this.textBoxSaldoInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSaldoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSaldoInicial.Location = new System.Drawing.Point(471, 80);
            this.textBoxSaldoInicial.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxSaldoInicial.Name = "textBoxSaldoInicial";
            this.textBoxSaldoInicial.Size = new System.Drawing.Size(115, 23);
            this.textBoxSaldoInicial.TabIndex = 2;
            this.textBoxSaldoInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSaldoInicial_KeyPress);
            // 
            // dateTimeDataInicial
            // 
            this.dateTimeDataInicial.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimeDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDataInicial.Location = new System.Drawing.Point(596, 80);
            this.dateTimeDataInicial.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimeDataInicial.Name = "dateTimeDataInicial";
            this.dateTimeDataInicial.Size = new System.Drawing.Size(98, 23);
            this.dateTimeDataInicial.TabIndex = 3;
            // 
            // comboBoxPadraoReceitas
            // 
            this.comboBoxPadraoReceitas.BackColor = System.Drawing.Color.White;
            this.comboBoxPadraoReceitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPadraoReceitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxPadraoReceitas.FormattingEnabled = true;
            this.comboBoxPadraoReceitas.Items.AddRange(new object[] {
            "SIM",
            "NAO"});
            this.comboBoxPadraoReceitas.Location = new System.Drawing.Point(239, 152);
            this.comboBoxPadraoReceitas.Name = "comboBoxPadraoReceitas";
            this.comboBoxPadraoReceitas.Size = new System.Drawing.Size(222, 26);
            this.comboBoxPadraoReceitas.TabIndex = 5;
            // 
            // comboBoxPadraoDespesas
            // 
            this.comboBoxPadraoDespesas.BackColor = System.Drawing.Color.White;
            this.comboBoxPadraoDespesas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPadraoDespesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxPadraoDespesas.FormattingEnabled = true;
            this.comboBoxPadraoDespesas.Items.AddRange(new object[] {
            "SIM",
            "NAO"});
            this.comboBoxPadraoDespesas.Location = new System.Drawing.Point(470, 152);
            this.comboBoxPadraoDespesas.Name = "comboBoxPadraoDespesas";
            this.comboBoxPadraoDespesas.Size = new System.Drawing.Size(224, 26);
            this.comboBoxPadraoDespesas.TabIndex = 6;
            // 
            // FormCadContasBancarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(729, 267);
            this.Controls.Add(this.comboBoxPadraoDespesas);
            this.Controls.Add(label6);
            this.Controls.Add(this.comboBoxPadraoReceitas);
            this.Controls.Add(label4);
            this.Controls.Add(this.dateTimeDataInicial);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxSaldoInicial);
            this.Controls.Add(this.comboBoxBanco);
            this.Controls.Add(label8);
            this.Controls.Add(this.comboBoxSituacao);
            this.Controls.Add(label5);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxNomeConta);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadContasBancarias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor - Contas Bancárias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadContasBancarias_FormClosing);
            this.Load += new System.EventHandler(this.FormCadContasBancarias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSituacao;
        private System.Windows.Forms.TextBox textBoxNomeConta;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxBanco;
        private System.Windows.Forms.TextBox textBoxSaldoInicial;
        private System.Windows.Forms.DateTimePicker dateTimeDataInicial;
        private System.Windows.Forms.ComboBox comboBoxPadraoReceitas;
        private System.Windows.Forms.ComboBox comboBoxPadraoDespesas;
    }
}