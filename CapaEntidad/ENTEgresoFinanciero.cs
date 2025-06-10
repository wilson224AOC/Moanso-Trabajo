using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTEgresoFinanciero
    {
        public int IdEgreso { get; set; }
        public int IdOrdenCompra {  get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string TipoEgreso { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
