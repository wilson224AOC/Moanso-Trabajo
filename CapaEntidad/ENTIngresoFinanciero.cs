using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTIngresoFinanciero
    {
        public int IdIngreso {  get; set; }
        public int IdDetalle { get; set; }
        public string Concepto { get; set; }
        public Decimal Monto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observaciones { get; set; }
    }
}
