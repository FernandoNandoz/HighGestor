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

namespace High_Gestor.Forms.Produtos.ListaPreco
{
    public partial class FormListaPreco : Form
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

        Banco banco = new Banco();

        public FormListaPreco()
        {
            InitializeComponent();
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


        private void verificarQuantidade()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            string Fornecedor = ("SELECT COUNT(*) FROM ListaPreco");
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

        private void dataListaPreco()
        {
            decimal baseCalculo = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idListaPreco, descricao, tipoAjuste, situacao, baseCalculoValorProduto, baseCalculoValorLista, modalidadeAjuste FROM ListaPreco ORDER BY idListaPreco");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                if (datareader[6].ToString() == "VALOR PRODUTO")
                {
                    baseCalculo = datareader.GetDecimal(4);
                }
                else if (datareader[6].ToString() == "VALOR LISTA")
                {
                    baseCalculo = datareader.GetDecimal(4) + datareader.GetDecimal(5);
                }

                dataGridViewContent.Rows.Add(datareader.GetInt32(0),
                                        datareader.GetString(1),
                                        datareader.GetString(2),
                                        baseCalculo,
                                        datareader.GetString(3));
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void FormListaPreco_Load(object sender, EventArgs e)
        {
            verificarQuantidade();
            dataListaPreco();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelBack_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                verificarQuantidade();
                dataListaPreco();
                dataGridViewContent.Refresh();
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            openChildForm(new FormCadListaPreco());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0 && dataGridViewContent.CurrentRow.Cells[0].Value.ToString() != "1")
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string Fornecedor = ("DELETE FROM ListaPreco WHERE idListaPreco = @ID");
                        SqlCommand command = new SqlCommand(Fornecedor, banco.connection);

                        command.Parameters.AddWithValue("@ID", dataGridViewContent.CurrentRow.Cells[0].Value);

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                        MessageBox.Show("Lista de Preco apagada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataListaPreco();
                        dataGridViewContent.Refresh();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "ListaPreco:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Operção cancelada!", "Operação não concluida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            decimal baseCalculo = 0;

            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idListaPreco, descricao, tipoAjuste, situacao, baseCalculoValorProduto, baseCalculoValorLista, modalidadeAjuste FROM ListaPreco WHERE descricao LIKE (@descricao + '%') ORDER BY idListaPreco");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@descricao", textBoxPesquisar.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                if (datareader.GetString(6) == "VALOR PRODUTO")
                {
                    baseCalculo = datareader.GetDecimal(4);
                }
                else if (datareader.GetString(6) == "VALOR LISTA")
                {
                    baseCalculo = datareader.GetDecimal(4) + datareader.GetDecimal(5);
                }

                dataGridViewContent.Rows.Add(datareader.GetInt32(0),
                                        datareader.GetString(1),
                                        datareader.GetString(2),
                                        baseCalculo,
                                        datareader.GetString(3));
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void dataGridViewContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5)
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContent.Rows.Count != 0 && dataGridViewContent.CurrentRow.Cells[0].Value.ToString() != "1")
                {
                    updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                    openChildForm(new FormCadListaPreco());
                }
            }
        }

        private void dataGridViewContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                FormListaParametros window = new FormListaParametros();
                window.ShowDialog();
                window.Dispose();

                if (ViewForms._responseViewForm() == true)
                {
                    verificarQuantidade();
                    dataListaPreco();
                    dataGridViewContent.Refresh();
                }
            }
        }
    }
}
