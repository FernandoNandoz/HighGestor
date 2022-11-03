namespace High_Gestor.Forms.Compras.ContasLancadas.ItemContaLancada
{
    partial class UserControl_ItemConta
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
            this.labelValueStatus = new System.Windows.Forms.Label();
            this.labelValueValor = new System.Windows.Forms.Label();
            this.labelValueData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelValueStatus
            // 
            this.labelValueStatus.AutoSize = true;
            this.labelValueStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueStatus.Location = new System.Drawing.Point(286, 7);
            this.labelValueStatus.Name = "labelValueStatus";
            this.labelValueStatus.Size = new System.Drawing.Size(113, 16);
            this.labelValueStatus.TabIndex = 5;
            this.labelValueStatus.Text = "1.1 / EM ABERTO";
            // 
            // labelValueValor
            // 
            this.labelValueValor.AutoSize = true;
            this.labelValueValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueValor.Location = new System.Drawing.Point(150, 7);
            this.labelValueValor.Name = "labelValueValor";
            this.labelValueValor.Size = new System.Drawing.Size(51, 16);
            this.labelValueValor.TabIndex = 4;
            this.labelValueValor.Text = "R$ 0,00";
            // 
            // labelValueData
            // 
            this.labelValueData.AutoSize = true;
            this.labelValueData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueData.Location = new System.Drawing.Point(16, 7);
            this.labelValueData.Name = "labelValueData";
            this.labelValueData.Size = new System.Drawing.Size(71, 16);
            this.labelValueData.TabIndex = 3;
            this.labelValueData.Text = "00/00/0000";
            // 
            // UserControl_ItemConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelValueStatus);
            this.Controls.Add(this.labelValueValor);
            this.Controls.Add(this.labelValueData);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ItemConta";
            this.Size = new System.Drawing.Size(420, 30);
            this.Load += new System.EventHandler(this.UserControl_ItemConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelValueStatus;
        public System.Windows.Forms.Label labelValueValor;
        public System.Windows.Forms.Label labelValueData;
    }
}
