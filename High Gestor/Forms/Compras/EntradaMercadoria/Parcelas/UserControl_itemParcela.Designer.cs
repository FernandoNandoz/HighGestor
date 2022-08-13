namespace High_Gestor.Forms.Compras.EntradaMercadoria.Parcelas
{
    partial class UserControl_itemParcela
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
            this.comboBoxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.dateTimeVencimento = new System.Windows.Forms.DateTimePicker();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(358, 5);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(197, 24);
            this.comboBoxFormaPagamento.TabIndex = 8;
            // 
            // textBoxValor
            // 
            this.textBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.Location = new System.Drawing.Point(195, 6);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(152, 23);
            this.textBoxValor.TabIndex = 7;
            // 
            // dateTimeVencimento
            // 
            this.dateTimeVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeVencimento.Location = new System.Drawing.Point(46, 6);
            this.dateTimeVencimento.Name = "dateTimeVencimento";
            this.dateTimeVencimento.Size = new System.Drawing.Size(139, 23);
            this.dateTimeVencimento.TabIndex = 6;
            // 
            // labelNumero
            // 
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(2, 5);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(27, 24);
            this.labelNumero.TabIndex = 5;
            this.labelNumero.Text = "0";
            this.labelNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservacao.Location = new System.Drawing.Point(566, 6);
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(313, 23);
            this.textBoxObservacao.TabIndex = 9;
            // 
            // UserControl_itemParcela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.comboBoxFormaPagamento);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.dateTimeVencimento);
            this.Controls.Add(this.labelNumero);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Name = "UserControl_itemParcela";
            this.Size = new System.Drawing.Size(1085, 35);
            this.Load += new System.EventHandler(this.UserControl_itemParcela_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        public System.Windows.Forms.TextBox textBoxValor;
        public System.Windows.Forms.DateTimePicker dateTimeVencimento;
        public System.Windows.Forms.TextBox textBoxObservacao;
        public System.Windows.Forms.Label labelNumero;
    }
}
