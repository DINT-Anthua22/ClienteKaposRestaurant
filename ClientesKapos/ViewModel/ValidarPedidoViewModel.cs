using ClientesKapos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesKapos.ViewModel
{
    class ValidarPedidoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ELEMENTOS> ListaElementosPedidos { get; set; }
        public int CantidadElementoPedido { get; set; }

        public double PrecioTotal { get; set; }

        public ValidarPedidoViewModel(Object objeto, double precioTotal)
        {
            ListaElementosPedidos = (ObservableCollection<ELEMENTOS>)objeto;
            PrecioTotal = precioTotal;
        }

        public void AbrirValidacionManualUsuario()
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString() /*+ "\\NombreManual.chm"*/);
        }

    }
}
