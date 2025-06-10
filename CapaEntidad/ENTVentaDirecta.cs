using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTVentaDirecta
    {
        public int IdVenta {  get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string NumeroVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
