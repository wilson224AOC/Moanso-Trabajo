using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGNotaEntrada
    {
        #region sigleton
        private static readonly LOGNotaEntrada _instancia = new LOGNotaEntrada();
        public static LOGNotaEntrada Instancia
        {
            get
            {
                return LOGNotaEntrada._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTNotaEntrada> ListarNotaIngreso()
        {
            return DATNotaEntrada.Instancia.ListarNotaIngreso();
        }
        public void InsertarNotaIngreso(ENTNotaEntrada notE)
        {
            DATNotaEntrada.Instancia.InsertarNotaIngreso(notE);
        }

        public void EliminarNotaIngreso(int idNotaentrada)
        {
            DATNotaEntrada.Instancia.EliminarNotaIngreso(idNotaentrada);
        }
        #endregion metodos
    }
}
