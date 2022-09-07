namespace High_Gestor.Forms.Configuracoes.DadosEmpresa
{
    partial class FormApresentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApresentacao));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSim = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDescricao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // buttonSim
            // 
            this.buttonSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(185)))), ((int)(((byte)(63)))));
            this.buttonSim.FlatAppearance.BorderSize = 0;
            this.buttonSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSim.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSim.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSim.Location = new System.Drawing.Point(322, 69);
            this.buttonSim.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSim.Name = "buttonSim";
            this.buttonSim.Size = new System.Drawing.Size(100, 30);
            this.buttonSim.TabIndex = 50;
            this.buttonSim.Text = "OK (ENTER)";
            this.buttonSim.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSim.UseVisualStyleBackColor = false;
            this.buttonSim.Click += new System.EventHandler(this.buttonSim_Click);
            this.buttonSim.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSim_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // labelDescricao
            // 
            this.labelDescricao.Font = new System.Drawing.Font("Microsoft PhagsPa", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(83)))), ((int)(((byte)(119)))));
            this.labelDescricao.Location = new System.Drawing.Point(74, 12);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(345, 57);
            this.labelDescricao.TabIndex = 51;
            this.labelDescricao.Text = "INFORME OS DADOS DA SUA EMPRESA PARA LIBERAR O ACESSO!";
            // 
            // FormApresentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(445, 109);
            this.Controls.Add(this.buttonSim);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormApresentacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem vindo ao High Gestor!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormApresentacao_FormClosing);
            this.Load += new System.EventHandler(this.FormApresentacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonSim;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDescricao;
    }
}