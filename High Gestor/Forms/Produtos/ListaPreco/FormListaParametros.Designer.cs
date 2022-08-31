namespace High_Gestor.Forms.Produtos.ListaPreco
{
    partial class FormListaParametros
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaParametros));
            this.radioButtonValorProduto = new System.Windows.Forms.RadioButton();
            this.radioButtonValorProdutoListaSelecionada = new System.Windows.Forms.RadioButton();
            this.radioButtonDesconto = new System.Windows.Forms.RadioButton();
            this.radioButtonAcrescimo = new System.Windows.Forms.RadioButton();
            this.textBoxValorPorcentagem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.panelEscolha1 = new System.Windows.Forms.Panel();
            this.panelEscolha2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelEscolha1.SuspendLayout();
            this.panelEscolha2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(16, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(207, 24);
            label1.TabIndex = 155;
            label1.Text = "Atualizar lista de preços";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label8.Location = new System.Drawing.Point(5, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(211, 18);
            label8.TabIndex = 239;
            label8.Text = "Escolha as opções desejadas:";
            // 
            // label9
            // 
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(7, 24);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(566, 42);
            label9.TabIndex = 238;
            label9.Text = "1 - Atualizar a lista de acordo com o valor atual do produto, ou atualizar a list" +
    "a com referência ao valor do produto na lista selecionada?";
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(7, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(566, 25);
            label3.TabIndex = 242;
            label3.Text = "2 - Selecione qual ajuste será feito no valor dos produtos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(7, 95);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(129, 15);
            label5.TabIndex = 253;
            label5.Text = "Valor para atualização";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(326, 95);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(18, 15);
            label2.TabIndex = 254;
            label2.Text = "%";
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(12, 28);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(532, 38);
            label4.TabIndex = 254;
            label4.Text = "Atenção! A atualização de preços é realizada em todos os produtos, esta ação não " +
    "poderá ser desfeita.";
            // 
            // radioButtonValorProduto
            // 
            this.radioButtonValorProduto.AutoSize = true;
            this.radioButtonValorProduto.Checked = true;
            this.radioButtonValorProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonValorProduto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonValorProduto.Location = new System.Drawing.Point(23, 76);
            this.radioButtonValorProduto.Name = "radioButtonValorProduto";
            this.radioButtonValorProduto.Size = new System.Drawing.Size(132, 21);
            this.radioButtonValorProduto.TabIndex = 240;
            this.radioButtonValorProduto.TabStop = true;
            this.radioButtonValorProduto.Text = "Valor do produto";
            this.radioButtonValorProduto.UseVisualStyleBackColor = true;
            // 
            // radioButtonValorProdutoListaSelecionada
            // 
            this.radioButtonValorProdutoListaSelecionada.AutoSize = true;
            this.radioButtonValorProdutoListaSelecionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonValorProdutoListaSelecionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonValorProdutoListaSelecionada.Location = new System.Drawing.Point(197, 76);
            this.radioButtonValorProdutoListaSelecionada.Name = "radioButtonValorProdutoListaSelecionada";
            this.radioButtonValorProdutoListaSelecionada.Size = new System.Drawing.Size(261, 21);
            this.radioButtonValorProdutoListaSelecionada.TabIndex = 241;
            this.radioButtonValorProdutoListaSelecionada.Text = "Valor do produto na lista selecionada";
            this.radioButtonValorProdutoListaSelecionada.UseVisualStyleBackColor = true;
            // 
            // radioButtonDesconto
            // 
            this.radioButtonDesconto.AutoSize = true;
            this.radioButtonDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDesconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonDesconto.Location = new System.Drawing.Point(160, 43);
            this.radioButtonDesconto.Name = "radioButtonDesconto";
            this.radioButtonDesconto.Size = new System.Drawing.Size(86, 21);
            this.radioButtonDesconto.TabIndex = 245;
            this.radioButtonDesconto.Text = "Desconto";
            this.radioButtonDesconto.UseVisualStyleBackColor = true;
            // 
            // radioButtonAcrescimo
            // 
            this.radioButtonAcrescimo.AutoSize = true;
            this.radioButtonAcrescimo.Checked = true;
            this.radioButtonAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAcrescimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.radioButtonAcrescimo.Location = new System.Drawing.Point(23, 43);
            this.radioButtonAcrescimo.Name = "radioButtonAcrescimo";
            this.radioButtonAcrescimo.Size = new System.Drawing.Size(91, 21);
            this.radioButtonAcrescimo.TabIndex = 244;
            this.radioButtonAcrescimo.TabStop = true;
            this.radioButtonAcrescimo.Text = "Acréscimo";
            this.radioButtonAcrescimo.UseVisualStyleBackColor = true;
            // 
            // textBoxValorPorcentagem
            // 
            this.textBoxValorPorcentagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorPorcentagem.Location = new System.Drawing.Point(144, 89);
            this.textBoxValorPorcentagem.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBoxValorPorcentagem.Name = "textBoxValorPorcentagem";
            this.textBoxValorPorcentagem.Size = new System.Drawing.Size(176, 26);
            this.textBoxValorPorcentagem.TabIndex = 252;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(565, 81);
            this.groupBox1.TabIndex = 255;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atenção";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(22, 450);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(213, 32);
            this.buttonSalvar.TabIndex = 256;
            this.buttonSalvar.Text = "Salvar configurações";
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // panelEscolha1
            // 
            this.panelEscolha1.Controls.Add(label9);
            this.panelEscolha1.Controls.Add(label8);
            this.panelEscolha1.Controls.Add(this.radioButtonValorProduto);
            this.panelEscolha1.Controls.Add(this.radioButtonValorProdutoListaSelecionada);
            this.panelEscolha1.Location = new System.Drawing.Point(12, 71);
            this.panelEscolha1.Name = "panelEscolha1";
            this.panelEscolha1.Size = new System.Drawing.Size(583, 119);
            this.panelEscolha1.TabIndex = 257;
            // 
            // panelEscolha2
            // 
            this.panelEscolha2.Controls.Add(label3);
            this.panelEscolha2.Controls.Add(this.radioButtonAcrescimo);
            this.panelEscolha2.Controls.Add(label2);
            this.panelEscolha2.Controls.Add(this.radioButtonDesconto);
            this.panelEscolha2.Controls.Add(label5);
            this.panelEscolha2.Controls.Add(this.textBoxValorPorcentagem);
            this.panelEscolha2.Location = new System.Drawing.Point(12, 193);
            this.panelEscolha2.Name = "panelEscolha2";
            this.panelEscolha2.Size = new System.Drawing.Size(583, 142);
            this.panelEscolha2.TabIndex = 258;
            // 
            // FormListaParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(607, 508);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label1);
            this.Controls.Add(this.panelEscolha1);
            this.Controls.Add(this.panelEscolha2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListaParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Lista Parametros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormListaParametros_FormClosing);
            this.Load += new System.EventHandler(this.FormListaParametros_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormListaParametros_Paint);
            this.groupBox1.ResumeLayout(false);
            this.panelEscolha1.ResumeLayout(false);
            this.panelEscolha1.PerformLayout();
            this.panelEscolha2.ResumeLayout(false);
            this.panelEscolha2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonValorProduto;
        private System.Windows.Forms.RadioButton radioButtonValorProdutoListaSelecionada;
        private System.Windows.Forms.RadioButton radioButtonDesconto;
        private System.Windows.Forms.RadioButton radioButtonAcrescimo;
        private System.Windows.Forms.TextBox textBoxValorPorcentagem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Panel panelEscolha1;
        private System.Windows.Forms.Panel panelEscolha2;
    }
}