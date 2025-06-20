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
    public class DATVentaDirecta
    {
        #region singleton
        private static readonly DATVentaDirecta _instancia = new DATVentaDirecta();
        public static DATVentaDirecta Instancia
        {
            get
            {
                return _instancia;
            }
        }
        #endregion singleton

        #region metodos

        public List<ENTVentaDirecta> ListarVentaDirecta()
        {
            SqlCommand cmd = null;
            List<ENTVentaDirecta> lista = new List<ENTVentaDirecta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarVentasDirectas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTVentaDirecta venD = new ENTVentaDirecta();
                    venD.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                    venD.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    venD.IdFormaPago = Convert.ToInt32(dr["IdFormaPago"]);
                    venD.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    venD.NumeroVenta = dr["NumeroVenta"].ToString();
                    venD.FechaVenta = Convert.ToDateTime(dr["FechaVenta"]);
                    venD.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                    venD.Observaciones = dr["Observaciones"].ToString();
                    venD.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(venD);
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

        public bool InsertarVentaDirecta(ENTVentaDirecta venD)
        {
            SqlCommand cmd = null;
            bool insertado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarVentaDirecta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdProducto", venD.IdProducto);
                cmd.Parameters.AddWithValue("@IdFormaPago", venD.IdFormaPago);
                cmd.Parameters.AddWithValue("@Cantidad", venD.Cantidad);
                cmd.Parameters.AddWithValue("@NumeroVenta", venD.NumeroVenta);
                cmd.Parameters.AddWithValue("@FechaVenta", venD.FechaVenta);
                cmd.Parameters.AddWithValue("@MontoTotal", venD.MontoTotal);
                cmd.Parameters.AddWithValue("@Observaciones", venD.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", venD.FechaRegistro);

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

        public void DeshabilitaVentaDirecta(int Idventa)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminarVentaDirecta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", Idventa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
