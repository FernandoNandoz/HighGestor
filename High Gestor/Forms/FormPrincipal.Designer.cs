namespace High_Gestor
{
    partial class FormHighGestor
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelLinhaMenuInferior;
            System.Windows.Forms.Label labelTituloMenu;
            System.Windows.Forms.Label labelTitulo;
            System.Windows.Forms.Label labelLinhaTopo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHighGestor));
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.buttonFinanceiro = new System.Windows.Forms.Button();
            this.buttonCompras = new System.Windows.Forms.Button();
            this.buttonConfiguracoes = new System.Windows.Forms.Button();
            this.buttonRelatorio = new System.Windows.Forms.Button();
            this.buttonClientes = new System.Windows.Forms.Button();
            this.buttonProdutos = new System.Windows.Forms.Button();
            this.buttonVendas = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonTitlerSair = new System.Windows.Forms.Button();
            this.buttonTitlerMaximizar = new System.Windows.Forms.Button();
            this.buttonTitlerMinimizar = new System.Windows.Forms.Button();
            this.paneTitlerBar = new System.Windows.Forms.Panel();
            this.labelNameEstebelecimento = new System.Windows.Forms.Label();
            this.buttonAjuda = new System.Windows.Forms.Button();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.pictureBoxPapelParede = new System.Windows.Forms.PictureBox();
            labelLinhaMenuInferior = new System.Windows.Forms.Label();
            labelTituloMenu = new System.Windows.Forms.Label();
            labelTitulo = new System.Windows.Forms.Label();
            labelLinhaTopo = new System.Windows.Forms.Label();
            this.panelMenuBar.SuspendLayout();
            this.paneTitlerBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPapelParede)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLinhaMenuInferior
            // 
            labelLinhaMenuInferior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            labelLinhaMenuInferior.AutoSize = true;
            labelLinhaMenuInferior.ForeColor = System.Drawing.Color.White;
            labelLinhaMenuInferior.Location = new System.Drawing.Point(13, 572);
            labelLinhaMenuInferior.Name = "labelLinhaMenuInferior";
            labelLinhaMenuInferior.Size = new System.Drawing.Size(133, 13);
            labelLinhaMenuInferior.TabIndex = 9;
            labelLinhaMenuInferior.Text = "_____________________";
            // 
            // labelTituloMenu
            // 
            labelTituloMenu.AutoSize = true;
            labelTituloMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTituloMenu.ForeColor = System.Drawing.Color.White;
            labelTituloMenu.Location = new System.Drawing.Point(42, 40);
            labelTituloMenu.Name = "labelTituloMenu";
            labelTituloMenu.Size = new System.Drawing.Size(74, 31);
            labelTituloMenu.TabIndex = 4;
            labelTituloMenu.Text = "High";
            // 
            // labelTitulo
            // 
            labelTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTitulo.Location = new System.Drawing.Point(500, 9);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(84, 17);
            labelTitulo.TabIndex = 4;
            labelTitulo.Text = "High Gestor";
            // 
            // labelLinhaTopo
            // 
            labelLinhaTopo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            labelLinhaTopo.AutoSize = true;
            labelLinhaTopo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            labelLinhaTopo.Location = new System.Drawing.Point(-528, 67);
            labelLinhaTopo.Name = "labelLinhaTopo";
            labelLinhaTopo.Size = new System.Drawing.Size(2341, 13);
            labelLinhaTopo.TabIndex = 7;
            labelLinhaTopo.Text = resources.GetString("labelLinhaTopo.Text");
            // 
            // panelMenuBar
            // 
            this.panelMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.panelMenuBar.Controls.Add(this.buttonFinanceiro);
            this.panelMenuBar.Controls.Add(this.buttonCompras);
            this.panelMenuBar.Controls.Add(this.buttonConfiguracoes);
            this.panelMenuBar.Controls.Add(this.buttonRelatorio);
            this.panelMenuBar.Controls.Add(labelLinhaMenuInferior);
            this.panelMenuBar.Controls.Add(this.buttonClientes);
            this.panelMenuBar.Controls.Add(this.buttonProdutos);
            this.panelMenuBar.Controls.Add(this.buttonVendas);
            this.panelMenuBar.Controls.Add(labelTituloMenu);
            this.panelMenuBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelMenuBar.Name = "panelMenuBar";
            this.panelMenuBar.Size = new System.Drawing.Size(158, 722);
            this.panelMenuBar.TabIndex = 0;
            // 
            // buttonFinanceiro
            // 
            this.buttonFinanceiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonFinanceiro.FlatAppearance.BorderSize = 0;
            this.buttonFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinanceiro.ForeColor = System.Drawing.Color.White;
            this.buttonFinanceiro.Image = ((System.Drawing.Image)(resources.GetObject("buttonFinanceiro.Image")));
            this.buttonFinanceiro.Location = new System.Drawing.Point(0, 453);
            this.buttonFinanceiro.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFinanceiro.Name = "buttonFinanceiro";
            this.buttonFinanceiro.Size = new System.Drawing.Size(158, 120);
            this.buttonFinanceiro.TabIndex = 8;
            this.buttonFinanceiro.Text = "Financeiro";
            this.buttonFinanceiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonFinanceiro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonFinanceiro.UseVisualStyleBackColor = false;
            this.buttonFinanceiro.Click += new System.EventHandler(this.buttonFinanceiro_Click);
            this.buttonFinanceiro.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonFinanceiro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonCompras
            // 
            this.buttonCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonCompras.FlatAppearance.BorderSize = 0;
            this.buttonCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCompras.ForeColor = System.Drawing.Color.White;
            this.buttonCompras.Location = new System.Drawing.Point(0, 596);
            this.buttonCompras.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCompras.Name = "buttonCompras";
            this.buttonCompras.Size = new System.Drawing.Size(158, 35);
            this.buttonCompras.TabIndex = 12;
            this.buttonCompras.Text = "Compras";
            this.buttonCompras.UseVisualStyleBackColor = false;
            this.buttonCompras.Click += new System.EventHandler(this.buttonCompras_Click);
            this.buttonCompras.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonCompras.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonConfiguracoes
            // 
            this.buttonConfiguracoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConfiguracoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonConfiguracoes.FlatAppearance.BorderSize = 0;
            this.buttonConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfiguracoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.buttonConfiguracoes.Location = new System.Drawing.Point(0, 670);
            this.buttonConfiguracoes.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfiguracoes.Name = "buttonConfiguracoes";
            this.buttonConfiguracoes.Size = new System.Drawing.Size(158, 35);
            this.buttonConfiguracoes.TabIndex = 11;
            this.buttonConfiguracoes.Text = "Configurações";
            this.buttonConfiguracoes.UseVisualStyleBackColor = false;
            this.buttonConfiguracoes.Click += new System.EventHandler(this.buttonConfiguracoes_Click);
            this.buttonConfiguracoes.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonConfiguracoes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonRelatorio
            // 
            this.buttonRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonRelatorio.FlatAppearance.BorderSize = 0;
            this.buttonRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorio.ForeColor = System.Drawing.Color.White;
            this.buttonRelatorio.Location = new System.Drawing.Point(0, 633);
            this.buttonRelatorio.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRelatorio.Name = "buttonRelatorio";
            this.buttonRelatorio.Size = new System.Drawing.Size(158, 35);
            this.buttonRelatorio.TabIndex = 10;
            this.buttonRelatorio.Text = "Relatorios";
            this.buttonRelatorio.UseVisualStyleBackColor = false;
            this.buttonRelatorio.Click += new System.EventHandler(this.buttonRelatorio_Click);
            this.buttonRelatorio.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonRelatorio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonClientes
            // 
            this.buttonClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonClientes.FlatAppearance.BorderSize = 0;
            this.buttonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClientes.ForeColor = System.Drawing.Color.White;
            this.buttonClientes.Image = ((System.Drawing.Image)(resources.GetObject("buttonClientes.Image")));
            this.buttonClientes.Location = new System.Drawing.Point(0, 323);
            this.buttonClientes.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(158, 130);
            this.buttonClientes.TabIndex = 7;
            this.buttonClientes.Text = "Clientes";
            this.buttonClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonClientes.UseVisualStyleBackColor = false;
            this.buttonClientes.Click += new System.EventHandler(this.buttonClientes_Click);
            this.buttonClientes.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonClientes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonProdutos
            // 
            this.buttonProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonProdutos.FlatAppearance.BorderSize = 0;
            this.buttonProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProdutos.ForeColor = System.Drawing.Color.White;
            this.buttonProdutos.Image = ((System.Drawing.Image)(resources.GetObject("buttonProdutos.Image")));
            this.buttonProdutos.Location = new System.Drawing.Point(0, 203);
            this.buttonProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.buttonProdutos.Name = "buttonProdutos";
            this.buttonProdutos.Size = new System.Drawing.Size(158, 120);
            this.buttonProdutos.TabIndex = 6;
            this.buttonProdutos.Text = "Produtos";
            this.buttonProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonProdutos.UseVisualStyleBackColor = false;
            this.buttonProdutos.Click += new System.EventHandler(this.buttonProdutos_Click);
            this.buttonProdutos.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonProdutos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // buttonVendas
            // 
            this.buttonVendas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(80)))));
            this.buttonVendas.FlatAppearance.BorderSize = 0;
            this.buttonVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVendas.ForeColor = System.Drawing.Color.White;
            this.buttonVendas.Image = ((System.Drawing.Image)(resources.GetObject("buttonVendas.Image")));
            this.buttonVendas.Location = new System.Drawing.Point(0, 83);
            this.buttonVendas.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVendas.Name = "buttonVendas";
            this.buttonVendas.Size = new System.Drawing.Size(158, 120);
            this.buttonVendas.TabIndex = 5;
            this.buttonVendas.Text = "Vendas";
            this.buttonVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonVendas.UseVisualStyleBackColor = false;
            this.buttonVendas.Click += new System.EventHandler(this.buttonVendas_Click);
            this.buttonVendas.MouseLeave += new System.EventHandler(this.paint_MouseLeave);
            this.buttonVendas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_MouseMove);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(158, 82);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1208, 640);
            this.panelContent.TabIndex = 2;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            // 
            // buttonTitlerSair
            // 
            this.buttonTitlerSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTitlerSair.FlatAppearance.BorderSize = 0;
            this.buttonTitlerSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTitlerSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTitlerSair.Location = new System.Drawing.Point(1156, 0);
            this.buttonTitlerSair.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTitlerSair.Name = "buttonTitlerSair";
            this.buttonTitlerSair.Size = new System.Drawing.Size(52, 30);
            this.buttonTitlerSair.TabIndex = 0;
            this.buttonTitlerSair.Text = "X";
            this.buttonTitlerSair.UseVisualStyleBackColor = true;
            this.buttonTitlerSair.Click += new System.EventHandler(this.buttonTitlerSair_Click);
            this.buttonTitlerSair.MouseLeave += new System.EventHandler(this.buttonTitlerSair_MouseLeave);
            this.buttonTitlerSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonTitlerSair_MouseMove);
            // 
            // buttonTitlerMaximizar
            // 
            this.buttonTitlerMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTitlerMaximizar.FlatAppearance.BorderSize = 0;
            this.buttonTitlerMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTitlerMaximizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTitlerMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonTitlerMaximizar.Image")));
            this.buttonTitlerMaximizar.Location = new System.Drawing.Point(1109, 0);
            this.buttonTitlerMaximizar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTitlerMaximizar.Name = "buttonTitlerMaximizar";
            this.buttonTitlerMaximizar.Size = new System.Drawing.Size(46, 30);
            this.buttonTitlerMaximizar.TabIndex = 2;
            this.buttonTitlerMaximizar.UseVisualStyleBackColor = true;
            this.buttonTitlerMaximizar.Click += new System.EventHandler(this.buttonTitlerMaximizar_Click);
            // 
            // buttonTitlerMinimizar
            // 
            this.buttonTitlerMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTitlerMinimizar.FlatAppearance.BorderSize = 0;
            this.buttonTitlerMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTitlerMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTitlerMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonTitlerMinimizar.Image")));
            this.buttonTitlerMinimizar.Location = new System.Drawing.Point(1060, 0);
            this.buttonTitlerMinimizar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTitlerMinimizar.Name = "buttonTitlerMinimizar";
            this.buttonTitlerMinimizar.Size = new System.Drawing.Size(46, 30);
            this.buttonTitlerMinimizar.TabIndex = 1;
            this.buttonTitlerMinimizar.UseVisualStyleBackColor = true;
            this.buttonTitlerMinimizar.Click += new System.EventHandler(this.buttonTitlerMinimizar_Click);
            // 
            // paneTitlerBar
            // 
            this.paneTitlerBar.Controls.Add(this.labelNameEstebelecimento);
            this.paneTitlerBar.Controls.Add(labelLinhaTopo);
            this.paneTitlerBar.Controls.Add(this.buttonAjuda);
            this.paneTitlerBar.Controls.Add(this.labelUsuario);
            this.paneTitlerBar.Controls.Add(labelTitulo);
            this.paneTitlerBar.Controls.Add(this.buttonTitlerMinimizar);
            this.paneTitlerBar.Controls.Add(this.buttonTitlerMaximizar);
            this.paneTitlerBar.Controls.Add(this.buttonTitlerSair);
            this.paneTitlerBar.Controls.Add(this.pictureBoxPapelParede);
            this.paneTitlerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneTitlerBar.Location = new System.Drawing.Point(158, 0);
            this.paneTitlerBar.Margin = new System.Windows.Forms.Padding(0);
            this.paneTitlerBar.Name = "paneTitlerBar";
            this.paneTitlerBar.Size = new System.Drawing.Size(1208, 82);
            this.paneTitlerBar.TabIndex = 1;
            this.paneTitlerBar.Paint += new System.Windows.Forms.PaintEventHandler(this.paneTitlerBar_Paint);
            // 
            // labelNameEstebelecimento
            // 
            this.labelNameEstebelecimento.AutoSize = true;
            this.labelNameEstebelecimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameEstebelecimento.Location = new System.Drawing.Point(18, 43);
            this.labelNameEstebelecimento.Name = "labelNameEstebelecimento";
            this.labelNameEstebelecimento.Size = new System.Drawing.Size(211, 29);
            this.labelNameEstebelecimento.TabIndex = 3;
            this.labelNameEstebelecimento.Text = "Agropecuaria TX";
            // 
            // buttonAjuda
            // 
            this.buttonAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjuda.FlatAppearance.BorderSize = 0;
            this.buttonAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjuda.Location = new System.Drawing.Point(996, -1);
            this.buttonAjuda.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAjuda.Name = "buttonAjuda";
            this.buttonAjuda.Size = new System.Drawing.Size(46, 30);
            this.buttonAjuda.TabIndex = 6;
            this.buttonAjuda.Text = "?";
            this.buttonAjuda.UseVisualStyleBackColor = true;
            this.buttonAjuda.Click += new System.EventHandler(this.buttonAjuda_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(803, 8);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(175, 17);
            this.labelUsuario.TabIndex = 5;
            this.labelUsuario.Text = "Fernando | Desenvolvedor";
            // 
            // pictureBoxPapelParede
            // 
            this.pictureBoxPapelParede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPapelParede.Location = new System.Drawing.Point(734, 0);
            this.pictureBoxPapelParede.Name = "pictureBoxPapelParede";
            this.pictureBoxPapelParede.Size = new System.Drawing.Size(474, 64);
            this.pictureBoxPapelParede.TabIndex = 8;
            this.pictureBoxPapelParede.TabStop = false;
            // 
            // FormHighGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 722);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.paneTitlerBar);
            this.Controls.Add(this.panelMenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1366, 722);
            this.Name = "FormHighGestor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHighGestor_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormHighGestor_Paint);
            this.panelMenuBar.ResumeLayout(false);
            this.panelMenuBar.PerformLayout();
            this.paneTitlerBar.ResumeLayout(false);
            this.paneTitlerBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPapelParede)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuBar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonTitlerSair;
        private System.Windows.Forms.Button buttonTitlerMaximizar;
        private System.Windows.Forms.Button buttonTitlerMinimizar;
        private System.Windows.Forms.Panel paneTitlerBar;
        private System.Windows.Forms.Label labelNameEstebelecimento;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button buttonCompras;
        private System.Windows.Forms.Button buttonConfiguracoes;
        private System.Windows.Forms.Button buttonRelatorio;
        private System.Windows.Forms.Button buttonFinanceiro;
        private System.Windows.Forms.Button buttonClientes;
        private System.Windows.Forms.Button buttonProdutos;
        private System.Windows.Forms.Button buttonVendas;
        private System.Windows.Forms.Button buttonAjuda;
        private System.Windows.Forms.PictureBox pictureBoxPapelParede;
    }
}

