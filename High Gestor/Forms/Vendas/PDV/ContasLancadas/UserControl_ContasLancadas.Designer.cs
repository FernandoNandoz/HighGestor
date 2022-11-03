namespace High_Gestor.Forms.Vendas.PDV.ContasLancadas
{
    partial class UserControl_ContasLancadas
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
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label29;
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            panel3 = new System.Windows.Forms.Panel();
            label25 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            panel3.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
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
            panel3.Size = new System.Drawing.Size(436, 30);
            panel3.TabIndex = 244;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label25.Location = new System.Drawing.Point(277, 7);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(44, 16);
            label25.TabIndex = 234;
            label25.Text = "Status";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label27.Location = new System.Drawing.Point(13, 7);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(78, 16);
            label27.TabIndex = 233;
            label27.Text = "Vencimento";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label29.Location = new System.Drawing.Point(136, 7);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(39, 16);
            label29.TabIndex = 231;
            label29.Text = "Valor";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.flowLayoutPanelContent);
            this.panelContent.Controls.Add(panel3);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(438, 178);
            this.panelContent.TabIndex = 176;
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.AutoScroll = true;
            this.flowLayoutPanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(0, 30);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(436, 146);
            this.flowLayoutPanelContent.TabIndex = 245;
            // 
            // UserControl_ContasLancadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_ContasLancadas";
            this.Size = new System.Drawing.Size(438, 178);
            this.Load += new System.EventHandler(this.UserControl_ContasLancadas_Load);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
    }
}
