using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaEntidad
{
    public class ENTOrdenCompra
    {
        public int IdOrdenCompra {  get; set; }
        public int IdCotizacion { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaOrden {  get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado {  get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
