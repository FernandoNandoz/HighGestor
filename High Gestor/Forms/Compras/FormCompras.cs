using High_Gestor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Compras
{
    public partial class FormCompras : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        Banco banco = new Banco();

        DataTable compras = new DataTable();

        public FormCompras()
        {
            InitializeComponent();

            dataTableCompras();

            dataGridViewContent.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewContent.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            SendMessage(textBoxPesquisarFornecedor.Handle, EM_SETCUEBANNER, 0, "Fornecedor");
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void panelEntradaMercadoria_Paint(object sender, PaintEventArgs e)
        {
            panelEntradaMercadoria.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelEntradaMercadoria.Width,
            panelEntradaMercadoria.Height, 7, 7));
        }

        private void panelOrdemCompra_Paint(object sender, PaintEventArgs e)
        {
            panelOrdemCompra.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelOrdemCompra.Width,
            panelOrdemCompra.Height, 7, 7));
        }

        private void panelFornecedor_Paint(object sender, PaintEventArgs e)
        {
            panelFornecedor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelFornecedor.Width,
            panelFornecedor.Height, 7, 7));
        }

        private void panelRelatorio_Paint(object sender, PaintEventArgs e)
        {
            panelRelatorio.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelRelatorio.Width,
            panelRelatorio.Height, 7, 7));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 9, 9));
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
            activeForm.Width = panelContent.Width;
            activeForm.Height = panelContent.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelContent.Controls.Add(childForm);
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void dataTableCompras()
        {
            compras.Columns.Add("IdCompras", typeof(int));
            compras.Columns.Add("Numero", typeof(string));
            compras.Columns.Add("Data", typeof(DateTime));
            compras.Columns.Add("NomeFornecedor", typeof(string));
            compras.Columns.Add("ValorTotal", typeof(decimal));
            compras.Columns.Add("Situacao", typeof(string));
            compras.Columns.Add("SituacaoImage", typeof(Image));
            compras.Columns.Add("IdFornecedorFK", typeof(int));
        }

        private void dataCompras()
        {
            int contador = 0;
            Image image = null;

            try
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string query = ("SELECT PedidosCompra.idPedidosCompra, PedidosCompra.dataEntrada, Fornecedor.nomeFantasia, PedidosCompra.valorTotalEntrada, PedidosCompra.situacao, PedidosCompra.idFornecedorFK FROM PedidosCompra INNER JOIN Fornecedor ON PedidosCompra.idFornecedorFK = Fornecedor.idFornecedor WHERE situacao != 'CANCELADO' ORDER BY dataEntrada DESC");
                SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
                banco.conectar();

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                compras.Rows.Clear();

                while (datareader.Read())
                {
                    contador += 1;

                    if (datareader[4].ToString() == "EM ABERTO")
                    {
                        image = Resources.cinza;
                    }
                    else if(datareader[4].ToString() == "EM ANDAMENTO")
                    {
                        image = Resources.amarelo;
                    }
                    else if (datareader[4].ToString() == "ATENDIDO")
                    {
                        image = Resources.verde;
                    }
                    else if (datareader[4].ToString() == "CANCELADO")
                    {
                        image = Resources.vermelho;
                    }

                    compras.Rows.Add(datareader[0],
                                      contador.ToString(),
                                      datareader.GetDateTime(1),
                                      datareader.GetString(2),
                                      datareader.GetDecimal(3),
                                      datareader.GetString(4),
                                      image,
                                      datareader.GetInt32(5)
                                    );
                }

                banco.desconectar();

                dataGridViewContent.AutoGenerateColumns = false;

                dataGridViewContent.DataSource = compras;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            dataCompras();

        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                compras.Rows.Clear();

                dataCompras();
            }
        }

        private void buttonEntradaMercadoria_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);
            //
            openChildForm(new EntradaMercadoria.FormEntradaMercadoria());
        }

        private void buttonOrdemCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            openChildForm(new Fornecedores.FormFornecedores());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelBuscaAvancada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabelBuscaAvancada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelBuscaAvancada_Click(sender,e);
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            compras.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeFornecedor", textBoxPesquisarFornecedor.Text);
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewContent.Rows.Count != 0 && e.ColumnIndex != 6 && e.ColumnIndex != 8)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new EntradaMercadoria.FormEntradaMercadoria());
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                FormAlterarSituacao window = new FormAlterarSituacao();
                window.ShowDialog();
                window.Dispose();
            }

            if(e.ColumnIndex == 8)
            {
                
            }
        }
    }
}
