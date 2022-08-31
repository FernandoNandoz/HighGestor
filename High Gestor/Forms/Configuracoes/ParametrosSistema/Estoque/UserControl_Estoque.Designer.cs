namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.Estoque
{
    partial class UserControl_Estoque
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            this.comboBoxBloquearVendas = new System.Windows.Forms.ComboBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label2.Location = new System.Drawing.Point(18, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 20);
            label2.TabIndex = 158;
            label2.Text = "Estoque";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(21, 96);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(267, 15);
            label6.TabIndex = 223;
            label6.Text = "Bloquear venda caso o estoque esteja negativo.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label5.Location = new System.Drawing.Point(19, 74);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(114, 18);
            label5.TabIndex = 225;
            label5.Text = "Bloquear venda ";
            // 
            // comboBoxBloquearVendas
            // 
            this.comboBoxBloquearVendas.BackColor = System.Drawing.Color.White;
            this.comboBoxBloquearVendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBloquearVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBloquearVendas.FormattingEnabled = true;
            this.comboBoxBloquearVendas.Items.AddRange(new object[] {
            "SIM",
            "NAO"});
            this.comboBoxBloquearVendas.Location = new System.Drawing.Point(25, 123);
            this.comboBoxBloquearVendas.Name = "comboBoxBloquearVendas";
            this.comboBoxBloquearVendas.Size = new System.Drawing.Size(299, 26);
            this.comboBoxBloquearVendas.TabIndex = 224;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(37, 529);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(213, 32);
            this.buttonSalvar.TabIndex = 227;
            this.buttonSalvar.Text = "Salvar configurações";
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // UserControl_Estoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.comboBoxBloquearVendas);
            this.Controls.Add(label5);
            this.Controls.Add(label6);
            this.Controls.Add(label2);
            this.Name = "UserControl_Estoque";
            this.Size = new System.Drawing.Size(783, 596);
            this.Load += new System.EventHandler(this.UserControl_Estoque_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxBloquearVendas;
        private System.Windows.Forms.Button buttonSalvar;
    }
}
