using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTDetalleVenta
    {
        public int IdDetalle { get; set; }
        public string TipoVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdVentaCredito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
