using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Vendas.Comissao.Report
{
    public partial class FormRelatorioGeral : Form
    {
        FormRelatorioComissao instancia;

        public FormRelatorioGeral(FormRelatorioComissao comissao)
        {
            InitializeComponent();
            instancia = comissao;
        }

        private void FormRelatorioGeral_Load(object sender, EventArgs e)
        {
            DateTime inicio = instancia.dataInicio;
            DateTime final = inicio.AddMonths(+1);

            this.relatorioGeralComissaoTableAdapter.RelatorioGeral(this.databaseHighDataDataSet.RelatorioGeralComissao, inicio, final);

            this.reportViewerContent.RefreshReport();
        }
    }
}
