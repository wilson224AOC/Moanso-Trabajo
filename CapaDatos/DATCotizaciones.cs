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
    public class DATCotizaciones
    {
        #region singleton
        private static readonly DATCotizaciones _instancia = new DATCotizaciones();
        public static DATCotizaciones Instancia
        {
            get
            {
                return DATCotizaciones._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTCotizaciones> ListarCotizaciones()
        {
            SqlCommand cmd = null;
            List<ENTCotizaciones> lista = new List<ENTCotizaciones>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaCotizaciones", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTCotizaciones cot = new ENTCotizaciones();
                    cot.IdCotizacion = Convert.ToInt32(dr["IdCotizacion"]);
                    cot.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                    cot.RazonSocial = dr["RazonSocial"].ToString();
                    cot.IdRequerimiento = Convert.ToInt32(dr["IdRequerimiento"]);
                    cot.FechaCotizacion = Convert.ToDateTime(dr["FechaCotizacion"]);
                    cot.FechaVencimiento = dr["FechaVencimiento"] != DBNull.Value ? Convert.ToDateTime(dr["FechaVencimiento"]) : (DateTime?)null;
                    cot.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                    cot.Estado = dr["Estado"].ToString();
                    cot.Observaciones = dr["Observaciones"].ToString();
                    cot.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(cot);
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

        public Boolean InsertarCotizaciones(ENTCotizaciones cot)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaCotizaciones", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", cot.IdProveedor);
                cmd.Parameters.AddWithValue("@IdRequerimiento", cot.IdRequerimiento);
                cmd.Parameters.AddWithValue("@FechaCotizacion", cot.FechaCotizacion);
                cmd.Parameters.AddWithValue("@FechaVencimiento", cot.FechaVencimiento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MontoTotal", cot.MontoTotal);
                cmd.Parameters.AddWithValue("@Estado", cot.Estado);
                cmd.Parameters.AddWithValue("@Observaciones", cot.Observaciones);
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

        public void EliminarCotizaciones(int idCotizacion)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaCotizaciones", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
