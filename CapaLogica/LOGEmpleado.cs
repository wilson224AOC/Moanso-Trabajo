using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGEmpleado
    {
        #region sigleton
        private static readonly LOGEmpleado _instancia = new LOGEmpleado();
        public static LOGEmpleado Instancia
        {
            get
            {
                return LOGEmpleado._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTEmpleado> ListarEmpleado()
        {
            return DATEmpleado.Instancia.ListarEmpleado();
        }
        public void InsertarEmpleado(ENTEmpleado emp)
        {
            DATEmpleado.Instancia.InsertarEmpleado(emp);
        }

        public void EditarEmpleado(ENTEmpleado emp)
        {
            DATEmpleado.Instancia.EditarEmpleado(emp);
        }
        public void DeshabilitarEmpleado(int idEmpleado)
        {
            DATEmpleado.Instancia.DeshabilitarEmpleado(idEmpleado);
        }
        #endregion metodos
    }
}
