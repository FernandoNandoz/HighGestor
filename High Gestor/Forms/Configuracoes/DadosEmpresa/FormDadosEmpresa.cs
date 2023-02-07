using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_Gestor.Forms.Configuracoes.DadosEmpresa
{
    public partial class FormDadosEmpresa : Form
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

        bool PrimeiraVez = false;

        public FormDadosEmpresa()
        {
            InitializeComponent(); 

            if (PrimeiroAcesso._retornarDados() == true)
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

        #endregion

        private void verificarTipoPessoa()
        {
            if (comboBoxTipoPessoa.Text == "JURIDICA")
            {
                labelNome_Razao.Text = "Razão social *";
                labelNumeroCPF_CNPJ.Text = "Nº de CNPJ";

                maskedCPF_CNPJ.Mask = "00.000.000/0000-00";
            }
            else if (comboBoxTipoPessoa.Text == "FISICA")
            {
                labelNome_Razao.Text = "Nome completo *";
                labelNumeroCPF_CNPJ.Text = "Nº de CPF";

                maskedCPF_CNPJ.Mask = "000.000.000-00";
            }

            maskedCPF_CNPJ.Focus();
        }

        private void carregarDados()
        {
            //Retorna os dados da tabela Produtos para o DataGridView
            string query = ("SELECT tipoPessoa, nomeCompleto_RazaoSocial, nomeFantasia, responsavel, CPF_CNPJ, inscricaoEstadual, CEP, endereco, numero, bairro, complemento, cidade, estado, telefone, celular, webSite, email FROM DadosEmpresa");
            SqlCommand exeVerificacao = new SqlCommand(query, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            if (datareader.Read())
            {
                PrimeiraVez = false;

                comboBoxTipoPessoa.Text = datareader.GetString(0);
                textBoxNome_Razao.Text = datareader.GetString(1);
                textBoxNomeFantasia.Text = datareader.GetString(2);
                textBoxNomeResponsavel.Text = datareader.GetString(3);
                maskedCPF_CNPJ.Text = datareader.GetString(4);
                maskedTextBoxInscrocaoEstadual.Text = datareader.GetString(5);
                maskedTextBoxCEP.Text = datareader.GetString(6);
                textBoxEndereco.Text = datareader.GetString(7);
                textBoxNumero.Text = datareader.GetString(8);
                textBoxBairro.Text = datareader.GetString(9);
                textBoxComplemento.Text = datareader.GetString(10);
                textBoxCidade.Text = datareader.GetString(11);
                textBoxEstado.Text = datareader.GetString(12);
                maskedTelefone.Text = datareader.GetString(13);
                maskedCelular.Text = datareader.GetString(14);
                textBoxWebSite.Text = datareader.GetString(15);
                textBoxEmail.Text = datareader.GetString(16);
            }
            else
            {
                PrimeiraVez = true;
            }

            banco.desconectar();
        }

        private void ResetarID(string tabela)
        {
            string query = ("DBCC CHECKIDENT(@tabela, RESEED, 0)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@tabela", tabela);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private void queryUpdate()
        {
            string query = ("UPDATE DadosEmpresa SET tipoPessoa = @tipoPessoa, nomeCompleto_RazaoSocial = @nome_Razao, nomeFantasia = @nomeFantasia, responsavel = @responsavel, CPF_CNPJ = @CPF_CNPJ, InscricaoEstadual = @InscricaoEstadual, CEP = @CEP, endereco = @endereco, numero = @numero, bairro = @bairro, complemento = @complemento, cidade = @cidade, estado = @estado, telefone = @telefone, celular = @celular, webSite = @webSite, email = @email");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@tipoPessoa", comboBoxTipoPessoa.Text);
            exeQuery.Parameters.AddWithValue("@nome_Razao", textBoxNome_Razao.Text);
            exeQuery.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
            exeQuery.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);
            exeQuery.Parameters.AddWithValue("@InscricaoEstadual", maskedTextBoxInscrocaoEstadual.Text);
            exeQuery.Parameters.AddWithValue("@responsavel", textBoxNomeResponsavel.Text);
            exeQuery.Parameters.AddWithValue("@CEP", maskedTextBoxCEP.Text);
            exeQuery.Parameters.AddWithValue("@endereco", textBoxEndereco.Text);
            exeQuery.Parameters.AddWithValue("@numero", textBoxNumero.Text);
            exeQuery.Parameters.AddWithValue("@bairro", textBoxBairro.Text);
            exeQuery.Parameters.AddWithValue("@complemento", textBoxComplemento.Text);
            exeQuery.Parameters.AddWithValue("@cidade", textBoxCidade.Text);
            exeQuery.Parameters.AddWithValue("@estado", textBoxEstado.Text);
            exeQuery.Parameters.AddWithValue("@telefone", maskedTelefone.Text);
            exeQuery.Parameters.AddWithValue("@celular", maskedCelular.Text);
            exeQuery.Parameters.AddWithValue("@webSite", textBoxWebSite.Text);
            exeQuery.Parameters.AddWithValue("@email", textBoxEmail.Text);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void queryInsert()
        {
            ResetarID("DadosEmpresa");

            string query = ("INSERT INTO DadosEmpresa (tipoPessoa, nomeCompleto_RazaoSocial, nomeFantasia, responsavel, CPF_CNPJ, InscricaoEstadual, CEP, endereco, numero, bairro, complemento, cidade, estado, telefone, celular, webSite, email) VALUES (@tipoPessoa, @nome_Razao, @nomeFantasia, @responsavel, @CPF_CNPJ, @InscricaoEstadual, @CEP, @endereco, @numero, @bairro, @complemento, @cidade, @estado, @telefone, @celular, @webSite, @email)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@tipoPessoa", comboBoxTipoPessoa.Text);
            exeQuery.Parameters.AddWithValue("@nome_Razao", textBoxNome_Razao.Text);
            exeQuery.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
            exeQuery.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);
            exeQuery.Parameters.AddWithValue("@InscricaoEstadual", maskedTextBoxInscrocaoEstadual.Text);
            exeQuery.Parameters.AddWithValue("@responsavel", textBoxNomeResponsavel.Text);
            exeQuery.Parameters.AddWithValue("@CEP", maskedTextBoxCEP.Text);
            exeQuery.Parameters.AddWithValue("@endereco", textBoxEndereco.Text);
            exeQuery.Parameters.AddWithValue("@numero", textBoxNumero.Text);
            exeQuery.Parameters.AddWithValue("@bairro", textBoxBairro.Text);
            exeQuery.Parameters.AddWithValue("@complemento", textBoxComplemento.Text);
            exeQuery.Parameters.AddWithValue("@cidade", textBoxCidade.Text);
            exeQuery.Parameters.AddWithValue("@estado", textBoxEstado.Text);
            exeQuery.Parameters.AddWithValue("@telefone", maskedTelefone.Text);
            exeQuery.Parameters.AddWithValue("@celular", maskedCelular.Text);
            exeQuery.Parameters.AddWithValue("@webSite", textBoxWebSite.Text);
            exeQuery.Parameters.AddWithValue("@email", textBoxEmail.Text);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();

            insertParametrosImpressao();

            MessageBox.Show("Salvo com Sucesso!", "Parabens! Operação bem sucedida!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            PrimeiroAcesso.receberDados(false);
            PrimeiroAcesso.receberDadosEmpresa(true);
        }

        private void insertParametrosImpressao()
        {
            string CPF_CNPJ = string.Empty;
            string endereco = textBoxEndereco.Text;
            string numero = textBoxNumero.Text;
            string bairro = textBoxBairro.Text;
            string cidade = textBoxCidade.Text;
            string estado = textBoxEstado.Text;
            string cep = maskedTextBoxCEP.Text;
            string fone = maskedCelular.Text;
            string mensagemCliente = "Obrigado pela preferência. Volte sempre!!";

            TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;

            string rodapeEndereco = endereco + ", Nº " + numero + ", " + bairro;
            rodapeEndereco = rodapeEndereco.ToLower();
            rodapeEndereco = myTI.ToTitleCase(rodapeEndereco);

            cidade = cidade.ToLower();
            cidade = myTI.ToTitleCase(cidade);

            ResetarID("ParametrosImpressao");

            string insert = ("INSERT INTO ParametrosImpressao (tipoImpressao, modoImpressao, impressoraPadraoPDV, impressoraPadraoSistema, tipoPessoa, nomeFantasia, nomeEmpresa, CPF_CNPJ, INSC_ESTADUAL, endereco_numero_bairro, cidade_cep_fone, mensagemRodape, createdAt) VALUES (@tipoImpressao, @modoImpressao, @impressoraPadraoPDV, @impressoraPadraoSistema, @tipoPessoa, @nomeFantasia, @nomeEmpresa, @CPF_CNPJ, @INSC_ESTADUAL, @endereco_numero_bairro, @cidade_cep_fone, @mensagemRodape, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@tipoImpressao", "DIRETA");
            exeInsert.Parameters.AddWithValue("@modoImpressao", "COMUM (A4)"); //
            exeInsert.Parameters.AddWithValue("@impressoraPadraoPDV", "Microsoft Print to PDF");
            exeInsert.Parameters.AddWithValue("@impressoraPadraoSistema", "Microsoft Print to PDF");
            exeInsert.Parameters.AddWithValue("@tipoPessoa", comboBoxTipoPessoa.Text);
            exeInsert.Parameters.AddWithValue("@nomeFantasia", textBoxNomeFantasia.Text);
            exeInsert.Parameters.AddWithValue("@nomeEmpresa", textBoxNome_Razao.Text);
            exeInsert.Parameters.AddWithValue("@CPF_CNPJ", maskedCPF_CNPJ.Text);
            exeInsert.Parameters.AddWithValue("@INSC_ESTADUAL", maskedTextBoxInscrocaoEstadual.Text);
            exeInsert.Parameters.AddWithValue("@endereco_numero_bairro", rodapeEndereco);
            exeInsert.Parameters.AddWithValue("@cidade_cep_fone", cidade + "/" + estado + ", " + cep + ", Fone: " + fone);
            exeInsert.Parameters.AddWithValue("@mensagemRodape", mensagemCliente);
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();
        }

        private void FormDadosEmpresa_Load(object sender, EventArgs e)
        {
            verificarTipoPessoa();
            carregarDados();

            if (PrimeiraVez == true)
            {
                comboBoxTipoPessoa.SelectedIndex = 1;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (PrimeiraVez == false)
            {
                queryUpdate();
            }
            else
            {
                queryInsert();

                Close();
            }
        }

        private void FormDadosEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void comboBoxTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTipoPessoa();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            ViewForms.requestBackMenu(true);

            this.Close();
        }
    }
}
