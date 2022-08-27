namespace High_Gestor.Forms.Financeiro.Parametros.CategoriaContas
{
    partial class FormCadCategoriaContas
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            this.comboBoxTipoCategoria = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxNomeCategoria = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxGrupoFinanceiro = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxTipoCategoria
            // 
            this.comboBoxTipoCategoria.BackColor = System.Drawing.Color.White;
            this.comboBoxTipoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxTipoCategoria.FormattingEnabled = true;
            this.comboBoxTipoCategoria.Items.AddRange(new object[] {
            "RECEITAS",
            "DESPESAS"});
            this.comboBoxTipoCategoria.Location = new System.Drawing.Point(31, 224);
            this.comboBoxTipoCategoria.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxTipoCategoria.Name = "comboBoxTipoCategoria";
            this.comboBoxTipoCategoria.Size = new System.Drawing.Size(268, 26);
            this.comboBoxTipoCategoria.TabIndex = 2;
            this.comboBoxTipoCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoCategoria_SelectedIndexChanged);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(27, 205);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(114, 16);
            label3.TabIndex = 145;
            label3.Text = "Tipo de categoria";
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
            this.comboBoxStatus.Location = new System.Drawing.Point(307, 85);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(266, 26);
            this.comboBoxStatus.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(304, 66);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 16);
            label5.TabIndex = 143;
            label5.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(27, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 17);
            label1.TabIndex = 141;
            label1.Text = "Codigo";
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigo.Enabled = false;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCodigo.Location = new System.Drawing.Point(31, 87);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(266, 23);
            this.textBoxCodigo.TabIndex = 135;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label2.Location = new System.Drawing.Point(27, 135);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(137, 17);
            label2.TabIndex = 140;
            label2.Text = "Nome da categoria *";
            // 
            // textBoxNomeCategoria
            // 
            this.textBoxNomeCategoria.BackColor = System.Drawing.Color.White;
            this.textBoxNomeCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeCategoria.Location = new System.Drawing.Point(31, 155);
            this.textBoxNomeCategoria.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNomeCategoria.Name = "textBoxNomeCategoria";
            this.textBoxNomeCategoria.Size = new System.Drawing.Size(545, 23);
            this.textBoxNomeCategoria.TabIndex = 1;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(12, 18);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(260, 24);
            this.labelContagem.TabIndex = 139;
            this.labelContagem.Text = "Cadastrar Categoria financeira";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(506, 582);
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
            this.buttonSalvar.Location = new System.Drawing.Point(391, 582);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(109, 37);
            this.buttonSalvar.TabIndex = 4;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
            // 
            // comboBoxGrupoFinanceiro
            // 
            this.comboBoxGrupoFinanceiro.BackColor = System.Drawing.Color.White;
            this.comboBoxGrupoFinanceiro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxGrupoFinanceiro.FormattingEnabled = true;
            this.comboBoxGrupoFinanceiro.Location = new System.Drawing.Point(309, 224);
            this.comboBoxGrupoFinanceiro.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxGrupoFinanceiro.Name = "comboBoxGrupoFinanceiro";
            this.comboBoxGrupoFinanceiro.Size = new System.Drawing.Size(267, 26);
            this.comboBoxGrupoFinanceiro.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(304, 205);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(113, 16);
            label4.TabIndex = 147;
            label4.Text = "Grupo financeiro *";
            // 
            // FormCadCategoriaContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(977, 640);
            this.Controls.Add(this.comboBoxGrupoFinanceiro);
            this.Controls.Add(label4);
            this.Controls.Add(this.comboBoxTipoCategoria);
            this.Controls.Add(label3);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label5);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxNomeCategoria);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadCategoriaContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadCategoriaContas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadCategoriaContas_FormClosing);
            this.Load += new System.EventHandler(this.FormCadCategoriaContas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTipoCategoria;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.TextBox textBoxNomeCategoria;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxGrupoFinanceiro;
    }
}