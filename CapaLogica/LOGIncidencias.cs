using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGIncidencias
    {
        #region sigleton
        private static readonly LOGIncidencias _instancia = new LOGIncidencias();
        public static LOGIncidencias Instancia
        {
            get
            {
                return LOGIncidencias._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTIncidencias> ListarIncidencias()
        {
            return DATIncidencias.Instancia.ListarIncidencias();
        }
        public void InsertarIncidencias(ENTIncidencias inc)
        {
            DATIncidencias.Instancia.InsertarIncidencias(inc);
        }

        public void EliminarIncidencias(int Idincidencias)
        {
            DATIncidencias.Instancia.EliminarIncidencias(Idincidencias);
        }
        #endregion metodos
    }
}
