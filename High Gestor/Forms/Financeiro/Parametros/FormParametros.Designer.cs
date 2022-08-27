namespace High_Gestor.Forms.Financeiro.Parametros
{
    partial class FormParametros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametros));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonCondicaoPagamento = new System.Windows.Forms.Button();
            this.buttonCentroCusto = new System.Windows.Forms.Button();
            this.buttonCategoriaContas = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.buttonCondicaoPagamento);
            this.panelMenu.Controls.Add(this.buttonCentroCusto);
            this.panelMenu.Controls.Add(this.buttonCategoriaContas);
            this.panelMenu.Controls.Add(this.buttonVoltar);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(231, 640);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // buttonCondicaoPagamento
            // 
            this.buttonCondicaoPagamento.FlatAppearance.BorderSize = 0;
            this.buttonCondicaoPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCondicaoPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCondicaoPagamento.Image = ((System.Drawing.Image)(resources.GetObject("buttonCondicaoPagamento.Image")));
            this.buttonCondicaoPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCondicaoPagamento.Location = new System.Drawing.Point(0, 144);
            this.buttonCondicaoPagamento.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.buttonCondicaoPagamento.Name = "buttonCondicaoPagamento";
            this.buttonCondicaoPagamento.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonCondicaoPagamento.Size = new System.Drawing.Size(229, 40);
            this.buttonCondicaoPagamento.TabIndex = 97;
            this.buttonCondicaoPagamento.Text = "  Condições de pagamento";
            this.buttonCondicaoPagamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCondicaoPagamento.UseVisualStyleBackColor = true;
            this.buttonCondicaoPagamento.Click += new System.EventHandler(this.buttonCondicaoPagamento_Click);
            // 
            // buttonCentroCusto
            // 
            this.buttonCentroCusto.FlatAppearance.BorderSize = 0;
            this.buttonCentroCusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCentroCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCentroCusto.Image = ((System.Drawing.Image)(resources.GetObject("buttonCentroCusto.Image")));
            this.buttonCentroCusto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCentroCusto.Location = new System.Drawing.Point(0, 98);
            this.buttonCentroCusto.Name = "buttonCentroCusto";
            this.buttonCentroCusto.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonCentroCusto.Size = new System.Drawing.Size(229, 40);
            this.buttonCentroCusto.TabIndex = 96;
            this.buttonCentroCusto.Text = "  Centro de custos";
            this.buttonCentroCusto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCentroCusto.UseVisualStyleBackColor = true;
            this.buttonCentroCusto.Click += new System.EventHandler(this.buttonCentroCusto_Click);
            // 
            // buttonCategoriaContas
            // 
            this.buttonCategoriaContas.FlatAppearance.BorderSize = 0;
            this.buttonCategoriaContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategoriaContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCategoriaContas.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategoriaContas.Image")));
            this.buttonCategoriaContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCategoriaContas.Location = new System.Drawing.Point(0, 54);
            this.buttonCategoriaContas.Name = "buttonCategoriaContas";
            this.buttonCategoriaContas.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.buttonCategoriaContas.Size = new System.Drawing.Size(229, 40);
            this.buttonCategoriaContas.TabIndex = 95;
            this.buttonCategoriaContas.Text = "  Categorias financeiras";
            this.buttonCategoriaContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCategoriaContas.UseVisualStyleBackColor = true;
            this.buttonCategoriaContas.Click += new System.EventHandler(this.buttonCategoriaContas_Click);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.BackColor = System.Drawing.Color.Transparent;
            this.buttonVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonVoltar.FlatAppearance.BorderSize = 0;
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonVoltar.Image = ((System.Drawing.Image)(resources.GetObject("buttonVoltar.Image")));
            this.buttonVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVoltar.Location = new System.Drawing.Point(9, 10);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(211, 35);
            this.buttonVoltar.TabIndex = 93;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(231, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(977, 640);
            this.panelContent.TabIndex = 3;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            // 
            // FormParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormParametros";
            this.Load += new System.EventHandler(this.FormParametros_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonCentroCusto;
        private System.Windows.Forms.Button buttonCategoriaContas;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button buttonCondicaoPagamento;
        private System.Windows.Forms.Panel panelContent;
    }
}