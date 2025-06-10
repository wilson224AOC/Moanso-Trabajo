using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGVentaCredito
    {
        #region singleton
        private static readonly LOGVentaCredito _instancia = new LOGVentaCredito();
        public static LOGVentaCredito Instancia
        {
            get
            {
                return LOGVentaCredito._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTVentaCredito> ListarVentaCredito()
        {
            return DATVentaCredito.Instancia.ListarVentaCredito();
        }

        public void InsertarVentaCredito(ENTVentaCredito venC)
        {
            DATVentaCredito.Instancia.InsertarVentaCredito(venC);
        }

        public void DeshabilitaVentaCredito(int IdVentaCredito)
        {
            DATVentaCredito.Instancia.DeshabilitaVentaCredito(IdVentaCredito);
        }
        #endregion metodos
    }
}
