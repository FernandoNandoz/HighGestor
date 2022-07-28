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

namespace High_Gestor.Forms.Configuracoes.Fornecedores
{
    public partial class FormFornecedores : Form
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

        public FormFornecedores()
        {
            InitializeComponent();

            if (ViewForms._responseViewFormLink() == true)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        #region Paint

        private void buttonSair_Paint(object sender, PaintEventArgs e)
        {
            buttonSair.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonSair.Width,
            buttonSair.Height, 5, 5));
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

        private void verificarQuantidadeFornecedor()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            string Fornecedor = ("SELECT COUNT(*) FROM Fornecedor");
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

        private void dataFornecedor()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idFornecedor, codigoFornecedor, nomeFantasia, representante FROM Fornecedor ORDER BY nomeFantasia");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewContent.Rows.Add(datareader[0],
                                            datareader[1],
                                            datareader[2],
                                            datareader[3]);
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void FormFornecedores_Load(object sender, EventArgs e)
        {
            verificarQuantidadeFornecedor();
            //
            dataFornecedor();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void FormFornecedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                verificarQuantidadeFornecedor();
                dataFornecedor();
                dataGridViewContent.Refresh();
            }
        }

        private void textBoxPesquisarNome_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBoxPesquisarNome.Text != string.Empty)
            {
                string dado = string.Empty;

                dado = textBoxPesquisarNome.Text;

                if (dado.All(Char.IsNumber))
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string Fornecedor = ("SELECT idFornecedor, codigoFornecedor, nomeFantasia, representante FROM Fornecedor WHERE codigoFornecedor LIKE (@codigo + '%') ORDER BY nomeFantasia");
                    SqlCommand exeVerificacao = new SqlCommand(Fornecedor, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@codigo", textBoxPesquisarNome.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewContent.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewContent.Rows.Add(datareader[0],
                                                    datareader[1],
                                                    datareader[2],
                                                    datareader[3]);
                    }

                    banco.desconectar();

                    dataGridViewContent.Refresh();
                }

                if (dado.All(Char.IsLetter))
                {
                    //Retorna os dados da tabela Produtos para o DataGridView
                    string Fornecedor = ("SELECT idFornecedor, codigoFornecedor, nomeFantasia, representante FROM Fornecedor WHERE nomeFantasia LIKE (@nomeFantasia + '%') ORDER BY nomeFantasia");
                    SqlCommand exeVerificacao = new SqlCommand(Fornecedor, banco.connection);
                    banco.conectar();

                    exeVerificacao.Parameters.AddWithValue("@nomeFantasia", textBoxPesquisarNome.Text);

                    SqlDataReader datareader = exeVerificacao.ExecuteReader();

                    dataGridViewContent.Rows.Clear();
                    while (datareader.Read())
                    {
                        dataGridViewContent.Rows.Add(datareader[0],
                                                    datareader[1],
                                                    datareader[2],
                                                    datareader[3]);
                    }

                    banco.desconectar();

                    dataGridViewContent.Refresh();
                }
            }
            else
            {
                dataFornecedor();
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            openChildForm(new Fornecedores.FormCadFornecedores());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditarCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContent.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new Fornecedores.FormCadFornecedores());
            }
        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContent.Rows.Count != 0)
            {
                if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        string Fornecedor = ("DELETE FROM Fornecedor WHERE idFornecedor = @ID");
                        SqlCommand command = new SqlCommand(Fornecedor, banco.connection);

                        command.Parameters.AddWithValue("@ID", dataGridViewContent.CurrentRow.Cells[0].Value);

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                        MessageBox.Show("Fornecedor apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataFornecedor();
                        dataGridViewContent.Refresh();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Fornecedor:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                openChildForm(new Fornecedores.FormCadFornecedores());
            }
        }
    }
}
