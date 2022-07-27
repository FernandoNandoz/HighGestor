using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Clientes
{
    public partial class FormCadCliente : Form
    {
        public FormCadCliente()
        {
            InitializeComponent();
        }

        private void FormCadCliente_Load(object sender, EventArgs e)
        {
            textBoxNomeCliente.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
