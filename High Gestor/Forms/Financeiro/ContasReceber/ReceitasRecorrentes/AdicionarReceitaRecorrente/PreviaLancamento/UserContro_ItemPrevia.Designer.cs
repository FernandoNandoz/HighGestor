namespace High_Gestor.Forms.Financeiro.ContasReceber.ReceitasRecorrentes.AdicionarReceitaRecorrente.PreviaLancamento
{
    partial class UserContro_ItemPrevia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserContro_ItemPrevia));
            System.Windows.Forms.PictureBox pictureBox4;
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.dateTimeVencimento = new System.Windows.Forms.DateTimePicker();
            this.panelDadosPrevia = new System.Windows.Forms.Panel();
            this.labelVencimento = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSituacao = new System.Windows.Forms.Button();
            this.buttonLancarConta = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonContaLancada = new System.Windows.Forms.Button();
            this.buttonEstornarConta = new System.Windows.Forms.Button();
            this.buttonDetalhes = new System.Windows.Forms.Button();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelDadosPrevia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxValor
            // 
            this.textBoxValor.BackColor = System.Drawing.Color.White;
            this.textBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.Location = new System.Drawing.Point(191, 6);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(152, 23);
            this.textBoxValor.TabIndex = 19;
            this.textBoxValor.Text = "0,00";
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.apenasNumero_KeyPress);
            // 
            // dateTimeVencimento
            // 
            this.dateTimeVencimento.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimeVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeVencimento.Location = new System.Drawing.Point(9, 6);
            this.dateTimeVencimento.Name = "dateTimeVencimento";
            this.dateTimeVencimento.Size = new System.Drawing.Size(139, 23);
            this.dateTimeVencimento.TabIndex = 18;
            // 
            // panelDadosPrevia
            // 
            this.panelDadosPrevia.Controls.Add(this.buttonSalvar);
            this.panelDadosPrevia.Controls.Add(this.buttonCancelar);
            this.panelDadosPrevia.Controls.Add(this.dateTimeVencimento);
            this.panelDadosPrevia.Controls.Add(this.textBoxValor);
            this.panelDadosPrevia.Location = new System.Drawing.Point(177, 0);
            this.panelDadosPrevia.Margin = new System.Windows.Forms.Padding(0);
            this.panelDadosPrevia.Name = "panelDadosPrevia";
            this.panelDadosPrevia.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.panelDadosPrevia.Size = new System.Drawing.Size(640, 35);
            this.panelDadosPrevia.TabIndex = 284;
            this.panelDadosPrevia.Visible = false;
            // 
            // labelVencimento
            // 
            this.labelVencimento.AutoSize = true;
            this.labelVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVencimento.Location = new System.Drawing.Point(184, 9);
            this.labelVencimento.Name = "labelVencimento";
            this.labelVencimento.Size = new System.Drawing.Size(80, 17);
            this.labelVencimento.TabIndex = 285;
            this.labelVencimento.Text = "00/00/0000";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValor.Location = new System.Drawing.Point(366, 9);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(58, 17);
            this.labelValor.TabIndex = 286;
            this.labelValor.Text = "R$ 0,00";
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSalvar.FlatAppearance.BorderSize = 0;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.Location = new System.Drawing.Point(484, 0);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(28, 35);
            this.buttonSalvar.TabIndex = 283;
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            this.buttonSalvar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancelar.FlatAppearance.BorderSize = 0;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.Image")));
            this.buttonCancelar.Location = new System.Drawing.Point(512, 0);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(28, 35);
            this.buttonCancelar.TabIndex = 282;
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            this.buttonCancelar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonSituacao
            // 
            this.buttonSituacao.FlatAppearance.BorderSize = 0;
            this.buttonSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSituacao.Image = global::High_Gestor.Properties.Resources.cinza;
            this.buttonSituacao.Location = new System.Drawing.Point(59, 5);
            this.buttonSituacao.Name = "buttonSituacao";
            this.buttonSituacao.Size = new System.Drawing.Size(30, 25);
            this.buttonSituacao.TabIndex = 283;
            this.buttonSituacao.UseVisualStyleBackColor = true;
            this.buttonSituacao.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonLancarConta
            // 
            this.buttonLancarConta.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLancarConta.FlatAppearance.BorderSize = 0;
            this.buttonLancarConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLancarConta.Image = ((System.Drawing.Image)(resources.GetObject("buttonLancarConta.Image")));
            this.buttonLancarConta.Location = new System.Drawing.Point(573, 0);
            this.buttonLancarConta.Name = "buttonLancarConta";
            this.buttonLancarConta.Size = new System.Drawing.Size(30, 35);
            this.buttonLancarConta.TabIndex = 282;
            this.buttonLancarConta.UseVisualStyleBackColor = true;
            this.buttonLancarConta.Click += new System.EventHandler(this.buttonLancarConta_Click);
            this.buttonLancarConta.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEditar.FlatAppearance.BorderSize = 0;
            this.buttonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditar.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditar.Image")));
            this.buttonEditar.Location = new System.Drawing.Point(603, 0);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(28, 35);
            this.buttonEditar.TabIndex = 281;
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            this.buttonEditar.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExcluir.FlatAppearance.BorderSize = 0;
            this.buttonExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcluir.Image = ((System.Drawing.Image)(resources.GetObject("buttonExcluir.Image")));
            this.buttonExcluir.Location = new System.Drawing.Point(631, 0);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(28, 35);
            this.buttonExcluir.TabIndex = 280;
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            this.buttonExcluir.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonContaLancada
            // 
            this.buttonContaLancada.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonContaLancada.FlatAppearance.BorderSize = 0;
            this.buttonContaLancada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContaLancada.Image = ((System.Drawing.Image)(resources.GetObject("buttonContaLancada.Image")));
            this.buttonContaLancada.Location = new System.Drawing.Point(659, 0);
            this.buttonContaLancada.Name = "buttonContaLancada";
            this.buttonContaLancada.Size = new System.Drawing.Size(28, 35);
            this.buttonContaLancada.TabIndex = 279;
            this.buttonContaLancada.UseVisualStyleBackColor = true;
            this.buttonContaLancada.Visible = false;
            this.buttonContaLancada.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonEstornarConta
            // 
            this.buttonEstornarConta.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEstornarConta.FlatAppearance.BorderSize = 0;
            this.buttonEstornarConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEstornarConta.Image = ((System.Drawing.Image)(resources.GetObject("buttonEstornarConta.Image")));
            this.buttonEstornarConta.Location = new System.Drawing.Point(687, 0);
            this.buttonEstornarConta.Name = "buttonEstornarConta";
            this.buttonEstornarConta.Size = new System.Drawing.Size(28, 35);
            this.buttonEstornarConta.TabIndex = 278;
            this.buttonEstornarConta.UseVisualStyleBackColor = true;
            this.buttonEstornarConta.Visible = false;
            this.buttonEstornarConta.Click += new System.EventHandler(this.buttonEstornarConta_Click);
            this.buttonEstornarConta.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // buttonDetalhes
            // 
            this.buttonDetalhes.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDetalhes.FlatAppearance.BorderSize = 0;
            this.buttonDetalhes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetalhes.Image = ((System.Drawing.Image)(resources.GetObject("buttonDetalhes.Image")));
            this.buttonDetalhes.Location = new System.Drawing.Point(715, 0);
            this.buttonDetalhes.Name = "buttonDetalhes";
            this.buttonDetalhes.Size = new System.Drawing.Size(28, 35);
            this.buttonDetalhes.TabIndex = 277;
            this.buttonDetalhes.UseVisualStyleBackColor = true;
            this.buttonDetalhes.Click += new System.EventHandler(this.buttonDetalhes_Click);
            this.buttonDetalhes.Paint += new System.Windows.Forms.PaintEventHandler(this.button_Paint);
            // 
            // pictureBox4
            // 
            pictureBox4.Image = global::High_Gestor.Properties.Resources.verde;
            pictureBox4.Location = new System.Drawing.Point(65, 7);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(20, 20);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 258;
            pictureBox4.TabStop = false;
            // 
            // UserContro_ItemPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelDadosPrevia);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.labelVencimento);
            this.Controls.Add(this.buttonSituacao);
            this.Controls.Add(this.buttonLancarConta);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonContaLancada);
            this.Controls.Add(this.buttonEstornarConta);
            this.Controls.Add(this.buttonDetalhes);
            this.Controls.Add(pictureBox4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserContro_ItemPrevia";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 155, 0);
            this.Size = new System.Drawing.Size(898, 35);
            this.Load += new System.EventHandler(this.UserContro_ItemPrevia_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserContro_ItemPrevia_Paint);
            this.panelDadosPrevia.ResumeLayout(false);
            this.panelDadosPrevia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox textBoxValor;
        public System.Windows.Forms.DateTimePicker dateTimeVencimento;
        private System.Windows.Forms.Button buttonDetalhes;
        private System.Windows.Forms.Button buttonEstornarConta;
        private System.Windows.Forms.Button buttonContaLancada;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonLancarConta;
        private System.Windows.Forms.Button buttonSituacao;
        private System.Windows.Forms.Panel panelDadosPrevia;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelVencimento;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}
