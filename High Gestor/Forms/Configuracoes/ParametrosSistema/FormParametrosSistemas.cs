using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Configuracoes.ParametrosSistema
{
    public partial class FormParametrosSistemas : Form
    {
        public FormParametrosSistemas()
        {
            InitializeComponent();
        }

        private void FormParametrosSistemas_Load(object sender, EventArgs e)
        {

        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGerais_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.FromArgb(43, 87, 154);
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {   
            buttonFinanceiro.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonEstoque.ForeColor = Color.FromArgb(43, 87, 154);
        }

        private void buttonFinanceiro_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.FromArgb(43, 87, 154);
        }

        private void buttonDadosEmpresa_Click(object sender, EventArgs e)
        {
            buttonEstoque.ForeColor = Color.Black;
            buttonFinanceiro.ForeColor = Color.Black;
            buttonGerais.ForeColor = Color.Black;
            buttonDadosEmpresa.ForeColor = Color.FromArgb(43, 87, 154);
        }
    }
}
