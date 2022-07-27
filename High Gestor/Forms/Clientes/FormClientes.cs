﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Clientes
{
    public partial class FormClientes : Form
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

        public FormClientes()
        {
            InitializeComponent();
        }

        #region Event Components

        private void buttonSair_Paint(object sender, PaintEventArgs e)
        {
            buttonSair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSair.Width,
            buttonSair.Height, 5, 5));
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
            activeForm.Width = panelBack.Width;
            activeForm.Height = panelBack.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelBack.Controls.Add(childForm);
            panelBack.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion

        private void FormClientes_Load(object sender, EventArgs e)
        {
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
            dataGridViewContent.Rows.Add("Fernando Souza Damasceno", "ATIVO", "R$ 450,00");
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);
            //
            Close();
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {

        }

        
    }
}