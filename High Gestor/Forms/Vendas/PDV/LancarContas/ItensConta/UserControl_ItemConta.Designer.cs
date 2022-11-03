namespace High_Gestor.Forms.Vendas.PDV.LancarContas.ItensConta
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
            this.maskedDataPagamento = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxPago = new System.Windows.Forms.CheckBox();
            this.labelFormaPagamento = new System.Windows.Forms.Label();
            this.labelValueValor = new System.Windows.Forms.Label();
            this.labelValueData = new System.Windows.Forms.Label();
            this.comboBoxContaBancaria = new System.Windows.Forms.ComboBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maskedDataPagamento
            // 
            this.maskedDataPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedDataPagamento.Location = new System.Drawing.Point(670, 6);
            this.maskedDataPagamento.Name = "maskedDataPagamento";
            this.maskedDataPagamento.Size = new System.Drawing.Size(100, 23);
            this.maskedDataPagamento.TabIndex = 31;
            // 
            // checkBoxPago
            // 
            this.checkBoxPago.AutoSize = true;
            this.checkBoxPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPago.Location = new System.Drawing.Point(618, 11);
            this.checkBoxPago.Name = "checkBoxPago";
            this.checkBoxPago.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPago.TabIndex = 30;
            this.checkBoxPago.UseVisualStyleBackColor = true;
            this.checkBoxPago.CheckedChanged += new System.EventHandler(this.checkBoxPago_CheckedChanged);
            // 
            // labelFormaPagamento
            // 
            this.labelFormaPagamento.AutoSize = true;
            this.labelFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormaPagamento.Location = new System.Drawing.Point(237, 8);
            this.labelFormaPagamento.Name = "labelFormaPagamento";
            this.labelFormaPagamento.Size = new System.Drawing.Size(126, 18);
            this.labelFormaPagamento.TabIndex = 29;
            this.labelFormaPagamento.Text = "Form. pagamento";
            this.labelFormaPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelValueValor
            // 
            this.labelValueValor.AutoSize = true;
            this.labelValueValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueValor.Location = new System.Drawing.Point(130, 8);
            this.labelValueValor.Name = "labelValueValor";
            this.labelValueValor.Size = new System.Drawing.Size(59, 18);
            this.labelValueValor.TabIndex = 28;
            this.labelValueValor.Text = "R$ 0,00";
            this.labelValueValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelValueData
            // 
            this.labelValueData.AutoSize = true;
            this.labelValueData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueData.Location = new System.Drawing.Point(30, 8);
            this.labelValueData.Name = "labelValueData";
            this.labelValueData.Size = new System.Drawing.Size(80, 18);
            this.labelValueData.TabIndex = 27;
            this.labelValueData.Text = "00/00/0000";
            this.labelValueData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxContaBancaria
            // 
            this.comboBoxContaBancaria.BackColor = System.Drawing.Color.White;
            this.comboBoxContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContaBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxContaBancaria.FormattingEnabled = true;
            this.comboBoxContaBancaria.Location = new System.Drawing.Point(402, 5);
            this.comboBoxContaBancaria.Name = "comboBoxContaBancaria";
            this.comboBoxContaBancaria.Size = new System.Drawing.Size(176, 24);
            this.comboBoxContaBancaria.TabIndex = 26;
            // 
            // labelNumero
            // 
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(-3, 5);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(27, 24);
            this.labelNumero.TabIndex = 25;
            this.labelNumero.Text = "0";
            this.labelNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl_ItemConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.maskedDataPagamento);
            this.Controls.Add(this.checkBoxPago);
            this.Controls.Add(this.labelFormaPagamento);
            this.Controls.Add(this.labelValueValor);
            this.Controls.Add(this.labelValueData);
            this.Controls.Add(this.comboBoxContaBancaria);
            this.Controls.Add(this.labelNumero);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ItemConta";
            this.Size = new System.Drawing.Size(785, 35);
            this.Load += new System.EventHandler(this.UserControl_ItemConta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox maskedDataPagamento;
        public System.Windows.Forms.CheckBox checkBoxPago;
        public System.Windows.Forms.Label labelFormaPagamento;
        public System.Windows.Forms.Label labelValueValor;
        public System.Windows.Forms.Label labelValueData;
        public System.Windows.Forms.ComboBox comboBoxContaBancaria;
        public System.Windows.Forms.Label labelNumero;
    }
}
