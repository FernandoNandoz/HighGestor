﻿namespace High_Gestor.Forms.Configuracoes
{
    partial class FormConfiguracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguracoes));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonConfigSistema = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonFornecedores = new System.Windows.Forms.Button();
            this.buttonFuncionarios = new System.Windows.Forms.Button();
            this.buttonCategorias = new System.Windows.Forms.Button();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonConfigSistema);
            this.panelMenu.Controls.Add(this.buttonBackup);
            this.panelMenu.Controls.Add(this.buttonFornecedores);
            this.panelMenu.Controls.Add(this.buttonFuncionarios);
            this.panelMenu.Controls.Add(this.buttonCategorias);
            this.panelMenu.Controls.Add(this.buttonVoltar);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 648);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // buttonConfigSistema
            // 
            this.buttonConfigSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConfigSistema.FlatAppearance.BorderSize = 0;
            this.buttonConfigSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfigSistema.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigSistema.Image")));
            this.buttonConfigSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfigSistema.Location = new System.Drawing.Point(12, 596);
            this.buttonConfigSistema.Name = "buttonConfigSistema";
            this.buttonConfigSistema.Size = new System.Drawing.Size(186, 40);
            this.buttonConfigSistema.TabIndex = 99;
            this.buttonConfigSistema.Text = "   Config Sistema";
            this.buttonConfigSistema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonConfigSistema.UseVisualStyleBackColor = true;
            this.buttonConfigSistema.Click += new System.EventHandler(this.buttonConfigSistema_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBackup.FlatAppearance.BorderSize = 0;
            this.buttonBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBackup.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackup.Image")));
            this.buttonBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackup.Location = new System.Drawing.Point(12, 552);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buttonBackup.Size = new System.Drawing.Size(186, 40);
            this.buttonBackup.TabIndex = 98;
            this.buttonBackup.Text = "   Backup";
            this.buttonBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonFornecedores
            // 
            this.buttonFornecedores.FlatAppearance.BorderSize = 0;
            this.buttonFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFornecedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonFornecedores.Image = ((System.Drawing.Image)(resources.GetObject("buttonFornecedores.Image")));
            this.buttonFornecedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFornecedores.Location = new System.Drawing.Point(12, 98);
            this.buttonFornecedores.Name = "buttonFornecedores";
            this.buttonFornecedores.Size = new System.Drawing.Size(186, 40);
            this.buttonFornecedores.TabIndex = 97;
            this.buttonFornecedores.Text = "   Fornecedores";
            this.buttonFornecedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFornecedores.UseVisualStyleBackColor = true;
            this.buttonFornecedores.Click += new System.EventHandler(this.buttonFornecedores_Click);
            // 
            // buttonFuncionarios
            // 
            this.buttonFuncionarios.FlatAppearance.BorderSize = 0;
            this.buttonFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFuncionarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonFuncionarios.Image = ((System.Drawing.Image)(resources.GetObject("buttonFuncionarios.Image")));
            this.buttonFuncionarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFuncionarios.Location = new System.Drawing.Point(12, 142);
            this.buttonFuncionarios.Name = "buttonFuncionarios";
            this.buttonFuncionarios.Size = new System.Drawing.Size(186, 40);
            this.buttonFuncionarios.TabIndex = 96;
            this.buttonFuncionarios.Text = "   Funcionarios";
            this.buttonFuncionarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFuncionarios.UseVisualStyleBackColor = true;
            this.buttonFuncionarios.Click += new System.EventHandler(this.buttonFuncionarios_Click);
            // 
            // buttonCategorias
            // 
            this.buttonCategorias.FlatAppearance.BorderSize = 0;
            this.buttonCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonCategorias.Image = ((System.Drawing.Image)(resources.GetObject("buttonCategorias.Image")));
            this.buttonCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCategorias.Location = new System.Drawing.Point(12, 54);
            this.buttonCategorias.Name = "buttonCategorias";
            this.buttonCategorias.Size = new System.Drawing.Size(186, 40);
            this.buttonCategorias.TabIndex = 95;
            this.buttonCategorias.Text = "   Categorias";
            this.buttonCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCategorias.UseVisualStyleBackColor = true;
            this.buttonCategorias.Click += new System.EventHandler(this.buttonCategorias_Click);
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
            this.buttonVoltar.Size = new System.Drawing.Size(180, 35);
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
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1008, 648);
            this.panelContent.TabIndex = 1;
            this.panelContent.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelContent_ControlRemoved);
            // 
            // FormConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 648);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConfiguracoes";
            this.Load += new System.EventHandler(this.FormConfiguracoes_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button buttonConfigSistema;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonFornecedores;
        private System.Windows.Forms.Button buttonFuncionarios;
        private System.Windows.Forms.Button buttonCategorias;
    }
}