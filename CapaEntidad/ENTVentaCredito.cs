using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTVentaCredito
    {
        public int IdVentaCredito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoCredito { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEmpleado { get; set; }
    }
}
