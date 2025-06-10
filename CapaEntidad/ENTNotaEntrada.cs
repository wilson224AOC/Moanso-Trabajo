using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTNotaEntrada
    {
        public int IdNotaIngreso {  get; set; }
        public int IdOrdenCompra { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoIngreso { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
