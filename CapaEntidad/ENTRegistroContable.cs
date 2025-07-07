using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTRegistroContable
    {
        public int IdRegistro {  get; set; }
        public int IdIngreso { get; set; }
        public int IdEgreso { get; set; }
        public string TipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
