namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.CadastrarCaixa.ItemUsuariosPermitidos
{
    partial class UserControl_ItemUsuarioPermitido
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
            this.checkBoxSelecionado = new System.Windows.Forms.CheckBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxSelecionado
            // 
            this.checkBoxSelecionado.AutoSize = true;
            this.checkBoxSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSelecionado.Location = new System.Drawing.Point(17, 10);
            this.checkBoxSelecionado.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSelecionado.Name = "checkBoxSelecionado";
            this.checkBoxSelecionado.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSelecionado.TabIndex = 0;
            this.checkBoxSelecionado.UseVisualStyleBackColor = true;
            this.checkBoxSelecionado.CheckedChanged += new System.EventHandler(this.checkBoxSelecionado_CheckedChanged);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(42, 6);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(57, 18);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "usuario";
            // 
            // UserControl_ItemUsuarioPermitido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.checkBoxSelecionado);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ItemUsuarioPermitido";
            this.Size = new System.Drawing.Size(825, 30);
            this.Load += new System.EventHandler(this.UserControl_ItemUsuarioPermitido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSelecionado;
        private System.Windows.Forms.Label labelUsuario;
    }
}
