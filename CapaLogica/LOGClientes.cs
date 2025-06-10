using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class LOGClientes
    {
        #region sigleton
        private static readonly LOGClientes _instancia = new LOGClientes();
        public static LOGClientes Instancia
        {
            get
            {
                return LOGClientes._instancia;
            }
        }
        #endregion singleton

        #region metodos


        public List<ENTClientes> ListarCliente()
        {
            return DATClientes.Instancia.ListarCliente();
        }
        ///inserta
        public void InsertaCliente(ENTClientes cli)
        {
            DATClientes.Instancia.InsertarCliente(cli);
        }

        //edita
        public void EditaCliente(ENTClientes cli)
        {
            DATClientes.Instancia.EditarCliente(cli);
        }
        public void DeshabilitarCliente(int idCliente)
        {
            DATClientes.Instancia.EliminarCliente(idCliente);
        }  
        #endregion metodos
    }
}
