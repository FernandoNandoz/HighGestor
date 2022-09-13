namespace High_Gestor.Forms.Configuracoes.ParametrosSistema
{
    partial class FormParametrosSistemas
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Panel panelSubMenu;
            System.Windows.Forms.Panel panelHeaderSubMenu;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Panel panelSubMenuBorder;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParametrosSistemas));
            this.buttonCompras = new System.Windows.Forms.Button();
            this.buttonVendas = new System.Windows.Forms.Button();
            this.buttonDadosEmpresa = new System.Windows.Forms.Button();
            this.buttonGerais = new System.Windows.Forms.Button();
            this.buttonFinanceiro = new System.Windows.Forms.Button();
            this.buttonEstoque = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panelSubMenu = new System.Windows.Forms.Panel();
            panelHeaderSubMenu = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            panelSubMenuBorder = new System.Windows.Forms.Panel();
            panelSubMenu.SuspendLayout();
            panelHeaderSubMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(15, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(200, 24);
            label1.TabIndex = 154;
            label1.Text = "Parâmetros do sistema";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelSubMenu
            // 
            panelSubMenu.Controls.Add(this.buttonCompras);
            panelSubMenu.Controls.Add(this.buttonVendas);
            panelSubMenu.Controls.Add(this.buttonDadosEmpresa);
            panelSubMenu.Controls.Add(this.buttonGerais);
            panelSubMenu.Controls.Add(this.buttonFinanceiro);
            panelSubMenu.Controls.Add(this.buttonEstoque);
            panelSubMenu.Controls.Add(panelHeaderSubMenu);
            panelSubMenu.Location = new System.Drawing.Point(19, 23);
            panelSubMenu.Name = "panelSubMenu";
            panelSubMenu.Size = new System.Drawing.Size(200, 425);
            panelSubMenu.TabIndex = 0;
            // 
            // buttonCompras
            // 
            this.buttonCompras.FlatAppearance.BorderSize = 0;
            this.buttonCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCompras.Location = new System.Drawing.Point(2, 137);
            this.buttonCompras.Name = "buttonCompras";
            this.buttonCompras.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCompras.Size = new System.Drawing.Size(195, 40);
            this.buttonCompras.TabIndex = 101;
            this.buttonCompras.Text = "Compras";
            this.buttonCompras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCompras.UseVisualStyleBackColor = true;
            this.buttonCompras.Click += new System.EventHandler(this.buttonCompras_Click);
            // 
            // buttonVendas
            // 
            this.buttonVendas.FlatAppearance.BorderSize = 0;
            this.buttonVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVendas.Location = new System.Drawing.Point(2, 91);
            this.buttonVendas.Name = "buttonVendas";
            this.buttonVendas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonVendas.Size = new System.Drawing.Size(195, 40);
            this.buttonVendas.TabIndex = 100;
            this.buttonVendas.Text = "Vendas";
            this.buttonVendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVendas.UseVisualStyleBackColor = true;
            this.buttonVendas.Click += new System.EventHandler(this.buttonVendas_Click);
            // 
            // buttonDadosEmpresa
            // 
            this.buttonDadosEmpresa.FlatAppearance.BorderSize = 0;
            this.buttonDadosEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDadosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDadosEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDadosEmpresa.Location = new System.Drawing.Point(2, 275);
            this.buttonDadosEmpresa.Name = "buttonDadosEmpresa";
            this.buttonDadosEmpresa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonDadosEmpresa.Size = new System.Drawing.Size(195, 40);
            this.buttonDadosEmpresa.TabIndex = 99;
            this.buttonDadosEmpresa.Text = "Dados da empresa";
            this.buttonDadosEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDadosEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDadosEmpresa.UseVisualStyleBackColor = true;
            this.buttonDadosEmpresa.Visible = false;
            this.buttonDadosEmpresa.Click += new System.EventHandler(this.buttonDadosEmpresa_Click);
            // 
            // buttonGerais
            // 
            this.buttonGerais.FlatAppearance.BorderSize = 0;
            this.buttonGerais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGerais.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonGerais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGerais.Location = new System.Drawing.Point(2, 45);
            this.buttonGerais.Name = "buttonGerais";
            this.buttonGerais.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonGerais.Size = new System.Drawing.Size(195, 40);
            this.buttonGerais.TabIndex = 98;
            this.buttonGerais.Text = "Gerais";
            this.buttonGerais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGerais.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGerais.UseVisualStyleBackColor = true;
            this.buttonGerais.Click += new System.EventHandler(this.buttonGerais_Click);
            // 
            // buttonFinanceiro
            // 
            this.buttonFinanceiro.FlatAppearance.BorderSize = 0;
            this.buttonFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonFinanceiro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinanceiro.Location = new System.Drawing.Point(1, 229);
            this.buttonFinanceiro.Name = "buttonFinanceiro";
            this.buttonFinanceiro.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonFinanceiro.Size = new System.Drawing.Size(195, 40);
            this.buttonFinanceiro.TabIndex = 97;
            this.buttonFinanceiro.Text = "Financeiro";
            this.buttonFinanceiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinanceiro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFinanceiro.UseVisualStyleBackColor = true;
            this.buttonFinanceiro.Click += new System.EventHandler(this.buttonFinanceiro_Click);
            // 
            // buttonEstoque
            // 
            this.buttonEstoque.FlatAppearance.BorderSize = 0;
            this.buttonEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEstoque.Location = new System.Drawing.Point(2, 183);
            this.buttonEstoque.Name = "buttonEstoque";
            this.buttonEstoque.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEstoque.Size = new System.Drawing.Size(194, 40);
            this.buttonEstoque.TabIndex = 96;
            this.buttonEstoque.Text = "Estoque";
            this.buttonEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEstoque.UseVisualStyleBackColor = true;
            this.buttonEstoque.Click += new System.EventHandler(this.buttonEstoque_Click);
            // 
            // panelHeaderSubMenu
            // 
            panelHeaderSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            panelHeaderSubMenu.Controls.Add(label2);
            panelHeaderSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeaderSubMenu.Location = new System.Drawing.Point(0, 0);
            panelHeaderSubMenu.Name = "panelHeaderSubMenu";
            panelHeaderSubMenu.Size = new System.Drawing.Size(200, 37);
            panelHeaderSubMenu.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label2.Location = new System.Drawing.Point(13, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 18);
            label2.TabIndex = 155;
            label2.Text = "Menu";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelSubMenuBorder
            // 
            panelSubMenuBorder.BackColor = System.Drawing.SystemColors.ScrollBar;
            panelSubMenuBorder.Location = new System.Drawing.Point(18, 22);
            panelSubMenuBorder.Name = "panelSubMenuBorder";
            panelSubMenuBorder.Size = new System.Drawing.Size(202, 427);
            panelSubMenuBorder.TabIndex = 99;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.buttonVoltar);
            this.panelHeader.Controls.Add(label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1008, 50);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
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
            this.buttonVoltar.Location = new System.Drawing.Point(900, 6);
            this.buttonVoltar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(99, 30);
            this.buttonVoltar.TabIndex = 220;
            this.buttonVoltar.TabStop = false;
            this.buttonVoltar.Text = " Voltar";
            this.buttonVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonVoltar.UseVisualStyleBackColor = false;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            this.buttonVoltar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonVoltar_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(panelSubMenu);
            this.panelMenu.Controls.Add(panelSubMenuBorder);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 50);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(225, 590);
            this.panelMenu.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(225, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(783, 590);
            this.panelContent.TabIndex = 102;
            // 
            // FormParametrosSistemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1008, 640);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormParametrosSistemas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormParametrosSistemas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParametrosSistemas_FormClosing);
            this.Load += new System.EventHandler(this.FormParametrosSistemas_Load);
            panelSubMenu.ResumeLayout(false);
            panelHeaderSubMenu.ResumeLayout(false);
            panelHeaderSubMenu.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button buttonFinanceiro;
        private System.Windows.Forms.Button buttonEstoque;
        private System.Windows.Forms.Button buttonGerais;
        private System.Windows.Forms.Button buttonDadosEmpresa;
        private System.Windows.Forms.Button buttonCompras;
        private System.Windows.Forms.Button buttonVendas;
        private System.Windows.Forms.Panel panelContent;
    }
}