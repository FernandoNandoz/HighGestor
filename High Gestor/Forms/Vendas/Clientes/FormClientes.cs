using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace High_Gestor.Forms.Vendas.Clientes
{
    public partial class FormClientes : Form
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        #endregion

        Banco banco = new Banco();

        UserControl_Acoes acoes;

        bool acoesOpen = false;

        public FormClientes()
        {
            InitializeComponent();

            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Cliente");

            if (ViewForms._responseViewFormLink() == true)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        #region Paint

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        private void buttonVoltar_Paint(object sender, PaintEventArgs e)
        {
            buttonVoltar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonVoltar.Width,
            buttonVoltar.Height, 5, 5));
        }

        private void dataGridViewContent_Paint(object sender, PaintEventArgs e)
        {
            dataGridViewContent.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewContent.Width,
            dataGridViewContent.Height, 7, 7));
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
            activeForm.Width = panelBack.Width;
            activeForm.Height = panelBack.Height;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            panelBack.Controls.Add(childForm);
            panelBack.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion

        private void verificarQuantidadeClientes()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            string Fornecedor = ("SELECT COUNT(*) FROM ClientesFornecedores WHERE tipo = 'CLIENTE' OR tipo = 'CLIENTE/FORNECEDOR'");
            SqlCommand exeVerificacao = new SqlCommand(Fornecedor, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        private static string FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        private static string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }

        private void dataCliente()
        {
            string CPF_CNPJ = string.Empty;

            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idClienteFornecedor, nomeCompleto_RazaoSocial, CPF_CNPJ, carteiraProdutorRural, situacao, tipoPessoa FROM ClientesFornecedores ORDER BY idClienteFornecedor");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                if (datareader.GetString(5) == "JURIDICA")
                {
                    CPF_CNPJ = FormatCNPJ(datareader.GetString(2));
                }
                else if (datareader.GetString(5) == "FISICA")
                {
                    CPF_CNPJ = FormatCPF(datareader.GetString(2));
                }

                if (datareader.GetString(1) != "OPERACAO DE CAIXA")
                {
                    dataGridViewContent.Rows.Add(datareader.GetInt32(0),
                                            datareader.GetString(1),
                                            CPF_CNPJ,
                                            datareader.GetString(3),
                                            datareader.GetString(4),
                                            datareader.GetString(5));
                }
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            verificarQuantidadeClientes();

            dataCliente();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);
            //
            this.Close();
        } 

        private void FormClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
            ViewForms.requestViewForm(true, false);
        }

        private void panelBack_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                verificarQuantidadeClientes();
                dataCliente();
                dataGridViewContent.Refresh();
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            updateData.receberDados(0, false);

            openChildForm(new FormCadCliente());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string Fornecedor = ("DELETE FROM ClientesFornecedores WHERE idClienteFornecedor = @ID");
                        SqlCommand command = new SqlCommand(Fornecedor, banco.connection);

                        command.Parameters.AddWithValue("@ID", dataGridViewContent.CurrentRow.Cells[0].Value);

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                        MessageBox.Show("Cliente apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataCliente();
                        dataGridViewContent.Refresh();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Clientes:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Operção cancelada!", "Operação não concluida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FecharAcoes();

            if(e.ColumnIndex != 6 && e.ColumnIndex != 7)
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContent.Rows.Count != 0)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    openChildForm(new FormCadCliente());
                }
            }  
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            FecharAcoes();

            string CPF_CNPJ = string.Empty;

            if (textBoxPesquisar.Text != string.Empty)
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string Produtos = ("SELECT idClienteFornecedor, nomeCompleto_RazaoSocial, CPF_CNPJ, carteiraProdutorRural, situacao, tipoPessoa FROM ClientesFornecedores WHERE nomeCompleto_RazaoSocial LIKE (@nome_razao + '%') OR nomeFantasia LIKE (@nomeFantasia + '%') ORDER BY idClienteFornecedor");
                SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@nome_razao", textBoxPesquisar.Text);
                exeVerificacao.Parameters.AddWithValue("@nomeFantasia", textBoxPesquisar.Text);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewContent.Rows.Clear();
                while (datareader.Read())
                {
                    if (datareader.GetString(5) == "JURIDICA")
                    {
                        CPF_CNPJ = FormatCNPJ(datareader.GetString(2));
                    }
                    else if (datareader.GetString(5) == "FISICA")
                    {
                        CPF_CNPJ = FormatCPF(datareader.GetString(2));
                    }

                    if (datareader.GetString(1) != "OPERACAO DE CAIXA")
                    {
                        dataGridViewContent.Rows.Add(datareader.GetInt32(0),
                                                datareader.GetString(1),
                                                CPF_CNPJ,
                                                datareader.GetString(3),
                                                datareader.GetString(4),
                                                datareader.GetString(5));
                    }
                }

                banco.desconectar();

                dataGridViewContent.Refresh();
            }
            else
            {
                dataCliente();
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (acoesOpen == false)
                {
                    acoes = new UserControl_Acoes(this);

                    var cellRectangle = dataGridViewContent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    int X = dataGridViewContent.Width - acoes.Width - 10;
                    int y = cellRectangle.Bottom + acoes.Height - 38;
                    int yPanelContent = panelBack.Height;

                    if ((yPanelContent - y) > acoes.Height)
                    {
                        acoes.Location = new Point(X, y);
                    }
                    else
                    {
                        y = cellRectangle.Bottom;
                        acoes.Location = new Point(X, y);
                    }

                    panelBack.Controls.Add(acoes);
                    acoes.BringToFront();
                    acoes.Show();

                    acoesOpen = true;
                }
                else
                {
                    FecharAcoes();
                }
            }
        }

        public void FecharAcoes()
        {
            panelBack.Controls.Remove(acoes);

            acoesOpen = false;
        }

        private void panelBack_Click(object sender, EventArgs e)
        {
            FecharAcoes();
        }
    }
}
