using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGRequerimientoProductos
    {
        #region sigleton
        private static readonly LOGRequerimientoProductos _instancia = new LOGRequerimientoProductos();
        public static LOGRequerimientoProductos Instancia
        {
            get
            {
                return LOGRequerimientoProductos._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTRequerimientoProductos> ListarRequerimientoProducto()
        {
            return DATRequerimiento_Productos.Instancia.ListarRequerimientoProducto();
        }
        public void InsertarRequerimientoProducto(ENTRequerimientoProductos req)
        {
            DATRequerimiento_Productos.Instancia.InsertarRequerimientoProducto(req);
        }

        public void DeshabilitaRequerimientoProducto(int Idrequerimiento)
        {
            DATRequerimiento_Productos.Instancia.DeshabilitaRequerimientoProducto(Idrequerimiento);
        }
        #endregion metodos
    }
}
