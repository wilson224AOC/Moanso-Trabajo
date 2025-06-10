using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGProductos
    {
        #region sigleton
        private static readonly LOGProductos _instancia = new LOGProductos();
        public static LOGProductos Instancia
        {
            get
            {
                return LOGProductos._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTProductos> ListarProducto()
        {
            return DATProductos.Instancia.ListarProducto();
        }
        public void InsertarProducto(ENTProductos prod)
        {
            DATProductos.Instancia.InsertarProducto(prod);
        }

        public void EditarProducto(ENTProductos prod)
        {
            DATProductos.Instancia.EditarProducto(prod);
        }
        public void EliminarProducto(int idProducto)
        {
            DATProductos.Instancia.EliminarProducto(idProducto);
        }
        #endregion metodos
    }
}
