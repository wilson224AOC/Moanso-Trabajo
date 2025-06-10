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
    public class DATEgresoFinanciero
    {
        #region singleton
        private static readonly DATEgresoFinanciero _instancia = new DATEgresoFinanciero();
        public static DATEgresoFinanciero Instancia
        {
            get
            {
                return DATEgresoFinanciero._instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<ENTEgresoFinanciero> ListarEgresoFinanciero()
        {
            SqlCommand cmd = null;
            List<ENTEgresoFinanciero> lista = new List<ENTEgresoFinanciero>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaEgresoFinanciero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTEgresoFinanciero egr = new ENTEgresoFinanciero();
                    egr.IdEgreso = Convert.ToInt32(dr["IdEgreso"]);
                    egr.IdOrdenCompra = Convert.ToInt32(dr["IdOrdenCompra"]);
                    egr.Concepto = dr["Concepto"].ToString();
                    egr.FechaEgreso = Convert.ToDateTime(dr["FechaEgreso"]);
                    egr.Monto = Convert.ToDecimal(dr["Monto"]);
                    egr.Observaciones = dr["Observaciones"].ToString();
                    egr.TipoEgreso = dr["TipoEgreso"].ToString();
                    egr.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(egr);
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

        public Boolean InsertarEgresoFinanciero(ENTEgresoFinanciero egr)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaEgresoFinanciero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenCompra", egr.@IdOrdenCompra);
                cmd.Parameters.AddWithValue("@Concepto", egr.Concepto);
                cmd.Parameters.AddWithValue("@Monto", egr.Monto);
                cmd.Parameters.AddWithValue("@FechaEgreso", egr.FechaEgreso);
                cmd.Parameters.AddWithValue("@TipoEgreso", egr.TipoEgreso);
                cmd.Parameters.AddWithValue("@Observaciones", egr.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", egr.FechaRegistro);
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

        public void EliminarEgresoFinanciero(int idEgreso)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaEgresoFinanciero", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEgreso", idEgreso);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
