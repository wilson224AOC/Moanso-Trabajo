using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTCotizaciones
    {
        public int IdCotizacion { get; set; }
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; } 
        public DateTime FechaCotizacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdRequerimiento { get; set; }
    }
}
