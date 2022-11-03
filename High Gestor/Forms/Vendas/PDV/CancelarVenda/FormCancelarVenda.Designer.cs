namespace High_Gestor.Forms.Vendas.PDV.CancelarVenda
{
    partial class FormCancelarVenda
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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCancelarVenda));
            this.radioButtonCaixa = new System.Windows.Forms.RadioButton();
            this.radioButtonConta = new System.Windows.Forms.RadioButton();
            this.pictureBoxInformativo = new System.Windows.Forms.PictureBox();
            this.checkBoxEstornarContasReceber = new System.Windows.Forms.CheckBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelValueTotal = new System.Windows.Forms.Label();
            this.panelEstornarContasReceber = new System.Windows.Forms.Panel();
            this.panelHeaderContent = new System.Windows.Forms.Panel();
            this.checkBoxEstornarEstoque = new System.Windows.Forms.CheckBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInformativo)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelEstornarContasReceber.SuspendLayout();
            this.panelHeaderContent.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(58, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(139, 17);
            label1.TabIndex = 0;
            label1.Text = "Estorno em dinheiro:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(this.radioButtonCaixa);
            flowLayoutPanel1.Controls.Add(this.radioButtonConta);
            flowLayoutPanel1.Controls.Add(this.pictureBoxInformativo);
            flowLayoutPanel1.Location = new System.Drawing.Point(61, 28);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(200, 27);
            flowLayoutPanel1.TabIndex = 227;
            // 
            // radioButtonCaixa
            // 
            this.radioButtonCaixa.AutoSize = true;
            this.radioButtonCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonCaixa.Location = new System.Drawing.Point(3, 3);
            this.radioButtonCaixa.Name = "radioButtonCaixa";
            this.radioButtonCaixa.Size = new System.Drawing.Size(60, 21);
            this.radioButtonCaixa.TabIndex = 2;
            this.radioButtonCaixa.Text = "Caixa";
            this.radioButtonCaixa.UseVisualStyleBackColor = true;
            this.radioButtonCaixa.CheckedChanged += new System.EventHandler(this.radioButtonCaixa_CheckedChanged);
            // 
            // radioButtonConta
            // 
            this.radioButtonConta.AutoSize = true;
            this.radioButtonConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonConta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonConta.Location = new System.Drawing.Point(96, 3);
            this.radioButtonConta.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.radioButtonConta.Name = "radioButtonConta";
            this.radioButtonConta.Size = new System.Drawing.Size(63, 21);
            this.radioButtonConta.TabIndex = 3;
            this.radioButtonConta.Text = "Conta";
            this.radioButtonConta.UseVisualStyleBackColor = true;
            this.radioButtonConta.CheckedChanged += new System.EventHandler(this.radioButtonConta_CheckedChanged);
            // 
            // pictureBoxInformativo
            // 
            this.pictureBoxInformativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxInformativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxInformativo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInformativo.Image")));
            this.pictureBoxInformativo.Location = new System.Drawing.Point(162, 6);
            this.pictureBoxInformativo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 5);
            this.pictureBoxInformativo.Name = "pictureBoxInformativo";
            this.pictureBoxInformativo.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxInformativo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxInformativo.TabIndex = 253;
            this.pictureBoxInformativo.TabStop = false;
            this.pictureBoxInformativo.Click += new System.EventHandler(this.pictureBoxInformativo_MouseEnter);
            this.pictureBoxInformativo.MouseEnter += new System.EventHandler(this.pictureBoxInformativo_MouseEnter);
            // 
            // checkBoxEstornarContasReceber
            // 
            this.checkBoxEstornarContasReceber.AutoSize = true;
            this.checkBoxEstornarContasReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEstornarContasReceber.Location = new System.Drawing.Point(42, 6);
            this.checkBoxEstornarContasReceber.Name = "checkBoxEstornarContasReceber";
            this.checkBoxEstornarContasReceber.Size = new System.Drawing.Size(192, 21);
            this.checkBoxEstornarContasReceber.TabIndex = 0;
            this.checkBoxEstornarContasReceber.Text = "Estornar contas a receber";
            this.checkBoxEstornarContasReceber.UseVisualStyleBackColor = true;
            this.checkBoxEstornarContasReceber.CheckedChanged += new System.EventHandler(this.checkBoxEstornarContasReceber_CheckedChanged);
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTitulo.Location = new System.Drawing.Point(12, 11);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(225, 24);
            this.labelTitulo.TabIndex = 182;
            this.labelTitulo.Text = "Cancelamento de vendas";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(374, 62);
            this.panelTop.TabIndex = 228;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // labelValueTotal
            // 
            this.labelValueTotal.AutoSize = true;
            this.labelValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelValueTotal.Location = new System.Drawing.Point(198, 7);
            this.labelValueTotal.Name = "labelValueTotal";
            this.labelValueTotal.Size = new System.Drawing.Size(58, 17);
            this.labelValueTotal.TabIndex = 1;
            this.labelValueTotal.Text = "R$ 0,00";
            // 
            // panelEstornarContasReceber
            // 
            this.panelEstornarContasReceber.Controls.Add(this.checkBoxEstornarContasReceber);
            this.panelEstornarContasReceber.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEstornarContasReceber.Location = new System.Drawing.Point(0, 62);
            this.panelEstornarContasReceber.Margin = new System.Windows.Forms.Padding(0);
            this.panelEstornarContasReceber.Name = "panelEstornarContasReceber";
            this.panelEstornarContasReceber.Size = new System.Drawing.Size(374, 32);
            this.panelEstornarContasReceber.TabIndex = 227;
            // 
            // panelHeaderContent
            // 
            this.panelHeaderContent.Controls.Add(label1);
            this.panelHeaderContent.Controls.Add(this.labelValueTotal);
            this.panelHeaderContent.Controls.Add(flowLayoutPanel1);
            this.panelHeaderContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderContent.Location = new System.Drawing.Point(0, 94);
            this.panelHeaderContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeaderContent.Name = "panelHeaderContent";
            this.panelHeaderContent.Size = new System.Drawing.Size(374, 55);
            this.panelHeaderContent.TabIndex = 229;
            // 
            // checkBoxEstornarEstoque
            // 
            this.checkBoxEstornarEstoque.AutoSize = true;
            this.checkBoxEstornarEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEstornarEstoque.Location = new System.Drawing.Point(42, 13);
            this.checkBoxEstornarEstoque.Name = "checkBoxEstornarEstoque";
            this.checkBoxEstornarEstoque.Size = new System.Drawing.Size(136, 21);
            this.checkBoxEstornarEstoque.TabIndex = 1;
            this.checkBoxEstornarEstoque.Text = "Estornar estoque";
            this.checkBoxEstornarEstoque.UseVisualStyleBackColor = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSalvar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSalvar.Location = new System.Drawing.Point(248, 53);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(100, 27);
            this.buttonSalvar.TabIndex = 226;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Concluir";
            this.buttonSalvar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSalvar_Paint);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 149);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(374, 149);
            this.panelContent.TabIndex = 230;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonSalvar);
            this.panelBottom.Controls.Add(this.checkBoxEstornarEstoque);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 202);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(374, 96);
            this.panelBottom.TabIndex = 231;
            // 
            // FormCancelarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 298);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeaderContent);
            this.Controls.Add(this.panelEstornarContasReceber);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCancelarVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Gestor - Cancelar Venda";
            this.Load += new System.EventHandler(this.FormCancelarVenda_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormCancelarVenda_Paint);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInformativo)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelEstornarContasReceber.ResumeLayout(false);
            this.panelEstornarContasReceber.PerformLayout();
            this.panelHeaderContent.ResumeLayout(false);
            this.panelHeaderContent.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEstornarContasReceber;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelValueTotal;
        private System.Windows.Forms.RadioButton radioButtonCaixa;
        private System.Windows.Forms.RadioButton radioButtonConta;
        private System.Windows.Forms.Panel panelEstornarContasReceber;
        private System.Windows.Forms.Panel panelHeaderContent;
        private System.Windows.Forms.CheckBox checkBoxEstornarEstoque;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox pictureBoxInformativo;
    }
}