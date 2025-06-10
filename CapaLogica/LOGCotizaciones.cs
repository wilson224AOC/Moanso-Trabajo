using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGCotizaciones
    {
        #region sigleton
        private static readonly LOGCotizaciones _instancia = new LOGCotizaciones();
        public static LOGCotizaciones Instancia
        {
            get
            {
                return LOGCotizaciones._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTCotizaciones> ListarCotizaciones()
        {
            return DATCotizaciones.Instancia.ListarCotizaciones();
        }
        public void InsertarCotizaciones(ENTCotizaciones cot)
        {
            DATCotizaciones.Instancia.InsertarCotizaciones(cot);
        }

        public void EliminarCotizaciones(int idCotizacion)
        {
            DATCotizaciones.Instancia.EliminarCotizaciones(idCotizacion);
        }
        #endregion metodos
    }
}
