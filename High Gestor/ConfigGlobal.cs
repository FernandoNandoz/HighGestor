using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace High_Gestor
{

    class Banco
    {
        public SqlConnection connection = new SqlConnection();

        public void conectar()
        {
            try
            {
                connection.ConnectionString = ("Data Source=(local);Initial Catalog=DatabaseHighData;Integrated Security=True");
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("there was an issue!" + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("there was another issue!" + ex);
            }
        }

        public void desconectar()
        {
            connection.Close();
        }
    }

    public class Autenticacao
    {
        static int idUsuario;
        static string nome;
        static string usuario;
        static string senha;
        static string perfil;

        public static void login(int idUsuario1, string nome1, string usuario1, string senha1, string perfil1)
        {
            idUsuario = idUsuario1;
            nome = nome1;
            usuario = usuario1;
            senha = senha1;
            perfil = perfil1;
        }

        public static int _idUsuario()
        {
            return idUsuario;
        }

        public static string _nome()
        {
            return nome;
        }

        public static string _usuario()
        {
            return usuario;
        }

        public static string _perfil()
        {
            return perfil;
        }

        public static string _senha()
        {
            return senha;
        }
    }

    public class ViewForms
    {
        static bool BackMenu = false;
        static bool fechado = false;
        static bool Link = false;

        public static void requestViewForm(bool dataFechado, bool link)
        {
            fechado = dataFechado;
            Link = link;
        }

        public static bool _responseViewForm()
        {
            return fechado;
        }

        public static bool _responseViewFormLink()
        {
            return Link;
        }

        public static void requestBackMenu(bool backMenu)
        {
            BackMenu = backMenu;
        }

        public static bool _responseBackMenu()
        {
            return BackMenu;
        }
    }

    public class LogSystem
    {
        static int IdLog;

        public static int gerarLog(int idFuncionario, string caminho, string tabela, string Query, string descricao)
        {
            Banco banco = new Banco();

            string logINSERT = ("INSERT INTO LogSystem (idFuncionarioFK, caminho, tabelaBanco, Query, descricao, createdAt) VALUES (@idFuncionarioFK, @caminho, @tabelaBanco, @Query, @descricao, @createdAt)");
            SqlCommand sqlCommand = new SqlCommand(logINSERT, banco.connection);

            sqlCommand.Parameters.AddWithValue("@idFuncionarioFK", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@caminho", caminho);
            sqlCommand.Parameters.AddWithValue("@tabelaBanco", tabela);
            sqlCommand.Parameters.AddWithValue("@Query", Query);
            sqlCommand.Parameters.AddWithValue("@descricao", descricao);
            sqlCommand.Parameters.AddWithValue("createdAt", DateTime.Now);

            banco.conectar();
            sqlCommand.ExecuteNonQuery();
            banco.desconectar();



            //Pega o ultimo ID resgitrado na tabela log
            string logSELECT = ("SELECT idLog FROM LogSystem WHERE idLog=(SELECT MAX(idLog) FROM LogSystem)");
            SqlCommand exeVerificacao = new SqlCommand(logSELECT, banco.connection);
            banco.conectar();

            SqlDataReader datareader = exeVerificacao.ExecuteReader();

            while (datareader.Read())
            {
                IdLog = int.Parse(datareader[0].ToString());
            }

            banco.desconectar();

            return IdLog;
        }
    }

    public class updateData
    {
        static int ID = 0;
        static bool Validacao = false;

        public static void receberDados(int id, bool validacao)
        {
            ID = id;
            Validacao = validacao;
        }

        public static bool _retornarValidacao()
        {
            return Validacao;
        }

        public static int _retornarID()
        {
            return ID;
        }
    }

    public class alterouSize
    {
        static string formName;
        static int Validacao = 0;
        static string formNameSecundario;
        static string formOpenSecundario;
        static int ValidacaoSecundario = 0;

        public static void receberName(string form)
        {
            formName = form;
        }

        public static void receberValidacao(int validacao)
        {
            Validacao = validacao;
        }

        public static string _retornarFormName()
        {
            return formName;
        }

        public static int _retornarValidacao()
        {
            return Validacao;
        }



        public static void receberNameSecundario(string form)
        {
            formNameSecundario = form;
        }

        public static void receberOpenSecundario(string form)
        {
            formOpenSecundario = form;
        }

        public static void receberValidacaoSecundario(int validacao)
        {
            ValidacaoSecundario = validacao;
        }

        public static string _retornarFormNameSecundario()
        {
            return formNameSecundario;
        }

        public static string _retornarFormOpenSecundario()
        {
            return formOpenSecundario;
        }

        public static int _retornarValidacaoSecundario()
        {
            return ValidacaoSecundario;
        }
    }

    public class PrimeiroAcesso
    {
        static bool PrimeiroVez = false;
        static bool EmpresaCadastrada = false;

        public static void receberDados(bool validacao)
        {
            PrimeiroVez = validacao;
        }

        public static bool _retornarDados()
        {
            return PrimeiroVez;
        }

        public static void receberDadosEmpresa(bool validacao)
        {
            EmpresaCadastrada = validacao;
        }

        public static bool _retornarDadosEmpresa()
        {
            return EmpresaCadastrada;
        }
    }

    public class SistemaVerificacao
    {
        static Banco banco = new Banco();

        static DataTable MedotodosPagamento = new DataTable();
        static DataTable CategoriaFinanceiro = new DataTable();
        static DataTable CentroCusto = new DataTable();

        public static bool verificarDadosEmpresa()
        {
            bool encontrado = false;

            string queryDadosEmpresa = ("SELECT COUNT(*) FROM DadosEmpresa");
            SqlCommand exeQueryDadosEmpresa = new SqlCommand(queryDadosEmpresa, banco.connection);
            banco.conectar();

            SqlDataReader readerDadosEmpresa = exeQueryDadosEmpresa.ExecuteReader();

            if (readerDadosEmpresa.Read())
            {
                if (readerDadosEmpresa.GetInt32(0) > 0)
                {
                    encontrado = true;
                }
                else
                {
                    encontrado = false;
                }
            }
            banco.desconectar();

            if (encontrado == false)
            {
                PrimeiroAcesso.receberDados(true);

                Forms.Configuracoes.DadosEmpresa.FormApresentacao window = new Forms.Configuracoes.DadosEmpresa.FormApresentacao();
                window.ShowDialog();
                window.Dispose();

                if (PrimeiroAcesso._retornarDadosEmpresa() == false)
                {
                    encontrado = false;
                }
                else
                {
                    encontrado = true;
                }
            }

            return encontrado;
        }

        public static void DefauthConfig(bool Parametros, bool ListaPreco, bool Perfil, bool Desenvolvedor, bool FormaPagamento, bool Transporte, bool ContaBancaria, bool CategoriaFinanceira, bool CentroCusto)
        {
            if (Parametros == false)
            {
                insertParametrosPadrao();
            }

            if (ListaPreco == false)
            {
                insertListaPreco();
            }

            if (Perfil == false)
            {
                insertPerfil();
            }

            if (Desenvolvedor == false)
            {
                insertDesenvolvedor();
            }

            if(FormaPagamento == false)
            {
                insertFormaPagamento();
            }

            if(Transporte == false)
            {
                insertTransporte();
            }

            if(ContaBancaria == false)
            {
                insertContaBancaria();
            }

            if (CategoriaFinanceira == false)
            {
                insertCategoriaFinanceiro();
            }

            if(CentroCusto == false)
            {
                insertCentroCusto();
            }
        }

        private static void insertParametrosPadrao()
        {
            string query = ("INSERT INTO ParametrosSistema (comissao, comissionamento, categoriaPadraoReceitas, categoriaPadraoDespesas, categoriaPadraoVendas, categoriaPadraoCompras, custoPadraoReceitas, custoPadraoDespesas, bloquearVendaEstoque, atualizarCustoProduto, ListaPreco, idLog, createdAt) VALUES (@comissao, @comissionamento, @categoriaPadraoReceitas, @categoriaPadraoDespesas, @categoriaPadraoVendas, @categoriaPadraoCompras, @custoPadraoReceitas, @custoPadraoDespesas, @bloquearVendaEstoque, @atualizarCustoProduto, @ListaPreco, @idLog, @createdAt)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@comissao", "DESATIVADO");
            exeQuery.Parameters.AddWithValue("@comissionamento", "TOTAL DE VENDAS");
            exeQuery.Parameters.AddWithValue("@valorComissao", "0");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoReceitas", "OUTRAS RECEITAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoDespesas", "OUTRAS DESPESAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoVendas", "VENDAS");
            exeQuery.Parameters.AddWithValue("@categoriaPadraoCompras", "FORNECEDOR");
            exeQuery.Parameters.AddWithValue("@custoPadraoReceitas", "RECEITAS GERAIS");
            exeQuery.Parameters.AddWithValue("@custoPadraoDespesas", "DESPESAS GERAIS");
            exeQuery.Parameters.AddWithValue("@bloquearVendaEstoque", "SIM");
            exeQuery.Parameters.AddWithValue("@atualizarCustoProduto", "SIM");
            exeQuery.Parameters.AddWithValue("@ListaPreco", "NAO");
            exeQuery.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeQuery.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private static void insertListaPreco()
        {
            string query = ("INSERT INTO ListaPreco (situacao, descricao, modalidadeAjuste, tipoAjuste, baseCalculoValorProduto, baseCalculoValorLista, idLog, createdAt) VALUES (@situacao, @descricao, @modalidadeAjuste, @tipoAjuste, @baseCalculoValorProduto, @baseCalculoValorLista, @idLog, @createdAt)");
            SqlCommand command = new SqlCommand(query, banco.connection);

            command.Parameters.AddWithValue("@situacao", "ATIVO");
            command.Parameters.AddWithValue("@descricao", "LISTA PADRAO");
            command.Parameters.AddWithValue("@modalidadeAjuste", "PADRAO");
            command.Parameters.AddWithValue("@tipoAjuste", "PADRAO");
            command.Parameters.AddWithValue("@baseCalculoValorProduto", 0);
            command.Parameters.AddWithValue("@baseCalculoValorLista", 0);
            command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", query, "Cadastrando uma lista Padrao"));
            command.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            command.ExecuteNonQuery();
            banco.desconectar();
        }

        private static void insertPerfil()
        {
            string perfil = ("INSERT INTO Perfil (codigoPerfil, perfil, createdAt) VALUES (@codigoPerfil, @perfil, @createdAt)");
            SqlCommand exePerfil = new SqlCommand(perfil, banco.connection);

            for (int i=0; i < 3; i++)
            {
                string nomePerfil = string.Empty;

                if(i == 0)
                {
                    nomePerfil = "DESENVOLVEDOR";
                }

                if (i == 1)
                {
                    nomePerfil = "ADMINISTRADOR";
                }

                if (i == 2)
                {
                    nomePerfil = "VENDEDOR";
                }

                exePerfil.Parameters.Clear();
                exePerfil.Parameters.AddWithValue("@codigoPerfil", i.ToString());
                exePerfil.Parameters.AddWithValue("@perfil", nomePerfil);
                exePerfil.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exePerfil.ExecuteNonQuery();
                banco.desconectar();
            }
        }

        private static void insertDesenvolvedor()
        {
            string query = ("INSERT INTO Funcionario (idLog, idPerfilFK, situacao, codigoFuncionario, usuario, senha, nomeCompleto, comissaoPercent, CPF, endereco, whatsApp, telefoneContato, createdAt) VALUES (@idLog, @idPerfilFK, @situacao, @codigoFuncionario, @usuario, @senha, @nomeCompleto, @comissaoPercent, @CPF, @endereco, @whatsApp, @telefoneContato, @createdAt)");
            SqlCommand command = new SqlCommand(query, banco.connection);

            command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            command.Parameters.AddWithValue("@idPerfilFK", 1);
            command.Parameters.AddWithValue("@situacao", "ATIVO");
            command.Parameters.AddWithValue("@codigoFuncionario", "0");
            command.Parameters.AddWithValue("@usuario", "FERNANDO");
            command.Parameters.AddWithValue("@senha", "145989");
            command.Parameters.AddWithValue("@nomeCompleto", "FERNANDO DAMASCENO");
            command.Parameters.AddWithValue("@comissaoPercent", "0");
            command.Parameters.AddWithValue("@CPF", "00000000000");
            command.Parameters.AddWithValue("@endereco", "Boca do Acre - AM");
            command.Parameters.AddWithValue("@whatsApp", "68981065738");
            command.Parameters.AddWithValue("@telefoneContato", "68981065738");
            command.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            command.ExecuteNonQuery();
            banco.desconectar();
        }

        // Forma Pagamento
        private static void carregarMetodosPagamento()
        {
            MedotodosPagamento.Columns.Add("DescricaoMetodo", typeof(string));

            MedotodosPagamento.Rows.Add("BANCO");
            MedotodosPagamento.Rows.Add("BOLETO");
            MedotodosPagamento.Rows.Add("CARTAO DE CREDITO");
            MedotodosPagamento.Rows.Add("CARTAO DE DEBITO");
            MedotodosPagamento.Rows.Add("CARTEIRA DIGITAL");
            MedotodosPagamento.Rows.Add("CHEQUE");
            MedotodosPagamento.Rows.Add("CREDITO DE TROCA");
            MedotodosPagamento.Rows.Add("CREDITO LOJA");
            MedotodosPagamento.Rows.Add("DEPOSITO BANCARIO");
            MedotodosPagamento.Rows.Add("DEPOSITO EM C/C");
            MedotodosPagamento.Rows.Add("DINHEIRO");
            MedotodosPagamento.Rows.Add("DOC");
            MedotodosPagamento.Rows.Add("OUTROS");
            MedotodosPagamento.Rows.Add("PAGAMENTOS ONLINE");
            MedotodosPagamento.Rows.Add("PERMUTA");
            MedotodosPagamento.Rows.Add("PIX");
            MedotodosPagamento.Rows.Add("TED");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA BANCARIA");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA BANCARIA, CARTEIRA DIGITAL");
            MedotodosPagamento.Rows.Add("VALE ALIMENTACAO");
            MedotodosPagamento.Rows.Add("VALE COMBUSTIVEL");
            MedotodosPagamento.Rows.Add("VALE PRESENTE");
            MedotodosPagamento.Rows.Add("VALE REFEICAO");
        }

        private static void insertFormaPagamento()
        {
            carregarMetodosPagamento();

            string FormaPagamento = ("INSERT INTO FormaPagamento (codigoFormaPagamento, descricao, situacao, createdAt) VALUES (@codigoFormaPagamento, @descricao, @situacao, @createdAt)");
            SqlCommand exeFormaPagamento = new SqlCommand(FormaPagamento, banco.connection);

            for (int i = 0; i < MedotodosPagamento.Rows.Count; i++)
            {
                exeFormaPagamento.Parameters.Clear();
                exeFormaPagamento.Parameters.AddWithValue("@codigoFormaPagamento", (i+1).ToString());
                exeFormaPagamento.Parameters.AddWithValue("@descricao", MedotodosPagamento.Rows[i][0].ToString());
                exeFormaPagamento.Parameters.AddWithValue("@situacao", "ATIVO");
                exeFormaPagamento.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                exeFormaPagamento.ExecuteNonQuery();
                banco.desconectar();
            }
        }
        //

        private static void insertTransporte()
        {
            #region Verificar nome da empresa cadastrada

            string nomeFantasia = string.Empty;

            string queryDadosEmpresa = ("SELECT (SELECT COUNT(*) FROM DadosEmpresa), nomeFantasia FROM DadosEmpresa");
            SqlCommand exeQueryDadosEmpresa = new SqlCommand(queryDadosEmpresa, banco.connection);
            banco.conectar();

            SqlDataReader readerDadosEmpresa = exeQueryDadosEmpresa.ExecuteReader();

            if (readerDadosEmpresa.Read())
            {
                if (readerDadosEmpresa.GetInt32(0) > 0)
                {
                    nomeFantasia = readerDadosEmpresa.GetString(1);
                }
            }
            banco.desconectar();

            #endregion

            string FormaPagamento = ("INSERT INTO Transporte (situacao, descricao, enderecoEntrega, observacao, createdAt) VALUES (@situacao, @descricao, @enderecoEntrega, @observacao, @createdAt)");
            SqlCommand exeFormaPagamento = new SqlCommand(FormaPagamento, banco.connection);

            exeFormaPagamento.Parameters.AddWithValue("@situacao", "ATIVO");
            exeFormaPagamento.Parameters.AddWithValue("@descricao", "RETIRAR NA LOJA");
            exeFormaPagamento.Parameters.AddWithValue("@enderecoEntrega", nomeFantasia);
            exeFormaPagamento.Parameters.AddWithValue("@observacao", "CLIENTE IRÁ RETIRAR A MERCADORIA NA LOJA.");
            exeFormaPagamento.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeFormaPagamento.ExecuteNonQuery();
            banco.desconectar();

        }

        private static void insertContaBancaria()
        {
            string query = ("INSERT INTO ContasBancarias (situacao, nomeBanco, nomeConta, saldoInicial, dataInicial, padraoReceitas, padraoDespesas) VALUES (@situacao, @nomeBanco, @nomeConta, @saldoInicial, @dataInicial, @padraoReceitas, @padraoDespesas)");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@situacao", "ATIVO");
            exeQuery.Parameters.AddWithValue("@nomeBanco", "NAO E UM BANCO (CARTAO, CAIXINHA, ETC)");
            exeQuery.Parameters.AddWithValue("@nomeConta", "CONTA PADRAO (CAIXINHA)");
            exeQuery.Parameters.AddWithValue("@saldoInicial", 0);
            exeQuery.Parameters.AddWithValue("@dataInicial", DateTime.Now);
            exeQuery.Parameters.AddWithValue("@padraoReceitas", "SIM");
            exeQuery.Parameters.AddWithValue("@padraoDespesas", "SIM");

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        // Categoria Financeiro
        private static void carregarCategoriaFinanceiro()
        {
            CategoriaFinanceiro.Columns.Add("descricao", typeof(string));
            CategoriaFinanceiro.Columns.Add("tipoCategoria", typeof(string));

            //Receitas
            CategoriaFinanceiro.Rows.Add("AJUSTE CAIXA", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("AJUSTE SALDO INICIAL", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("APLICAÇÕES FINANCEIRAS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("DESCONTOS RECEBIDOS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("DEVOLUÇÃO DE ADIANTAMENTO", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("FINANCIAMENTOS E INVESTIMENTOS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("JUROS / MULTAS RECEBIDOS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("OUTRAS RECEITAS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("RECEITAS SEM CATEGORIA", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("RETENÇÃO DE LUCROS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("SALDO INICIAL", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("SERVIÇOS", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("TRANSFERÊNCIA DE ENTRADA", "RECEITAS");
            CategoriaFinanceiro.Rows.Add("VENDAS", "RECEITAS");

            //Despesas
            CategoriaFinanceiro.Rows.Add("ADIANTAMENTO - FUNCIONÁRIOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("AJUSTE CAIXA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ALUGUEL", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("AMORTIZAÇÕES", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("AQUISIÇÃO DE EQUIPAMENTOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ASSESSORIAS E ASSOCIAÇÕES", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CARTÓRIO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("COMBUSTIVEL E TRANSLADOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("COMISSÃO VENDEDORES", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("COMPRAS CARTÃO DE CRÉDITO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CONFRATERNIZAÇÕES", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CONTABILIDADE", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CORREIOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CREDITO TROCA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CURSOS E TREINAMENTOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("CUSTOS DE SERVIÇOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("DEPRECIAÇÃO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("DESCONTOS CONCEDIDOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("DESPESAS BANCÁRIAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("DESPESAS SEM CATEGORIA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("DISTRIBUIÇÃO DE LUCROS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("EMPRÉSTIMOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - 13O SALÁRIO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - ALIMENTAÇÃO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - ASSIST.MÉDICA E ODONTOL.", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - EXAMES PRÉ E DEMISSIONAIS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - FGTS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONARIOS - HORAS EXTRAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - INSS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - RESCISÕES TRABALHISTAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - SALÁRIO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - SINDICATO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENCARGOS FUNCIONÁRIOS - VALE TRANSPORTE", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("ENERGIA ELÉTRICA + ÁGUA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("FINANCIAMENTOS E INVESTIMENTOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("FORNECEDOR", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - ALVARÁ", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - COFINS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - COLETA DE LIXO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - CSLL", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - DAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - ICMS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - IMPORTAÇÃO IPI", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - IOF", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - IPTU", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - IRPJ", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - ISS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("IMPOSTOS - PIS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("INSUMOS DE PRODUÇÃO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("JUROS / MULTAS PAGOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("LICENÇA OU ALUGUEL DE SOFTWARES", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("LIMPEZA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("MANUTENÇÃO EQUIPAMENTOS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("MARKETING E PUBLICIDADE", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("MATERIAL DE ESCRITÓRIO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("MATERIAL REFORMA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("OUTRAS DESPESAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("PROLABORE", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("SEGURANÇA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("SUPERMERCADO", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("TAXAS / TARIFAS BANCÁRIAS", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("TELEFONIA E INTERNET", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("TRANSFERÊNCIA DE SAÍDA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("TRANSPORTADORA", "DESPESAS");
            CategoriaFinanceiro.Rows.Add("VIAGENS", "DESPESAS");
        }

        private static void insertCategoriaFinanceiro()
        {
            carregarCategoriaFinanceiro();

            string Categoria = ("INSERT INTO CategoriaFinanceiro (situacao, descricao, tipoCategoria, grupoFinanceiro, idLog, createdAt) VALUES (@situacao, @descricao, @tipoCategoria, @grupoFinanceiro, @idLog, @createdAt)");
            SqlCommand command = new SqlCommand(Categoria, banco.connection);

            for(int i = 0; i < CategoriaFinanceiro.Rows.Count; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@situacao", "ATIVO");
                command.Parameters.AddWithValue("@descricao", CategoriaFinanceiro.Rows[i][0].ToString());
                command.Parameters.AddWithValue("@tipoCategoria", CategoriaFinanceiro.Rows[i][1].ToString());
                command.Parameters.AddWithValue("@grupoFinanceiro", "OUTRAS RECEITAS");
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }
        }
        //


        // Centro Custo
        private static void carregarCentroCusto()
        {
            CentroCusto.Columns.Add("codigo", typeof(string));
            CentroCusto.Columns.Add("descricao", typeof(string));

            CentroCusto.Rows.Add("1", "RECEITAS GERAIS");
            CentroCusto.Rows.Add("2", "DESPESAS GERAIS");
            CentroCusto.Rows.Add("3", "OUTROS");
        }

        private static void insertCentroCusto()
        {
            carregarCentroCusto();

            string Categoria = ("INSERT INTO CentroCusto (idLog, codigoCusto, descricao, status, createdAt) VALUES (@idLog, @codigoCusto, @descricao, @status, @createdAt)");
            SqlCommand command = new SqlCommand(Categoria, banco.connection);

            for(int i = 0; i < CentroCusto.Rows.Count; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@codigoCusto", CentroCusto.Rows[i][0].ToString());
                command.Parameters.AddWithValue("@descricao", CentroCusto.Rows[i][1].ToString());
                command.Parameters.AddWithValue("@status", "ATIVO");
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }
        }


        //Verificações - Consultas
        public static bool verificarComissao()
        {
            bool comissao = false;

            string select = ("SELECT comissao FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                if(reader.GetString(0) != "DESATIVADO")
                {
                    comissao = true;

                }
                else
                {
                    comissao= false;
                }
            }
            banco.desconectar();

            return comissao;
        }

        public static bool verificarListaPreco()
        {
            bool ListaPrecoPadrao = false;

            string select = ("SELECT ListaPreco FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "SIM")
                {
                    ListaPrecoPadrao = true;
                }
                else
                {
                    ListaPrecoPadrao = false;
                }
            }
            banco.desconectar();

            return ListaPrecoPadrao;
        }

        public static string verificarCategoriaPadraoVendas()
        {
            string result = string.Empty;

            string select = ("SELECT categoriaPadraoVendas FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                result = reader[0].ToString();
            }
            banco.desconectar();

            return result;
        }

        public static string verificarCustoPadraoReceitas()
        {
            string result = string.Empty;

            string select = ("SELECT custoPadraoReceitas FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                result = reader[0].ToString();
            }
            banco.desconectar();

            return result;
        }

        public static string verificarPadraoEstoque()
        {
            string result = string.Empty;

            string select = ("SELECT bloquearVendaEstoque FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                result = reader[0].ToString();
            }
            banco.desconectar();

            return result;
        }
    }
}
