using ClientesKapos.Model;
using ClientesKapos.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientesKapos.View
{
    /// <summary>
    /// Lógica de interacción para ValidarPedido.xaml
    /// </summary>
    public partial class ValidarPedido : Window
    {
        public ValidarPedido(ObservableCollection<ELEMENTOS> listaElementos, double precioTotal)
        {
            this.DataContext = new ValidarPedidoViewModel(listaElementos, precioTotal);
            InitializeComponent();   
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void HelpValidacionButton_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ValidarPedidoViewModel).AbrirValidacionManualUsuario();
        }
    }
}
