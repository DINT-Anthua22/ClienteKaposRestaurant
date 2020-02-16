using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientesKapos.Service
{
    class Producto
    {
        public int IVA { get; set; }
    }
    public static class ApirRestIva
    {
        public static int RescatarIva()
        {
            try
            {
                string url = "https://apidint1920.azurewebsites.net/api/iva";
                var json = new WebClient().DownloadString(url);
                Producto x = JsonConvert.DeserializeObject<Producto>(json);
                return x.IVA;
            }
            catch (Exception) { return 10; }

        }
    }
}
