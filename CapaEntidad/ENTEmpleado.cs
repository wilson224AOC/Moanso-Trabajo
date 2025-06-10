using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTEmpleado
    {
        public int IdEmpleado {  get; set; }
        public string NombreEmpleado { get; set; }
        public string NumeroDocumento { get; set; }
        public string CargoEmpleado { get; set; }
        public int Telefono { get; set; }
        public string Gmail { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}