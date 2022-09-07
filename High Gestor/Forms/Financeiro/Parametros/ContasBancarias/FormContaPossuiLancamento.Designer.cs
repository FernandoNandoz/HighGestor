namespace High_Gestor.Forms.Financeiro.Parametros.ContasBancarias
{
    partial class FormContaPossuiLancamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContaPossuiLancamento));
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label29;
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonInativarConta = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNomeConta = new System.Windows.Forms.Label();
            this.flowLayoutPanelBanco = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxDespesas = new System.Windows.Forms.PictureBox();
            this.pictureBoxReceitas = new System.Windows.Forms.PictureBox();
            this.labelValueNomeBanco = new System.Windows.Forms.Label();
            this.pictureBoxSituacao = new System.Windows.Forms.PictureBox();
            panel3 = new System.Windows.Forms.Panel();
            label25 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            panel3.SuspendLayout();
            this.flowLayoutPanelBanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDespesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSituacao)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTitulo.Location = new System.Drawing.Point(12, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(222, 24);
            this.labelTitulo.TabIndex = 172;
            this.labelTitulo.Text = "Conta possui lançamento";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 80);
            this.panel1.TabIndex = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(625, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // buttonInativarConta
            // 
            this.buttonInativarConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonInativarConta.FlatAppearance.BorderSize = 0;
            this.buttonInativarConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInativarConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInativarConta.ForeColor = System.Drawing.Color.White;
            this.buttonInativarConta.Location = new System.Drawing.Point(16, 244);
            this.buttonInativarConta.Margin = new System.Windows.Forms.Padding(5);
            this.buttonInativarConta.Name = "buttonInativarConta";
            this.buttonInativarConta.Size = new System.Drawing.Size(167, 32);
            this.buttonInativarConta.TabIndex = 237;
            this.buttonInativarConta.Text = "Inativar conta";
            this.buttonInativarConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonInativarConta.UseVisualStyleBackColor = false;
            this.buttonInativarConta.Click += new System.EventHandler(this.buttonInativarConta_Click);
            this.buttonInativarConta.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBoxSituacao);
            this.panel2.Controls.Add(this.flowLayoutPanelBanco);
            this.panel2.Controls.Add(this.labelNomeConta);
            this.panel2.Controls.Add(panel3);
            this.panel2.Location = new System.Drawing.Point(16, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 76);
            this.panel2.TabIndex = 174;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            panel3.Controls.Add(label25);
            panel3.Controls.Add(label27);
            panel3.Controls.Add(label29);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(727, 25);
            panel3.TabIndex = 244;
            // 
            // label25
            // 
            label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.ForeColor = System.Drawing.SystemColors.ControlText;
            label25.Location = new System.Drawing.Point(646, 5);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(60, 16);
            label25.TabIndex = 234;
            label25.Text = "Situação";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.ForeColor = System.Drawing.SystemColors.ControlText;
            label27.Location = new System.Drawing.Point(19, 5);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(99, 16);
            label27.TabIndex = 233;
            label27.Text = "Nome da conta";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.ForeColor = System.Drawing.SystemColors.ControlText;
            label29.Location = new System.Drawing.Point(194, 5);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(46, 16);
            label29.TabIndex = 231;
            label29.Text = "Banco";
            // 
            // labelNomeConta
            // 
            this.labelNomeConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeConta.Location = new System.Drawing.Point(22, 39);
            this.labelNomeConta.Name = "labelNomeConta";
            this.labelNomeConta.Size = new System.Drawing.Size(168, 20);
            this.labelNomeConta.TabIndex = 245;
            this.labelNomeConta.Text = "nomeConta";
            // 
            // flowLayoutPanelBanco
            // 
            this.flowLayoutPanelBanco.Controls.Add(this.labelValueNomeBanco);
            this.flowLayoutPanelBanco.Controls.Add(this.pictureBoxReceitas);
            this.flowLayoutPanelBanco.Controls.Add(this.pictureBoxDespesas);
            this.flowLayoutPanelBanco.Location = new System.Drawing.Point(198, 39);
            this.flowLayoutPanelBanco.Name = "flowLayoutPanelBanco";
            this.flowLayoutPanelBanco.Size = new System.Drawing.Size(446, 18);
            this.flowLayoutPanelBanco.TabIndex = 246;
            // 
            // pictureBoxDespesas
            // 
            this.pictureBoxDespesas.Image = global::High_Gestor.Properties.Resources.padrao_despesas_1;
            this.pictureBoxDespesas.Location = new System.Drawing.Point(206, 0);
            this.pictureBoxDespesas.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxDespesas.Name = "pictureBoxDespesas";
            this.pictureBoxDespesas.Size = new System.Drawing.Size(130, 18);
            this.pictureBoxDespesas.TabIndex = 251;
            this.pictureBoxDespesas.TabStop = false;
            // 
            // pictureBoxReceitas
            // 
            this.pictureBoxReceitas.Image = global::High_Gestor.Properties.Resources.padrao_receitas;
            this.pictureBoxReceitas.Location = new System.Drawing.Point(75, 0);
            this.pictureBoxReceitas.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pictureBoxReceitas.Name = "pictureBoxReceitas";
            this.pictureBoxReceitas.Size = new System.Drawing.Size(130, 18);
            this.pictureBoxReceitas.TabIndex = 250;
            this.pictureBoxReceitas.TabStop = false;
            // 
            // labelValueNomeBanco
            // 
            this.labelValueNomeBanco.AutoSize = true;
            this.labelValueNomeBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueNomeBanco.Location = new System.Drawing.Point(0, 0);
            this.labelValueNomeBanco.Margin = new System.Windows.Forms.Padding(0);
            this.labelValueNomeBanco.MaximumSize = new System.Drawing.Size(184, 18);
            this.labelValueNomeBanco.Name = "labelValueNomeBanco";
            this.labelValueNomeBanco.Size = new System.Drawing.Size(74, 15);
            this.labelValueNomeBanco.TabIndex = 249;
            this.labelValueNomeBanco.Text = "nomeBanco";
            // 
            // pictureBoxSituacao
            // 
            this.pictureBoxSituacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSituacao.Image = global::High_Gestor.Properties.Resources.verde;
            this.pictureBoxSituacao.Location = new System.Drawing.Point(666, 39);
            this.pictureBoxSituacao.Name = "pictureBoxSituacao";
            this.pictureBoxSituacao.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSituacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSituacao.TabIndex = 247;
            this.pictureBoxSituacao.TabStop = false;
            // 
            // FormContaPossuiLancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 292);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonInativarConta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormContaPossuiLancamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor - Conta Possui Lançamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormContaPossuiLancamento_FormClosing);
            this.Load += new System.EventHandler(this.FormContaPossuiLancamento_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormContaPossuiLancamento_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            this.flowLayoutPanelBanco.ResumeLayout(false);
            this.flowLayoutPanelBanco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDespesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSituacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonInativarConta;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBanco;
        private System.Windows.Forms.Label labelValueNomeBanco;
        private System.Windows.Forms.PictureBox pictureBoxReceitas;
        private System.Windows.Forms.PictureBox pictureBoxDespesas;
        private System.Windows.Forms.Label labelNomeConta;
        private System.Windows.Forms.PictureBox pictureBoxSituacao;
    }
}