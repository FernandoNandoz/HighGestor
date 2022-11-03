using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Vendas.Comissao.RelatorioDetalhamento
{
    public partial class FormRelatorioDetalhamento : Form
    {
        FormDetalhamentoComissao instancia;

        public FormRelatorioDetalhamento(FormDetalhamentoComissao comissao)
        {
            InitializeComponent();
            instancia = comissao;
        }

        private void FormRelatorioDetalhamento_Load(object sender, EventArgs e)
        {
            DateTime dataInicial = DateTime.Parse(instancia.dateTimePeriodoIncial.Value.ToShortDateString());
            DateTime dataFinal = dataInicial.AddMonths(+1);

            this.relatorioComissaoTableAdapter.RelatorioComissao(this.databaseHighDataDataSet.RelatorioComissao, dataInicial, dataFinal);


            this.reportViewerContent.RefreshReport();
        }
    }
}
