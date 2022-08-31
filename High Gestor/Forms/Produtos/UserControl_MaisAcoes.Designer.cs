namespace High_Gestor.Forms.Produtos
{
    partial class UserControl_MaisAcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_MaisAcoes));
            this.buttonCategoria = new System.Windows.Forms.Button();
            this.buttonListaPreco = new System.Windows.Forms.Button();
            this.buttonEditarMassa = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCategoria
            // 
            this.buttonCategoria.FlatAppearance.BorderSize = 0;
            this.buttonCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCategoria.ForeColor = System.Drawing.Color.White;
            this.buttonCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCategoria.Location = new System.Drawing.Point(4, 6);
            this.buttonCategoria.Name = "buttonCategoria";
            this.buttonCategoria.Size = new System.Drawing.Size(166, 30);
            this.buttonCategoria.TabIndex = 101;
            this.buttonCategoria.Text = "Categorias";
            this.buttonCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCategoria.UseVisualStyleBackColor = true;
            this.buttonCategoria.Click += new System.EventHandler(this.buttonCategoria_Click);
            // 
            // buttonListaPreco
            // 
            this.buttonListaPreco.FlatAppearance.BorderSize = 0;
            this.buttonListaPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListaPreco.ForeColor = System.Drawing.Color.White;
            this.buttonListaPreco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonListaPreco.Location = new System.Drawing.Point(4, 78);
            this.buttonListaPreco.Name = "buttonListaPreco";
            this.buttonListaPreco.Size = new System.Drawing.Size(166, 30);
            this.buttonListaPreco.TabIndex = 102;
            this.buttonListaPreco.Text = "Lista de preços";
            this.buttonListaPreco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonListaPreco.UseVisualStyleBackColor = true;
            this.buttonListaPreco.Click += new System.EventHandler(this.buttonListaPreco_Click);
            // 
            // buttonEditarMassa
            // 
            this.buttonEditarMassa.FlatAppearance.BorderSize = 0;
            this.buttonEditarMassa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditarMassa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditarMassa.ForeColor = System.Drawing.Color.White;
            this.buttonEditarMassa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditarMassa.Location = new System.Drawing.Point(4, 42);
            this.buttonEditarMassa.Name = "buttonEditarMassa";
            this.buttonEditarMassa.Size = new System.Drawing.Size(166, 30);
            this.buttonEditarMassa.TabIndex = 103;
            this.buttonEditarMassa.Text = "Editar em massa";
            this.buttonEditarMassa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEditarMassa.UseVisualStyleBackColor = true;
            this.buttonEditarMassa.Click += new System.EventHandler(this.buttonEditarMassa_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.panelContent.Controls.Add(this.buttonCategoria);
            this.panelContent.Controls.Add(this.buttonEditarMassa);
            this.panelContent.Controls.Add(this.buttonListaPreco);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelContent.Location = new System.Drawing.Point(0, 8);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(174, 120);
            this.panelContent.TabIndex = 104;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(72, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 105;
            this.pictureBox1.TabStop = false;
            // 
            // UserControl_MaisAcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserControl_MaisAcoes";
            this.Size = new System.Drawing.Size(174, 128);
            this.Load += new System.EventHandler(this.UserControl_MaisAcoes_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl_MaisAcoes_Paint);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCategoria;
        private System.Windows.Forms.Button buttonListaPreco;
        private System.Windows.Forms.Button buttonEditarMassa;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
