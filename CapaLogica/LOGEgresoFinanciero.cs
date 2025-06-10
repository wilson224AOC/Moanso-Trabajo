using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGEgresoFinanciero
    {
        #region sigleton
        private static readonly LOGEgresoFinanciero _instancia = new LOGEgresoFinanciero();
        public static LOGEgresoFinanciero Instancia
        {
            get
            {
                return LOGEgresoFinanciero._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTEgresoFinanciero> ListarEgresoFinanciero()
        {
            return DATEgresoFinanciero.Instancia.ListarEgresoFinanciero();
        }
        public void InsertarEgresoFinanciero(ENTEgresoFinanciero egr)
        {
            DATEgresoFinanciero.Instancia.InsertarEgresoFinanciero(egr);
        }

        public void EliminarEgresoFinanciero(int idEgreso)
        {
            DATEgresoFinanciero.Instancia.EliminarEgresoFinanciero(idEgreso);
        }
        #endregion metodos
    }
}
