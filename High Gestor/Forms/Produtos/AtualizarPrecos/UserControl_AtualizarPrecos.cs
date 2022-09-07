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

namespace High_Gestor.Forms.Produtos.AtualizarPrecos
{
    public partial class UserControl_AtualizarPrecos : UserControl
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

        FormProdutos instancia;

        DataTable ListaPreco = new DataTable();
        DataTable Produto = new DataTable();

        ItemLista.UserControl_ItemPreco[] itemPreco;

        string TipoAjuste = string.Empty;

        public UserControl_AtualizarPrecos(FormProdutos Produto)
        {
            InitializeComponent();
            instancia = Produto;

            inicializarDataTables();
        }

        #region Event Components

        private void button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;

            button.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button.Width,
            button.Height, 3, 3));
        }

        #endregion

        private void inicializarDataTables()
        {
            ListaPreco.Columns.Add("IdListaPreco", typeof(int));
            ListaPreco.Columns.Add("Descricao", typeof(string));
            ListaPreco.Columns.Add("ModalidadeAjuste", typeof(string));
            ListaPreco.Columns.Add("TipoAjuste", typeof(string));
            ListaPreco.Columns.Add("BaseCalculoValorProduto", typeof(decimal));
            ListaPreco.Columns.Add("BaseCalculoValorLista", typeof(decimal));


            Produto.Columns.Add("IdProduto", typeof(int));
            Produto.Columns.Add("ValorVenda", typeof(decimal));
            Produto.Columns.Add("ValorCusto", typeof(decimal));
            Produto.Columns.Add("Margem", typeof(decimal));
        }

        private void carregarListaPreco()
        {
            string select = ("SELECT idListaPreco, descricao, modalidadeAjuste, tipoAjuste, baseCalculoValorProduto, baseCalculoValorLista FROM ListaPreco");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            while(reader.Read())
            {
                ListaPreco.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1), 
                    reader.GetString(2), 
                    reader.GetString(3), 
                    reader.GetDecimal(4),
                    reader.GetDecimal(5));
            }
            banco.desconectar();
        }

        private void carregarProduto()
        {
            string select = ("SELECT idProduto, valorVenda, valorCusto, margemLucro FROM Produtos WHERE idProduto = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                Produto.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDecimal(1),
                    reader.GetDecimal(2),
                    reader.GetDecimal(3));
            }
            banco.desconectar();
        }

        private decimal CalcularValorProduto(string modalidadeAjuste, string tipoAjuste, decimal baseCalculoValorProduto, decimal baseCalculoValorLista)
        {
            decimal valorProduto = 0, valorVenda = decimal.Parse(Produto.Rows[0][1].ToString());

            if(modalidadeAjuste == "VALOR PRODUTO")
            {
                if(tipoAjuste == "ACRESCIMO")
                {
                    valorProduto = valorVenda + (valorVenda * (baseCalculoValorProduto / 100));
                }
                else if(tipoAjuste == "DESCONTO")
                {
                    valorProduto = valorVenda - (valorVenda * (baseCalculoValorProduto / 100));
                }
            }
            else if (modalidadeAjuste == "VALOR LISTA")
            {
                decimal valorLista = 0;

                if (tipoAjuste == "ACRESCIMO")
                {
                    valorLista = valorVenda + (valorVenda * (baseCalculoValorProduto / 100));

                    valorProduto = valorLista + (valorLista * (baseCalculoValorLista / 100));
                }
                else if (tipoAjuste == "DESCONTO")
                {
                    valorLista = valorVenda - (valorVenda * (baseCalculoValorProduto / 100));

                    valorProduto = valorLista - (valorLista * (baseCalculoValorLista / 100));
                }
            }
            else if (modalidadeAjuste == "PADRAO")
            {
                valorProduto = valorVenda;
            }

            return valorProduto;
        }

        private void carregarListaItem()
        {

            itemPreco = new ItemLista.UserControl_ItemPreco[ListaPreco.Rows.Count];

            flowLayoutPanelContent.Controls.Clear();

            for (int i = 0; i < ListaPreco.Rows.Count; i++)
            {
                string modalidadeAjuste = ListaPreco.Rows[i][2].ToString();
                string tipoAjuste = ListaPreco.Rows[i][3].ToString();
                decimal baseCalculoValorProduto = decimal.Parse(ListaPreco.Rows[i][4].ToString());
                decimal baseCalculoValorLista = decimal.Parse(ListaPreco.Rows[i][5].ToString());

                itemPreco[i] = new ItemLista.UserControl_ItemPreco();
                itemPreco[i].Descricao = ListaPreco.Rows[i][1].ToString();
                itemPreco[i].ValorProduto = CalcularValorProduto(modalidadeAjuste, tipoAjuste, baseCalculoValorProduto, baseCalculoValorLista);

                flowLayoutPanelContent.Controls.Add(itemPreco[i]);
            }
        }

        private decimal CalcularNovaBaseCalculo(string modalidadeAjuste, decimal baseCalculoValorProduto, decimal NovoValor)
        {
            decimal baseCalculo = 0, valorProduto, valorVenda = decimal.Parse(Produto.Rows[0][1].ToString());

            if (modalidadeAjuste == "VALOR PRODUTO")
            {
                if (NovoValor >= valorVenda)
                {
                    TipoAjuste = "ACRESCIMO";

                    baseCalculo = (NovoValor - valorVenda) / (valorVenda / 100);
                }
                else
                {
                    TipoAjuste = "DESCONTO";

                    baseCalculo = (valorVenda - NovoValor) / (valorVenda / 100);
                }
            }
            else if (modalidadeAjuste == "VALOR LISTA")
            {
                valorProduto = valorVenda + (valorVenda * (baseCalculoValorProduto / 100));

                if (NovoValor >= valorVenda)
                {
                    TipoAjuste = "ACRESCIMO";

                    baseCalculo = (NovoValor - valorProduto) / (valorProduto / 100);
                }
                else
                {
                    TipoAjuste = "DESCONTO";

                    baseCalculo = (valorProduto - NovoValor) / (valorProduto / 100);
                }
            }
            else if (modalidadeAjuste == "PADRAO")
            {
                decimal valorCusto = decimal.Parse(Produto.Rows[0][2].ToString());

                baseCalculo = (NovoValor - valorCusto) / (valorCusto / 100);
            }

            return baseCalculo;
        }

        private void updateQuery()
        {
            for (int i = 0; i < ListaPreco.Rows.Count; i++)
            {
                if (itemPreco[i].textBoxValorLista.Text != string.Empty && itemPreco[i].textBoxValorLista.Text != "0" && itemPreco[i].textBoxValorLista.Text != "0,00")
                {
                    int idListaPreco = int.Parse(ListaPreco.Rows[i][0].ToString());
                    string modalidadeAjuste = ListaPreco.Rows[i][2].ToString();
                    decimal baseCalculoValorProduto = decimal.Parse(ListaPreco.Rows[i][4].ToString());
                    decimal baseCalculoValorLista = decimal.Parse(ListaPreco.Rows[i][5].ToString());
                    decimal valorAtualizado = decimal.Parse(itemPreco[i].textBoxValorLista.Text);

                    if (modalidadeAjuste == "VALOR PRODUTO")
                    {
                        decimal margem = CalcularNovaBaseCalculo(ListaPreco.Rows[i][2].ToString(), baseCalculoValorProduto, valorAtualizado);

                        if (margem != decimal.Parse(ListaPreco.Rows[i][4].ToString()))
                        {
                            string query = ("UPDATE ListaPreco SET tipoAjuste = @tipoAjuste, baseCalculoValorProduto = @baseCalculoValorProduto, idLog = @idLog WHERE idListaPreco = @ID");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@tipoAjuste", TipoAjuste);
                            exeQuery.Parameters.AddWithValue("@baseCalculoValorProduto", CalcularNovaBaseCalculo(ListaPreco.Rows[i][2].ToString(), baseCalculoValorProduto, valorAtualizado));
                            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(Autenticacao._idUsuario(), "Produtos/Atualizar Valores", "ListaPreco", query, "Altualizando a lista de acordo com o valor total do produto"));
                            exeQuery.Parameters.AddWithValue("@ID", idListaPreco);

                            banco.conectar();
                            exeQuery.ExecuteNonQuery();
                            banco.desconectar();
                        }
                    }
                    else if (modalidadeAjuste == "VALOR LISTA")
                    {
                        decimal margem = CalcularNovaBaseCalculo(ListaPreco.Rows[i][2].ToString(), baseCalculoValorProduto, valorAtualizado);

                        if (margem != decimal.Parse(ListaPreco.Rows[i][5].ToString()))
                        {
                            string query = ("UPDATE ListaPreco SET tipoAjuste = @tipoAjuste, baseCalculoValorLista = @baseCalculoValorLista, idLog = @idLog WHERE idListaPreco = @ID");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@tipoAjuste", TipoAjuste);
                            exeQuery.Parameters.AddWithValue("@baseCalculoValorLista", CalcularNovaBaseCalculo(ListaPreco.Rows[i][2].ToString(), baseCalculoValorProduto, valorAtualizado));
                            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(Autenticacao._idUsuario(), "Produtos/Atualizar Valores", "ListaPreco", query, "Altualizando a lista com referencia ao valor do produto nalisata selecionada"));
                            exeQuery.Parameters.AddWithValue("@ID", idListaPreco);

                            banco.conectar();
                            exeQuery.ExecuteNonQuery();
                            banco.desconectar();
                        }
                    }
                    else if (modalidadeAjuste == "PADRAO")
                    {
                        int idProduto = int.Parse(Produto.Rows[0][0].ToString());
                        decimal valorCusto = decimal.Parse(Produto.Rows[0][2].ToString());
                        decimal margem = CalcularNovaBaseCalculo(ListaPreco.Rows[i][2].ToString(), baseCalculoValorProduto, valorAtualizado);
                        decimal valorVenda = valorCusto + (valorCusto * (margem / 100));
                        
                        if (margem != decimal.Parse(Produto.Rows[0][3].ToString()))
                        {
                            string query = ("UPDATE Produtos SET margemLucro = @margemLucro, valorVenda = @valorVenda, idLog = @idLog WHERE idProduto = @ID");
                            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                            exeQuery.Parameters.Clear();
                            exeQuery.Parameters.AddWithValue("@valorVenda", valorVenda);
                            exeQuery.Parameters.AddWithValue("@margemLucro", margem);
                            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(Autenticacao._idUsuario(), "Produtos/Atualizar Valores", "ListaPreco", query, "Altualizando valor venda do produto (PADRAO)"));
                            exeQuery.Parameters.AddWithValue("@ID", idProduto);

                            banco.conectar();
                            exeQuery.ExecuteNonQuery();
                            banco.desconectar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema: " + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            MessageBox.Show("Valores atualizados com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UserControl_AtualizarPrecos_Load(object sender, EventArgs e)
        {
            carregarListaPreco();
            carregarProduto();

            carregarListaItem();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            updateQuery();

            instancia.dataProdutos();

            instancia.FecharAcoesPrecos(sender, e);
        }
    }
}
