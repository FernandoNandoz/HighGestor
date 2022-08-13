namespace High_Gestor.Forms.Compras.EntradaMercadoria.ItensProduto
{
    partial class UserControl_ItemProduto
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
            this.labelNumero = new System.Windows.Forms.Label();
            this.textBoxNomeProduto = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxValorCusto = new System.Windows.Forms.TextBox();
            this.textBoxValorTotal = new System.Windows.Forms.TextBox();
            this.labelRemover = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNumero
            // 
            this.labelNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(131)))), ((int)(((byte)(216)))));
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.ForeColor = System.Drawing.Color.White;
            this.labelNumero.Location = new System.Drawing.Point(0, 5);
            this.labelNumero.Margin = new System.Windows.Forms.Padding(0);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(35, 24);
            this.labelNumero.TabIndex = 6;
            this.labelNumero.Text = "0";
            this.labelNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNumero.Paint += new System.Windows.Forms.PaintEventHandler(this.labelNumero_Paint);
            // 
            // textBoxNomeProduto
            // 
            this.textBoxNomeProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxNomeProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeProduto.Location = new System.Drawing.Point(41, 6);
            this.textBoxNomeProduto.Name = "textBoxNomeProduto";
            this.textBoxNomeProduto.Size = new System.Drawing.Size(398, 23);
            this.textBoxNomeProduto.TabIndex = 3;
            this.textBoxNomeProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNomeProduto_KeyUp);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(445, 6);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.Size = new System.Drawing.Size(111, 23);
            this.textBoxCodigo.TabIndex = 4;
            this.textBoxCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxCodigo_KeyUp);
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.Location = new System.Drawing.Point(562, 6);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(152, 23);
            this.textBoxQuantidade.TabIndex = 5;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            this.textBoxQuantidade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxQuantidade_KeyUp);
            // 
            // textBoxValorCusto
            // 
            this.textBoxValorCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorCusto.Location = new System.Drawing.Point(720, 6);
            this.textBoxValorCusto.Name = "textBoxValorCusto";
            this.textBoxValorCusto.Size = new System.Drawing.Size(152, 23);
            this.textBoxValorCusto.TabIndex = 6;
            this.textBoxValorCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxValorCusto_KeyDown);
            this.textBoxValorCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorCusto_KeyPress);
            this.textBoxValorCusto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValorCusto_KeyUp);
            // 
            // textBoxValorTotal
            // 
            this.textBoxValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorTotal.Location = new System.Drawing.Point(878, 6);
            this.textBoxValorTotal.Name = "textBoxValorTotal";
            this.textBoxValorTotal.Size = new System.Drawing.Size(152, 23);
            this.textBoxValorTotal.TabIndex = 7;
            this.textBoxValorTotal.TextChanged += new System.EventHandler(this.textBoxValorTotal_TextChanged);
            this.textBoxValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorTotal_KeyPress);
            this.textBoxValorTotal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValorTotal_KeyUp);
            // 
            // labelRemover
            // 
            this.labelRemover.AutoSize = true;
            this.labelRemover.BackColor = System.Drawing.Color.Transparent;
            this.labelRemover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemover.ForeColor = System.Drawing.Color.Red;
            this.labelRemover.Location = new System.Drawing.Point(1040, 9);
            this.labelRemover.Margin = new System.Windows.Forms.Padding(0);
            this.labelRemover.Name = "labelRemover";
            this.labelRemover.Size = new System.Drawing.Size(18, 17);
            this.labelRemover.TabIndex = 13;
            this.labelRemover.Text = "X";
            this.labelRemover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRemover.Click += new System.EventHandler(this.labelRemover_Click);
            // 
            // UserControl_ItemProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelRemover);
            this.Controls.Add(this.textBoxValorTotal);
            this.Controls.Add(this.textBoxValorCusto);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.textBoxCodigo);
            this.Controls.Add(this.textBoxNomeProduto);
            this.Controls.Add(this.labelNumero);
            this.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Name = "UserControl_ItemProduto";
            this.Size = new System.Drawing.Size(1085, 35);
            this.Load += new System.EventHandler(this.UserControl_ItemProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelNumero;
        public System.Windows.Forms.TextBox textBoxNomeProduto;
        public System.Windows.Forms.TextBox textBoxCodigo;
        public System.Windows.Forms.TextBox textBoxQuantidade;
        public System.Windows.Forms.TextBox textBoxValorCusto;
        public System.Windows.Forms.TextBox textBoxValorTotal;
        public System.Windows.Forms.Label labelRemover;
    }
}
