using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTIncidencias
    {
        public int IdIncidencia { get; set; }
        public int? IdNotaIngreso { get; set; }
        public string TipoIncidencia { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIncidencia { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
