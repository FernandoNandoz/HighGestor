namespace High_Gestor.Forms.Financeiro.ContasReceber.NovoRecebimento.Parcelado
{
    partial class UserControl_ItemParcela
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
            this.SuspendLayout();
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.BackColor = System.Drawing.Color.White;
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(357, 5);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(197, 24);
            this.comboBoxFormaPagamento.TabIndex = 17;
            this.comboBoxFormaPagamento.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormaPagamento_SelectedIndexChanged);
            this.comboBoxFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxFormaPagamento_KeyPress);
            // 
            // textBoxValor
            // 
            this.textBoxValor.BackColor = System.Drawing.Color.White;
            this.textBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.Location = new System.Drawing.Point(194, 6);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(152, 23);
            this.textBoxValor.TabIndex = 16;
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValor_KeyPress);
            // 
            // dateTimeVencimento
            // 
            this.dateTimeVencimento.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimeVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeVencimento.Location = new System.Drawing.Point(45, 6);
            this.dateTimeVencimento.Name = "dateTimeVencimento";
            this.dateTimeVencimento.Size = new System.Drawing.Size(139, 23);
            this.dateTimeVencimento.TabIndex = 15;
            this.dateTimeVencimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimeVencimento_KeyPress);
            // 
            // labelNumero
            // 
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(1, 5);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(27, 24);
            this.labelNumero.TabIndex = 14;
            this.labelNumero.Text = "0";
            this.labelNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl_ItemParcela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.comboBoxFormaPagamento);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.dateTimeVencimento);
            this.Controls.Add(this.labelNumero);
            this.Name = "UserControl_ItemParcela";
            this.Size = new System.Drawing.Size(875, 35);
            this.Load += new System.EventHandler(this.UserControl_ItemParcela_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        public System.Windows.Forms.TextBox textBoxValor;
        public System.Windows.Forms.DateTimePicker dateTimeVencimento;
        public System.Windows.Forms.Label labelNumero;
    }
}
