namespace High_Gestor.Forms.Produtos.ListaPreco
{
    partial class FormCadListaPreco
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label labelContagem;
            this.comboBoxSituacao = new System.Windows.Forms.ComboBox();
            this.labelNome_Razao = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            labelContagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.comboBoxSituacao.Location = new System.Drawing.Point(51, 82);
            this.comboBoxSituacao.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxSituacao.Name = "comboBoxSituacao";
            this.comboBoxSituacao.Size = new System.Drawing.Size(135, 26);
            this.comboBoxSituacao.TabIndex = 128;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(48, 63);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 16);
            label8.TabIndex = 136;
            label8.Text = "Situação *";
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
            labelContagem.TabIndex = 134;
            labelContagem.Text = "Cadastro de Clientes";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNome_Razao
            // 
            this.labelNome_Razao.AutoSize = true;
            this.labelNome_Razao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome_Razao.Location = new System.Drawing.Point(48, 125);
            this.labelNome_Razao.Name = "labelNome_Razao";
            this.labelNome_Razao.Size = new System.Drawing.Size(159, 16);
            this.labelNome_Razao.TabIndex = 133;
            this.labelNome_Razao.Text = "Descrição / nome da lista";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.BackColor = System.Drawing.Color.White;
            this.textBoxDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxDescricao.Location = new System.Drawing.Point(51, 146);
            this.textBoxDescricao.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(563, 26);
            this.textBoxDescricao.TabIndex = 131;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(607, 579);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(120, 40);
            this.btnSair.TabIndex = 138;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(481, 579);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(120, 40);
            this.buttonSalvar.TabIndex = 137;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // FormCadListaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.comboBoxSituacao);
            this.Controls.Add(label8);
            this.Controls.Add(labelContagem);
            this.Controls.Add(this.labelNome_Razao);
            this.Controls.Add(this.textBoxDescricao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadListaPreco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadListaPreco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadListaPreco_FormClosing);
            this.Load += new System.EventHandler(this.FormCadListaPreco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSituacao;
        private System.Windows.Forms.Label labelNome_Razao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
    }
}