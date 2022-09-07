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

namespace High_Gestor.Forms.Financeiro.Parametros.ContasBancarias
{
    public partial class FormContasBancarias : Form
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

        DataTable ContasBancarias = new DataTable();


        public FormContasBancarias()
        {
            InitializeComponent();

            InicializarDataTable();

            dataGridViewContent.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Conta bancaria");
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

        private void InicializarDataTable()
        {
            ContasBancarias.Columns.Add("IdContaBancaria", typeof(int));
            ContasBancarias.Columns.Add("NomeConta", typeof(string));
            ContasBancarias.Columns.Add("NomeBanco", typeof(string));
            ContasBancarias.Columns.Add("ImagePadraoReceitas", typeof(Image));
            ContasBancarias.Columns.Add("ImagePadraoDespesas", typeof(Image));
            ContasBancarias.Columns.Add("Situacao", typeof(string));
            ContasBancarias.Columns.Add("SituacaoImage", typeof(Image));
        }

        private void pesquisaAutoComplete()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeConta FROM ContasBancarias WHERE situacao = 'ATIVO'", banco.connection);

                banco.conectar();
                SqlDataReader dr = exePesquisa.ExecuteReader();

                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
                banco.desconectar();

                textBoxPesquisar.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void verificarQuantidade()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            string Custo = ("SELECT COUNT(*) FROM ContasBancarias WHERE situacao = 'ATIVO'");
            SqlCommand exeVerificacao = new SqlCommand(Custo, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private void dataContasBancarias()
        {
            Image image = null;

            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idContaBancaria, nomeConta, nomeBanco, padraoReceitas, padraoDespesas, situacao FROM ContasBancarias WHERE situacao = 'ATIVO' ORDER BY idContaBancaria");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            ContasBancarias.Rows.Clear();

            while (datareader.Read())
            {
                Image padraoReceitas = null;
                Image padraoDespesas = null;

                if (datareader[3].ToString() == "SIM" && datareader[4].ToString() == "SIM")
                {
                    padraoReceitas = Resources.padrao_receitas;
                    padraoDespesas = Resources.padrao_despesas_1;         
                }
                else if (datareader[3].ToString() == "SIM" && datareader[4].ToString() == "NAO")
                {
                    padraoReceitas = Resources.padrao_receitas;
                    padraoDespesas = Resources.padrao_contaBancaria_NULO_1;
                }
                else if (datareader[3].ToString() == "NAO" && datareader[4].ToString() == "SIM")
                {
                    padraoReceitas = Resources.padrao_contaBancaria_NULO_1;
                    padraoDespesas = Resources.padrao_despesas_1;              
                }
                else if (datareader[3].ToString() == "NAO" && datareader[4].ToString() == "NAO")
                {
                    padraoReceitas = Resources.padrao_contaBancaria_NULO_1;
                    padraoDespesas = Resources.padrao_contaBancaria_NULO_1;
                }

                if (datareader[5].ToString() == "ATIVO")
                {
                    image = Resources.verde;
                }
                else if (datareader[5].ToString() == "INATIVO")
                {
                    image = Resources.cinza;
                }

                ContasBancarias.Rows.Add(datareader[0],
                                        datareader[1].ToString(),
                                        datareader[2].ToString(),
                                        padraoReceitas,
                                        padraoDespesas,
                                        datareader[5].ToString(),
                                        image);
            }

            banco.desconectar();

            dataGridViewContent.AutoGenerateColumns = false;

            dataGridViewContent.DataSource = ContasBancarias;
        }

        private void verificarContaContasPadroes()
        {
            int id = 0, quantidade = 0;

            //Pega o ultimo ID resgitrado na tabela log
            string query = ("SELECT idContaBancaria, (SELECT COUNT(*) FROM ContasBancarias) FROM ContasBancarias WHERE idContaBancaria=(SELECT MAX(idContaBancaria) FROM ContasBancarias)");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                id = datareader.GetInt32(0);
                quantidade = datareader.GetInt32(1);
            }
            banco.desconectar();

            if(quantidade == 1)
            {
                string queryUpdate = ("UPDATE ContasBancarias SET padraoReceitas = @padraoReceitas, padraoDespesas = @padraoDespesas WHERE idContaBancaria = @ID");
                SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                exeQueryUpdate.Parameters.AddWithValue("@padraoReceitas", "SIM");
                exeQueryUpdate.Parameters.AddWithValue("@padraoDespesas", "SIM");
                exeQueryUpdate.Parameters.AddWithValue("@ID", id);

                banco.conectar();
                exeQueryUpdate.ExecuteNonQuery();
                banco.desconectar();
            } 
        }

        private bool verificarLancamentoNaConta()
        {
            int resultCount = 0;
            bool lancamentoEncontrado = false;

            string select = ("SELECT COUNT(*) FROM ContasReceber WHERE idContaBancariaFK = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()));

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if(reader.Read())
            {
                resultCount = reader.GetInt32(0);
            }
            banco.desconectar();

            if(resultCount >= 1)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                ViewForms.requestViewForm(false, true);

                FormContaPossuiLancamento window = new FormContaPossuiLancamento();
                window.ShowDialog();
                window.Dispose();

                if (ViewForms._responseViewForm() == true)
                {
                    pesquisaAutoComplete();

                    verificarQuantidade();
                    dataContasBancarias();
                }

                lancamentoEncontrado = true;
            }
            else
            {
                lancamentoEncontrado = false;
            }

            return lancamentoEncontrado;
        }

        private void FormContasBancarias_Load(object sender, EventArgs e)
        {
            pesquisaAutoComplete();

            verificarQuantidade();
            dataContasBancarias();
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
                verificarQuantidade();
                dataContasBancarias();
                dataGridViewContent.Refresh();

                pesquisaAutoComplete();
            }
        }

        private void FormContasBancarias_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            ContasBancarias.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "NomeConta", textBoxPesquisar.Text);
        }

        private void buttonAdicionarNovo_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            ViewForms.requestViewForm(false, true);

            FormCadContasBancarias window = new FormCadContasBancarias();
            window.ShowDialog();
            window.Dispose();

            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoComplete();

                verificarQuantidade();
                dataContasBancarias();
            }
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0 && verificarLancamentoNaConta() == false)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string categoria = ("DELETE FROM ContasBancarias WHERE idContaBancaria = @ID");
                        SqlCommand command = new SqlCommand(categoria, banco.connection);

                        command.Parameters.AddWithValue("@ID", ContasBancarias.Rows[dataGridViewContent.CurrentRow.Index][0].ToString());

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();


                        MessageBox.Show("Conta bancária apagada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        verificarContaContasPadroes();

                        dataContasBancarias();
                        dataGridViewContent.Refresh();      
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Operção cancelada!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);
                
                ViewForms.requestViewForm(false, true);

                FormCadContasBancarias window = new FormCadContasBancarias();
                window.ShowDialog();
                window.Dispose();

                if (ViewForms._responseViewForm() == true)
                {
                    pesquisaAutoComplete();

                    verificarQuantidade();
                    dataContasBancarias();
                }
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridViewContent.Rows.Count != 0)
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    ViewForms.requestViewForm(false, true);

                    FormCadContasBancarias window = new FormCadContasBancarias();
                    window.ShowDialog();
                    window.Dispose();

                    if (ViewForms._responseViewForm() == true)
                    {
                        pesquisaAutoComplete();

                        verificarQuantidade();
                        dataContasBancarias();
                    }
                }
            }
        }
    }
}
