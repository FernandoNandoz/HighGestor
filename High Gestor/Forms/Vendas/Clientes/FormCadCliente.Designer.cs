namespace High_Gestor.Forms.Vendas.Clientes
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelContagem;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label2;
            this.labelNumeroCPF_CNPJ = new System.Windows.Forms.Label();
            this.labelNome_Razao = new System.Windows.Forms.Label();
            this.maskedCPF_CNPJ = new System.Windows.Forms.MaskedTextBox();
            this.maskedTelefoneContato = new System.Windows.Forms.MaskedTextBox();
            this.maskedWhatsApp = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.textBoxComplemento = new System.Windows.Forms.TextBox();
            this.textBoxNome_Razao = new System.Windows.Forms.TextBox();
            this.textBoxNomeResponsavel = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxSituacao = new System.Windows.Forms.ComboBox();
            this.comboBoxTipoPessoa = new System.Windows.Forms.ComboBox();
            this.textBoxCodigoCliente = new System.Windows.Forms.TextBox();
            this.checkBoxGerarCodigoAutomaticamente = new System.Windows.Forms.CheckBox();
            this.maskedDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNomeFantasia = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.textBoxCarteiraProdutorRural = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelContagem = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(193, 309);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(123, 16);
            label10.TabIndex = 89;
            label10.Text = "Telefone p/ contato";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(48, 309);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(69, 16);
            label9.TabIndex = 88;
            label9.Text = "Whatsapp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(621, 115);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(135, 16);
            label3.TabIndex = 87;
            label3.Text = "Data de nascimento *";
            // 
            // labelContagem
            // 
            labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelContagem.AutoSize = true;
            labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            labelContagem.Location = new System.Drawing.Point(29, 14);
            labelContagem.Name = "labelContagem";
            labelContagem.Size = new System.Drawing.Size(183, 24);
            labelContagem.TabIndex = 86;
            labelContagem.Text = "Cadastro de Clientes";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(48, 441);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(91, 16);
            label7.TabIndex = 84;
            label7.Text = "Complemento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(48, 378);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(164, 16);
            label6.TabIndex = 83;
            label6.Text = "Endereço - Rua, Nº, Bairro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(409, 176);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(313, 16);
            label1.TabIndex = 80;
            label1.Text = "Nome do responsavel  (caso seja pessoa Juridica)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(48, 53);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 16);
            label8.TabIndex = 92;
            label8.Text = "Situação *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(193, 53);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 16);
            label4.TabIndex = 94;
            label4.Text = "Tipo de pessoa *";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(338, 53);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(112, 16);
            label11.TabIndex = 96;
            label11.Text = "Codigo do cliente";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(48, 176);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(274, 16);
            label13.TabIndex = 131;
            label13.Text = "Nome fantasia  (caso seja pessoa Juridica) *";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.Location = new System.Drawing.Point(338, 309);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(41, 16);
            label14.TabIndex = 133;
            label14.Text = "Email";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label15.Location = new System.Drawing.Point(48, 502);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(82, 16);
            label15.TabIndex = 135;
            label15.Text = "Observação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(409, 245);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(162, 16);
            label2.TabIndex = 137;
            label2.Text = "Carteira do Produtor Rural";
            // 
            // labelNumeroCPF_CNPJ
            // 
            this.labelNumeroCPF_CNPJ.AutoSize = true;
            this.labelNumeroCPF_CNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroCPF_CNPJ.Location = new System.Drawing.Point(48, 245);
            this.labelNumeroCPF_CNPJ.Name = "labelNumeroCPF_CNPJ";
            this.labelNumeroCPF_CNPJ.Size = new System.Drawing.Size(126, 16);
            this.labelNumeroCPF_CNPJ.TabIndex = 90;
            this.labelNumeroCPF_CNPJ.Text = "Nº de CPF ou CNPJ";
            // 
            // labelNome_Razao
            // 
            this.labelNome_Razao.AutoSize = true;
            this.labelNome_Razao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome_Razao.Location = new System.Drawing.Point(48, 115);
            this.labelNome_Razao.Name = "labelNome_Razao";
            this.labelNome_Razao.Size = new System.Drawing.Size(215, 16);
            this.labelNome_Razao.TabIndex = 81;
            this.labelNome_Razao.Text = "Nome do cliente ou Razão Social *";
            // 
            // maskedCPF_CNPJ
            // 
            this.maskedCPF_CNPJ.BackColor = System.Drawing.Color.White;
            this.maskedCPF_CNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedCPF_CNPJ.Location = new System.Drawing.Point(51, 264);
            this.maskedCPF_CNPJ.Margin = new System.Windows.Forms.Padding(5);
            this.maskedCPF_CNPJ.Name = "maskedCPF_CNPJ";
            this.maskedCPF_CNPJ.Size = new System.Drawing.Size(351, 26);
            this.maskedCPF_CNPJ.TabIndex = 7;
            // 
            // maskedTelefoneContato
            // 
            this.maskedTelefoneContato.BackColor = System.Drawing.Color.White;
            this.maskedTelefoneContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTelefoneContato.Location = new System.Drawing.Point(196, 328);
            this.maskedTelefoneContato.Margin = new System.Windows.Forms.Padding(5);
            this.maskedTelefoneContato.Mask = "(00) 0 0000-0000";
            this.maskedTelefoneContato.Name = "maskedTelefoneContato";
            this.maskedTelefoneContato.Size = new System.Drawing.Size(135, 26);
            this.maskedTelefoneContato.TabIndex = 10;
            // 
            // maskedWhatsApp
            // 
            this.maskedWhatsApp.BackColor = System.Drawing.Color.White;
            this.maskedWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedWhatsApp.Location = new System.Drawing.Point(51, 328);
            this.maskedWhatsApp.Margin = new System.Windows.Forms.Padding(5);
            this.maskedWhatsApp.Mask = "(00) 0 0000-0000";
            this.maskedWhatsApp.Name = "maskedWhatsApp";
            this.maskedWhatsApp.Size = new System.Drawing.Size(135, 26);
            this.maskedWhatsApp.TabIndex = 9;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.BackColor = System.Drawing.Color.White;
            this.textBoxEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEndereco.Location = new System.Drawing.Point(51, 397);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(697, 26);
            this.textBoxEndereco.TabIndex = 12;
            // 
            // textBoxComplemento
            // 
            this.textBoxComplemento.BackColor = System.Drawing.Color.White;
            this.textBoxComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxComplemento.Location = new System.Drawing.Point(51, 460);
            this.textBoxComplemento.Name = "textBoxComplemento";
            this.textBoxComplemento.Size = new System.Drawing.Size(697, 26);
            this.textBoxComplemento.TabIndex = 13;
            // 
            // textBoxNome_Razao
            // 
            this.textBoxNome_Razao.BackColor = System.Drawing.Color.White;
            this.textBoxNome_Razao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNome_Razao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNome_Razao.Location = new System.Drawing.Point(51, 134);
            this.textBoxNome_Razao.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxNome_Razao.Name = "textBoxNome_Razao";
            this.textBoxNome_Razao.Size = new System.Drawing.Size(563, 26);
            this.textBoxNome_Razao.TabIndex = 3;
            // 
            // textBoxNomeResponsavel
            // 
            this.textBoxNomeResponsavel.BackColor = System.Drawing.Color.White;
            this.textBoxNomeResponsavel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeResponsavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNomeResponsavel.Location = new System.Drawing.Point(412, 195);
            this.textBoxNomeResponsavel.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeResponsavel.Name = "textBoxNomeResponsavel";
            this.textBoxNomeResponsavel.Size = new System.Drawing.Size(336, 26);
            this.textBoxNomeResponsavel.TabIndex = 6;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(607, 580);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(481, 580);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 15;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
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
            this.comboBoxSituacao.Location = new System.Drawing.Point(51, 72);
            this.comboBoxSituacao.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSituacao.Name = "comboBoxSituacao";
            this.comboBoxSituacao.Size = new System.Drawing.Size(135, 26);
            this.comboBoxSituacao.TabIndex = 0;
            // 
            // comboBoxTipoPessoa
            // 
            this.comboBoxTipoPessoa.BackColor = System.Drawing.Color.White;
            this.comboBoxTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxTipoPessoa.FormattingEnabled = true;
            this.comboBoxTipoPessoa.Items.AddRange(new object[] {
            "FISICA",
            "JURIDICA"});
            this.comboBoxTipoPessoa.Location = new System.Drawing.Point(196, 72);
            this.comboBoxTipoPessoa.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxTipoPessoa.Name = "comboBoxTipoPessoa";
            this.comboBoxTipoPessoa.Size = new System.Drawing.Size(135, 26);
            this.comboBoxTipoPessoa.TabIndex = 1;
            this.comboBoxTipoPessoa.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoPessoa_SelectedIndexChanged);
            // 
            // textBoxCodigoCliente
            // 
            this.textBoxCodigoCliente.BackColor = System.Drawing.Color.White;
            this.textBoxCodigoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCodigoCliente.Location = new System.Drawing.Point(341, 72);
            this.textBoxCodigoCliente.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxCodigoCliente.Name = "textBoxCodigoCliente";
            this.textBoxCodigoCliente.Size = new System.Drawing.Size(142, 26);
            this.textBoxCodigoCliente.TabIndex = 2;
            // 
            // checkBoxGerarCodigoAutomaticamente
            // 
            this.checkBoxGerarCodigoAutomaticamente.AutoSize = true;
            this.checkBoxGerarCodigoAutomaticamente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGerarCodigoAutomaticamente.Location = new System.Drawing.Point(500, 73);
            this.checkBoxGerarCodigoAutomaticamente.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGerarCodigoAutomaticamente.Name = "checkBoxGerarCodigoAutomaticamente";
            this.checkBoxGerarCodigoAutomaticamente.Size = new System.Drawing.Size(248, 24);
            this.checkBoxGerarCodigoAutomaticamente.TabIndex = 127;
            this.checkBoxGerarCodigoAutomaticamente.TabStop = false;
            this.checkBoxGerarCodigoAutomaticamente.Text = "Gerar codigo automaticamente";
            this.checkBoxGerarCodigoAutomaticamente.UseVisualStyleBackColor = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckedChanged += new System.EventHandler(this.checkBoxGerarCodigoAutomaticamente_CheckedChanged);
            // 
            // maskedDataNascimento
            // 
            this.maskedDataNascimento.BackColor = System.Drawing.Color.White;
            this.maskedDataNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedDataNascimento.Location = new System.Drawing.Point(624, 134);
            this.maskedDataNascimento.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.maskedDataNascimento.Mask = "00/00/0000";
            this.maskedDataNascimento.Name = "maskedDataNascimento";
            this.maskedDataNascimento.Size = new System.Drawing.Size(124, 26);
            this.maskedDataNascimento.TabIndex = 4;
            // 
            // textBoxNomeFantasia
            // 
            this.textBoxNomeFantasia.BackColor = System.Drawing.Color.White;
            this.textBoxNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNomeFantasia.Location = new System.Drawing.Point(51, 195);
            this.textBoxNomeFantasia.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeFantasia.Name = "textBoxNomeFantasia";
            this.textBoxNomeFantasia.Size = new System.Drawing.Size(351, 26);
            this.textBoxNomeFantasia.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEmail.Location = new System.Drawing.Point(341, 328);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(407, 26);
            this.textBoxEmail.TabIndex = 11;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.BackColor = System.Drawing.Color.White;
            this.textBoxObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxObservacao.Location = new System.Drawing.Point(51, 521);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(697, 26);
            this.textBoxObservacao.TabIndex = 14;
            // 
            // textBoxCarteiraProdutorRural
            // 
            this.textBoxCarteiraProdutorRural.BackColor = System.Drawing.Color.White;
            this.textBoxCarteiraProdutorRural.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCarteiraProdutorRural.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCarteiraProdutorRural.Location = new System.Drawing.Point(412, 264);
            this.textBoxCarteiraProdutorRural.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxCarteiraProdutorRural.Name = "textBoxCarteiraProdutorRural";
            this.textBoxCarteiraProdutorRural.Size = new System.Drawing.Size(336, 26);
            this.textBoxCarteiraProdutorRural.TabIndex = 8;
            // 
            // FormCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxCarteiraProdutorRural);
            this.Controls.Add(label15);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(label14);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(label13);
            this.Controls.Add(this.textBoxNomeFantasia);
            this.Controls.Add(this.maskedDataNascimento);
            this.Controls.Add(this.checkBoxGerarCodigoAutomaticamente);
            this.Controls.Add(label11);
            this.Controls.Add(this.textBoxCodigoCliente);
            this.Controls.Add(this.comboBoxTipoPessoa);
            this.Controls.Add(label4);
            this.Controls.Add(this.comboBoxSituacao);
            this.Controls.Add(label8);
            this.Controls.Add(this.labelNumeroCPF_CNPJ);
            this.Controls.Add(this.maskedCPF_CNPJ);
            this.Controls.Add(this.maskedTelefoneContato);
            this.Controls.Add(this.maskedWhatsApp);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label3);
            this.Controls.Add(labelContagem);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.labelNome_Razao);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxComplemento);
            this.Controls.Add(this.textBoxNome_Razao);
            this.Controls.Add(this.textBoxNomeResponsavel);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadCliente_FormClosing);
            this.Load += new System.EventHandler(this.FormCadCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedCPF_CNPJ;
        private System.Windows.Forms.MaskedTextBox maskedTelefoneContato;
        private System.Windows.Forms.MaskedTextBox maskedWhatsApp;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.TextBox textBoxComplemento;
        private System.Windows.Forms.TextBox textBoxNome_Razao;
        private System.Windows.Forms.TextBox textBoxNomeResponsavel;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxSituacao;
        private System.Windows.Forms.ComboBox comboBoxTipoPessoa;
        private System.Windows.Forms.TextBox textBoxCodigoCliente;
        private System.Windows.Forms.CheckBox checkBoxGerarCodigoAutomaticamente;
        private System.Windows.Forms.MaskedTextBox maskedDataNascimento;
        private System.Windows.Forms.TextBox textBoxNomeFantasia;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.Label labelNome_Razao;
        private System.Windows.Forms.Label labelNumeroCPF_CNPJ;
        private System.Windows.Forms.TextBox textBoxCarteiraProdutorRural;
    }
}