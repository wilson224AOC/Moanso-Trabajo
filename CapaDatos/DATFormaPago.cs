using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.SqlServer.Server;

namespace CapaDatos
{
    public class DATFormaPago
    {
        #region singleton
        private static readonly DATFormaPago _instancia = new DATFormaPago();
        public static DATFormaPago Instancia
        {
            get
            {
                return DATFormaPago._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTFormaPago> ListarFormaPago()
        {
            SqlCommand cmd = null;
            List<ENTFormaPago> lista = new List<ENTFormaPago>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaFormaPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTFormaPago formp = new ENTFormaPago();
                    formp.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"]);
                    formp.Nombre = dr["Nombre"].ToString();
                    formp.Descripcion = dr["Descripcion"].ToString();
                    formp.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    formp.DatosBancarios = Convert.ToBoolean(dr["DatosBancarios"]);
                    formp.DatosBa = dr["DatosBa"].ToString();
                    formp.Estado = Convert.ToBoolean(dr["Estado"]);
                    lista.Add(formp);
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

        public Boolean InsertarFormaPago(ENTFormaPago formp)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaFormaPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", formp.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", formp.Descripcion);
                cmd.Parameters.AddWithValue("@FechaCreacion", formp.FechaCreacion);
                cmd.Parameters.AddWithValue("@Estado", formp.Estado);
                cmd.Parameters.AddWithValue("@DatosBancarios", formp.DatosBancarios);
                cmd.Parameters.AddWithValue("@DatosBa", formp.DatosBa);
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

        public Boolean EditarFormaPago(ENTFormaPago formp)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaFormaPago", cn);
                cmd.Parameters.AddWithValue("@Nombre", formp.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", formp.Descripcion);
                cmd.Parameters.AddWithValue("@FechaCreacion", formp.FechaCreacion);
                cmd.Parameters.AddWithValue("@Estado", formp.Estado);
                cmd.Parameters.AddWithValue("@DatosBancarios", formp.DatosBancarios);
                cmd.Parameters.AddWithValue("@DatosBa", formp.DatosBa);
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

        public void DeshabilitarFormaPago(int idFormapago)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaFormaPago", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFormaPago", idFormapago);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
