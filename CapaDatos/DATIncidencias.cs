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
    public class DATIncidencias
    {
        #region singleton

        private static readonly DATIncidencias _instancia = new DATIncidencias();
        public static DATIncidencias Instancia
        {
            get
            {
                return DATIncidencias._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTIncidencias> ListarIncidencias()
        {
            SqlCommand cmd = null;
            List<ENTIncidencias> lista = new List<ENTIncidencias>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); 
                cmd = new SqlCommand("spListaIncidencias", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTIncidencias inc = new ENTIncidencias();
                    inc.IdIncidencia = Convert.ToInt32(dr["IdIncidencia"]);
                    inc.IdNotaIngreso = dr["IdNotaIngreso"] != DBNull.Value ? Convert.ToInt32(dr["IdNotaIngreso"]) : (int?)null;
                    inc.TipoIncidencia = dr["TipoIncidencia"].ToString();
                    inc.Descripcion = dr["Descripcion"].ToString();
                    inc.FechaIncidencia = Convert.ToDateTime(dr["FechaIncidencia"]);
                    inc.Estado = dr["Estado"].ToString();
                    inc.Observaciones = dr["Observaciones"].ToString();
                    inc.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(inc);
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

        public Boolean InsertarIncidencias(ENTIncidencias inc)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaIncidencias", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotaIngreso", inc.IdNotaIngreso ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoIncidencia", inc.TipoIncidencia);
                cmd.Parameters.AddWithValue("@Descripcion", inc.Descripcion);
                cmd.Parameters.AddWithValue("@FechaIncidencia", inc.FechaIncidencia);
                cmd.Parameters.AddWithValue("@Estado", inc.Estado);
                cmd.Parameters.AddWithValue("@Observaciones", inc.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", inc.FechaRegistro);
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

        public void EliminarIncidencias(int Idincidencias)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaIncidencias", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdIncidencia", Idincidencias);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
