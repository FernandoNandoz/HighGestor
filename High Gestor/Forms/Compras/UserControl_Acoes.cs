using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Compras
{
    public partial class UserControl_Acoes : UserControl
    {
        FormCompras instancia;

        public UserControl_Acoes(FormCompras Compras)
        {
            InitializeComponent();
            instancia = Compras;
        }

        private void UserControl_Acoes_Load(object sender, EventArgs e)
        {

        }

        private void buttonImprimirEntrada_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes();
        }

        private void buttonLancarContas_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes();
        }

        private void buttonLancarEstoque_Click(object sender, EventArgs e)
        {
            instancia.queryInsertEstoque();
            instancia.FecharAcoes();
        }

        private void buttonAlterarStatus_Click(object sender, EventArgs e)
        {
            instancia.FecharAcoes();
        }
    }
}
