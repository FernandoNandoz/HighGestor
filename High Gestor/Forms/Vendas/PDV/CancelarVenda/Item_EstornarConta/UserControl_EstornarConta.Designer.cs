namespace High_Gestor.Forms.Vendas.PDV.CancelarVenda.Item_EstornarConta
{
    partial class UserControl_EstornarConta
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
            System.Windows.Forms.Label label1;
            this.comboBoxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.comboBoxContaBancaria = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(64, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(143, 17);
            label1.TabIndex = 17;
            label1.Text = "Forma de pagamento";
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.DropDownWidth = 300;
            this.comboBoxFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(64, 67);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(220, 28);
            this.comboBoxFormaPagamento.TabIndex = 16;
            // 
            // comboBoxContaBancaria
            // 
            this.comboBoxContaBancaria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContaBancaria.DropDownWidth = 240;
            this.comboBoxContaBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContaBancaria.FormattingEnabled = true;
            this.comboBoxContaBancaria.Location = new System.Drawing.Point(64, 5);
            this.comboBoxContaBancaria.Name = "comboBoxContaBancaria";
            this.comboBoxContaBancaria.Size = new System.Drawing.Size(220, 28);
            this.comboBoxContaBancaria.TabIndex = 15;
            // 
            // UserControl_EstornarConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxFormaPagamento);
            this.Controls.Add(this.comboBoxContaBancaria);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_EstornarConta";
            this.Size = new System.Drawing.Size(374, 113);
            this.Load += new System.EventHandler(this.UserControl_EstornarConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        public System.Windows.Forms.ComboBox comboBoxContaBancaria;
    }
}
