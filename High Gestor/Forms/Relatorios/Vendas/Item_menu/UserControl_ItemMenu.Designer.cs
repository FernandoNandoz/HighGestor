namespace High_Gestor.Forms.Relatorios.Vendas.Item_menu
{
    partial class UserControl_ItemMenu
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
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelTituloRelatorio = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.BackColor = System.Drawing.Color.Transparent;
            this.labelDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.Location = new System.Drawing.Point(152, 54);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(71, 17);
            this.labelDescricao.TabIndex = 5;
            this.labelDescricao.Text = "Descricao";
            this.labelDescricao.Click += new System.EventHandler(this.UserControl_ItemMenu_Click);
            this.labelDescricao.MouseEnter += new System.EventHandler(this.UserControl_ItemMenu_MouseEnter);
            this.labelDescricao.MouseLeave += new System.EventHandler(this.UserControl_ItemMenu_MouseLeave);
            // 
            // labelTituloRelatorio
            // 
            this.labelTituloRelatorio.AutoSize = true;
            this.labelTituloRelatorio.BackColor = System.Drawing.Color.Transparent;
            this.labelTituloRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloRelatorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTituloRelatorio.Location = new System.Drawing.Point(145, 30);
            this.labelTituloRelatorio.Name = "labelTituloRelatorio";
            this.labelTituloRelatorio.Size = new System.Drawing.Size(43, 20);
            this.labelTituloRelatorio.TabIndex = 4;
            this.labelTituloRelatorio.Text = "titulo";
            this.labelTituloRelatorio.Click += new System.EventHandler(this.UserControl_ItemMenu_Click);
            this.labelTituloRelatorio.MouseEnter += new System.EventHandler(this.UserControl_ItemMenu_MouseEnter);
            this.labelTituloRelatorio.MouseLeave += new System.EventHandler(this.UserControl_ItemMenu_MouseLeave);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Location = new System.Drawing.Point(26, 23);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(84, 55);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 3;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.UserControl_ItemMenu_Click);
            this.pictureBoxIcon.MouseEnter += new System.EventHandler(this.UserControl_ItemMenu_MouseEnter);
            this.pictureBoxIcon.MouseLeave += new System.EventHandler(this.UserControl_ItemMenu_MouseLeave);
            // 
            // UserControl_ItemMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelTituloRelatorio);
            this.Controls.Add(this.pictureBoxIcon);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ItemMenu";
            this.Size = new System.Drawing.Size(1105, 100);
            this.Load += new System.EventHandler(this.UserControl_ItemMenu_Load);
            this.Click += new System.EventHandler(this.UserControl_ItemMenu_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl_ItemMenu_Paint);
            this.MouseEnter += new System.EventHandler(this.UserControl_ItemMenu_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControl_ItemMenu_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelTituloRelatorio;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}
