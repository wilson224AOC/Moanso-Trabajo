using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGFormaPago
    {
        #region sigleton
        private static readonly LOGFormaPago _instancia = new LOGFormaPago();
        public static LOGFormaPago Instancia
        {
            get
            {
                return LOGFormaPago._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTFormaPago> ListarFormaPago()
        {
            return DATFormaPago.Instancia.ListarFormaPago();
        }
        public void InsertarFormaPago(ENTFormaPago formp)
        {
            DATFormaPago.Instancia.InsertarFormaPago(formp);
        }

        public void EditarFormaPago(ENTFormaPago formp)
        {
            DATFormaPago.Instancia.EditarFormaPago(formp);
        }
        public void DeshabilitarFormaPago(int idFormapago)
        {
            DATFormaPago.Instancia.DeshabilitarFormaPago(idFormapago);
        }
        #endregion metodos
    }
}
