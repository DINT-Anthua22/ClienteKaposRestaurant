using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientesKapos.Commands
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Añadir = new RoutedUICommand
            (
                "Añadir",
                "Añadir",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.A, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Cancelar = new RoutedUICommand
            (
                "Cancelar",
                "Cancelar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.C, ModifierKeys.Alt)
                }
            );

        public static readonly RoutedUICommand Validar = new RoutedUICommand
            (
                "Validar",
                "Validar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.V, ModifierKeys.Alt)
                }
            );


    }
}
