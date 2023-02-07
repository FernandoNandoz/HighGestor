namespace High_Gestor.Forms.Financeiro.ContasReceber
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
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonLiquidarContas = new System.Windows.Forms.Button();
            this.buttonDesliquidarContas = new System.Windows.Forms.Button();
            this.buttonReceitaRecorrente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.flowLayoutPanelContent.Controls.Add(this.buttonLiquidarContas);
            this.flowLayoutPanelContent.Controls.Add(this.buttonDesliquidarContas);
            this.flowLayoutPanelContent.Controls.Add(this.buttonReceitaRecorrente);
            this.flowLayoutPanelContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(0, 8);
            this.flowLayoutPanelContent.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(212, 114);
            this.flowLayoutPanelContent.TabIndex = 110;
            this.flowLayoutPanelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelContent_Paint);
            // 
            // buttonLiquidarContas
            // 
            this.buttonLiquidarContas.FlatAppearance.BorderSize = 0;
            this.buttonLiquidarContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLiquidarContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLiquidarContas.ForeColor = System.Drawing.Color.White;
            this.buttonLiquidarContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLiquidarContas.Location = new System.Drawing.Point(3, 6);
            this.buttonLiquidarContas.Name = "buttonLiquidarContas";
            this.buttonLiquidarContas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonLiquidarContas.Size = new System.Drawing.Size(206, 30);
            this.buttonLiquidarContas.TabIndex = 104;
            this.buttonLiquidarContas.Text = "Liquidar contas";
            this.buttonLiquidarContas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLiquidarContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLiquidarContas.UseVisualStyleBackColor = true;
            this.buttonLiquidarContas.Click += new System.EventHandler(this.buttonLiquidarContas_Click);
            // 
            // buttonDesliquidarContas
            // 
            this.buttonDesliquidarContas.FlatAppearance.BorderSize = 0;
            this.buttonDesliquidarContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesliquidarContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDesliquidarContas.ForeColor = System.Drawing.Color.White;
            this.buttonDesliquidarContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDesliquidarContas.Location = new System.Drawing.Point(3, 42);
            this.buttonDesliquidarContas.Name = "buttonDesliquidarContas";
            this.buttonDesliquidarContas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonDesliquidarContas.Size = new System.Drawing.Size(206, 30);
            this.buttonDesliquidarContas.TabIndex = 106;
            this.buttonDesliquidarContas.Text = "Desliquidar contas";
            this.buttonDesliquidarContas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDesliquidarContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDesliquidarContas.UseVisualStyleBackColor = true;
            this.buttonDesliquidarContas.Click += new System.EventHandler(this.buttonDesliquidarContas_Click);
            // 
            // buttonReceitaRecorrente
            // 
            this.buttonReceitaRecorrente.FlatAppearance.BorderSize = 0;
            this.buttonReceitaRecorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceitaRecorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReceitaRecorrente.ForeColor = System.Drawing.Color.White;
            this.buttonReceitaRecorrente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReceitaRecorrente.Location = new System.Drawing.Point(3, 78);
            this.buttonReceitaRecorrente.Name = "buttonReceitaRecorrente";
            this.buttonReceitaRecorrente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonReceitaRecorrente.Size = new System.Drawing.Size(206, 30);
            this.buttonReceitaRecorrente.TabIndex = 107;
            this.buttonReceitaRecorrente.Text = "Receitas recorrêntes";
            this.buttonReceitaRecorrente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReceitaRecorrente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonReceitaRecorrente.UseVisualStyleBackColor = true;
            this.buttonReceitaRecorrente.Click += new System.EventHandler(this.buttonReceitaRecorrente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(91, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 109;
            this.pictureBox1.TabStop = false;
            // 
            // UserControl_MaisAcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.flowLayoutPanelContent);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_MaisAcoes";
            this.Size = new System.Drawing.Size(212, 122);
            this.Load += new System.EventHandler(this.UserControl_MaisAcoes_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl_MaisAcoes_Paint);
            this.flowLayoutPanelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
        private System.Windows.Forms.Button buttonLiquidarContas;
        private System.Windows.Forms.Button buttonDesliquidarContas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonReceitaRecorrente;
    }
}
