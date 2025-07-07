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
    public class DATIngresoFinanciero
    {
        #region singleton
        private static readonly DATIngresoFinanciero _instancia = new DATIngresoFinanciero();
        public static DATIngresoFinanciero Instancia
        {
            get
            {
                return DATIngresoFinanciero._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTIngresoFinanciero> ListarIngresoFinanciero()
        {
            SqlCommand cmd = null;
            List<ENTIngresoFinanciero> lista = new List<ENTIngresoFinanciero>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaIngresoFinanciero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTIngresoFinanciero ingreso = new ENTIngresoFinanciero();
                    ingreso.IdIngreso = Convert.ToInt32(dr["IdIngreso"]);
                    ingreso.IdDetalle = Convert.ToInt32(dr["IdDetalle"]);
                    ingreso.Concepto = dr["Concepto"].ToString();
                    ingreso.Monto = Convert.ToDecimal(dr["Monto"]);
                    ingreso.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    ingreso.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    ingreso.Observaciones = dr["Observaciones"] != DBNull.Value ? dr["Observaciones"].ToString() : string.Empty;
                    lista.Add(ingreso);
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

        public Boolean InsertarIngresoFinanciero(ENTIngresoFinanciero ingreso)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaIngresoFinanciero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", ingreso.IdDetalle);
                cmd.Parameters.AddWithValue("@Concepto", ingreso.Concepto);
                cmd.Parameters.AddWithValue("@Monto", ingreso.Monto);
                cmd.Parameters.AddWithValue("@FechaIngreso", ingreso.FechaIngreso);
                cmd.Parameters.AddWithValue("@Observaciones", string.IsNullOrEmpty(ingreso.Observaciones) ? (object)DBNull.Value : ingreso.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", ingreso.FechaRegistro);
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
            finally
            {
                cmd.Connection.Close();
            }
            return inserta;
        }

        public void EliminarIngresoFinanciero(int idIngreso)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaIngresoFinanciero", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
