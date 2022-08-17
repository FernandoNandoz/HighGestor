namespace High_Gestor.Forms.Compras
{
    partial class UserControl_Acoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Acoes));
            this.buttonImprimirEntrada = new System.Windows.Forms.Button();
            this.buttonLancarContas = new System.Windows.Forms.Button();
            this.buttonLancarEstoque = new System.Windows.Forms.Button();
            this.buttonAlterarStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonImprimirEntrada
            // 
            this.buttonImprimirEntrada.FlatAppearance.BorderSize = 0;
            this.buttonImprimirEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimirEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonImprimirEntrada.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimirEntrada.Image")));
            this.buttonImprimirEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImprimirEntrada.Location = new System.Drawing.Point(-1, 3);
            this.buttonImprimirEntrada.Name = "buttonImprimirEntrada";
            this.buttonImprimirEntrada.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonImprimirEntrada.Size = new System.Drawing.Size(159, 30);
            this.buttonImprimirEntrada.TabIndex = 96;
            this.buttonImprimirEntrada.Text = "   Imprimir entrada";
            this.buttonImprimirEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonImprimirEntrada.UseVisualStyleBackColor = true;
            this.buttonImprimirEntrada.Click += new System.EventHandler(this.buttonImprimirEntrada_Click);
            // 
            // buttonLancarContas
            // 
            this.buttonLancarContas.FlatAppearance.BorderSize = 0;
            this.buttonLancarContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLancarContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLancarContas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonLancarContas.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancarContas.Image")));
            this.buttonLancarContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLancarContas.Location = new System.Drawing.Point(-1, 39);
            this.buttonLancarContas.Name = "buttonLancarContas";
            this.buttonLancarContas.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonLancarContas.Size = new System.Drawing.Size(159, 30);
            this.buttonLancarContas.TabIndex = 97;
            this.buttonLancarContas.Text = "   Lançar contas";
            this.buttonLancarContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLancarContas.UseVisualStyleBackColor = true;
            this.buttonLancarContas.Click += new System.EventHandler(this.buttonLancarContas_Click);
            // 
            // buttonLancarEstoque
            // 
            this.buttonLancarEstoque.FlatAppearance.BorderSize = 0;
            this.buttonLancarEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLancarEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLancarEstoque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonLancarEstoque.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancarEstoque.Image")));
            this.buttonLancarEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLancarEstoque.Location = new System.Drawing.Point(-1, 72);
            this.buttonLancarEstoque.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLancarEstoque.Name = "buttonLancarEstoque";
            this.buttonLancarEstoque.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonLancarEstoque.Size = new System.Drawing.Size(159, 30);
            this.buttonLancarEstoque.TabIndex = 98;
            this.buttonLancarEstoque.Text = "   Lançar estoque";
            this.buttonLancarEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLancarEstoque.UseVisualStyleBackColor = true;
            this.buttonLancarEstoque.Click += new System.EventHandler(this.buttonLancarEstoque_Click);
            // 
            // buttonAlterarStatus
            // 
            this.buttonAlterarStatus.FlatAppearance.BorderSize = 0;
            this.buttonAlterarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlterarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterarStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonAlterarStatus.Image = ((System.Drawing.Image)(resources.GetObject("buttonAlterarStatus.Image")));
            this.buttonAlterarStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAlterarStatus.Location = new System.Drawing.Point(-1, 105);
            this.buttonAlterarStatus.Name = "buttonAlterarStatus";
            this.buttonAlterarStatus.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonAlterarStatus.Size = new System.Drawing.Size(159, 30);
            this.buttonAlterarStatus.TabIndex = 99;
            this.buttonAlterarStatus.Text = "   Alterar status";
            this.buttonAlterarStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAlterarStatus.UseVisualStyleBackColor = true;
            this.buttonAlterarStatus.Click += new System.EventHandler(this.buttonAlterarStatus_Click);
            // 
            // UserControl_Acoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonAlterarStatus);
            this.Controls.Add(this.buttonLancarEstoque);
            this.Controls.Add(this.buttonLancarContas);
            this.Controls.Add(this.buttonImprimirEntrada);
            this.Name = "UserControl_Acoes";
            this.Size = new System.Drawing.Size(157, 141);
            this.Load += new System.EventHandler(this.UserControl_Acoes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimirEntrada;
        private System.Windows.Forms.Button buttonLancarContas;
        private System.Windows.Forms.Button buttonLancarEstoque;
        private System.Windows.Forms.Button buttonAlterarStatus;
    }
}
