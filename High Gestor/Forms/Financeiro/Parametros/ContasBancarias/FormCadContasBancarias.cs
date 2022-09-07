using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Financeiro.Parametros.ContasBancarias
{
    public partial class FormCadContasBancarias : Form
    {
        Banco banco = new Banco();

        DataTable ContasBancarias = new DataTable();

        public FormCadContasBancarias()
        {
            InitializeComponent();

            inicializarDataTable();
        }

        private void inicializarDataTable()
        {
            ContasBancarias.Columns.Add("idContaBancaria", typeof(int));
            ContasBancarias.Columns.Add("padraoReceitas", typeof(string));
            ContasBancarias.Columns.Add("padraoDespesas", typeof(string));
        }

        private void limparValores()
        {
            comboBoxBanco.Text = "";
            textBoxNomeConta.Clear();

            textBoxSaldoInicial.Text = string.Format("{0:#,##0.00}", 0d);
            textBoxSaldoInicial.Select(textBoxSaldoInicial.Text.Length, 0);

            dateTimeDataInicial.Value = DateTime.Now;

            comboBoxSituacao.SelectedIndex = 0;
            comboBoxPadraoReceitas.SelectedIndex = 1;
            comboBoxPadraoDespesas.SelectedIndex = 1;
            //

            comboBoxBanco.Focus();
        }

        private bool verificarCamposPreenchidos()
        {
            bool liberado = false;

            if (comboBoxBanco.Text != string.Empty
                && textBoxNomeConta.Text != string.Empty)
            {
                liberado = true;
            }

            return liberado;
        }

        private bool verificarContaExistente()
        {
            string message = string.Empty;
            bool existente = false;

            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT nomeConta FROM ContasBancarias WHERE nomeConta = @descricao");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            verificarCategoria.Parameters.AddWithValue("@descricao", textBoxNomeConta.Text);

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            if (datareader.Read())
            {
                existente = true;

                if (textBoxNomeConta.Text == datareader[0].ToString())
                {
                    message = "Ja existe uma Conta bancária com este nome.";
                }

                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            banco.desconectar();

            return existente;
        }

        private void verificarContaContasPadroes(string padraoReceitas, string padraoDespesas)
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT idContaBancaria, padraoReceitas, padraoDespesas FROM ContasBancarias");
            SqlCommand verificarCategoria = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = verificarCategoria.ExecuteReader();

            while (datareader.Read())
            {
                ContasBancarias.Rows.Add(datareader[0].ToString(), datareader[1].ToString(), datareader[2].ToString());
            }
            banco.desconectar();


            for (int i = 0; i < ContasBancarias.Rows.Count; i++)
            {
                if (padraoReceitas == "SIM" && padraoDespesas == "SIM")
                {
                    string queryUpdate = ("UPDATE ContasBancarias SET padraoReceitas = @padraoReceitas, padraoDespesas = @padraoDespesas");
                    SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                    exeQueryUpdate.Parameters.AddWithValue("@padraoReceitas", "NAO");
                    exeQueryUpdate.Parameters.AddWithValue("@padraoDespesas", "NAO");

                    banco.conectar();
                    exeQueryUpdate.ExecuteNonQuery();
                    banco.desconectar();
                }

                if (padraoReceitas == "SIM" && padraoDespesas == "NAO")
                {
                    if (ContasBancarias.Rows[i][1].ToString() == "SIM" && ContasBancarias.Rows[i][2].ToString() == "SIM")
                    {
                        string queryUpdate = ("UPDATE ContasBancarias SET padraoReceitas = @padraoReceitas, padraoDespesas = @padraoDespesas WHERE idContaBancaria = @ID");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.AddWithValue("@padraoReceitas", "NAO");
                        exeQueryUpdate.Parameters.AddWithValue("@padraoDespesas", "SIM");
                        exeQueryUpdate.Parameters.AddWithValue("@ID", ContasBancarias.Rows[i][0].ToString());

                        banco.conectar();
                        exeQueryUpdate.ExecuteNonQuery();
                        banco.desconectar();
                    }
                    else if (ContasBancarias.Rows[i][1].ToString() == "SIM" && ContasBancarias.Rows[i][2].ToString() == "NAO")
                    {
                        string queryUpdate = ("UPDATE ContasBancarias SET padraoReceitas = @padraoReceitas WHERE idContaBancaria = @ID");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.AddWithValue("@padraoReceitas", "NAO");
                        exeQueryUpdate.Parameters.AddWithValue("@ID", ContasBancarias.Rows[i][0].ToString());

                        banco.conectar();
                        exeQueryUpdate.ExecuteNonQuery();
                        banco.desconectar();
                    }
                    
                }

                if (padraoReceitas == "NAO" && padraoDespesas == "SIM")
                {
                    if (ContasBancarias.Rows[i][1].ToString() == "SIM" && ContasBancarias.Rows[i][2].ToString() == "SIM")
                    {
                        string queryUpdate = ("UPDATE ContasBancarias SET padraoReceitas = @padraoReceitas, padraoDespesas = @padraoDespesas WHERE idContaBancaria = @ID");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.AddWithValue("@padraoReceitas", "SIM");
                        exeQueryUpdate.Parameters.AddWithValue("@padraoDespesas", "NAO");
                        exeQueryUpdate.Parameters.AddWithValue("@ID", ContasBancarias.Rows[i][0].ToString());

                        banco.conectar();
                        exeQueryUpdate.ExecuteNonQuery();
                        banco.desconectar();
                    }
                    else if (ContasBancarias.Rows[i][1].ToString() == "NAO" && ContasBancarias.Rows[i][2].ToString() == "SIM")
                    {
                        string queryUpdate = ("UPDATE ContasBancarias SET padraoDespesas = @padraoDespesas WHERE idContaBancaria = @ID");
                        SqlCommand exeQueryUpdate = new SqlCommand(queryUpdate, banco.connection);

                        exeQueryUpdate.Parameters.AddWithValue("@padraoDespesas", "NAO");
                        exeQueryUpdate.Parameters.AddWithValue("@ID", ContasBancarias.Rows[i][0].ToString());

                        banco.conectar();
                        exeQueryUpdate.ExecuteNonQuery();
                        banco.desconectar();
                    }

                }
            }
        }

        private void carregarDados()
        {
            string select = ("SELECT nomeBanco, nomeConta, saldoInicial, dataInicial, situacao, padraoReceitas, padraoDespesas FROM ContasBancarias WHERE idContaBancaria = @ID");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            exeSelect.Parameters.AddWithValue("@ID", updateData._retornarID());

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();
            
            if(reader.Read())
            {
                string nomeBanco = string.Empty;

                if(reader[0].ToString() == "CARTEIRA")
                {
                    nomeBanco = "NAO E UM BANCO (CARTAO, CAIXINHA, ETC)";
                }

                comboBoxBanco.Text = nomeBanco;
                textBoxNomeConta.Text = reader[1].ToString();
                textBoxSaldoInicial.Text = reader.GetDecimal(2).ToString("N2");
                dateTimeDataInicial.Value = reader.GetDateTime(3);
                comboBoxSituacao.Text = reader[4].ToString();
                comboBoxPadraoReceitas.Text = reader[5].ToString();
                comboBoxPadraoDespesas.Text = reader[6].ToString();
            }
            banco.desconectar();
        }

        private void insertQuery()
        {
            string nomeBanco = string.Empty;
            decimal saldoInicial = 0;

            verificarContaContasPadroes(comboBoxPadraoReceitas.Text, comboBoxPadraoDespesas.Text);

            if(textBoxSaldoInicial.Text != string.Empty)
            {
                saldoInicial = decimal.Parse(textBoxSaldoInicial.Text);
            }

            if(comboBoxBanco.Text == "NAO E UM BANCO (CARTAO, CAIXINHA, ETC)")
            {
                nomeBanco = "CARTEIRA";
            }
            else
            {
                nomeBanco = comboBoxBanco.Text;
            }

            try
            {
                string query = ("INSERT INTO ContasBancarias (situacao, nomeBanco, nomeConta, saldoInicial, dataInicial, padraoReceitas, padraoDespesas) VALUES (@situacao, @nomeBanco, @nomeConta, @saldoInicial, @dataInicial, @padraoReceitas, @padraoDespesas)");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                exeQuery.Parameters.AddWithValue("@nomeBanco", nomeBanco);
                exeQuery.Parameters.AddWithValue("@nomeConta", textBoxNomeConta.Text);
                exeQuery.Parameters.AddWithValue("@saldoInicial", saldoInicial);
                exeQuery.Parameters.AddWithValue("@dataInicial", dateTimeDataInicial.Value);
                exeQuery.Parameters.AddWithValue("@padraoReceitas", comboBoxPadraoReceitas.Text);
                exeQuery.Parameters.AddWithValue("@padraoDespesas", comboBoxPadraoDespesas.Text);

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro realizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void updateQuery()
        {
            string nomeBanco = string.Empty;
            decimal saldoInicial = 0;

            verificarContaContasPadroes(comboBoxPadraoReceitas.Text, comboBoxPadraoDespesas.Text);

            if (textBoxSaldoInicial.Text != string.Empty)
            {
                saldoInicial = decimal.Parse(textBoxSaldoInicial.Text);
            }

            if (comboBoxBanco.Text == "NAO E UM BANCO (CARTAO, CAIXINHA, ETC)")
            {
                nomeBanco = "CARTEIRA";
            }
            else
            {
                nomeBanco = comboBoxBanco.Text;
            }

            try
            {
                string query = ("UPDATE ContasBancarias SET situacao = @situacao, nomeBanco = @nomeBanco, nomeConta = @nomeConta, saldoInicial = @saldoInicial, dataInicial = @dataInicial, padraoReceitas = @padraoReceitas, padraoDespesas = @padraoDespesas WHERE idContaBancaria = @ID");
                SqlCommand exeQuery = new SqlCommand(query, banco.connection);

                exeQuery.Parameters.AddWithValue("@situacao", comboBoxSituacao.Text);
                exeQuery.Parameters.AddWithValue("@nomeBanco", nomeBanco);
                exeQuery.Parameters.AddWithValue("@nomeConta", textBoxNomeConta.Text);
                exeQuery.Parameters.AddWithValue("@saldoInicial", saldoInicial);
                exeQuery.Parameters.AddWithValue("@dataInicial", dateTimeDataInicial.Value);
                exeQuery.Parameters.AddWithValue("@padraoReceitas", comboBoxPadraoReceitas.Text);
                exeQuery.Parameters.AddWithValue("@padraoDespesas", comboBoxPadraoDespesas.Text);
                exeQuery.Parameters.AddWithValue("@ID", updateData._retornarID());

                banco.conectar();
                exeQuery.ExecuteNonQuery();
                banco.desconectar();

                MessageBox.Show("Cadastro atuaizado com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + erro.Message, "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void FormCadContasBancarias_Load(object sender, EventArgs e)
        {
            limparValores();

            if (updateData._retornarValidacao() == true)
            {
                carregarDados();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparValores();
            //
            this.Close();
        }

        private void FormCadContasBancarias_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewForms.requestViewForm(true, false);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (updateData._retornarValidacao() == true)
            {
                updateQuery();
            }
            else
            {
                if (verificarCamposPreenchidos() == true)
                {
                    if (verificarContaExistente() == false)
                    {
                        insertQuery();
                        //
                        limparValores();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel concluir a operação..." + "\n" + "\n" + "Erro do Sistema:" + "\n" + "\n" + "Categoria:" + "\n" + "\n" + "Todos os campos estão vazios...", "Oppa!!! Temos problema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonSalvar_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.KeyCode == Keys.Enter)
            {
                buttonSalvar_Click(sender, e);
            }
        }

        private void textBoxSaldoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox value = (TextBox)sender;
                string stringValue = Regex.Replace(value.Text, "[^0-9]", string.Empty);
                if (stringValue == string.Empty) stringValue = "00";

                if (e.KeyChar.Equals((char)Keys.Back))      //  If backspace
                    stringValue = stringValue.Substring(0, stringValue.Length - 1);      //      takes out the rightmost digit
                else
                    stringValue += e.KeyChar;

                value.Text = string.Format("{0:#,##0.00}", Double.Parse(stringValue) / 100);
                value.Select(value.Text.Length, 0);
            }

            e.Handled = true;
        }
    }
}
