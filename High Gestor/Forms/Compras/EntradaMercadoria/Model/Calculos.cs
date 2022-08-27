using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace High_Gestor.Forms.Compras.EntradaMercadoria.Model
{
    /// <summary>
    /// Função desativada
    /// </summary>

    public class Calculos : INotifyPropertyChanged
    {
        static int TotalItensLancados = 0;
        static int TotalProdutos = 0;
        static decimal TotalEntrada = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal AlterarTotalEntrada
        {
            get { return TotalEntrada; }
            set {
                if(value == TotalEntrada)
                {
                    return;
                }
                TotalEntrada = value;
                OnPropertyChanged();
            }
        }

        public int AlterarTotalItensLancados
        {
            get { return TotalItensLancados; }
            set
            {
                if (value == TotalItensLancados)
                {
                    return;
                }
                TotalItensLancados = value;
                OnPropertyChanged();
            }
        }

        public int AlterarTotalProdutos
        {
            get { return TotalProdutos; }
            set
            {
                if (value == TotalProdutos)
                {
                    return;
                }
                TotalProdutos = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
