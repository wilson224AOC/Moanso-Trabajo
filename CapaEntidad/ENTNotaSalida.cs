using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTNotaSalida
    {
        public int IdNotaSalida {  get; set; }
        public int IdDetalle { get; set; }
        public DateTime FechaSalida { get; set; }
        public string TipoSalida { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
