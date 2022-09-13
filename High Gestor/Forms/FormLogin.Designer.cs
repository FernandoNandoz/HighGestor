namespace High_Gestor.Forms
{
    partial class FormLogin
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
            System.Windows.Forms.Label labelTitulo;
            System.Windows.Forms.Label labelSenha;
            System.Windows.Forms.Label labelUsuario;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            System.Windows.Forms.Label label2;
            this.containerPai = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxMostrarSenha = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            labelTitulo = new System.Windows.Forms.Label();
            labelSenha = new System.Windows.Forms.Label();
            labelUsuario = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.containerPai.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // containerPai
            // 
            this.containerPai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.containerPai.Controls.Add(label2);
            this.containerPai.Controls.Add(this.pictureBox1);
            this.containerPai.Controls.Add(this.panel1);
            this.containerPai.Controls.Add(label3);
            this.containerPai.Controls.Add(label4);
            this.containerPai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPai.Location = new System.Drawing.Point(0, 0);
            this.containerPai.Name = "containerPai";
            this.containerPai.Size = new System.Drawing.Size(800, 450);
            this.containerPai.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.checkBoxMostrarSenha);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(labelTitulo);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnEntrar);
            this.panel1.Controls.Add(labelSenha);
            this.panel1.Controls.Add(this.textBoxSenha);
            this.panel1.Controls.Add(labelUsuario);
            this.panel1.Controls.Add(this.textBoxUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(387, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 450);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxMostrarSenha
            // 
            this.checkBoxMostrarSenha.AutoSize = true;
            this.checkBoxMostrarSenha.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F);
            this.checkBoxMostrarSenha.ForeColor = System.Drawing.Color.Black;
            this.checkBoxMostrarSenha.Location = new System.Drawing.Point(38, 285);
            this.checkBoxMostrarSenha.Name = "checkBoxMostrarSenha";
            this.checkBoxMostrarSenha.Size = new System.Drawing.Size(116, 22);
            this.checkBoxMostrarSenha.TabIndex = 39;
            this.checkBoxMostrarSenha.Text = "Mostrar senha";
            this.checkBoxMostrarSenha.UseVisualStyleBackColor = true;
            this.checkBoxMostrarSenha.CheckedChanged += new System.EventHandler(this.checkBoxMostrarSenha_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft PhagsPa", 14F);
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(126, 391);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(169, 24);
            this.linkLabel1.TabIndex = 38;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Esqueceu a senha?";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelTitulo.Font = new System.Drawing.Font("Microsoft PhagsPa", 26F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.Color.Black;
            labelTitulo.Location = new System.Drawing.Point(131, 42);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(218, 46);
            labelTitulo.TabIndex = 37;
            labelTitulo.Text = "High Gestor";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSair.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSair.Location = new System.Drawing.Point(216, 335);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(138, 35);
            this.btnSair.TabIndex = 36;
            this.btnSair.Text = "Fechar";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSair_Paint);
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnEntrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEntrar.Location = new System.Drawing.Point(60, 335);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(138, 35);
            this.btnEntrar.TabIndex = 35;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            this.btnEntrar.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEntrar_Paint);
            // 
            // labelSenha
            // 
            labelSenha.AutoSize = true;
            labelSenha.Font = new System.Drawing.Font("Microsoft PhagsPa", 18F);
            labelSenha.ForeColor = System.Drawing.Color.Black;
            labelSenha.Location = new System.Drawing.Point(29, 214);
            labelSenha.Name = "labelSenha";
            labelSenha.Size = new System.Drawing.Size(80, 31);
            labelSenha.TabIndex = 30;
            labelSenha.Text = "Senha";
            labelSenha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.textBoxSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.textBoxSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.textBoxSenha.Location = new System.Drawing.Point(34, 246);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(341, 34);
            this.textBoxSenha.TabIndex = 29;
            this.textBoxSenha.UseSystemPasswordChar = true;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Font = new System.Drawing.Font("Microsoft PhagsPa", 18F);
            labelUsuario.ForeColor = System.Drawing.Color.Black;
            labelUsuario.Location = new System.Drawing.Point(29, 134);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new System.Drawing.Size(94, 31);
            labelUsuario.TabIndex = 28;
            labelUsuario.Text = "Usuário";
            labelUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.textBoxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.textBoxUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            this.textBoxUsuario.Location = new System.Drawing.Point(34, 166);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(341, 34);
            this.textBoxUsuario.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label3.Location = new System.Drawing.Point(13, 254);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(360, 26);
            label3.TabIndex = 39;
            label3.Text = "_____________________________";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(203)))), ((int)(((byte)(205)))));
            label4.Location = new System.Drawing.Point(13, 411);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(360, 26);
            label4.TabIndex = 40;
            label4.Text = "_____________________________";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(18, 283);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(355, 142);
            label2.TabIndex = 38;
            label2.Text = "     O High Gestor é um sistema de Gestão Empresarial pensado e desenvolvido para" +
    " ajudar o pequeno e medio empreendedor na gestão da sua empresa de forma simples" +
    " e rápida.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(48, 34);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.containerPai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.containerPai.ResumeLayout(false);
            this.containerPai.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerPai;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxMostrarSenha;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}