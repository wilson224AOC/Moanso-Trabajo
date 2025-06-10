using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ENTRequerimientoProductos
    {
        public int IdRequerimiento { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } 
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int CantidadRecibida { get; set; }
        public bool Estado { get; set; }
    }
}
