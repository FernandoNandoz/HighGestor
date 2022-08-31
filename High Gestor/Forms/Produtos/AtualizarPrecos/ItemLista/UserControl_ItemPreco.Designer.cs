namespace High_Gestor.Forms.Produtos.AtualizarPrecos.ItemLista
{
    partial class UserControl_ItemPreco
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
            this.labelNomeValue = new System.Windows.Forms.Label();
            this.textBoxValorLista = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNomeValue
            // 
            this.labelNomeValue.AutoSize = true;
            this.labelNomeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelNomeValue.Location = new System.Drawing.Point(7, 5);
            this.labelNomeValue.Name = "labelNomeValue";
            this.labelNomeValue.Size = new System.Drawing.Size(62, 15);
            this.labelNomeValue.TabIndex = 0;
            this.labelNomeValue.Text = "Descricao";
            // 
            // textBoxValorLista
            // 
            this.textBoxValorLista.Location = new System.Drawing.Point(175, 5);
            this.textBoxValorLista.Name = "textBoxValorLista";
            this.textBoxValorLista.Size = new System.Drawing.Size(77, 20);
            this.textBoxValorLista.TabIndex = 1;
            this.textBoxValorLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxValorLista_KeyDown);
            this.textBoxValorLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorLista_KeyPress);
            // 
            // UserControl_ItemPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.textBoxValorLista);
            this.Controls.Add(this.labelNomeValue);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ItemPreco";
            this.Size = new System.Drawing.Size(265, 26);
            this.Load += new System.EventHandler(this.UserControl_ItemPreco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNomeValue;
        public System.Windows.Forms.TextBox textBoxValorLista;
    }
}
