using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGCategoria
    {
        #region sigleton
        private static readonly LOGCategoria _instancia = new LOGCategoria();
        public static LOGCategoria Instancia
        {
            get
            {
                return LOGCategoria._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTCategoria> ListarCategoria()
        {
            return DATCategoria.Instancia.ListarCategoria();
        }
        public void InsertarCategoria(ENTCategoria cat)
        {
            DATCategoria.Instancia.InsertarCategoria(cat);
        }

        public void EditarCategoria(ENTCategoria cat)
        {
            DATCategoria.Instancia.EditarCategoria(cat);
        }
        public void EliminarCategoria(int idCategoria)
        {
            DATCategoria.Instancia.EliminarCategoria(idCategoria);
        }
        #endregion metodos
    }
}
