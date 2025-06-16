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
    public class DATNotaSalida
    {
        #region singleton
        private static readonly DATNotaSalida _instancia = new DATNotaSalida();
        public static DATNotaSalida Instancia
        {
            get
            {
                return DATNotaSalida._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTNotaSalida> ListarNotaSalida()
        {
            SqlCommand cmd = null;
            List<ENTNotaSalida> lista = new List<ENTNotaSalida>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaNotaSalida", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTNotaSalida notS = new ENTNotaSalida();
                    notS.IdNotaSalida = Convert.ToInt32(dr["IdNotaSalida"]);
                    notS.IdDetalle = Convert.ToInt32(dr["IdDetalle"]);
                    notS.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                    notS.TipoSalida = dr["TipoSalida"].ToString();
                    notS.Observaciones = dr["Observaciones"].ToString();
                    notS.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

                    lista.Add(notS);
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

        public Boolean InsertarNotaSalida(ENTNotaSalida notS)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaNotaSalida", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", notS.IdDetalle);
                cmd.Parameters.AddWithValue("@FechaSalida", notS.FechaSalida);
                cmd.Parameters.AddWithValue("@TipoSalida", notS.TipoSalida);
                cmd.Parameters.AddWithValue("@Observaciones", notS.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", notS.FechaRegistro);

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

        public void EliminarNotaSalida(int idNotasalida)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaNotaSalida", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotaSalida", idNotasalida);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
