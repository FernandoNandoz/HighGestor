namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.CadastrarCaixa
{
    partial class UserControl_NovoCaixa
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.textBoxNomeCaixa = new System.Windows.Forms.TextBox();
            this.textBoxValorMinimo = new System.Windows.Forms.TextBox();
            this.textBoxValorMaximo = new System.Windows.Forms.TextBox();
            this.checkBoxAbaixoMinimo = new System.Windows.Forms.CheckBox();
            this.checkBoxAcimaMaximo = new System.Windows.Forms.CheckBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.flowLayoutPanelContent = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.checkBoxSelecionado = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label5.Location = new System.Drawing.Point(29, 79);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 18);
            label5.TabIndex = 307;
            label5.Text = "Nome do Caixa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label1.Location = new System.Drawing.Point(29, 144);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(95, 18);
            label1.TabIndex = 309;
            label1.Text = "Valor mínimo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label2.Location = new System.Drawing.Point(29, 237);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(99, 18);
            label2.TabIndex = 311;
            label2.Text = "Valor máximo";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label3.Location = new System.Drawing.Point(28, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(95, 20);
            label3.TabIndex = 318;
            label3.Text = "Novo caixa";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNomeCaixa
            // 
            this.textBoxNomeCaixa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeCaixa.Location = new System.Drawing.Point(32, 100);
            this.textBoxNomeCaixa.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBoxNomeCaixa.Name = "textBoxNomeCaixa";
            this.textBoxNomeCaixa.Size = new System.Drawing.Size(400, 26);
            this.textBoxNomeCaixa.TabIndex = 308;
            // 
            // textBoxValorMinimo
            // 
            this.textBoxValorMinimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValorMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorMinimo.Location = new System.Drawing.Point(32, 165);
            this.textBoxValorMinimo.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBoxValorMinimo.Name = "textBoxValorMinimo";
            this.textBoxValorMinimo.Size = new System.Drawing.Size(400, 26);
            this.textBoxValorMinimo.TabIndex = 310;
            this.textBoxValorMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // textBoxValorMaximo
            // 
            this.textBoxValorMaximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValorMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValorMaximo.Location = new System.Drawing.Point(32, 258);
            this.textBoxValorMaximo.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.textBoxValorMaximo.Name = "textBoxValorMaximo";
            this.textBoxValorMaximo.Size = new System.Drawing.Size(400, 26);
            this.textBoxValorMaximo.TabIndex = 312;
            this.textBoxValorMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // checkBoxAbaixoMinimo
            // 
            this.checkBoxAbaixoMinimo.AutoSize = true;
            this.checkBoxAbaixoMinimo.Checked = true;
            this.checkBoxAbaixoMinimo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAbaixoMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAbaixoMinimo.Location = new System.Drawing.Point(36, 197);
            this.checkBoxAbaixoMinimo.Name = "checkBoxAbaixoMinimo";
            this.checkBoxAbaixoMinimo.Size = new System.Drawing.Size(200, 19);
            this.checkBoxAbaixoMinimo.TabIndex = 313;
            this.checkBoxAbaixoMinimo.Text = "Permitir valor abaixo do mínimo";
            this.checkBoxAbaixoMinimo.UseVisualStyleBackColor = true;
            // 
            // checkBoxAcimaMaximo
            // 
            this.checkBoxAcimaMaximo.AutoSize = true;
            this.checkBoxAcimaMaximo.Checked = true;
            this.checkBoxAcimaMaximo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAcimaMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAcimaMaximo.Location = new System.Drawing.Point(36, 290);
            this.checkBoxAcimaMaximo.Name = "checkBoxAcimaMaximo";
            this.checkBoxAcimaMaximo.Size = new System.Drawing.Size(200, 19);
            this.checkBoxAcimaMaximo.TabIndex = 314;
            this.checkBoxAcimaMaximo.Text = "Permitir valor acima do máximo";
            this.checkBoxAcimaMaximo.UseVisualStyleBackColor = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(36, 613);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(163, 32);
            this.buttonSalvar.TabIndex = 315;
            this.buttonSalvar.Text = "Salvar cadastro";
            this.buttonSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(207, 613);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(162, 32);
            this.buttonCancelar.TabIndex = 317;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            label4.Location = new System.Drawing.Point(33, 354);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(160, 18);
            label4.TabIndex = 319;
            label4.Text = "Usuários permitidos";
            // 
            // flowLayoutPanelContent
            // 
            this.flowLayoutPanelContent.AutoScroll = true;
            this.flowLayoutPanelContent.Location = new System.Drawing.Point(36, 411);
            this.flowLayoutPanelContent.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelContent.Name = "flowLayoutPanelContent";
            this.flowLayoutPanelContent.Size = new System.Drawing.Size(843, 174);
            this.flowLayoutPanelContent.TabIndex = 320;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(42, 5);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(120, 18);
            this.labelUsuario.TabIndex = 322;
            this.labelUsuario.Text = "Selecionar todos";
            // 
            // checkBoxSelecionado
            // 
            this.checkBoxSelecionado.AutoSize = true;
            this.checkBoxSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSelecionado.Location = new System.Drawing.Point(17, 8);
            this.checkBoxSelecionado.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSelecionado.Name = "checkBoxSelecionado";
            this.checkBoxSelecionado.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSelecionado.TabIndex = 321;
            this.checkBoxSelecionado.UseVisualStyleBackColor = true;
            this.checkBoxSelecionado.Click += new System.EventHandler(this.checkBoxSelecionado_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxSelecionado);
            this.panel1.Controls.Add(this.labelUsuario);
            this.panel1.Location = new System.Drawing.Point(36, 384);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 27);
            this.panel1.TabIndex = 323;
            // 
            // UserControl_NovoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.checkBoxAcimaMaximo);
            this.Controls.Add(this.checkBoxAbaixoMinimo);
            this.Controls.Add(this.textBoxValorMaximo);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBoxValorMinimo);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxNomeCaixa);
            this.Controls.Add(label5);
            this.Controls.Add(this.flowLayoutPanelContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl_NovoCaixa";
            this.Size = new System.Drawing.Size(950, 673);
            this.Load += new System.EventHandler(this.UserControl_NovoCaixa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNomeCaixa;
        private System.Windows.Forms.TextBox textBoxValorMinimo;
        private System.Windows.Forms.TextBox textBoxValorMaximo;
        private System.Windows.Forms.CheckBox checkBoxAbaixoMinimo;
        private System.Windows.Forms.CheckBox checkBoxAcimaMaximo;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContent;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.CheckBox checkBoxSelecionado;
        private System.Windows.Forms.Panel panel1;
    }
}
