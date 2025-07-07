using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGRegistroContable
    {
        #region sigleton
        private static readonly LOGRegistroContable _instancia = new LOGRegistroContable();
        public static LOGRegistroContable Instancia
        {
            get
            {
                return LOGRegistroContable._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTRegistroContable> ListarRegistrosContables()
        {
            return DATRegistroContable.Instancia.ListarRegistrosContables();
        }
        public void InsertarRegistroContable(ENTRegistroContable reg)
        {
            DATRegistroContable.Instancia.InsertarRegistroContable(reg);
        }

        public void EliminarRegistroContable(int idRegistro)
        {
            DATRegistroContable.Instancia.EliminarRegistroContable(idRegistro);
        }
        #endregion metodos
    }
}
