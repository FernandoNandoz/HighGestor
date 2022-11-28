namespace High_Gestor.Forms.Financeiro.ContasReceber.LiquidarVariasContas
{
    partial class FormLiquidarVariasContas
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiquidarVariasContas));
            System.Windows.Forms.Label label6;
            this.comboBoxFormaPagamento = new System.Windows.Forms.ComboBox();
            this.comboBoxContaBancaria = new System.Windows.Forms.ComboBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelValueQuantidadeContas = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelValueValorReceber = new System.Windows.Forms.Label();
            this.buttonNovoCadastro = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.maskedTextDataPagamento = new System.Windows.Forms.MaskedTextBox();
            this.labelDataPagamento = new System.Windows.Forms.Label();
            this.radioButtonOutraData = new System.Windows.Forms.RadioButton();
            this.radioButtonDataVencimento = new System.Windows.Forms.RadioButton();
            this.radioButtonDataAtual = new System.Windows.Forms.RadioButton();
            this.labelTitulo = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.panelContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(302, 308);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(137, 16);
            label4.TabIndex = 291;
            label4.Text = "Forma de pagamento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(42, 308);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 16);
            label3.TabIndex = 289;
            label3.Text = "Conta bancária";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label22.Location = new System.Drawing.Point(37, 60);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(154, 18);
            label22.TabIndex = 271;
            label22.Text = "Data de pagamento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label2.Location = new System.Drawing.Point(37, 273);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(281, 18);
            label2.TabIndex = 297;
            label2.Text = "Definir outros dados para liquidação";
            // 
            // label11
            // 
            label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label11.Location = new System.Drawing.Point(676, 499);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(137, 17);
            label11.TabIndex = 302;
            label11.Text = "Valor total a receber";
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(12, 28);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(623, 38);
            label5.TabIndex = 254;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label6.Location = new System.Drawing.Point(500, 499);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(148, 17);
            label6.TabIndex = 305;
            label6.Text = "Quantidade de contas";
            // 
            // comboBoxFormaPagamento
            // 
            this.comboBoxFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormaPagamento.DropDownWidth = 300;
            this.comboBoxFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFormaPagamento.FormattingEnabled = true;
            this.comboBoxFormaPagamento.Location = new System.Drawing.Point(305, 329);
            this.comboBoxFormaPagamento.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxFormaPagamento.Name = "comboBoxFormaPagamento";
            this.comboBoxFormaPagamento.Size = new System.Drawing.Size(250, 26);
            this.comboBoxFormaPagamento.TabIndex = 290;
            // 
            // comboBoxContaBancaria
            // 
            this.comboBoxContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContaBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContaBancaria.FormattingEnabled = true;
            this.comboBoxContaBancaria.Location = new System.Drawing.Point(45, 329);
            this.comboBoxContaBancaria.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxContaBancaria.Name = "comboBoxContaBancaria";
            this.comboBoxContaBancaria.Size = new System.Drawing.Size(250, 26);
            this.comboBoxContaBancaria.TabIndex = 288;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelContent.Controls.Add(this.labelValueQuantidadeContas);
            this.panelContent.Controls.Add(label6);
            this.panelContent.Controls.Add(this.groupBox1);
            this.panelContent.Controls.Add(this.labelValueValorReceber);
            this.panelContent.Controls.Add(label11);
            this.panelContent.Controls.Add(this.buttonNovoCadastro);
            this.panelContent.Controls.Add(this.buttonSair);
            this.panelContent.Controls.Add(label2);
            this.panelContent.Controls.Add(this.maskedTextDataPagamento);
            this.panelContent.Controls.Add(this.labelDataPagamento);
            this.panelContent.Controls.Add(this.radioButtonOutraData);
            this.panelContent.Controls.Add(this.radioButtonDataVencimento);
            this.panelContent.Controls.Add(this.radioButtonDataAtual);
            this.panelContent.Controls.Add(label4);
            this.panelContent.Controls.Add(this.comboBoxFormaPagamento);
            this.panelContent.Controls.Add(label3);
            this.panelContent.Controls.Add(this.comboBoxContaBancaria);
            this.panelContent.Controls.Add(label22);
            this.panelContent.Controls.Add(this.labelTitulo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(844, 570);
            this.panelContent.TabIndex = 292;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // labelValueQuantidadeContas
            // 
            this.labelValueQuantidadeContas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelValueQuantidadeContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueQuantidadeContas.Location = new System.Drawing.Point(509, 520);
            this.labelValueQuantidadeContas.Name = "labelValueQuantidadeContas";
            this.labelValueQuantidadeContas.Size = new System.Drawing.Size(139, 17);
            this.labelValueQuantidadeContas.TabIndex = 306;
            this.labelValueQuantidadeContas.Text = "0";
            this.labelValueQuantidadeContas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(45, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 78);
            this.groupBox1.TabIndex = 304;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atenção";
            // 
            // labelValueValorReceber
            // 
            this.labelValueValorReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelValueValorReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueValorReceber.Location = new System.Drawing.Point(654, 520);
            this.labelValueValorReceber.Name = "labelValueValorReceber";
            this.labelValueValorReceber.Size = new System.Drawing.Size(159, 17);
            this.labelValueValorReceber.TabIndex = 303;
            this.labelValueValorReceber.Text = "R$ 0,00";
            this.labelValueValorReceber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonNovoCadastro
            // 
            this.buttonNovoCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNovoCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonNovoCadastro.FlatAppearance.BorderSize = 0;
            this.buttonNovoCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNovoCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNovoCadastro.ForeColor = System.Drawing.Color.White;
            this.buttonNovoCadastro.Location = new System.Drawing.Point(31, 509);
            this.buttonNovoCadastro.Margin = new System.Windows.Forms.Padding(5);
            this.buttonNovoCadastro.Name = "buttonNovoCadastro";
            this.buttonNovoCadastro.Size = new System.Drawing.Size(156, 32);
            this.buttonNovoCadastro.TabIndex = 298;
            this.buttonNovoCadastro.Text = "Liquidar contas";
            this.buttonNovoCadastro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNovoCadastro.UseVisualStyleBackColor = false;
            this.buttonNovoCadastro.Click += new System.EventHandler(this.buttonNovoCadastro_Click);
            this.buttonNovoCadastro.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonSair
            // 
            this.buttonSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSair.BackColor = System.Drawing.Color.White;
            this.buttonSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSair.Location = new System.Drawing.Point(197, 509);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(134, 32);
            this.buttonSair.TabIndex = 299;
            this.buttonSair.Text = "Sair";
            this.buttonSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSair.UseVisualStyleBackColor = false;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // maskedTextDataPagamento
            // 
            this.maskedTextDataPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextDataPagamento.Location = new System.Drawing.Point(72, 195);
            this.maskedTextDataPagamento.Margin = new System.Windows.Forms.Padding(5);
            this.maskedTextDataPagamento.Mask = "00/00/0000";
            this.maskedTextDataPagamento.Name = "maskedTextDataPagamento";
            this.maskedTextDataPagamento.Size = new System.Drawing.Size(167, 26);
            this.maskedTextDataPagamento.TabIndex = 296;
            // 
            // labelDataPagamento
            // 
            this.labelDataPagamento.AutoSize = true;
            this.labelDataPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataPagamento.Location = new System.Drawing.Point(69, 173);
            this.labelDataPagamento.Name = "labelDataPagamento";
            this.labelDataPagamento.Size = new System.Drawing.Size(133, 17);
            this.labelDataPagamento.TabIndex = 295;
            this.labelDataPagamento.Text = "Data de pagamento";
            // 
            // radioButtonOutraData
            // 
            this.radioButtonOutraData.AutoSize = true;
            this.radioButtonOutraData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOutraData.Location = new System.Drawing.Point(45, 145);
            this.radioButtonOutraData.Name = "radioButtonOutraData";
            this.radioButtonOutraData.Size = new System.Drawing.Size(301, 21);
            this.radioButtonOutraData.TabIndex = 294;
            this.radioButtonOutraData.Text = "Considerar outra data para todas as contas";
            this.radioButtonOutraData.UseVisualStyleBackColor = true;
            this.radioButtonOutraData.Click += new System.EventHandler(this.carregarDados);
            // 
            // radioButtonDataVencimento
            // 
            this.radioButtonDataVencimento.AutoSize = true;
            this.radioButtonDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDataVencimento.Location = new System.Drawing.Point(45, 118);
            this.radioButtonDataVencimento.Name = "radioButtonDataVencimento";
            this.radioButtonDataVencimento.Size = new System.Drawing.Size(329, 21);
            this.radioButtonDataVencimento.TabIndex = 293;
            this.radioButtonDataVencimento.Text = "Considerar a data do vencimento de cada conta";
            this.radioButtonDataVencimento.UseVisualStyleBackColor = true;
            this.radioButtonDataVencimento.Click += new System.EventHandler(this.carregarDados);
            // 
            // radioButtonDataAtual
            // 
            this.radioButtonDataAtual.AutoSize = true;
            this.radioButtonDataAtual.Checked = true;
            this.radioButtonDataAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDataAtual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.radioButtonDataAtual.Location = new System.Drawing.Point(45, 91);
            this.radioButtonDataAtual.Name = "radioButtonDataAtual";
            this.radioButtonDataAtual.Size = new System.Drawing.Size(311, 21);
            this.radioButtonDataAtual.TabIndex = 292;
            this.radioButtonDataAtual.TabStop = true;
            this.radioButtonDataAtual.Text = "Considerar a data atual para todas as contas";
            this.radioButtonDataAtual.UseVisualStyleBackColor = true;
            this.radioButtonDataAtual.Click += new System.EventHandler(this.carregarDados);
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.labelTitulo.Location = new System.Drawing.Point(26, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(262, 24);
            this.labelTitulo.TabIndex = 182;
            this.labelTitulo.Text = "Liquidação - Contas a receber";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormLiquidarVariasContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(844, 570);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLiquidarVariasContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HIgh Gestor - Liquidar Contas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLiquidarVariasContas_FormClosed);
            this.Load += new System.EventHandler(this.FormLiquidarVariasContas_Load);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFormaPagamento;
        private System.Windows.Forms.ComboBox comboBoxContaBancaria;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.RadioButton radioButtonOutraData;
        private System.Windows.Forms.RadioButton radioButtonDataVencimento;
        private System.Windows.Forms.RadioButton radioButtonDataAtual;
        private System.Windows.Forms.MaskedTextBox maskedTextDataPagamento;
        private System.Windows.Forms.Button buttonNovoCadastro;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Label labelValueValorReceber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDataPagamento;
        private System.Windows.Forms.Label labelValueQuantidadeContas;
    }
}