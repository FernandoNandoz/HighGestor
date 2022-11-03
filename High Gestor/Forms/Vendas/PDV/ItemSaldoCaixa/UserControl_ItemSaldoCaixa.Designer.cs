namespace High_Gestor.Forms.Vendas.PDV.ItemSaldoCaixa
{
    partial class UserControl_ItemSaldoCaixa
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
            this.groupBoxSaldoCaixa = new System.Windows.Forms.GroupBox();
            this.labelStatusCaixa = new System.Windows.Forms.Label();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.labelNomeCaixa = new System.Windows.Forms.Label();
            this.groupBoxSaldoCaixa.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSaldoCaixa
            // 
            this.groupBoxSaldoCaixa.AutoSize = true;
            this.groupBoxSaldoCaixa.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSaldoCaixa.Controls.Add(this.labelStatusCaixa);
            this.groupBoxSaldoCaixa.Controls.Add(this.labelSaldo);
            this.groupBoxSaldoCaixa.Controls.Add(this.labelNomeCaixa);
            this.groupBoxSaldoCaixa.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSaldoCaixa.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoCaixa.MaximumSize = new System.Drawing.Size(280, 95);
            this.groupBoxSaldoCaixa.MinimumSize = new System.Drawing.Size(250, 95);
            this.groupBoxSaldoCaixa.Name = "groupBoxSaldoCaixa";
            this.groupBoxSaldoCaixa.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxSaldoCaixa.Size = new System.Drawing.Size(250, 95);
            this.groupBoxSaldoCaixa.TabIndex = 246;
            this.groupBoxSaldoCaixa.TabStop = false;
            this.groupBoxSaldoCaixa.Enter += new System.EventHandler(this.groupBoxSaldoCaixa_Enter);
            // 
            // labelStatusCaixa
            // 
            this.labelStatusCaixa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatusCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelStatusCaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelStatusCaixa.Location = new System.Drawing.Point(24, 67);
            this.labelStatusCaixa.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatusCaixa.Name = "labelStatusCaixa";
            this.labelStatusCaixa.Size = new System.Drawing.Size(203, 20);
            this.labelStatusCaixa.TabIndex = 22;
            this.labelStatusCaixa.Text = "FECHADO";
            this.labelStatusCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSaldo
            // 
            this.labelSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelSaldo.Location = new System.Drawing.Point(24, 41);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(203, 20);
            this.labelSaldo.TabIndex = 21;
            this.labelSaldo.Text = "R$ 0,00";
            this.labelSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNomeCaixa
            // 
            this.labelNomeCaixa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomeCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNomeCaixa.ForeColor = System.Drawing.Color.DimGray;
            this.labelNomeCaixa.Location = new System.Drawing.Point(24, 13);
            this.labelNomeCaixa.Name = "labelNomeCaixa";
            this.labelNomeCaixa.Size = new System.Drawing.Size(203, 22);
            this.labelNomeCaixa.TabIndex = 20;
            this.labelNomeCaixa.Text = "Caixa padrão";
            this.labelNomeCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl_ItemSaldoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.groupBoxSaldoCaixa);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Name = "UserControl_ItemSaldoCaixa";
            this.Size = new System.Drawing.Size(250, 95);
            this.Load += new System.EventHandler(this.UserControl_ItemSaldoCaixa_Load);
            this.groupBoxSaldoCaixa.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSaldoCaixa;
        private System.Windows.Forms.Label labelStatusCaixa;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Label labelNomeCaixa;
    }
}
