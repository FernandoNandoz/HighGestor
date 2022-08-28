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

namespace High_Gestor.Forms.Financeiro.Parametros.CategoriaContas
{
    public partial class FormCategoriaContas : Form
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

        string ControleSelecionado= string.Empty;

        public FormCategoriaContas()
        {
            InitializeComponent();

            SendMessage(textBoxPesquisar.Handle, EM_SETCUEBANNER, 0, "Pesquisar Categoria");
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

        private void pesquisaAutoComplete()
        {
            try
            {
                SqlCommand exePesquisa = new SqlCommand("SELECT descricao FROM CategoriaFinanceiro WHERE situacao = 'ATIVO'", banco.connection);

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

            if(ControleSelecionado == "RECEITAS")
            {
                string Custo = ("SELECT COUNT(*) FROM CategoriaFinanceiro WHERE tipoCategoria = 'RECEITAS' AND situacao = 'ATIVO'");
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
            else if (ControleSelecionado == "DESPESAS")
            {
                string Custo = ("SELECT COUNT(*) FROM CategoriaFinanceiro WHERE tipoCategoria = 'DESPESAS' AND situacao = 'ATIVO'");
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
                
            
        }

        private void dataCategoriaReceitas()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idCategoriaFinanceiro, descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'RECEITAS' AND situacao = 'ATIVO' ORDER BY descricao");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContentReceitas.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewContentReceitas.Rows.Add(datareader[0],
                                            datareader[1].ToString());
            }

            banco.desconectar();

            dataGridViewContentReceitas.Refresh();
        }

        private void dataCategoriaDespesas()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string Produtos = ("SELECT idCategoriaFinanceiro, descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'DESPESAS' AND situacao = 'ATIVO' ORDER BY descricao");
            SqlCommand exeVerificacao = new SqlCommand(Produtos, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContentDespesas.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewContentDespesas.Rows.Add(datareader[0],
                                            datareader[1].ToString());
            }

            banco.desconectar();

            dataGridViewContentDespesas.Refresh();
        }

        private void FormCategoriaContas_Load(object sender, EventArgs e)
        {
            ControleSelecionado = "RECEITAS";

            pesquisaAutoComplete();

            verificarQuantidade();
            dataCategoriaReceitas();
            dataCategoriaDespesas();
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
                ControleSelecionado = "RECEITAS";

                verificarQuantidade();
                dataCategoriaReceitas();
                dataCategoriaDespesas();

                pesquisaAutoComplete();
            }
        }

        private void FormCategoriaContas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            if(ControleSelecionado == "RECEITAS")
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string Categoria = ("SELECT idCategoriaFinanceiro, descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'RECEITAS' AND situacao = 'ATIVO' AND descricao LIKE (@descricao + '%') ORDER BY descricao");
                SqlCommand exeVerificacao = new SqlCommand(Categoria, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@descricao", textBoxPesquisar.Text);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewContentReceitas.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewContentReceitas.Rows.Add(datareader[0],
                                                datareader[1]);
                }

                banco.desconectar();

                dataGridViewContentReceitas.Refresh();
            }
            else if(ControleSelecionado == "DESPESAS")
            {
                //Retorna os dados da tabela Produtos para o DataGridView
                string Categoria = ("SELECT idCategoriaFinanceiro, descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'DESPESAS' AND situacao = 'ATIVO' AND descricao LIKE (@descricao + '%') ORDER BY descricao");
                SqlCommand exeVerificacao = new SqlCommand(Categoria, banco.connection);
                banco.conectar();

                exeVerificacao.Parameters.AddWithValue("@descricao", textBoxPesquisar.Text);

                SqlDataReader datareader = exeVerificacao.ExecuteReader();

                dataGridViewContentDespesas.Rows.Clear();
                while (datareader.Read())
                {
                    dataGridViewContentDespesas.Rows.Add(datareader[0],
                                                datareader[1]);
                }

                banco.desconectar();

                dataGridViewContentDespesas.Refresh();
            }
        }

        private void textBoxPesquisar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPesquisar_Click(sender, e);
            }
        }

        private void buttonAdicionarNovo_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            openChildForm(new CategoriaContas.FormCadCategoriaContas());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonExcluirCadastro_Click(object sender, EventArgs e)
        {
            if(ControleSelecionado == "RECEITAS")
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContentReceitas.Rows.Count != 0)
                {
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string categoria = ("DELETE FROM CategoriaFinanceiro WHERE idCategoriaFinanceiroo = @ID");
                            SqlCommand command = new SqlCommand(categoria, banco.connection);

                            command.Parameters.AddWithValue("@ID", dataGridViewContentReceitas.CurrentRow.Cells[0].Value);

                            banco.conectar();
                            command.ExecuteNonQuery();
                            banco.desconectar();

                            MessageBox.Show("Categoria Pagamento apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataCategoriaReceitas();
                            dataGridViewContentReceitas.Refresh();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operção cancelada!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if(ControleSelecionado == "DESPESAS")
            {
                //Query que deleta dados especificos atraves de parametros no banco de dados
                if (dataGridViewContentDespesas.Rows.Count != 0)
                {
                    if (MessageBox.Show("Tem certeza que deseja apagar?" + "\n" + "\n" + "Uma vez apagado, não será mais possivel recupera-lo!", "Ola! Você esta apagando algo do seu sistema!?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            string categoria = ("DELETE FROM CategoriaFinanceiro WHERE idCategoriaFinanceiroo = @ID");
                            SqlCommand command = new SqlCommand(categoria, banco.connection);

                            command.Parameters.AddWithValue("@ID", dataGridViewContentDespesas.CurrentRow.Cells[0].Value);

                            banco.conectar();
                            command.ExecuteNonQuery();
                            banco.desconectar();

                            MessageBox.Show("Categoria Pagamento apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dataCategoriaDespesas();
                            dataGridViewContentDespesas.Refresh();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Custo:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operção cancelada!", "Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridViewContentReceitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContentReceitas.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContentReceitas.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new CategoriaContas.FormCadCategoriaContas());
            }
        }

        private void dataGridViewContentDespesas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Query que deleta dados especificos atraves de parametros no banco de dados
            if (dataGridViewContentDespesas.Rows.Count != 0)
            {
                updateData.receberDados(int.Parse(dataGridViewContentDespesas.CurrentRow.Cells[0].Value.ToString()), true);

                openChildForm(new CategoriaContas.FormCadCategoriaContas());
            }
        }

        private void tabControlContent_Selected(object sender, TabControlEventArgs e)
        {
            ControleSelecionado = e.TabPage.Text;
        }
    }
}
