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
            System.Windows.Forms.Label label1EsqueceuSenha;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.containerPai = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRecupereAqui = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonMostrarSenha = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            labelTitulo = new System.Windows.Forms.Label();
            label1EsqueceuSenha = new System.Windows.Forms.Label();
            this.containerPai.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelTitulo.Font = new System.Drawing.Font("Microsoft PhagsPa", 22F, System.Drawing.FontStyle.Bold);
            labelTitulo.ForeColor = System.Drawing.Color.Black;
            labelTitulo.Location = new System.Drawing.Point(96, 69);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new System.Drawing.Size(186, 39);
            labelTitulo.TabIndex = 37;
            labelTitulo.Text = "High Gestor";
            // 
            // label1EsqueceuSenha
            // 
            label1EsqueceuSenha.AutoSize = true;
            label1EsqueceuSenha.Cursor = System.Windows.Forms.Cursors.Default;
            label1EsqueceuSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1EsqueceuSenha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1EsqueceuSenha.Location = new System.Drawing.Point(28, 362);
            label1EsqueceuSenha.Name = "label1EsqueceuSenha";
            label1EsqueceuSenha.Size = new System.Drawing.Size(129, 15);
            label1EsqueceuSenha.TabIndex = 42;
            label1EsqueceuSenha.Text = "Esqueceu sua senha?";
            // 
            // containerPai
            // 
            this.containerPai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.containerPai.Controls.Add(this.pictureBoxImage);
            this.containerPai.Controls.Add(this.panel1);
            this.containerPai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPai.Location = new System.Drawing.Point(0, 0);
            this.containerPai.Margin = new System.Windows.Forms.Padding(0);
            this.containerPai.Name = "containerPai";
            this.containerPai.Size = new System.Drawing.Size(800, 450);
            this.containerPai.TabIndex = 1;
            this.containerPai.Paint += new System.Windows.Forms.PaintEventHandler(this.containerPai_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.buttonMostrarSenha);
            this.panel1.Controls.Add(this.labelRecupereAqui);
            this.panel1.Controls.Add(label1EsqueceuSenha);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(labelTitulo);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnEntrar);
            this.panel1.Controls.Add(this.textBoxSenha);
            this.panel1.Controls.Add(this.textBoxUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(339, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 450);
            this.panel1.TabIndex = 0;
            // 
            // labelRecupereAqui
            // 
            this.labelRecupereAqui.AutoSize = true;
            this.labelRecupereAqui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRecupereAqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecupereAqui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(134)))));
            this.labelRecupereAqui.Location = new System.Drawing.Point(154, 362);
            this.labelRecupereAqui.Name = "labelRecupereAqui";
            this.labelRecupereAqui.Size = new System.Drawing.Size(88, 15);
            this.labelRecupereAqui.TabIndex = 43;
            this.labelRecupereAqui.Text = "Recupere aqui";
            this.labelRecupereAqui.Click += new System.EventHandler(this.labelRecupereAqui_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSair.Location = new System.Drawing.Point(421, 4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(35, 30);
            this.btnSair.TabIndex = 36;
            this.btnSair.Text = "X";
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
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEntrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEntrar.Location = new System.Drawing.Point(31, 285);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(319, 35);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            this.btnEntrar.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEntrar_Paint);
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.BackColor = System.Drawing.Color.White;
            this.textBoxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxSenha.ForeColor = System.Drawing.Color.Black;
            this.textBoxSenha.Location = new System.Drawing.Point(31, 216);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(319, 29);
            this.textBoxSenha.TabIndex = 29;
            this.textBoxSenha.UseSystemPasswordChar = true;
            this.textBoxSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSenha_KeyUp);
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.Color.White;
            this.textBoxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxUsuario.ForeColor = System.Drawing.Color.Black;
            this.textBoxUsuario.Location = new System.Drawing.Point(31, 157);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(319, 29);
            this.textBoxUsuario.TabIndex = 27;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxImage.Image")));
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(339, 450);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxImage_Paint);
            // 
            // buttonMostrarSenha
            // 
            this.buttonMostrarSenha.BackColor = System.Drawing.Color.White;
            this.buttonMostrarSenha.FlatAppearance.BorderSize = 0;
            this.buttonMostrarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrarSenha.Image = global::High_Gestor.Properties.Resources.eyes;
            this.buttonMostrarSenha.Location = new System.Drawing.Point(320, 220);
            this.buttonMostrarSenha.Name = "buttonMostrarSenha";
            this.buttonMostrarSenha.Size = new System.Drawing.Size(27, 20);
            this.buttonMostrarSenha.TabIndex = 44;
            this.buttonMostrarSenha.UseVisualStyleBackColor = false;
            this.buttonMostrarSenha.Click += new System.EventHandler(this.buttonMostrarSenha_Click);
            this.buttonMostrarSenha.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonMostrarSenha_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 50);
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
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormLogin_Paint);
            this.containerPai.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerPai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label labelRecupereAqui;
        private System.Windows.Forms.Button buttonMostrarSenha;
    }
}