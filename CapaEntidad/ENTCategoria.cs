using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTCategoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Boolean Estado {  get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
