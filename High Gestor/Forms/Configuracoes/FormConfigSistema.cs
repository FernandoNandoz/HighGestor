﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Configuracoes
{
    public partial class FormConfigSistema : Form
    {
        public FormConfigSistema()
        {
            InitializeComponent();
        }

        private void FormConfigSistema_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }
    }
}