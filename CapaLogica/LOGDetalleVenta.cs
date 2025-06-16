using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGDetalleVenta
    {
        #region sigleton
        private static readonly LOGDetalleVenta _instancia = new LOGDetalleVenta();
        public static LOGDetalleVenta Instancia
        {
            get
            {
                return LOGDetalleVenta._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTDetalleVenta> ListarDetalleVenta()
        {
            return DATDetalleVenta.Instancia.ListarDetalleVenta();
        }
        public void InsertarDetalleVenta(ENTDetalleVenta detv)
        {
            DATDetalleVenta.Instancia.InsertarDetalleVenta(detv);
        }
        public void EliminarDetalleVenta(int idDetalle)
        {
            DATDetalleVenta.Instancia.EliminarDetalleVenta(idDetalle);
        }
        #endregion metodos
    }
}
