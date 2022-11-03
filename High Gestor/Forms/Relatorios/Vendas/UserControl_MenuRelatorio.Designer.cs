namespace High_Gestor.Forms.Relatorios.Vendas
{
    partial class UserControl_MenuRelatorio
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
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(40, 15);
            this.flowLayoutPanelContent.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(1115, 723);
            this.flowLayoutPanelContent.TabIndex = 1;
            // 
            // UserControl_MenuRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.flowLayoutPanelContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_MenuRelatorio";
            this.Padding = new System.Windows.Forms.Padding(40, 15, 30, 0);
            this.Size = new System.Drawing.Size(1185, 738);
            this.Load += new System.EventHandler(this.UserControl_MenuRelatorio_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl_MenuRelatorio_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
    }
}
