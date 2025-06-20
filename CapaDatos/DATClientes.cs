using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class DATClientes
    {
        #region singleton
        private static readonly DATClientes _instancia = new DATClientes();
        public static DATClientes Instancia
        {
            get
            {
                return DATClientes._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTClientes> ListarCliente()
        {
            SqlCommand cmd = null;
            List<ENTClientes> lista = new List<ENTClientes>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTClientes cli = new ENTClientes();
                    cli.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    cli.TipoDocumento = dr["TipoDocumento"].ToString();
                    cli.NumeroDocumento = dr["NumeroDocumento"].ToString();
                    cli.Direccion = dr["Direccion"].ToString();
                    cli.Telefono = dr["Telefono"].ToString();
                    cli.Gmail = dr["Gmail"].ToString();
                    cli.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    cli.Ubigeo = Convert.ToInt32(dr["Ubigeo"]);
                    lista.Add(cli);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public Boolean InsertarCliente(ENTClientes cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento", cli.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", cli.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", cli.Gmail);
                cmd.Parameters.AddWithValue("@Ubigeo", cli.Ubigeo);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }

        public Boolean EditarCliente(ENTClientes cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", cli.IdCliente);
                cmd.Parameters.AddWithValue("@TipoDocumento", cli.TipoDocumento);
                cmd.Parameters.AddWithValue("@NumeroDocumento", cli.NumeroDocumento);
                cmd.Parameters.AddWithValue("@Direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", cli.Gmail);
                cmd.Parameters.AddWithValue("@Ubigeo", cli.Ubigeo);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }

        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
