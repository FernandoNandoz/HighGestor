namespace High_Gestor.Forms.Clientes
{
    partial class FormCadCliente
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelContagem;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.maskedCPF_CNPJ = new System.Windows.Forms.MaskedTextBox();
            this.maskedTelefoneLigacao = new System.Windows.Forms.MaskedTextBox();
            this.maskedWhatsApp = new System.Windows.Forms.MaskedTextBox();
            this.maskedRG = new System.Windows.Forms.MaskedTextBox();
            this.linkLabelCadTipoSeguimento = new System.Windows.Forms.LinkLabel();
            this.comboBoxTipoSeguimento = new System.Windows.Forms.ComboBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxComplemento = new System.Windows.Forms.TextBox();
            this.textBoxNomeCliente = new System.Windows.Forms.TextBox();
            this.textBoxNomeResponsavel = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelContagem = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(366, 229);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(109, 16);
            label5.TabIndex = 90;
            label5.Text = "Nº de CPF/CNPJ";
            // 
            // maskedCPF_CNPJ
            // 
            this.maskedCPF_CNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.maskedCPF_CNPJ.Location = new System.Drawing.Point(369, 248);
            this.maskedCPF_CNPJ.Name = "maskedCPF_CNPJ";
            this.maskedCPF_CNPJ.Size = new System.Drawing.Size(333, 27);
            this.maskedCPF_CNPJ.TabIndex = 73;
            // 
            // maskedTelefoneLigacao
            // 
            this.maskedTelefoneLigacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.maskedTelefoneLigacao.Location = new System.Drawing.Point(369, 325);
            this.maskedTelefoneLigacao.Mask = "(00) 0 0000-0000";
            this.maskedTelefoneLigacao.Name = "maskedTelefoneLigacao";
            this.maskedTelefoneLigacao.Size = new System.Drawing.Size(333, 27);
            this.maskedTelefoneLigacao.TabIndex = 75;
            // 
            // maskedWhatsApp
            // 
            this.maskedWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.maskedWhatsApp.Location = new System.Drawing.Point(63, 325);
            this.maskedWhatsApp.Mask = "(00) 0 0000-0000";
            this.maskedWhatsApp.Name = "maskedWhatsApp";
            this.maskedWhatsApp.Size = new System.Drawing.Size(300, 27);
            this.maskedWhatsApp.TabIndex = 74;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(366, 306);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(144, 16);
            label10.TabIndex = 89;
            label10.Text = "Telefone para Ligação";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(60, 306);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(70, 16);
            label9.TabIndex = 88;
            label9.Text = "WhatsApp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(60, 229);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(220, 16);
            label3.TabIndex = 87;
            label3.Text = "Nº de RG  (caso seja pessoa fisica)";
            // 
            // maskedRG
            // 
            this.maskedRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.maskedRG.Location = new System.Drawing.Point(63, 248);
            this.maskedRG.Name = "maskedRG";
            this.maskedRG.Size = new System.Drawing.Size(300, 27);
            this.maskedRG.TabIndex = 72;
            // 
            // labelContagem
            // 
            labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelContagem.AutoSize = true;
            labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            labelContagem.Location = new System.Drawing.Point(59, 23);
            labelContagem.Name = "labelContagem";
            labelContagem.Size = new System.Drawing.Size(183, 24);
            labelContagem.TabIndex = 86;
            labelContagem.Text = "Cadastro de Clientes";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabelCadTipoSeguimento
            // 
            this.linkLabelCadTipoSeguimento.ActiveLinkColor = System.Drawing.Color.Gray;
            this.linkLabelCadTipoSeguimento.AutoSize = true;
            this.linkLabelCadTipoSeguimento.LinkColor = System.Drawing.Color.Black;
            this.linkLabelCadTipoSeguimento.Location = new System.Drawing.Point(226, 203);
            this.linkLabelCadTipoSeguimento.Name = "linkLabelCadTipoSeguimento";
            this.linkLabelCadTipoSeguimento.Size = new System.Drawing.Size(137, 13);
            this.linkLabelCadTipoSeguimento.TabIndex = 85;
            this.linkLabelCadTipoSeguimento.TabStop = true;
            this.linkLabelCadTipoSeguimento.Text = "Cadastrar Tipo/Seguimento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(60, 453);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(91, 16);
            label7.TabIndex = 84;
            label7.Text = "Complemento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(60, 389);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(164, 16);
            label6.TabIndex = 83;
            label6.Text = "Endereço - Rua, Nº, Bairro";
            // 
            // comboBoxTipoSeguimento
            // 
            this.comboBoxTipoSeguimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoSeguimento.FormattingEnabled = true;
            this.comboBoxTipoSeguimento.Location = new System.Drawing.Point(63, 172);
            this.comboBoxTipoSeguimento.Name = "comboBoxTipoSeguimento";
            this.comboBoxTipoSeguimento.Size = new System.Drawing.Size(300, 28);
            this.comboBoxTipoSeguimento.TabIndex = 70;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(60, 153);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(184, 16);
            label4.TabIndex = 82;
            label4.Text = "Segimento ou Tipo do Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(60, 87);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 16);
            label2.TabIndex = 81;
            label2.Text = "Nome / Razão Social";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(366, 153);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(329, 16);
            label1.TabIndex = 80;
            label1.Text = "Nome do Responsavel  (caso não seja pessoa fisica)";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndereco.Location = new System.Drawing.Point(63, 408);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(639, 29);
            this.textBoxEndereco.TabIndex = 76;
            // 
            // textBoxComplemento
            // 
            this.textBoxComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComplemento.Location = new System.Drawing.Point(63, 472);
            this.textBoxComplemento.Name = "textBoxComplemento";
            this.textBoxComplemento.Size = new System.Drawing.Size(639, 29);
            this.textBoxComplemento.TabIndex = 77;
            // 
            // textBoxNomeCliente
            // 
            this.textBoxNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeCliente.Location = new System.Drawing.Point(63, 106);
            this.textBoxNomeCliente.Name = "textBoxNomeCliente";
            this.textBoxNomeCliente.Size = new System.Drawing.Size(639, 29);
            this.textBoxNomeCliente.TabIndex = 69;
            // 
            // textBoxNomeResponsavel
            // 
            this.textBoxNomeResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeResponsavel.Location = new System.Drawing.Point(369, 172);
            this.textBoxNomeResponsavel.Name = "textBoxNomeResponsavel";
            this.textBoxNomeResponsavel.Size = new System.Drawing.Size(333, 29);
            this.textBoxNomeResponsavel.TabIndex = 71;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(645, 606);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 79;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(519, 606);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 78;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            // 
            // FormCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(label5);
            this.Controls.Add(this.maskedCPF_CNPJ);
            this.Controls.Add(this.maskedTelefoneLigacao);
            this.Controls.Add(this.maskedWhatsApp);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label3);
            this.Controls.Add(this.maskedRG);
            this.Controls.Add(labelContagem);
            this.Controls.Add(this.linkLabelCadTipoSeguimento);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.comboBoxTipoSeguimento);
            this.Controls.Add(label4);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxComplemento);
            this.Controls.Add(this.textBoxNomeCliente);
            this.Controls.Add(this.textBoxNomeResponsavel);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadCliente";
            this.Text = "FormCadCliente";
            this.Load += new System.EventHandler(this.FormCadCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedCPF_CNPJ;
        private System.Windows.Forms.MaskedTextBox maskedTelefoneLigacao;
        private System.Windows.Forms.MaskedTextBox maskedWhatsApp;
        private System.Windows.Forms.MaskedTextBox maskedRG;
        private System.Windows.Forms.LinkLabel linkLabelCadTipoSeguimento;
        private System.Windows.Forms.ComboBox comboBoxTipoSeguimento;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxComplemento;
        private System.Windows.Forms.TextBox textBoxNomeCliente;
        private System.Windows.Forms.TextBox textBoxNomeResponsavel;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
    }
}