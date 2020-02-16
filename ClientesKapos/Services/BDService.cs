using ClientesKapos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesKapos.Service
{
    public static class BDService
    {
        private static readonly Tema_6Entities _contexto;

        static BDService()
        {
            _contexto = new Tema_6Entities();
            _contexto.CATEGORIAS.Load();
            _contexto.ELEMENTOS.Load();

        }

        public static ObservableCollection<CATEGORIA> GetCategorias()
        {
            return _contexto.CATEGORIAS.Local;
        }

        public static ObservableCollection<ELEMENTOS> GetElementos()
        {
            return _contexto.ELEMENTOS.Local;
        }

        public static string GetUrlImagen(int id)
        {
            var consulta = from n in _contexto.CATEGORIAS
                           where n.IdCategoria == id
                           select n.ImagenCategoriaURL;


            return consulta.First();
        }

        public static string GetNombre(int id)
        {
            var consulta = from n in _contexto.CATEGORIAS
                           where n.IdCategoria == id
                           select n.NombreCategoria;


            return consulta.First();
        }

        public static int AddFactura(FACTURA item)
        {
            _contexto.FACTURA.Add(item);
            return _contexto.SaveChanges();
        }

        public static int AddComanda(COMANDA item)
        {
            _contexto.COMANDAS.Add(item);
            return _contexto.SaveChanges();
        }

        public static void DeleteComanda(COMANDA item)
        {
            _contexto.COMANDAS.Remove(item);
        }


        //ESTE NO ESTÁ TERMINADO
        public static FACTURA ActualizarCantidadElementos(int idElemento, int idFactura)
        {
            var consulta = from f in _contexto.FACTURA
                           where f.IdElemento == idElemento && f.IdComanda == idFactura
                           select f;

            FACTURA factura = consulta.First();

            return factura;
        }

        public static int ActualizarBbdd()
        {
            return _contexto.SaveChanges();
        }
    }
}
