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
    public partial class FormListaParametros : Form
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

        public FormListaParametros()
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

        #endregion

        public void DrawLinePointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Silver, 1);

            // Create coordinates of points that define line.
            int x1 = 20;
            int y1 = 50;
            int x2 = Width - 50;
            int y2 = 50;

            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }

        private bool verificarCampos()
        {
            bool validacao = false;
            
            if(textBoxValorPorcentagem.Text != string.Empty)
            {
                validacao = true;
            }
            else
            {
                validacao = false;
            }

            return validacao;
        }

        private void queryUpdateLista()
        {
            string tipoAjuste = string.Empty;
            string modalidade = string.Empty;
            decimal baseCalculo = 0;

            if (radioButtonAcrescimo.Checked == true)
            {
                tipoAjuste = "ACRESCIMO";
            }
            else if (radioButtonDesconto.Checked == true)
            {
                tipoAjuste = "DESCONTO";
            }

            if(radioButtonValorProduto.Checked == true)
            {
                modalidade = "VALOR PRODUTO";

                if (textBoxValorPorcentagem.Text != string.Empty)
                {
                    baseCalculo = decimal.Parse(textBoxValorPorcentagem.Text);
                }

                string query = ("UPDATE ListaPreco SET tipoAjuste = @tipoAjuste, baseCalculoValorProduto = @baseCalculoValorProduto, modalidadeAjuste = @modalidade, idLog = @idLog, updatedAt = @updatedAt WHERE idListaPreco = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@modalidade", modalidade);
                exeQuery.Parameters.AddWithValue("@tipoAjuste", tipoAjuste);
                exeQuery.Parameters.AddWithValue("@baseCalculoValorProduto", baseCalculo);
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Lista de Preços atualizada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(radioButtonValorProdutoListaSelecionada.Checked == true)
            {
                modalidade = "VALOR LISTA";

                if (textBoxValorPorcentagem.Text != string.Empty)
                {
                    baseCalculo = decimal.Parse(textBoxValorPorcentagem.Text);
                }

                string query = ("UPDATE ListaPreco SET tipoAjuste = @tipoAjuste, baseCalculoValorLista = @baseCalculoValorLista, modalidadeAjuste = @modalidade, idLog = @idLog, updatedAt = @updatedAt WHERE idListaPreco = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@modalidade", modalidade);
                exeQuery.Parameters.AddWithValue("@tipoAjuste", tipoAjuste);
                exeQuery.Parameters.AddWithValue("@baseCalculoValorLista", baseCalculo);
                exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                exeQuery.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Lista de Preços atualizada com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormListaParametros_Load(object sender, EventArgs e)
        {
            radioButtonValorProduto.Checked = true;
            radioButtonAcrescimo.Checked = true;

            if (updateData._retornarID() == 1)
            {
                panelEscolha1.Enabled = false;
                panelEscolha2.Enabled = false;
                buttonSalvar.Enabled = false;
            }
            else if(updateData._retornarID() != 1)
            {
                panelEscolha1.Enabled = true;
                panelEscolha2.Enabled = true;
                buttonSalvar.Enabled = true;
            }
        }

        private void FormListaParametros_Paint(object sender, PaintEventArgs e)
        {
            DrawLinePointF(e);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (verificarCampos() == true)
            {
                if (MessageBox.Show("Tem certeza que deseja realmente atualizar os valores dessa lista?" + "\n" + "\n" + "Uma vez atualizados, não será mais possivel voltar atrás!", "Ola! Aviso de sistema!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    queryUpdateLista();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Operação cancelada!", "Operação não concluida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("O campo Valor para Atualização nao pode estar vazio!", "Operação não concluida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormListaParametros_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateData.receberDados(0, false);
            ViewForms.requestViewForm(true, false);
        }

    }
}
