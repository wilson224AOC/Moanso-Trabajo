using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGProveedor
    {
        #region sigleton
        private static readonly LOGProveedor _instancia = new LOGProveedor();
        public static LOGProveedor Instancia
        {
            get
            {
                return LOGProveedor._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTProveedor> ListarProveedor()
        {
            return DATProveedor.Instancia.ListarProveedor();
        }
        public void InsertarProveedor(ENTProveedor prov)
        {
            DATProveedor.Instancia.InsertarProveedor(prov);
        }

        public void EditarProveedor(ENTProveedor prov)
        {
            DATProveedor.Instancia.EditarProveedor(prov);
        }
        public void EliminarProveedor(int idProveedor)
        {
            DATProveedor.Instancia.EliminarProveedor(idProveedor);
        }
        #endregion metodos
    }
}
