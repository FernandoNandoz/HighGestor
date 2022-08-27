using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.Clientes
{
    public partial class UserControl_Acoes : UserControl
    {

        FormClientes instancia;

        public UserControl_Acoes(FormClientes Clientes)
        {
            InitializeComponent();
            instancia = Clientes;
        }

        private void UserControl_Acoes_Load(object sender, EventArgs e)
        {

        }
    }
}
