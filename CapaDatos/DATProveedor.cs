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
    public class DATProveedor
    {
        #region singleton
        private static readonly DATProveedor _instancia = new DATProveedor();
        public static DATProveedor Instancia
        {
            get
            {
                return DATProveedor._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<ENTProveedor> lista = new List<ENTProveedor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTProveedor prov = new ENTProveedor();
                    prov.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                    prov.RazonSocial = dr["RazonSocial"].ToString();
                    prov.RUC = dr["RUC"].ToString();
                    prov.Direccion = dr["Direccion"].ToString();
                    prov.Telefono = dr["Telefono"].ToString();
                    prov.Gmail = dr["Gmail"].ToString();
                    prov.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(prov);
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

        public Boolean InsertarProveedor(ENTProveedor prov)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RazonSocial", prov.RazonSocial);
                cmd.Parameters.AddWithValue("@RUC", prov.RUC);
                cmd.Parameters.AddWithValue("@Direccion", prov.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", prov.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", prov.Gmail);
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

        public Boolean EditarProveedor(ENTProveedor prov)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", prov.IdProveedor);
                cmd.Parameters.AddWithValue("@RazonSocial", prov.RazonSocial);
                cmd.Parameters.AddWithValue("@RUC", prov.RUC);
                cmd.Parameters.AddWithValue("@Direccion", prov.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", prov.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", prov.Gmail);
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

        public void EliminarProveedor(int idProveedor)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaProveedor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
