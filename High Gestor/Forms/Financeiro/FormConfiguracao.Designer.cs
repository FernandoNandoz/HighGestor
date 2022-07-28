namespace High_Gestor.Forms.Financeiro
{
    partial class FormConfiguracao
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguracao));
            this.panelMenuConfig = new System.Windows.Forms.Panel();
            this.buttonFormaPagamento = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonControleCustos = new System.Windows.Forms.Button();
            this.buttonControleContas = new System.Windows.Forms.Button();
            this.buttonConfigContasPagar = new System.Windows.Forms.Button();
            this.buttonConfigContasReceber = new System.Windows.Forms.Button();
            this.buttonControleCaixa = new System.Windows.Forms.Button();
            this.buttonSairOutrasOpcoes = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.panelMenuConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.White;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(16, 66);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label1.Size = new System.Drawing.Size(56, 20);
            label1.TabIndex = 95;
            label1.Text = "Caixa";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.White;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label3.Location = new System.Drawing.Point(17, 154);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label3.Size = new System.Drawing.Size(150, 20);
            label3.TabIndex = 99;
            label3.Text = "Contas a receber";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = System.Drawing.Color.White;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label7.Location = new System.Drawing.Point(17, 242);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label7.Size = new System.Drawing.Size(135, 20);
            label7.TabIndex = 100;
            label7.Text = "Contas a pagar";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = System.Drawing.Color.White;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label8.Location = new System.Drawing.Point(17, 330);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            label8.Size = new System.Drawing.Size(66, 20);
            label8.TabIndex = 101;
            label8.Text = "Outros";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMenuConfig
            // 
            this.panelMenuConfig.Controls.Add(this.buttonFormaPagamento);
            this.panelMenuConfig.Controls.Add(this.button6);
            this.panelMenuConfig.Controls.Add(this.buttonControleCustos);
            this.panelMenuConfig.Controls.Add(this.buttonControleContas);
            this.panelMenuConfig.Controls.Add(this.buttonConfigContasPagar);
            this.panelMenuConfig.Controls.Add(this.buttonConfigContasReceber);
            this.panelMenuConfig.Controls.Add(label8);
            this.panelMenuConfig.Controls.Add(label7);
            this.panelMenuConfig.Controls.Add(label3);
            this.panelMenuConfig.Controls.Add(label1);
            this.panelMenuConfig.Controls.Add(this.buttonControleCaixa);
            this.panelMenuConfig.Controls.Add(this.buttonSairOutrasOpcoes);
            this.panelMenuConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuConfig.Location = new System.Drawing.Point(0, 0);
            this.panelMenuConfig.Name = "panelMenuConfig";
            this.panelMenuConfig.Size = new System.Drawing.Size(252, 670);
            this.panelMenuConfig.TabIndex = 0;
            this.panelMenuConfig.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenuConfig_Paint);
            // 
            // buttonFormaPagamento
            // 
            this.buttonFormaPagamento.FlatAppearance.BorderSize = 0;
            this.buttonFormaPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonFormaPagamento.Image = ((System.Drawing.Image)(resources.GetObject("buttonFormaPagamento.Image")));
            this.buttonFormaPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFormaPagamento.Location = new System.Drawing.Point(30, 520);
            this.buttonFormaPagamento.Name = "buttonFormaPagamento";
            this.buttonFormaPagamento.Size = new System.Drawing.Size(220, 50);
            this.buttonFormaPagamento.TabIndex = 107;
            this.buttonFormaPagamento.Text = "   Formas de Pagamento";
            this.buttonFormaPagamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFormaPagamento.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button6.Location = new System.Drawing.Point(30, 464);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(220, 50);
            this.button6.TabIndex = 106;
            this.button6.Text = "????";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // buttonControleCustos
            // 
            this.buttonControleCustos.FlatAppearance.BorderSize = 0;
            this.buttonControleCustos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControleCustos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonControleCustos.Image = ((System.Drawing.Image)(resources.GetObject("buttonControleCustos.Image")));
            this.buttonControleCustos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonControleCustos.Location = new System.Drawing.Point(30, 408);
            this.buttonControleCustos.Name = "buttonControleCustos";
            this.buttonControleCustos.Size = new System.Drawing.Size(220, 50);
            this.buttonControleCustos.TabIndex = 105;
            this.buttonControleCustos.Text = "   Controle de Custos";
            this.buttonControleCustos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonControleCustos.UseVisualStyleBackColor = true;
            // 
            // buttonControleContas
            // 
            this.buttonControleContas.FlatAppearance.BorderSize = 0;
            this.buttonControleContas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControleContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonControleContas.Image = ((System.Drawing.Image)(resources.GetObject("buttonControleContas.Image")));
            this.buttonControleContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonControleContas.Location = new System.Drawing.Point(30, 352);
            this.buttonControleContas.Name = "buttonControleContas";
            this.buttonControleContas.Size = new System.Drawing.Size(220, 50);
            this.buttonControleContas.TabIndex = 104;
            this.buttonControleContas.Text = "   Controle de Contas";
            this.buttonControleContas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonControleContas.UseVisualStyleBackColor = true;
            // 
            // buttonConfigContasPagar
            // 
            this.buttonConfigContasPagar.FlatAppearance.BorderSize = 0;
            this.buttonConfigContasPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigContasPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfigContasPagar.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigContasPagar.Image")));
            this.buttonConfigContasPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfigContasPagar.Location = new System.Drawing.Point(30, 267);
            this.buttonConfigContasPagar.Name = "buttonConfigContasPagar";
            this.buttonConfigContasPagar.Size = new System.Drawing.Size(220, 50);
            this.buttonConfigContasPagar.TabIndex = 103;
            this.buttonConfigContasPagar.Text = "   Config Contas Pagar";
            this.buttonConfigContasPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonConfigContasPagar.UseVisualStyleBackColor = true;
            this.buttonConfigContasPagar.Click += new System.EventHandler(this.buttonConfigContasPagar_Click);
            // 
            // buttonConfigContasReceber
            // 
            this.buttonConfigContasReceber.FlatAppearance.BorderSize = 0;
            this.buttonConfigContasReceber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfigContasReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfigContasReceber.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigContasReceber.Image")));
            this.buttonConfigContasReceber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfigContasReceber.Location = new System.Drawing.Point(30, 179);
            this.buttonConfigContasReceber.Name = "buttonConfigContasReceber";
            this.buttonConfigContasReceber.Size = new System.Drawing.Size(220, 50);
            this.buttonConfigContasReceber.TabIndex = 102;
            this.buttonConfigContasReceber.Text = "   Config Contas Receber";
            this.buttonConfigContasReceber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonConfigContasReceber.UseVisualStyleBackColor = true;
            this.buttonConfigContasReceber.Click += new System.EventHandler(this.buttonConfigContasReceber_Click);
            // 
            // buttonControleCaixa
            // 
            this.buttonControleCaixa.FlatAppearance.BorderSize = 0;
            this.buttonControleCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonControleCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonControleCaixa.Image = ((System.Drawing.Image)(resources.GetObject("buttonControleCaixa.Image")));
            this.buttonControleCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonControleCaixa.Location = new System.Drawing.Point(30, 90);
            this.buttonControleCaixa.Name = "buttonControleCaixa";
            this.buttonControleCaixa.Size = new System.Drawing.Size(220, 50);
            this.buttonControleCaixa.TabIndex = 94;
            this.buttonControleCaixa.Text = "   Controle de caixa";
            this.buttonControleCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonControleCaixa.UseVisualStyleBackColor = true;
            this.buttonControleCaixa.Click += new System.EventHandler(this.buttonControleCaixa_Click);
            // 
            // buttonSairOutrasOpcoes
            // 
            this.buttonSairOutrasOpcoes.BackColor = System.Drawing.Color.Transparent;
            this.buttonSairOutrasOpcoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSairOutrasOpcoes.FlatAppearance.BorderSize = 0;
            this.buttonSairOutrasOpcoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSairOutrasOpcoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSairOutrasOpcoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSairOutrasOpcoes.Image = ((System.Drawing.Image)(resources.GetObject("buttonSairOutrasOpcoes.Image")));
            this.buttonSairOutrasOpcoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSairOutrasOpcoes.Location = new System.Drawing.Point(22, 15);
            this.buttonSairOutrasOpcoes.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSairOutrasOpcoes.Name = "buttonSairOutrasOpcoes";
            this.buttonSairOutrasOpcoes.Size = new System.Drawing.Size(217, 35);
            this.buttonSairOutrasOpcoes.TabIndex = 92;
            this.buttonSairOutrasOpcoes.TabStop = false;
            this.buttonSairOutrasOpcoes.Text = " Voltar";
            this.buttonSairOutrasOpcoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSairOutrasOpcoes.UseVisualStyleBackColor = false;
            this.buttonSairOutrasOpcoes.Click += new System.EventHandler(this.buttonSairOutrasOpcoes_Click);
            this.buttonSairOutrasOpcoes.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonSairOutrasOpcoes_Paint);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(252, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1032, 670);
            this.panelContent.TabIndex = 1;
            // 
            // FormConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenuConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConfiguracao";
            this.Load += new System.EventHandler(this.FormConfiguracao_Load);
            this.panelMenuConfig.ResumeLayout(false);
            this.panelMenuConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuConfig;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonSairOutrasOpcoes;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonControleCustos;
        private System.Windows.Forms.Button buttonControleContas;
        private System.Windows.Forms.Button buttonConfigContasPagar;
        private System.Windows.Forms.Button buttonConfigContasReceber;
        private System.Windows.Forms.Button buttonControleCaixa;
        private System.Windows.Forms.Button buttonFormaPagamento;
    }
}