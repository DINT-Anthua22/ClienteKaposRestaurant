using ClientesKapos.Model;
using ClientesKapos.Service;
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

        public ObservableCollection<FACTURA> ListaRegistrosPedido { get; set; }
        public COMANDA ComandaPedidoActual { get; set; }

        public double PrecioTotal { get; set; }
        public double PrecioTotalIVA { get; set; }
        int porcentajeIVA;

        public ValidarPedidoViewModel(double precioTotal, COMANDA comanda)
        {
            PrecioTotal = precioTotal;
            ComandaPedidoActual = comanda;
            ListaRegistrosPedido = new ObservableCollection<FACTURA>(ComandaPedidoActual.FACTURAS);
            porcentajeIVA = ApirRestIva.RescatarIva();

            PrecioTotalIVA = (PrecioTotal * porcentajeIVA) / 100 + precioTotal;
        }

        public void AbrirValidacionManualUsuario()
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString() /*+ "\\NombreManual.chm"*/);
        }

    }
}
