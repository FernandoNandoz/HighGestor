using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Reports.Produtos
{
    public partial class FormReportProdutos : Form
    {
        public FormReportProdutos()
        {
            InitializeComponent();
        }

        private void FormReportProdutos_Load(object sender, EventArgs e)
        {
            this.produtosTableAdapter.Fill(this.databaseHighDataDataSet.Produtos);

            this.reportViewerContent.RefreshReport();
        }
    }
}
