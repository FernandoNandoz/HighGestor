namespace High_Gestor.Forms.Relatorios
{
    partial class FormRelatorios
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
            System.Windows.Forms.Label labelContagem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorios));
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContentRelatorios = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelEstoque = new System.Windows.Forms.Panel();
            this.labelEstoque = new System.Windows.Forms.Label();
            this.panelPanelFinanceiro = new System.Windows.Forms.Panel();
            this.labelFinanceiro = new System.Windows.Forms.Label();
            this.panelCompras = new System.Windows.Forms.Panel();
            this.labelLabelCompras = new System.Windows.Forms.Label();
            this.panelVendas = new System.Windows.Forms.Panel();
            this.labelVendas = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            labelContagem = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelEstoque.SuspendLayout();
            this.panelPanelFinanceiro.SuspendLayout();
            this.panelCompras.SuspendLayout();
            this.panelVendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelContentRelatorios);
            this.panelContent.Controls.Add(this.panelHeader);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1208, 640);
            this.panelContent.TabIndex = 0;
            // 
            // panelContentRelatorios
            // 
            this.panelContentRelatorios.AutoScroll = true;
            this.panelContentRelatorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentRelatorios.Location = new System.Drawing.Point(0, 124);
            this.panelContentRelatorios.Margin = new System.Windows.Forms.Padding(0);
            this.panelContentRelatorios.Name = "panelContentRelatorios";
            this.panelContentRelatorios.Size = new System.Drawing.Size(1208, 516);
            this.panelContentRelatorios.TabIndex = 3;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelEstoque);
            this.panelHeader.Controls.Add(this.panelPanelFinanceiro);
            this.panelHeader.Controls.Add(this.panelCompras);
            this.panelHeader.Controls.Add(this.panelVendas);
            this.panelHeader.Controls.Add(this.buttonVoltar);
            this.panelHeader.Controls.Add(labelContagem);
            this.panelHeader.Controls.Add(this.panel6);
            this.panelHeader.Controls.Add(this.panel7);
            this.panelHeader.Controls.Add(this.panel1);
            this.panelHeader.Controls.Add(this.panel8);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1208, 124);
            this.panelHeader.TabIndex = 2;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // panelEstoque
            // 
            this.panelEstoque.Controls.Add(this.labelEstoque);
            this.panelEstoque.Location = new System.Drawing.Point(554, 76);
            this.panelEstoque.Margin = new System.Windows.Forms.Padding(0);
            this.panelEstoque.Name = "panelEstoque";
            this.panelEstoque.Size = new System.Drawing.Size(145, 47);
            this.panelEstoque.TabIndex = 257;
            // 
            // labelEstoque
            // 
            this.labelEstoque.BackColor = System.Drawing.Color.Transparent;
            this.labelEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstoque.Location = new System.Drawing.Point(0, 0);
            this.labelEstoque.Name = "labelEstoque";
            this.labelEstoque.Size = new System.Drawing.Size(145, 47);
            this.labelEstoque.TabIndex = 3;
            this.labelEstoque.Text = "Estoque";
            this.labelEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEstoque.Click += new System.EventHandler(this.labelEstoque_Click);
            // 
            // panelPanelFinanceiro
            // 
            this.panelPanelFinanceiro.Controls.Add(this.labelFinanceiro);
            this.panelPanelFinanceiro.Location = new System.Drawing.Point(381, 76);
            this.panelPanelFinanceiro.Margin = new System.Windows.Forms.Padding(0);
            this.panelPanelFinanceiro.Name = "panelPanelFinanceiro";
            this.panelPanelFinanceiro.Size = new System.Drawing.Size(145, 47);
            this.panelPanelFinanceiro.TabIndex = 257;
            // 
            // labelFinanceiro
            // 
            this.labelFinanceiro.BackColor = System.Drawing.Color.Transparent;
            this.labelFinanceiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFinanceiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinanceiro.Location = new System.Drawing.Point(0, 0);
            this.labelFinanceiro.Name = "labelFinanceiro";
            this.labelFinanceiro.Size = new System.Drawing.Size(145, 47);
            this.labelFinanceiro.TabIndex = 2;
            this.labelFinanceiro.Text = "Financeiro";
            this.labelFinanceiro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFinanceiro.Click += new System.EventHandler(this.labelFinanceiro_Click);
            // 
            // panelCompras
            // 
            this.panelCompras.Controls.Add(this.labelLabelCompras);
            this.panelCompras.Location = new System.Drawing.Point(211, 76);
            this.panelCompras.Margin = new System.Windows.Forms.Padding(0);
            this.panelCompras.Name = "panelCompras";
            this.panelCompras.Size = new System.Drawing.Size(145, 47);
            this.panelCompras.TabIndex = 257;
            // 
            // labelLabelCompras
            // 
            this.labelLabelCompras.BackColor = System.Drawing.Color.Transparent;
            this.labelLabelCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLabelCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLabelCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabelCompras.Location = new System.Drawing.Point(0, 0);
            this.labelLabelCompras.Name = "labelLabelCompras";
            this.labelLabelCompras.Size = new System.Drawing.Size(145, 47);
            this.labelLabelCompras.TabIndex = 2;
            this.labelLabelCompras.Text = "Compras";
            this.labelLabelCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLabelCompras.Click += new System.EventHandler(this.labelLabelCompras_Click);
            // 
            // panelVendas
            // 
            this.panelVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelVendas.Controls.Add(this.labelVendas);
            this.panelVendas.Location = new System.Drawing.Point(42, 76);
            this.panelVendas.Margin = new System.Windows.Forms.Padding(0);
            this.panelVendas.Name = "panelVendas";
            this.panelVendas.Size = new System.Drawing.Size(145, 51);
            this.panelVendas.TabIndex = 256;
            // 
            // labelVendas
            // 
            this.labelVendas.BackColor = System.Drawing.Color.Transparent;
            this.labelVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVendas.Location = new System.Drawing.Point(0, 0);
            this.labelVendas.Name = "labelVendas";
            this.labelVendas.Size = new System.Drawing.Size(145, 51);
            this.labelVendas.TabIndex = 0;
            this.labelVendas.Text = "Vendas";
            this.labelVendas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelVendas.Click += new System.EventHandler(this.labelVendas_Click);
            // 
            // labelContagem
            // 
            labelContagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelContagem.AutoSize = true;
            labelContagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            labelContagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            labelContagem.Location = new System.Drawing.Point(35, 17);
            labelContagem.Name = "labelContagem";
            labelContagem.Size = new System.Drawing.Size(93, 24);
            labelContagem.TabIndex = 254;
            labelContagem.Text = "Relatórios";
            labelContagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Location = new System.Drawing.Point(41, 75);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(148, 54);
            this.panel6.TabIndex = 257;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gray;
            this.panel7.Location = new System.Drawing.Point(210, 75);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(148, 54);
            this.panel7.TabIndex = 259;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(380, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 54);
            this.panel1.TabIndex = 260;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gray;
            this.panel8.Location = new System.Drawing.Point(553, 75);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(148, 54);
            this.panel8.TabIndex = 260;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVoltar.BackColor = System.Drawing.Color.Transparent;
            this.buttonVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonVoltar.FlatAppearance.BorderSize = 0;
            this.buttonVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonVoltar.Image = ((System.Drawing.Image)(resources.GetObject("buttonVoltar.Image")));
            this.buttonVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonVoltar.Location = new System.Drawing.Point(1090, 11);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 255;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // FormRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1208, 640);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRelatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRelatorios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRelatorios_FormClosing);
            this.Load += new System.EventHandler(this.FormRelatorios_Load);
            this.panelContent.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelEstoque.ResumeLayout(false);
            this.panelPanelFinanceiro.ResumeLayout(false);
            this.panelCompras.ResumeLayout(false);
            this.panelVendas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelContentRelatorios;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelEstoque;
        private System.Windows.Forms.Label labelEstoque;
        private System.Windows.Forms.Panel panelPanelFinanceiro;
        private System.Windows.Forms.Label labelFinanceiro;
        private System.Windows.Forms.Panel panelCompras;
        private System.Windows.Forms.Label labelLabelCompras;
        private System.Windows.Forms.Panel panelVendas;
        private System.Windows.Forms.Label labelVendas;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
    }
}