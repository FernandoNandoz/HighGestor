﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Configuracoes
{
    public partial class FormConfiguracoes : Form
    {
        #region Dll
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        #endregion

        public FormConfiguracoes()
        {
            InitializeComponent();
        }

        #region Paint

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        #endregion

        #region Metodo resposavel por chamar os formularios 

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.Width = panelContent.Width;
            activeForm.Height = panelContent.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion


        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 198;
            int y1 = 10;
            int x2 = 198;
            int y2 = panelMenu.Height - 10;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private void FormConfiguracoes_Load(object sender, System.EventArgs e)
        {
            if (alterouSize._retornarFormOpenSecundario() == "REDIMENCIONAR")
            {

                panelContent.Refresh();

                if (alterouSize._retornarFormNameSecundario() == "CATEGORIA")
                {


                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new Forms.Configuracoes.Categorias.FormCategorias());
                    //    
                }

                if (alterouSize._retornarFormNameSecundario() == "FORNECEDOR")
                {


                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new Forms.Configuracoes.Fornecedores.FormFornecedores());
                }

                if (alterouSize._retornarFormNameSecundario() == "FUNCIONARIO")
                {


                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new Forms.Configuracoes.Funcionarios.FormFuncionarios());
                }

                if (alterouSize._retornarFormNameSecundario() == "BACKUP")
                {


                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new Forms.Configuracoes.FormBackup());
                }

                if (alterouSize._retornarFormNameSecundario() == "CONFIG_SYSTEM")
                {
                    
                   

                    ViewForms.requestBackMenu(false);
                    //
                    openChildForm(new Forms.Configuracoes.FormConfigSistema());
                }
            }

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonVoltar_Click(object sender, System.EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void buttonCategorias_Click(object sender, EventArgs e)
        {
            buttonFornecedores.BackColor = Color.White;
            buttonFuncionarios.BackColor = Color.White;
            buttonBackup.BackColor = Color.White;
            buttonConfigSistema.BackColor = Color.White;
            buttonCategorias.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("CATEGORIA");
            alterouSize.receberValidacaoSecundario(1);

            openChildForm(new Categorias.FormCategorias());
        }

        private void buttonFornecedores_Click(object sender, EventArgs e)
        {
            buttonCategorias.BackColor = Color.White;
            buttonFuncionarios.BackColor = Color.White;
            buttonBackup.BackColor = Color.White;
            buttonConfigSistema.BackColor = Color.White;
            buttonFornecedores.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("FORNECEDOR");
            alterouSize.receberValidacaoSecundario(1);

            openChildForm(new Fornecedores.FormFornecedores());
        }

        private void buttonFuncionarios_Click(object sender, EventArgs e)
        {
            buttonCategorias.BackColor = Color.White;
            buttonFornecedores.BackColor = Color.White;
            buttonBackup.BackColor = Color.White;
            buttonConfigSistema.BackColor = Color.White;
            buttonFuncionarios.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("FUNCIONARIO");
            alterouSize.receberValidacaoSecundario(1);

            openChildForm(new Funcionarios.FormFuncionarios());
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            buttonCategorias.BackColor = Color.White;
            buttonFornecedores.BackColor = Color.White;
            buttonFuncionarios.BackColor = Color.White;        
            buttonConfigSistema.BackColor = Color.White;
            buttonBackup.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("BACKUP");
            alterouSize.receberValidacaoSecundario(1);

            openChildForm(new FormBackup());
        }

        private void buttonConfigSistema_Click(object sender, EventArgs e)
        {
            buttonCategorias.BackColor = Color.White;
            buttonFornecedores.BackColor = Color.White;
            buttonFuncionarios.BackColor = Color.White;
            buttonBackup.BackColor = Color.White;
            buttonConfigSistema.BackColor = Color.FromArgb(210, 210, 210);

            ViewForms.requestBackMenu(false);
            //
            alterouSize.receberNameSecundario("CONFIG_SYSTEM");
            alterouSize.receberValidacaoSecundario(1);

            openChildForm(new FormConfigSistema());
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseBackMenu() == true)
            {
                buttonCategorias.BackColor = Color.White;
                buttonFornecedores.BackColor = Color.White;
                buttonFuncionarios.BackColor = Color.White;
                buttonBackup.BackColor = Color.White;
                buttonConfigSistema.BackColor = Color.White;
            }
        }
    }
}
