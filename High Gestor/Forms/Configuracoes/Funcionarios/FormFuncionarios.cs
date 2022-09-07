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

namespace High_Gestor.Forms.Configuracoes.Funcionarios
{
    public partial class FormFuncionarios : Form
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

        public FormFuncionarios()
        {
            InitializeComponent();

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
                SqlCommand exePesquisa = new SqlCommand("SELECT nomeCompleto FROM Funcionario", banco.connection);

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

        private void verificarQuantidadeFuncionarios()
        {
            //Retorna a quantidade de Produtos cadastrados.

            int contagem = 0;

            string query = ("SELECT COUNT(*) FROM Funcionario");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                contagem = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            labelContagem.Text = ("Total: " + contagem + " Registros");
        }

        private void dataFuncionario()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT Funcionario.idFuncionario, Funcionario.codigoFuncionario, Funcionario.nomeCompleto, Perfil.perfil, Funcionario.situacao FROM Funcionario INNER JOIN Perfil ON Funcionario.idPerfilFK = Perfil.idPerfil ORDER BY nomeCompleto");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                if(datareader[1].ToString() != "0")
                {
                    dataGridViewContent.Rows.Add(datareader[0],
                            datareader[1],
                            datareader[2],
                            datareader[3],
                            datareader[4]);
                }
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            pesquisaAutoComplete();
            verificarQuantidadeFuncionarios();
            //
            dataFuncionario();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }

        private void panelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (ViewForms._responseViewForm() == true)
            {
                pesquisaAutoComplete();
                verificarQuantidadeFuncionarios();
                dataFuncionario();
                dataGridViewContent.Refresh();
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT Funcionario.idFuncionario, Funcionario.codigoFuncionario, Funcionario.nomeCompleto, Perfil.perfil, Funcionario.situacao FROM Funcionario INNER JOIN Perfil ON Funcionario.idPerfilFK = Perfil.idPerfil WHERE nomeCompleto LIKE (@nomeCompleto + '%') ORDER BY nomeCompleto");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            exeVerificacao.Parameters.AddWithValue("@nomeCompleto", textBoxPesquisar.Text);

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            dataGridViewContent.Rows.Clear();
            while (datareader.Read())
            {
                dataGridViewContent.Rows.Add(datareader[0],
                                            datareader[1],
                                            datareader[2],
                                            datareader[3],
                                            datareader[4]);
            }

            banco.desconectar();

            dataGridViewContent.Refresh();
        }

        private void textBoxPesquisar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPesquisar_Click(sender, e);
            }
        }

        private void buttonNovoCadastro_Click(object sender, EventArgs e)
        {
            updateData.receberDados(0, false);

            openChildForm(new Funcionarios.FormCadFuncionarios());
        }

        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ESTA FUÇÃO ESTA EM DESENVOLVIMENTO...", "Oppa!!! Ainda não.", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        string query = ("DELETE FROM Funcionario WHERE idFuncionario = @ID");
                        SqlCommand command = new SqlCommand(query, banco.connection);

                        command.Parameters.AddWithValue("@ID", dataGridViewContent.CurrentRow.Cells[0].Value);

                        banco.conectar();
                        command.ExecuteNonQuery();
                        banco.desconectar();

                        MessageBox.Show("Funcionario apagado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataFuncionario();
                        dataGridViewContent.Refresh();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Funcionario:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                openChildForm(new Funcionarios.FormCadFuncionarios());
            }
        }

        private void FormFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        
    }
}
