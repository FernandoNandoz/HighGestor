namespace High_Gestor.Forms.Configuracoes.Fornecedores
{
    partial class FormCadFornecedores
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
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label2;
            this.maskedTelefoneContato = new System.Windows.Forms.MaskedTextBox();
            this.maskedWhatsApp = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxGerarCodigoAutomaticamente = new System.Windows.Forms.CheckBox();
            this.textBoxCodigoFornecedor = new System.Windows.Forms.TextBox();
            this.maskedCPF = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxRepresentante = new System.Windows.Forms.TextBox();
            this.textBoxNomeFantasia = new System.Windows.Forms.TextBox();
            this.maskedCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.textBoxRazaoSocial = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maskedTelefoneContato
            // 
            this.maskedTelefoneContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTelefoneContato.Location = new System.Drawing.Point(347, 467);
            this.maskedTelefoneContato.Mask = "(00) 0 0000-0000";
            this.maskedTelefoneContato.Name = "maskedTelefoneContato";
            this.maskedTelefoneContato.Size = new System.Drawing.Size(306, 29);
            this.maskedTelefoneContato.TabIndex = 83;
            // 
            // maskedWhatsApp
            // 
            this.maskedWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedWhatsApp.Location = new System.Drawing.Point(35, 467);
            this.maskedWhatsApp.Mask = "(00) 0 0000-0000";
            this.maskedWhatsApp.Name = "maskedWhatsApp";
            this.maskedWhatsApp.Size = new System.Drawing.Size(306, 29);
            this.maskedWhatsApp.TabIndex = 82;
            // 
            // checkBoxGerarCodigoAutomaticamente
            // 
            this.checkBoxGerarCodigoAutomaticamente.AutoSize = true;
            this.checkBoxGerarCodigoAutomaticamente.Checked = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGerarCodigoAutomaticamente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGerarCodigoAutomaticamente.Location = new System.Drawing.Point(327, 77);
            this.checkBoxGerarCodigoAutomaticamente.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGerarCodigoAutomaticamente.Name = "checkBoxGerarCodigoAutomaticamente";
            this.checkBoxGerarCodigoAutomaticamente.Size = new System.Drawing.Size(248, 24);
            this.checkBoxGerarCodigoAutomaticamente.TabIndex = 96;
            this.checkBoxGerarCodigoAutomaticamente.TabStop = false;
            this.checkBoxGerarCodigoAutomaticamente.Text = "Gerar codigo automaticamente";
            this.checkBoxGerarCodigoAutomaticamente.UseVisualStyleBackColor = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckedChanged += new System.EventHandler(this.checkBoxGerarCodigoAutomaticamente_CheckedChanged);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(32, 56);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(149, 17);
            label9.TabIndex = 95;
            label9.Text = "Codigo da Fornecedor";
            // 
            // textBoxCodigoFornecedor
            // 
            this.textBoxCodigoFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigoFornecedor.Enabled = false;
            this.textBoxCodigoFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigoFornecedor.Location = new System.Drawing.Point(35, 76);
            this.textBoxCodigoFornecedor.Name = "textBoxCodigoFornecedor";
            this.textBoxCodigoFornecedor.Size = new System.Drawing.Size(266, 29);
            this.textBoxCodigoFornecedor.TabIndex = 75;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(344, 247);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(277, 16);
            label7.TabIndex = 94;
            label7.Text = "CPF (Caso o Fornecedor seja pessoa Fisica)";
            // 
            // maskedCPF
            // 
            this.maskedCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedCPF.Location = new System.Drawing.Point(347, 266);
            this.maskedCPF.Mask = "000.000.000-00";
            this.maskedCPF.Name = "maskedCPF";
            this.maskedCPF.Size = new System.Drawing.Size(306, 29);
            this.maskedCPF.TabIndex = 79;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(344, 448);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(141, 16);
            label6.TabIndex = 93;
            label6.Text = "Telefone para Contato";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(32, 448);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 16);
            label5.TabIndex = 92;
            label5.Text = "WhatApp";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(32, 379);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 16);
            label4.TabIndex = 91;
            label4.Text = "Endereço";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndereco.Location = new System.Drawing.Point(35, 398);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(618, 29);
            this.textBoxEndereco.TabIndex = 81;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(32, 314);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(96, 16);
            label3.TabIndex = 90;
            label3.Text = "Representante";
            // 
            // textBoxRepresentante
            // 
            this.textBoxRepresentante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxRepresentante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRepresentante.Location = new System.Drawing.Point(35, 333);
            this.textBoxRepresentante.Name = "textBoxRepresentante";
            this.textBoxRepresentante.Size = new System.Drawing.Size(618, 29);
            this.textBoxRepresentante.TabIndex = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(32, 184);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 16);
            label1.TabIndex = 89;
            label1.Text = "Nome Fantasia";
            // 
            // textBoxNomeFantasia
            // 
            this.textBoxNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeFantasia.Location = new System.Drawing.Point(35, 203);
            this.textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            this.textBoxNomeFantasia.Size = new System.Drawing.Size(618, 29);
            this.textBoxNomeFantasia.TabIndex = 77;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(32, 247);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(42, 16);
            label8.TabIndex = 88;
            label8.Text = "CNPJ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(32, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 16);
            label2.TabIndex = 87;
            label2.Text = "Nome / Razão Social";
            // 
            // maskedCNPJ
            // 
            this.maskedCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedCNPJ.Location = new System.Drawing.Point(35, 266);
            this.maskedCNPJ.Mask = "00.000.000/0000-00";
            this.maskedCNPJ.Name = "maskedCNPJ";
            this.maskedCNPJ.Size = new System.Drawing.Size(306, 29);
            this.maskedCNPJ.TabIndex = 78;
            // 
            // textBoxRazaoSocial
            // 
            this.textBoxRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxRazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRazaoSocial.Location = new System.Drawing.Point(35, 140);
            this.textBoxRazaoSocial.Name = "textBoxRazaoSocial";
            this.textBoxRazaoSocial.Size = new System.Drawing.Size(618, 29);
            this.textBoxRazaoSocial.TabIndex = 76;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(13, 11);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(194, 24);
            this.labelContagem.TabIndex = 86;
            this.labelContagem.Text = "Cadastrar Fornecedor";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(507, 587);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 85;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(381, 587);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 84;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // FormCadFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 648);
            this.Controls.Add(this.maskedTelefoneContato);
            this.Controls.Add(this.maskedWhatsApp);
            this.Controls.Add(this.checkBoxGerarCodigoAutomaticamente);
            this.Controls.Add(label9);
            this.Controls.Add(this.textBoxCodigoFornecedor);
            this.Controls.Add(label7);
            this.Controls.Add(this.maskedCPF);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBoxRepresentante);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxNomeFantasia);
            this.Controls.Add(label8);
            this.Controls.Add(label2);
            this.Controls.Add(this.maskedCNPJ);
            this.Controls.Add(this.textBoxRazaoSocial);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadFornecedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadFornecedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadFornecedores_FormClosing);
            this.Load += new System.EventHandler(this.FormCadFornecedores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTelefoneContato;
        private System.Windows.Forms.MaskedTextBox maskedWhatsApp;
        private System.Windows.Forms.CheckBox checkBoxGerarCodigoAutomaticamente;
        private System.Windows.Forms.TextBox textBoxCodigoFornecedor;
        private System.Windows.Forms.MaskedTextBox maskedCPF;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxRepresentante;
        private System.Windows.Forms.TextBox textBoxNomeFantasia;
        private System.Windows.Forms.MaskedTextBox maskedCNPJ;
        private System.Windows.Forms.TextBox textBoxRazaoSocial;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
    }
}