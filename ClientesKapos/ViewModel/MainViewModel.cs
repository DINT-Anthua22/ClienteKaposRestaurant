
using ClientesKapos.Model;
using ClientesKapos.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ClientesKapos.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //Clase que sirve de modelo de datos para la vista MainWindows
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewSource ListaElementos { get; set; }


        public ELEMENTOS ElementoSeleccionado { get; set; }

        public int TotalElementosSeleccionados { get; set; }


        //lista para ir añadiendo los elementos seleccionados.
        public ObservableCollection<ELEMENTOS> ElementosSeleccionados { get; set; }
        public FACTURA ComandaPedidoActual { get; set; }

        public COMANDA PedidoActual { get; set; }

        bool repetido;

        public MainViewModel()
        {
            ListaElementos = new CollectionViewSource
            {
                Source = BDService.GetElementos()
            };

            repetido = false;

            PedidoActual = new COMANDA
            {
                FechaComanda = DateTime.Now,
                Servida = 0
            };

            BDService.AddComanda(PedidoActual);

            TotalElementosSeleccionados = 0;

            ElementosSeleccionados = new ObservableCollection<ELEMENTOS>();
        }



        public bool Añadir_CanExecute()
        {
            return (ElementoSeleccionado != null);
        }

        public bool Cancelar_CanExecute()
        {
            return (ElementosSeleccionados.Count > 0);
        }

        public void Añadir_Executed()
        {

            if (ElementosSeleccionados.Count > 0)
            {
                if (ElementosSeleccionados.Contains(ElementoSeleccionado))
                {
                    ComandaPedidoActual = BDService.ActualizarCantidadElementos(ElementoSeleccionado.IdElemento, ComandaPedidoActual.IdComanda);
                    ComandaPedidoActual.CantidadElementos++;
                    BDService.ActualizarBbdd();
                    repetido = true;
                }
                else
                {
                    InsertarNuevoElemento();
                    repetido = false;
                }
            }
            else
            {
                InsertarNuevoElemento();
            }

            if (!repetido)
                ElementosSeleccionados.Add(ElementoSeleccionado);

            TotalElementosSeleccionados = ElementosSeleccionados.Count;
        }

        void InsertarNuevoElemento()
        {
            ComandaPedidoActual = new FACTURA();
            ComandaPedidoActual.IdComanda = PedidoActual.IdComanda;
            ComandaPedidoActual.IdElemento = ElementoSeleccionado.IdElemento;
            ComandaPedidoActual.CantidadElementos = 1;
            BDService.AddFactura(ComandaPedidoActual);
        }

        public bool Validar_CanExecute()
        {
            return (ElementosSeleccionados.Count > 0);
        }

        public void Validar_Executed()
        {
            foreach (var item in ElementosSeleccionados)
            {

            }
        }

        public void abrirManualUsuario()
        {
            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString() /*+ "\\NombreManual.chm"*/);
        }


    }
}
