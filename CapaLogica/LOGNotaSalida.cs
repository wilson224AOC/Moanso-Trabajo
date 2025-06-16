using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGNotaSalida
    {
        #region sigleton
        private static readonly LOGNotaSalida _instancia = new LOGNotaSalida();
        public static LOGNotaSalida Instancia
        {
            get
            {
                return LOGNotaSalida._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTNotaSalida> ListarNotaSalida()
        {
            return DATNotaSalida.Instancia.ListarNotaSalida();
        }
        public void InsertarNotaSalida(ENTNotaSalida notS)
        {
            DATNotaSalida.Instancia.InsertarNotaSalida(notS);
        }

        public void EliminarNotaSalida(int idNotasalida)
        {
            DATNotaSalida.Instancia.EliminarNotaSalida(idNotasalida);
        }
        #endregion metodos
    }
}
