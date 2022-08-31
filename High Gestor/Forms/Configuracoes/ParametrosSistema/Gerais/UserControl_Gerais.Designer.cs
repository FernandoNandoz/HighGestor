namespace High_Gestor.Forms.Configuracoes.ParametrosSistema.Gerais
{
    partial class UserControl_Gerais
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.comboBoxComissionamento = new System.Windows.Forms.ComboBox();
            this.textBoxValorPorcentagem = new System.Windows.Forms.TextBox();
            this.comboBoxComissao = new System.Windows.Forms.ComboBox();
            this.panelValorComissao = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.panelValorComissao.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label2.Location = new System.Drawing.Point(18, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(155, 20);
            label2.TabIndex = 156;
            label2.Text = "Parâmetros gerais";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label4.Location = new System.Drawing.Point(20, 172);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(130, 18);
            label4.TabIndex = 241;
            label4.Text = "Comissionamento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(22, 194);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(215, 15);
            label7.TabIndex = 239;
            label7.Text = "Base de cálculo do comissionamento.";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(30, 524);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(213, 32);
            this.buttonSalvar.TabIndex = 245;
            this.buttonSalvar.Text = "Salvar configurações";
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // comboBoxComissionamento
            // 
            this.comboBoxComissionamento.BackColor = System.Drawing.Color.White;
            this.comboBoxComissionamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComissionamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComissionamento.FormattingEnabled = true;
            this.comboBoxComissionamento.Items.AddRange(new object[] {
            "TOTAL DE VENDAS",
            "TOTAL DE PRODUTOS",
            "TOTAL DE RECEITAS"});
            this.comboBoxComissionamento.Location = new System.Drawing.Point(26, 221);
            this.comboBoxComissionamento.Name = "comboBoxComissionamento";
            this.comboBoxComissionamento.Size = new System.Drawing.Size(299, 26);
            this.comboBoxComissionamento.TabIndex = 240;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(24, 69);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(163, 18);
            label1.TabIndex = 248;
            label1.Text = "Comissão do vendedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(26, 91);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(429, 15);
            label3.TabIndex = 246;
            label3.Text = "Defini se a comissão será calculada de forma fixa ou variavel ou nao calcular.";
            // 
            // textBoxValorPorcentagem
            // 
            this.textBoxValorPorcentagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorPorcentagem.Location = new System.Drawing.Point(24, 55);
            this.textBoxValorPorcentagem.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBoxValorPorcentagem.Name = "textBoxValorPorcentagem";
            this.textBoxValorPorcentagem.Size = new System.Drawing.Size(298, 26);
            this.textBoxValorPorcentagem.TabIndex = 249;
            this.textBoxValorPorcentagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // comboBoxComissao
            // 
            this.comboBoxComissao.BackColor = System.Drawing.Color.White;
            this.comboBoxComissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComissao.FormattingEnabled = true;
            this.comboBoxComissao.Items.AddRange(new object[] {
            "FIXA",
            "VARIAVEL",
            "DESATIVADO"});
            this.comboBoxComissao.Location = new System.Drawing.Point(26, 122);
            this.comboBoxComissao.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxComissao.Name = "comboBoxComissao";
            this.comboBoxComissao.Size = new System.Drawing.Size(299, 26);
            this.comboBoxComissao.TabIndex = 250;
            this.comboBoxComissao.SelectedIndexChanged += new System.EventHandler(this.comboBoxComissaoFixa_SelectedIndexChanged);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(24, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(308, 15);
            label5.TabIndex = 251;
            label5.Text = "Informe o valor em porcentagem (%) da comissão FIXA";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label6.Location = new System.Drawing.Point(24, 5);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(132, 18);
            label6.TabIndex = 252;
            label6.Text = "Valor da comissão";
            // 
            // panelValorComissao
            // 
            this.panelValorComissao.Controls.Add(label6);
            this.panelValorComissao.Controls.Add(label5);
            this.panelValorComissao.Controls.Add(this.textBoxValorPorcentagem);
            this.panelValorComissao.Location = new System.Drawing.Point(3, 277);
            this.panelValorComissao.Name = "panelValorComissao";
            this.panelValorComissao.Size = new System.Drawing.Size(777, 100);
            this.panelValorComissao.TabIndex = 253;
            this.panelValorComissao.Visible = false;
            // 
            // UserControl_Gerais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.comboBoxComissao);
            this.Controls.Add(label1);
            this.Controls.Add(label3);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.comboBoxComissionamento);
            this.Controls.Add(label4);
            this.Controls.Add(label7);
            this.Controls.Add(label2);
            this.Controls.Add(this.panelValorComissao);
            this.Name = "UserControl_Gerais";
            this.Size = new System.Drawing.Size(783, 596);
            this.Load += new System.EventHandler(this.UserControl_Gerais_Load);
            this.panelValorComissao.ResumeLayout(false);
            this.panelValorComissao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.ComboBox comboBoxComissionamento;
        private System.Windows.Forms.TextBox textBoxValorPorcentagem;
        private System.Windows.Forms.ComboBox comboBoxComissao;
        private System.Windows.Forms.Panel panelValorComissao;
    }
}
