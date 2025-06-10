using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGVentaDirecta
    {
        #region sigleton
        private static readonly LOGVentaDirecta _instancia = new LOGVentaDirecta();
        public static LOGVentaDirecta Instancia
        {
            get
            {
                return LOGVentaDirecta._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTVentaDirecta> ListarVentaDirecta()
        {
            return DATVentaDirecta.Instancia.ListarVentaDirecta();
        }
        public void InsertarVentaDirecta(ENTVentaDirecta venD)
        {
            DATVentaDirecta.Instancia.InsertarVentaDirecta(venD);
        }

        public void DeshabilitaVentaDirecta(int Idventa)
        {
            DATVentaDirecta.Instancia.DeshabilitaVentaDirecta(Idventa);
        }
        #endregion metodos
    }
}
