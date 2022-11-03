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

namespace High_Gestor.Forms.Vendas.PDV.ParametrosPDV.Gerais
{
    public partial class UserControl_Gerais : UserControl
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

        public UserControl_Gerais()
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

        private void apenasNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //aceita apenas números, tecla backspace.
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void DataListaPreco()
        {
            string select = ("SELECT descricao FROM ListaPreco");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxListaPreco.Items.Clear();

            while (reader.Read())
            {
                comboBoxListaPreco.Items.Add(reader.GetString(0));
            }
            banco.desconectar();
        }

        private string carregarListaPreco(int idListaPreco)
        {
            string ListaPreco = string.Empty;

            string select = ("SELECT descricao FROM ListaPreco WHERE idListaPreco = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", idListaPreco);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if(reader.Read())
            {
                ListaPreco = reader.GetString(0);
            }
            banco.desconectar();

            return ListaPreco;
        }

        private int verificarIdListaPreco(string ListaPreco)
        {
            int IdListaPreco = 0;

            string select = ("SELECT idListaPreco FROM ListaPreco WHERE descricao = @nome");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@nome", ListaPreco);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                IdListaPreco = reader.GetInt32(0);
            }
            banco.desconectar();

            return IdListaPreco;
        }

        private void DataCategoriaFinanceiro_DESPESAS()
        {
            string select = ("SELECT descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'DESPESAS'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxCategoriaPadraoReforco.Items.Clear();

            while (reader.Read())
            {
                comboBoxCategoriaPadraoReforco.Items.Add(reader.GetString(0));
            }
            banco.desconectar();
        }

        private void DataCategoriaFinanceiro_RECEITAS()
        {
            string select = ("SELECT descricao FROM CategoriaFinanceiro WHERE tipoCategoria = 'RECEITAS'");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            comboBoxCategoriaPadraoSangria.Items.Clear();

            while (reader.Read())
            {
                comboBoxCategoriaPadraoSangria.Items.Add(reader.GetString(0));
            }
            banco.desconectar();
        }

        private string carregarCategoriaFinanceiro_RECEITAS(int idCategoriaFinanceiro)
        {
            string CategoriaFinanceiro = string.Empty;

            string select = ("SELECT descricao FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", idCategoriaFinanceiro);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                CategoriaFinanceiro = reader.GetString(0);
            }
            banco.desconectar();

            return CategoriaFinanceiro;
        }

        private string carregarCategoriaFinanceiro_DESPESAS(int idCategoriaFinanceiro)
        {
            string CategoriaFinanceiro = string.Empty;

            string select = ("SELECT descricao FROM CategoriaFinanceiro WHERE idCategoriaFinanceiro = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", idCategoriaFinanceiro);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                CategoriaFinanceiro = reader.GetString(0);
            }
            banco.desconectar();

            return CategoriaFinanceiro;
        }

        private int verificarIdCategoriaFinanceiro(string CategoriaFinanceiro, string tipoCategoria)
        {
            int IdCategoriaFinanceiro = 0;

            string select = ("SELECT idCategoriaFinanceiro FROM CategoriaFinanceiro WHERE descricao = @nome AND tipoCategoria = @tipo");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@nome", CategoriaFinanceiro);
            exeSelect.Parameters.AddWithValue("@tipo", tipoCategoria);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                IdCategoriaFinanceiro = reader.GetInt32(0);
            }
            banco.desconectar();

            return IdCategoriaFinanceiro;
        }

        private void carregarDados()
        {
            int IdListaPreco = 0, IdCategoriaPadraoReforco = 0, IdCategoriaPadraoSangria = 0;

            string query = ("SELECT aberturaFechamentoCaixa, idCategoriaPadraoReforco, idCategoriaPadraoSangria, lancarEstoque, lancarContasReceber, lancarComissao, tipoDesconto, descontoMaximo, tipoAcrescimo, acrescimoMaximo, qntDiaFaturarCredito, qntDiaFaturarDebito, somenteDiasUteis, valeBrinde, alterarPrecoVenda, alterarOperador, idListaPrecoFK FROM ParametrosPDV");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            SqlDataReader datareader = exeQuery.ExecuteReader();

            while (datareader.Read())
            {
                comboBoxAberturaFechamentoCaixa.Text = datareader.GetString(0);
                comboBoxLancarEstoque.Text = datareader.GetString(3);
                comboBoxLancarContasReceber.Text = datareader.GetString(4);
                comboBoxLancarComissao.Text = datareader.GetString(5);
                comboBoxTipoDesconto.Text = datareader.GetString(6);
                textBoxDescontoMaximo.Text = datareader.GetDecimal(7).ToString("N2");
                comboBoxTipoAcrescimo.Text = datareader.GetString(8);
                textBoxAcrescimoMaximo.Text = datareader.GetDecimal(9).ToString("N2");
                textBoxQntDiasCartaoCredito.Text = datareader.GetInt32(10).ToString();
                textBoxQntDiasCartaoDebito.Text = datareader.GetInt32(11).ToString();
                comboBoxSomenteDiasUteis.Text = datareader.GetString(12);
                textBoxValeBrinde.Text = datareader.GetDecimal(13).ToString("N2");
                comboBoxAlterarPrecoVenda.Text = datareader.GetString(14);
                comboBoxAlterarOperador.Text = datareader.GetString(15);
                IdCategoriaPadraoReforco = datareader.GetInt32(1);
                IdCategoriaPadraoSangria = datareader.GetInt32(2);
                IdListaPreco = datareader.GetInt32(16);
            }
            banco.desconectar();

            comboBoxCategoriaPadraoReforco.Text = carregarCategoriaFinanceiro_DESPESAS(IdCategoriaPadraoReforco);
            comboBoxCategoriaPadraoSangria.Text = carregarCategoriaFinanceiro_RECEITAS(IdCategoriaPadraoSangria);
            comboBoxListaPreco.Text = carregarListaPreco(IdListaPreco);
        }

        private void UpdateQuery()
        {
            string update = ("UPDATE ParametrosPDV SET aberturaFechamentoCaixa = @aberturaFechamentoCaixa, idCategoriaPadraoReforco = @idCategoriaPadraoReforco, idCategoriaPadraoSangria = @idCategoriaPadraoSangria, lancarEstoque = @lancarEstoque, lancarContasReceber = @lancarContasReceber, lancarComissao = @lancarComissao, tipoDesconto = @tipoDesconto, descontoMaximo = @descontoMaximo, tipoAcrescimo = @tipoAcrescimo, acrescimoMaximo = @acrescimoMaximo, qntDiaFaturarCredito = @qntDiaFaturarCredito, qntDiaFaturarDebito = @qntDiaFaturarDebito, somenteDiasUteis = @somenteDiasUteis, valeBrinde = @valeBrinde, alterarPrecoVenda = @alterarPrecoVenda, alterarOperador = @alterarOperador, idListaPrecoFK = @idListaPrecoFK, idLog = @idLog, updatedAt = @updatedAt");
            SqlCommand exeUpdate = new SqlCommand(update, banco.connection);

            exeUpdate.Parameters.AddWithValue("@aberturaFechamentoCaixa", comboBoxAberturaFechamentoCaixa.Text);
            exeUpdate.Parameters.AddWithValue("@idCategoriaPadraoReforco", verificarIdCategoriaFinanceiro(comboBoxCategoriaPadraoReforco.Text, "DESPESAS"));
            exeUpdate.Parameters.AddWithValue("@idCategoriaPadraoSangria", verificarIdCategoriaFinanceiro(comboBoxCategoriaPadraoSangria.Text, "RECEITAS"));
            exeUpdate.Parameters.AddWithValue("@lancarEstoque", comboBoxLancarEstoque.Text);
            exeUpdate.Parameters.AddWithValue("@lancarContasReceber", comboBoxLancarContasReceber.Text);
            exeUpdate.Parameters.AddWithValue("@lancarComissao", comboBoxLancarComissao.Text);
            exeUpdate.Parameters.AddWithValue("@tipoDesconto", comboBoxTipoDesconto.Text);
            exeUpdate.Parameters.AddWithValue("@descontoMaximo", decimal.Parse(textBoxDescontoMaximo.Text));
            exeUpdate.Parameters.AddWithValue("@tipoAcrescimo", comboBoxTipoAcrescimo.Text);
            exeUpdate.Parameters.AddWithValue("@acrescimoMaximo", decimal.Parse(textBoxAcrescimoMaximo.Text));
            exeUpdate.Parameters.AddWithValue("@qntDiaFaturarCredito", int.Parse(textBoxQntDiasCartaoCredito.Text));
            exeUpdate.Parameters.AddWithValue("@qntDiaFaturarDebito", int.Parse(textBoxQntDiasCartaoDebito.Text));
            exeUpdate.Parameters.AddWithValue("@somenteDiasUteis", comboBoxSomenteDiasUteis.Text);
            exeUpdate.Parameters.AddWithValue("@valeBrinde", decimal.Parse(textBoxValeBrinde.Text));
            exeUpdate.Parameters.AddWithValue("@alterarPrecoVenda", comboBoxAlterarPrecoVenda.Text);
            exeUpdate.Parameters.AddWithValue("@alterarOperador", comboBoxAlterarOperador.Text);
            exeUpdate.Parameters.AddWithValue("@idListaPrecoFK", verificarIdListaPreco(comboBoxListaPreco.Text));
            exeUpdate.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeUpdate.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            banco.conectar();
            exeUpdate.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControl_Gerais_Load(object sender, EventArgs e)
        {
            DataCategoriaFinanceiro_DESPESAS();
            DataCategoriaFinanceiro_RECEITAS();
            DataListaPreco();

            carregarDados();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            UpdateQuery();
        }
    }
}
