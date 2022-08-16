using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Gestor.Forms.Compras.EntradaMercadoria.Model
{
    public class ProtudoItens
    {
        static bool ItemEncontrado = false;
        static int IdProduto = 0;
        static string NomeProduto;
        static string CodigoProduto;
        static int Quantidade = 1;
        static decimal ValorUnitario = 0;

        public static void receberValidacao(bool validacao)
        {
            ItemEncontrado = validacao;
        }

        public static bool _ItemEncontrado()
        {
            return ItemEncontrado;
        }

        public static void receberProdutoItem(int ID, string produto, string codigo, int quantidade, decimal valorUnitario)
        {
            IdProduto = ID;
            NomeProduto = produto;
            CodigoProduto = codigo;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public static int _IdProduto()
        {
            return IdProduto;
        }

        public static string _NomeProduto()
        {
            return NomeProduto;
        }

        public static string _CodigoProduto()
        {
            return CodigoProduto;
        }

        public static int _Quantidade()
        {
            return Quantidade;
        }

        public static decimal _ValorUnitario()
        {
            return ValorUnitario;
        }
    }

}
