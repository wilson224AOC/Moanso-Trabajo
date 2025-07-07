using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTFormaPago
    {
        public int IdFormaPago { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Boolean DatosBancarios { get; set; }
        public string DatosBa {  get; set; }
        public Boolean Estado {  get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
