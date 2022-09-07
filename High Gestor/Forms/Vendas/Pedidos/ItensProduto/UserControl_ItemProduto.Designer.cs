namespace High_Gestor.Forms.Vendas.Pedidos.ItensProduto
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
            this.labelRemover = new System.Windows.Forms.Label();
            this.textBoxValorTotal = new System.Windows.Forms.TextBox();
            this.textBoxValorVenda = new System.Windows.Forms.TextBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxCodigo = new System.Windows.Forms.TextBox();
            this.textBoxNomeProduto = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.labelRemover.TabIndex = 20;
            this.labelRemover.Text = "X";
            this.labelRemover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRemover.Click += new System.EventHandler(this.labelRemover_Click);
            // 
            // textBoxValorTotal
            // 
            this.textBoxValorTotal.BackColor = System.Drawing.Color.White;
            this.textBoxValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorTotal.Location = new System.Drawing.Point(878, 6);
            this.textBoxValorTotal.Name = "textBoxValorTotal";
            this.textBoxValorTotal.Size = new System.Drawing.Size(152, 23);
            this.textBoxValorTotal.TabIndex = 8;
            this.textBoxValorTotal.TextChanged += new System.EventHandler(this.textBoxValorTotal_TextChanged);
            this.textBoxValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorTotal_KeyPress);
            this.textBoxValorTotal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValorTotal_KeyUp);
            // 
            // textBoxValorVenda
            // 
            this.textBoxValorVenda.BackColor = System.Drawing.Color.White;
            this.textBoxValorVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorVenda.Location = new System.Drawing.Point(720, 6);
            this.textBoxValorVenda.Name = "textBoxValorVenda";
            this.textBoxValorVenda.ReadOnly = true;
            this.textBoxValorVenda.Size = new System.Drawing.Size(152, 23);
            this.textBoxValorVenda.TabIndex = 7;
            this.textBoxValorVenda.TextChanged += new System.EventHandler(this.textBoxValorVenda_TextChanged);
            this.textBoxValorVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxValorCusto_KeyDown);
            this.textBoxValorVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValorCusto_KeyPress);
            this.textBoxValorVenda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxValorCusto_KeyUp);
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.BackColor = System.Drawing.Color.White;
            this.textBoxQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantidade.Location = new System.Drawing.Point(562, 6);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(152, 23);
            this.textBoxQuantidade.TabIndex = 6;
            this.textBoxQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantidade_KeyPress);
            this.textBoxQuantidade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxQuantidade_KeyUp);
            // 
            // textBoxCodigo
            // 
            this.textBoxCodigo.BackColor = System.Drawing.Color.White;
            this.textBoxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigo.Location = new System.Drawing.Point(445, 6);
            this.textBoxCodigo.Name = "textBoxCodigo";
            this.textBoxCodigo.ReadOnly = true;
            this.textBoxCodigo.Size = new System.Drawing.Size(111, 23);
            this.textBoxCodigo.TabIndex = 5;
            this.textBoxCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxCodigo_KeyUp);
            // 
            // textBoxNomeProduto
            // 
            this.textBoxNomeProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxNomeProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxNomeProduto.BackColor = System.Drawing.Color.White;
            this.textBoxNomeProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeProduto.Location = new System.Drawing.Point(41, 6);
            this.textBoxNomeProduto.Name = "textBoxNomeProduto";
            this.textBoxNomeProduto.Size = new System.Drawing.Size(398, 23);
            this.textBoxNomeProduto.TabIndex = 4;
            this.textBoxNomeProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNomeProduto_KeyUp);
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
            this.labelNumero.TabIndex = 18;
            this.labelNumero.Text = "0";
            this.labelNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelNumero.Paint += new System.Windows.Forms.PaintEventHandler(this.labelNumero_Paint);
            // 
            // UserControl_ItemProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.labelRemover);
            this.Controls.Add(this.textBoxValorTotal);
            this.Controls.Add(this.textBoxValorVenda);
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

        public System.Windows.Forms.Label labelRemover;
        public System.Windows.Forms.TextBox textBoxValorTotal;
        public System.Windows.Forms.TextBox textBoxValorVenda;
        public System.Windows.Forms.TextBox textBoxQuantidade;
        public System.Windows.Forms.TextBox textBoxCodigo;
        public System.Windows.Forms.TextBox textBoxNomeProduto;
        public System.Windows.Forms.Label labelNumero;
    }
}
