namespace High_Gestor.Forms.Configuracoes.Transporte
{
    partial class FormCadTransporte
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.textBoxEnderecoEntrega = new System.Windows.Forms.TextBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxNomeModalidade = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label6.Location = new System.Drawing.Point(38, 275);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(158, 17);
            label6.TabIndex = 150;
            label6.Text = "Observação da entrega";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label4.Location = new System.Drawing.Point(37, 205);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(151, 17);
            label4.TabIndex = 149;
            label4.Text = "Endereço de entrega *";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(315, 66);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 16);
            label5.TabIndex = 147;
            label5.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(38, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 17);
            label1.TabIndex = 146;
            label1.Text = "Codigo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label2.Location = new System.Drawing.Point(38, 135);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(151, 17);
            label2.TabIndex = 145;
            label2.Text = "Nome da modalidade *";
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.BackColor = System.Drawing.Color.White;
            this.textBoxObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservacao.Location = new System.Drawing.Point(42, 295);
            this.textBoxObservacao.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(543, 23);
            this.textBoxObservacao.TabIndex = 3;
            // 
            // textBoxEnderecoEntrega
            // 
            this.textBoxEnderecoEntrega.BackColor = System.Drawing.Color.White;
            this.textBoxEnderecoEntrega.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxEnderecoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnderecoEntrega.Location = new System.Drawing.Point(41, 225);
            this.textBoxEnderecoEntrega.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxEnderecoEntrega.Name = "textBoxEnderecoEntrega";
            this.textBoxEnderecoEntrega.Size = new System.Drawing.Size(543, 23);
            this.textBoxEnderecoEntrega.TabIndex = 2;
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
            this.comboBoxStatus.Location = new System.Drawing.Point(318, 85);
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
            this.textBoxCodigo.Location = new System.Drawing.Point(42, 87);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(266, 23);
            this.textBoxCodigo.TabIndex = 143;
            this.textBoxCodigo.TabStop = false;
            // 
            // textBoxNomeModalidade
            // 
            this.textBoxNomeModalidade.BackColor = System.Drawing.Color.White;
            this.textBoxNomeModalidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeModalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeModalidade.Location = new System.Drawing.Point(42, 155);
            this.textBoxNomeModalidade.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeModalidade.Name = "textBoxNomeModalidade";
            this.textBoxNomeModalidade.Size = new System.Drawing.Size(543, 23);
            this.textBoxNomeModalidade.TabIndex = 1;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(23, 18);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(308, 24);
            this.labelContagem.TabIndex = 144;
            this.labelContagem.Text = "Cadastrar modalidade de transporte";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(507, 582);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(109, 37);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(392, 582);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(109, 37);
            this.buttonSalvar.TabIndex = 4;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // FormCadTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1008, 640);
            this.Controls.Add(label6);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxEnderecoEntrega);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label5);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxNomeModalidade);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadTransporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadTransporte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadTransporte_FormClosing);
            this.Load += new System.EventHandler(this.FormCadTransporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.TextBox textBoxEnderecoEntrega;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxNomeModalidade;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
    }
}