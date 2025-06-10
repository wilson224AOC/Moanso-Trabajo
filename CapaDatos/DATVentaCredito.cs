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
    public class DATVentaCredito
    {
        #region singleton
        private static readonly DATVentaCredito _instancia = new DATVentaCredito();
        public static DATVentaCredito Instancia
        {
            get
            {
                return _instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTVentaCredito> ListarVentaCredito()
        {
            SqlCommand cmd = null;
            List<ENTVentaCredito> lista = new List<ENTVentaCredito>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarVentasCredito", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTVentaCredito venC = new ENTVentaCredito();
                    venC.IdVentaCredito = Convert.ToInt32(dr["IdVentaCredito"]);
                    venC.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    venC.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    venC.MontoCredito = Convert.ToDecimal(dr["MontoCredito"]);
                    venC.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                    venC.MontoPagado = Convert.ToDecimal(dr["MontoPagado"]);
                    venC.SaldoPendiente = Convert.ToDecimal(dr["SaldoPendiente"]);
                    venC.Estado = dr["Estado"].ToString();
                    venC.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    venC.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                    lista.Add(venC);
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

        public bool InsertarVentaCredito(ENTVentaCredito venC)
        {
            SqlCommand cmd = null;
            bool insertado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarVentaCredito", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", venC.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", venC.Cantidad);
                cmd.Parameters.AddWithValue("@MontoCredito", venC.MontoCredito);
                cmd.Parameters.AddWithValue("@FechaVencimiento", venC.FechaVencimiento);
                cmd.Parameters.AddWithValue("@MontoPagado", venC.MontoPagado);
                cmd.Parameters.AddWithValue("@SaldoPendiente", venC.SaldoPendiente);
                cmd.Parameters.AddWithValue("@Estado", venC.Estado);
                cmd.Parameters.AddWithValue("@FechaRegistro", venC.FechaRegistro);
                cmd.Parameters.AddWithValue("@IdEmpleado", venC.IdEmpleado);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    insertado = true;
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
            return insertado;
        }

        public void DeshabilitaVentaCredito(int IdVentaCredito)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminarVentaCredito", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVentaCredito", IdVentaCredito);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
