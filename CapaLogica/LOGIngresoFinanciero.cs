using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGIngresoFinanciero
    {
        #region sigleton
        private static readonly LOGIngresoFinanciero _instancia = new LOGIngresoFinanciero();
        public static LOGIngresoFinanciero Instancia
        {
            get
            {
                return LOGIngresoFinanciero._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTIngresoFinanciero> ListarIngresoFinanciero()
        {
            return DATIngresoFinanciero.Instancia.ListarIngresoFinanciero();
        }
        public void InsertarIngresoFinanciero(ENTIngresoFinanciero ingreso)
        {
            DATIngresoFinanciero.Instancia.InsertarIngresoFinanciero(ingreso);
        }

        public void EliminarIngresoFinanciero(int idIngreso)
        {
            DATIngresoFinanciero.Instancia.EliminarIngresoFinanciero(idIngreso);
        }
        #endregion metodos
    }
}
