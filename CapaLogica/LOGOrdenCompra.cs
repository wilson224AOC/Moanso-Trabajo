using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGOrdenCompra
    {
        #region sigleton
        private static readonly LOGOrdenCompra _instancia = new LOGOrdenCompra();
        public static LOGOrdenCompra Instancia
        {
            get
            {
                return LOGOrdenCompra._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTOrdenCompra> ListarOrdenCompra()
        {
            return DATOrdenCompra.Instancia.ListarOrdenCompra();
        }
        public void InsertarOrdenCompra(ENTOrdenCompra ordC)
        {
            DATOrdenCompra.Instancia.InsertarOrdenCompra(ordC);
        }
        public void EliminarOrdenCompra(int idOrdencompra)
        {
            DATOrdenCompra.Instancia.EliminarOrdenCompra(idOrdencompra);
        }
        #endregion metodos
    }
}
