namespace High_Gestor.Forms.Vendas.PDV.CancelarVenda.Item_EstornarCaixa
{
    partial class UserControl_EstornarCaixa
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
            this.comboBoxCaixa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCaixa
            // 
            this.comboBoxCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaixa.DropDownWidth = 240;
            this.comboBoxCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCaixa.FormattingEnabled = true;
            this.comboBoxCaixa.Location = new System.Drawing.Point(64, 5);
            this.comboBoxCaixa.Name = "comboBoxCaixa";
            this.comboBoxCaixa.Size = new System.Drawing.Size(220, 28);
            this.comboBoxCaixa.TabIndex = 13;
            // 
            // UserControl_EstornarCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.comboBoxCaixa);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_EstornarCaixa";
            this.Size = new System.Drawing.Size(374, 44);
            this.Load += new System.EventHandler(this.UserControl_EstornarCaixa_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox comboBoxCaixa;
    }
}
