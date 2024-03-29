﻿namespace High_Gestor.Forms.Financeiro.Parametros.CentroCustos
{
    partial class FormCadCustos
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            this.checkBoxGerarCodigoAutomaticamente = new System.Windows.Forms.CheckBox();
            this.textBoxCodigoCusto = new System.Windows.Forms.TextBox();
            this.textBoxNomeCusto = new System.Windows.Forms.TextBox();
            this.labelContagem = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(27, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 17);
            label1.TabIndex = 57;
            label1.Text = "Codigo da Custo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label2.Location = new System.Drawing.Point(27, 131);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 17);
            label2.TabIndex = 56;
            label2.Text = "Nome da Custo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(27, 203);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 16);
            label5.TabIndex = 116;
            label5.Text = "Status";
            // 
            // checkBoxGerarCodigoAutomaticamente
            // 
            this.checkBoxGerarCodigoAutomaticamente.AutoSize = true;
            this.checkBoxGerarCodigoAutomaticamente.Checked = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGerarCodigoAutomaticamente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGerarCodigoAutomaticamente.Location = new System.Drawing.Point(323, 82);
            this.checkBoxGerarCodigoAutomaticamente.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxGerarCodigoAutomaticamente.Name = "checkBoxGerarCodigoAutomaticamente";
            this.checkBoxGerarCodigoAutomaticamente.Size = new System.Drawing.Size(248, 24);
            this.checkBoxGerarCodigoAutomaticamente.TabIndex = 58;
            this.checkBoxGerarCodigoAutomaticamente.TabStop = false;
            this.checkBoxGerarCodigoAutomaticamente.Text = "Gerar codigo automaticamente";
            this.checkBoxGerarCodigoAutomaticamente.UseVisualStyleBackColor = true;
            this.checkBoxGerarCodigoAutomaticamente.CheckedChanged += new System.EventHandler(this.checkBoxGerarCodigoAutomaticamente_CheckedChanged);
            // 
            // textBoxCodigoCusto
            // 
            this.textBoxCodigoCusto.BackColor = System.Drawing.Color.White;
            this.textBoxCodigoCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigoCusto.Enabled = false;
            this.textBoxCodigoCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCodigoCusto.Location = new System.Drawing.Point(31, 83);
            this.textBoxCodigoCusto.Name = "textBoxCodigoCusto";
            this.textBoxCodigoCusto.Size = new System.Drawing.Size(266, 23);
            this.textBoxCodigoCusto.TabIndex = 0;
            // 
            // textBoxNomeCusto
            // 
            this.textBoxNomeCusto.BackColor = System.Drawing.Color.White;
            this.textBoxNomeCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeCusto.Location = new System.Drawing.Point(31, 151);
            this.textBoxNomeCusto.Name = "textBoxNomeCusto";
            this.textBoxNomeCusto.Size = new System.Drawing.Size(591, 23);
            this.textBoxNomeCusto.TabIndex = 1;
            // 
            // labelContagem
            // 
            this.labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContagem.AutoSize = true;
            this.labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelContagem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelContagem.Location = new System.Drawing.Point(12, 14);
            this.labelContagem.Name = "labelContagem";
            this.labelContagem.Size = new System.Drawing.Size(142, 24);
            this.labelContagem.TabIndex = 55;
            this.labelContagem.Text = "Cadastrar Custo";
            this.labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(491, 578);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(109, 37);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSalvar.BackColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(376, 578);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(109, 37);
            this.buttonSalvar.TabIndex = 3;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonSalvar_KeyUp);
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
            this.comboBoxStatus.Location = new System.Drawing.Point(30, 222);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(592, 26);
            this.comboBoxStatus.TabIndex = 2;
            // 
            // FormCadCustos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(977, 640);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(label5);
            this.Controls.Add(this.checkBoxGerarCodigoAutomaticamente);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxCodigoCusto);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxNomeCusto);
            this.Controls.Add(this.labelContagem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.buttonSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCadCustos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCadCustos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCadCustos_FormClosing);
            this.Load += new System.EventHandler(this.FormCadCustos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxGerarCodigoAutomaticamente;
        private System.Windows.Forms.TextBox textBoxCodigoCusto;
        private System.Windows.Forms.TextBox textBoxNomeCusto;
        private System.Windows.Forms.Label labelContagem;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxStatus;
    }
}