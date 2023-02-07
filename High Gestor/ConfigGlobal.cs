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
            connection.ConnectionString = ("Data Source=(local);Initial Catalog=DatabaseHighData;Integrated Security=True");
            //connection.ConnectionString = ("Data Source=192.168.100.22,1433;Network Library=DBMSSOCN;Initial Catalog=DatabaseHighData;User ID=sa;Password=Root145989Toor;");
            connection.Open();

            try
            {
                
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
        static int idUsuario = 0;
        static string situacao;
        static string nomeCompleto;
        static string usuario;
        static string senha;
        static int idPerfil = 0;
        static string perfil;

        public static void login(int idUsuario1, string situacao1, string nome1, string usuario1, string senha1, int idPerfil1, string perfil1)
        {
            idUsuario = idUsuario1;
            situacao = situacao1;
            nomeCompleto = nome1;
            usuario = usuario1;
            senha = senha1;
            idPerfil = idPerfil1;
            perfil = perfil1;
        }

        public static int _idUsuario()
        {
            return idUsuario;
        }

        public static string _situacao()
        {
            return situacao;
        }

        public static string _nomeCompleto()
        {
            return nomeCompleto;
        }

        public static string _usuario()
        {
            return usuario;
        }

        public static string _senha()
        {
            return senha;
        }

        public static int _idPerfil()
        {
            return idPerfil;
        }

        public static string _perfil()
        {
            return perfil;
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

    public class StatusContasEstoque
    {
        static bool situacaoAlterada = false;

        public static void receberSituacaoDados(bool validacao)
        {
            situacaoAlterada = validacao;
        }

        public static bool _retornarSituacao()
        {
            return situacaoAlterada;
        }
    }

    public class SistemaVerificacao
    {
        static Banco banco = new Banco();

        static DataTable MedotodosPagamento = new DataTable();
        static DataTable CategoriaFinanceiro = new DataTable();
        static DataTable CentroCusto = new DataTable();
        static DataTable Clientes = new DataTable();

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

        public static void DefauthConfig(bool Parametros, bool ParametrosPDV, bool CaixaPDV, bool ListaPreco, bool Perfil, bool Desenvolvedor, bool FormaPagamento, bool Transporte, bool ContaBancaria, bool CategoriaFinanceira, bool CentroCusto, bool ClientesFornecedores, bool CondicaoPagamento)
        {
            if (Parametros == false)
            {
                insertParametrosPadrao();
            }

            if (ParametrosPDV == false)
            {
                insertParametrosPDV();
            }

            if (CaixaPDV == false)
            {
                insertCaixa();
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

            if (FormaPagamento == false)
            {
                insertFormaPagamento();
            }

            if (Transporte == false)
            {
                insertTransporte();
            }

            if (ContaBancaria == false)
            {
                insertContaBancaria();
            }

            if (CategoriaFinanceira == false)
            {
                insertCategoriaFinanceiro();
            }

            if (CentroCusto == false)
            {
                insertCentroCusto();
            }

            if (ClientesFornecedores == false)
            {
                insertClienteFornecedores();
            }

            if (CondicaoPagamento == false)
            {
                insertCondicaoPagamento();
            }
        }

        private static void ResetarID(string tabela)
        {
            //
            //string query = ("DBCC CHECKIDENT(@tabela, RESEED, 0)");
            string query = ("TRUNCATE TABLE " + tabela);
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            banco.conectar();
            exeQuery.ExecuteNonQuery();
            banco.desconectar();
        }

        private static bool VerificarID(string tabela)
        {
            bool Resetar = false;

            string query = ("SELECT IDENT_CURRENT('ClientesFornecedores') + 1 as value");
            SqlCommand exeQuery = new SqlCommand(query, banco.connection);

            exeQuery.Parameters.AddWithValue("@tabela", tabela);

            banco.conectar();
            SqlDataReader reader = exeQuery.ExecuteReader();

            if (reader.Read())
            {
                decimal resultado = decimal.Parse(reader[0].ToString());

                if (resultado > 1)
                {
                    Resetar = true;
                }
                else
                {
                    Resetar = false;
                }
            }
            banco.desconectar();

            return Resetar;
        }

        private static void insertParametrosPadrao()
        {
            if (VerificarID("ParametrosSistema") == true)
            {
                ResetarID("ParametrosSistema");
            }

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
            if (VerificarID("ListaPreco") == true)
            {
                ResetarID("ListaPreco");
            } 

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
            if (VerificarID("Perfil") == true)
            {
                ResetarID("Perfil");
            }      

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
            if (VerificarID("Funcionario") == true)
            {
                ResetarID("Funcionario");
            }

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


        //PDV
        private static void insertParametrosPDV()
        {
            if (VerificarID("ParametrosPDV") == true)
            {
                ResetarID("ParametrosPDV");
            }

            string insert = ("INSERT INTO ParametrosPDV (aberturaFechamentoCaixa, idCategoriaPadraoReforco, idCategoriaPadraoSangria, lancarEstoque, lancarContasReceber, lancarComissao, tipoDesconto, descontoMaximo, tipoAcrescimo, acrescimoMaximo, qntDiaFaturarCredito, qntDiaFaturarDebito, somenteDiasUteis, valeBrinde, consultarClientes, alterarPrecoVenda, alterarOperador, idListaPrecoFK, idLog, createdAt) VALUES (@aberturaFechamentoCaixa, @idCategoriaPadraoReforco, @idCategoriaPadraoSangria, @lancarEstoque, @lancarContasReceber, @lancarComissao, @tipoDesconto, @descontoMaximo, @tipoAcrescimo, @acrescimoMaximo, @qntDiaFaturarCredito, @qntDiaFaturarDebito, @somenteDiasUteis, @valeBrinde, @consultarClientes, @alterarPrecoVenda, @alterarOperador, @idListaPrecoFK, @idLog, @createdAt)");
            SqlCommand exeinsert = new SqlCommand(insert, banco.connection);

            exeinsert.Parameters.AddWithValue("@aberturaFechamentoCaixa", "NAO");
            exeinsert.Parameters.AddWithValue("@idCategoriaPadraoReforco", 16);
            exeinsert.Parameters.AddWithValue("@idCategoriaPadraoSangria", 1);
            exeinsert.Parameters.AddWithValue("@lancarEstoque", "SIM");
            exeinsert.Parameters.AddWithValue("@lancarContasReceber", "SIM");
            exeinsert.Parameters.AddWithValue("@lancarComissao", "NAO");
            exeinsert.Parameters.AddWithValue("@tipoDesconto", "REAIS");
            exeinsert.Parameters.AddWithValue("@descontoMaximo", 0);
            exeinsert.Parameters.AddWithValue("@tipoAcrescimo", "REAIS");
            exeinsert.Parameters.AddWithValue("@acrescimoMaximo", 0);
            exeinsert.Parameters.AddWithValue("@qntDiaFaturarCredito", 0);
            exeinsert.Parameters.AddWithValue("@qntDiaFaturarDebito", 1);
            exeinsert.Parameters.AddWithValue("@somenteDiasUteis", "NAO");
            exeinsert.Parameters.AddWithValue("@valeBrinde", 0);
            exeinsert.Parameters.AddWithValue("@consultarClientes", "NAO");
            exeinsert.Parameters.AddWithValue("@alterarPrecoVenda", "NAO");
            exeinsert.Parameters.AddWithValue("@alterarOperador", "NAO");
            exeinsert.Parameters.AddWithValue("@idListaPrecoFK", 1);
            exeinsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeinsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeinsert.ExecuteNonQuery();
            banco.desconectar();
        }

        private static void insertCaixa()
        {
            if (VerificarID("Caixa") == true)
            {
                ResetarID("Caixa");
            }

            string insert = ("INSERT INTO Caixa (situacao, nomeCaixa, valorMinimo, valorMaximo, permitirAbaixoMinimo, permitirAcimaMaximo, idLog, createdAt) VALUES (@situacao, @nomeCaixa, @valorMinimo, @valorMaximo, @permitirAbaixoMinimo, @permitirAcimaMaximo, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.AddWithValue("@situacao", "FECHADO");
            exeInsert.Parameters.AddWithValue("@nomeCaixa", "CAIXA PADRAO");
            exeInsert.Parameters.AddWithValue("@valorMinimo", 0);
            exeInsert.Parameters.AddWithValue("@valorMaximo", 0);
            exeInsert.Parameters.AddWithValue("@permitirAbaixoMinimo", "SIM");
            exeInsert.Parameters.AddWithValue("@permitirAcimaMaximo", "SIM");
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();

            insertPermissaoCaixa();
        }

        private static void insertPermissaoCaixa()
        {
            if (VerificarID("PermissaoCaixa") == true)
            {
                ResetarID("PermissaoCaixa");
            }

            string insert = ("INSERT INTO PermissaoCaixa (abrirCaixa, sangriaCaixa, reforcoCaixa, trocarMercadoria, fecharCaixa, adicionarAcrescimo, adicionarDesconto, idFuncionarioFK, idCaixaFK, idLog, createdAt) VALUES (@abrirCaixa, @sangriaCaixa, @reforcoCaixa, @trocarMercadoria, @fecharCaixa, @adicionarAcrescimo, @adicionarDesconto, @idFuncionarioFK, @idCaixaFK, @idLog, @createdAt)");
            SqlCommand exeInsert = new SqlCommand(insert, banco.connection);

            exeInsert.Parameters.Clear();
            exeInsert.Parameters.AddWithValue("@abrirCaixa", "SIM");
            exeInsert.Parameters.AddWithValue("@sangriaCaixa", "SIM");
            exeInsert.Parameters.AddWithValue("@reforcoCaixa", "SIM");
            exeInsert.Parameters.AddWithValue("@trocarMercadoria", "SIM");
            exeInsert.Parameters.AddWithValue("@fecharCaixa", "SIM");
            exeInsert.Parameters.AddWithValue("@adicionarAcrescimo", "SIM");
            exeInsert.Parameters.AddWithValue("@adicionarDesconto", "SIM");
            exeInsert.Parameters.AddWithValue("@idFuncionarioFK", 1);
            exeInsert.Parameters.AddWithValue("@idCaixaFK", 1);
            exeInsert.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            exeInsert.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            exeInsert.ExecuteNonQuery();
            banco.desconectar();
        }

        // Forma Pagamento
        private static void carregarMetodosPagamento()
        {
            MedotodosPagamento.Columns.Add("DescricaoMetodo", typeof(string));
            MedotodosPagamento.Columns.Add("PDV", typeof(string));

            MedotodosPagamento.Rows.Add("BANCO", "NAO");
            MedotodosPagamento.Rows.Add("BOLETO", "SIM");
            MedotodosPagamento.Rows.Add("CARTAO DE CREDITO", "SIM");
            MedotodosPagamento.Rows.Add("CARTAO DE DEBITO", "SIM");
            MedotodosPagamento.Rows.Add("CHEQUE", "SIM");
            MedotodosPagamento.Rows.Add("CREDITO LOJA", "SIM");
            MedotodosPagamento.Rows.Add("OUTROS", "SIM");
            MedotodosPagamento.Rows.Add("DEPOSITO BANCARIO");
            MedotodosPagamento.Rows.Add("DEPOSITO EM C/C");
            MedotodosPagamento.Rows.Add("PIX", "SIM");
            MedotodosPagamento.Rows.Add("DINHEIRO", "SIM");
            MedotodosPagamento.Rows.Add("DOC", "NAO");
            MedotodosPagamento.Rows.Add("PAGAMENTOS ONLINE");
            MedotodosPagamento.Rows.Add("PERMUTA", "NAO");
            MedotodosPagamento.Rows.Add("CREDITO DE TROCA", "NAO");
            MedotodosPagamento.Rows.Add("TED", "NAO");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA", "NAO");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA BANCARIA", "NAO");
            MedotodosPagamento.Rows.Add("TRANSFERENCIA BANCARIA, CARTEIRA DIGITAL", "NAO");
            MedotodosPagamento.Rows.Add("VALE ALIMENTACAO", "SIM");
            MedotodosPagamento.Rows.Add("VALE COMBUSTIVEL", "SIM");
            MedotodosPagamento.Rows.Add("VALE PRESENTE", "SIM");
            MedotodosPagamento.Rows.Add("VALE REFEICAO", "SIM");
        }

        private static void insertFormaPagamento()
        {
            carregarMetodosPagamento();

            if (VerificarID("FormaPagamento") == true)
            {
                ResetarID("FormaPagamento");
            }

            string FormaPagamento = ("INSERT INTO FormaPagamento (codigoFormaPagamento, descricao, situacao, PDV, createdAt) VALUES (@codigoFormaPagamento, @descricao, @situacao, @PDV, @createdAt)");
            SqlCommand exeFormaPagamento = new SqlCommand(FormaPagamento, banco.connection);

            for (int i = 0; i < MedotodosPagamento.Rows.Count; i++)
            {
                exeFormaPagamento.Parameters.Clear();
                exeFormaPagamento.Parameters.AddWithValue("@codigoFormaPagamento", (i+1).ToString());
                exeFormaPagamento.Parameters.AddWithValue("@descricao", MedotodosPagamento.Rows[i][0].ToString());
                exeFormaPagamento.Parameters.AddWithValue("@situacao", "ATIVO");
                exeFormaPagamento.Parameters.AddWithValue("@PDV", MedotodosPagamento.Rows[i][1].ToString());
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

            if (VerificarID("Transporte") == true)
            {
                ResetarID("Transporte");
            }

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
            if (VerificarID("ContasBancarias") == true)
            {
                ResetarID("ContasBancarias");
            }

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

            if (VerificarID("CategoriaFinanceiro") == true)
            {
                ResetarID("CategoriaFinanceiro");
            }

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

            if (VerificarID("CentroCusto") == true)
            {
                ResetarID("CentroCusto");
            }

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

        //
        private static void carregarClientesFornecedor()
        {
            Clientes.Columns.Add("tipo", typeof(string));
            Clientes.Columns.Add("nomeCompletoRazao", typeof(string));
            Clientes.Columns.Add("responsavel", typeof(string));

            Clientes.Rows.Add("CLIENTE", "CONSUMIDOR FINAL", "CLIENTE FINAL");
            Clientes.Rows.Add("CLIENTE/FORNECEDOR", "OPERACAO DE CAIXA", "SISTEMA");
        }

        private static void insertClienteFornecedores()
        {
            if (VerificarID("ClientesFornecedores") == true)
            {
                ResetarID("ClientesFornecedores");
            }

            carregarClientesFornecedor();

            string query = ("INSERT INTO ClientesFornecedores (tipo, situacao, tipoPessoa, nomeCompleto_RazaoSocial, nomeFantasia, responsavel, dataNascimento, CPF_CNPJ, carteiraProdutorRural, telefoneWhatsApp, telefoneContato, email, enderecoCompleto, complemento, observacao, idLog, createdAt) VALUES (@tipo, @situacao, @tipoPessoa, @nomeCompleto_RazaoSocial, @nomeFantasia, @responsavel, @dataNascimento, @CPF_CNPJ, @carteiraProdutorRural, @telefoneWhatsApp, @telefoneContato, @email, @enderecoCompleto, @complemento, @observacao, @idLog, @createdAt)");
            SqlCommand command = new SqlCommand(query, banco.connection);

            for (int i = 0; i < Clientes.Rows.Count; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@tipo", Clientes.Rows[i][0].ToString());
                command.Parameters.AddWithValue("@situacao", "ATIVO");
                command.Parameters.AddWithValue("@tipoPessoa", "FISICA");
                command.Parameters.AddWithValue("@nomeCompleto_RazaoSocial", Clientes.Rows[i][1].ToString());
                command.Parameters.AddWithValue("@nomeFantasia", Clientes.Rows[i][1].ToString());
                command.Parameters.AddWithValue("@responsavel", Clientes.Rows[i][2].ToString());
                command.Parameters.AddWithValue("@dataNascimento", DBNull.Value);
                command.Parameters.AddWithValue("@CPF_CNPJ", "00000000000");
                command.Parameters.AddWithValue("@carteiraProdutorRural", "000000000");
                command.Parameters.AddWithValue("@telefoneWhatsApp", "00000000000");
                command.Parameters.AddWithValue("@telefoneContato", "00000000000");
                command.Parameters.AddWithValue("@email", "");
                command.Parameters.AddWithValue("@enderecoCompleto", "");
                command.Parameters.AddWithValue("@complemento", "");
                command.Parameters.AddWithValue("@observacao", "");
                command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                banco.conectar();
                command.ExecuteNonQuery();
                banco.desconectar();
            }  
        }

        //
        private static void insertCondicaoPagamento()
        {
            if (VerificarID("CondicaoPagamento") == true)
            {
                ResetarID("CondicaoPagamento");
            }

            string query = ("INSERT INTO CondicaoPagamento (situacao, descricao, intervaloParcela, primeiraParcela, quantidadeParcela, idFormaPagamentoFK, idLog, createdAt) VALUES (@situacao, @descricao, @intervaloParcela, @primeiraParcela, @quantidadeParcela, @idFormaPagamentoFK, @idLog, @createdAt)");
            SqlCommand command = new SqlCommand(query, banco.connection);

            command.Parameters.AddWithValue("@situacao", "ATIVO");
            command.Parameters.AddWithValue("@descricao", "A VISTA");
            command.Parameters.AddWithValue("@intervaloParcela", 0);
            command.Parameters.AddWithValue("@primeiraParcela", 0);
            command.Parameters.AddWithValue("@quantidadeParcela", 1);
            command.Parameters.AddWithValue("@idFormaPagamentoFK", 11);
            
            command.Parameters.AddWithValue("@idLog", LogSystem.gerarLog(0, "0", "0", "0", "0"));
            command.Parameters.AddWithValue("@createdAt", DateTime.Now);

            banco.conectar();
            command.ExecuteNonQuery();
            banco.desconectar();
        }


        //Verificações - Consultas

        //PDV
        public static string verificarAberturaFechamentoCaixa()
        {
            string result = string.Empty;

            string select = ("SELECT aberturaFechamentoCaixa FROM ParametrosPDV");
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




        //Sistema
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

        public static string verificarComissionamento()
        {
            string comissao = string.Empty;

            string select = ("SELECT comissionamento FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                comissao = reader.GetString(0);
            }
            banco.desconectar();

            return comissao;
        }

        public static int verificarPercentComissao()
        {
            int comissao = 0;

            string select = ("SELECT valorComissao FROM ParametrosSistema");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                comissao = int.Parse(reader[0].ToString());
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

        public static string verificarCategoriaPadraoReceitas()
        {
            string result = string.Empty;

            string select = ("SELECT categoriaPadraoReceitas FROM ParametrosSistema");
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

        public static int verificarCategoriaPadraoReforco()
        {
            int result = 0;

            string select = ("SELECT idCategoriaPadraoReforco FROM ParametrosPDV");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            banco.desconectar();

            return result;
        }

        public static int verificarCategoriaPadraoSangria()
        {
            int result = 0;

            string select = ("SELECT idCategoriaPadraoSangria FROM ParametrosPDV");
            SqlCommand exeSelect = new SqlCommand(select, banco.connection);

            banco.conectar();
            SqlDataReader reader = exeSelect.ExecuteReader();

            if (reader.Read())
            {
                result = reader.GetInt32(0);
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

        public static string verificarCategoriaPadraoDespesas()
        {
            string result = string.Empty;

            string select = ("SELECT categoriaPadraoDespesas FROM ParametrosSistema");
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
