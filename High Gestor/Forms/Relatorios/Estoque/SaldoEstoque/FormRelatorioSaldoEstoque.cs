using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Relatorios.Estoque.SaldoEstoque
{
    public partial class FormRelatorioSaldoEstoque : Form
    {
        public FormRelatorioSaldoEstoque()
        {
            InitializeComponent();
        }

        private void FormRelatorioSaldoEstoque_Load(object sender, EventArgs e)
        {
            this.produtosTableAdapter.Fill(this.databaseHighDataDataSet.Produtos);

            this.reportViewerContent.RefreshReport();
        }
    }
}
