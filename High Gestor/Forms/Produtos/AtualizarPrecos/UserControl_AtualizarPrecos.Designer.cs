namespace High_Gestor.Forms.Produtos.AtualizarPrecos
{
    partial class UserControl_AtualizarPrecos
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSalvar = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(10, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 18);
            label1.TabIndex = 155;
            label1.Text = "Atualizar preços";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(265, 34);
            this.panelHeader.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 27);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Valor do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lista";
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.AutoScroll = true;
            this.flowLayoutPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(265, 221);
            this.flowLayoutPanelContent.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSalvar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 37);
            this.panel2.TabIndex = 3;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSalvar.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSalvar.Location = new System.Drawing.Point(157, 4);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(100, 27);
            this.buttonSalvar.TabIndex = 225;
            this.buttonSalvar.TabStop = false;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // UserControl_AtualizarPrecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanelContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "UserControl_AtualizarPrecos";
            this.Size = new System.Drawing.Size(265, 282);
            this.Load += new System.EventHandler(this.UserControl_AtualizarPrecos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSalvar;
    }
}
