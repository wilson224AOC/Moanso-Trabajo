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
    public class DATDetalleVenta
    {
        #region singleton
        private static readonly DATDetalleVenta _instancia = new DATDetalleVenta();
        public static DATDetalleVenta Instancia
        {
            get
            {
                return DATDetalleVenta._instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<ENTDetalleVenta> ListarDetalleVenta()
        {
            SqlCommand cmd = null;
            List<ENTDetalleVenta> lista = new List<ENTDetalleVenta>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaDetalleVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTDetalleVenta detv = new ENTDetalleVenta();
                    detv.IdDetalle = Convert.ToInt32(dr["IdDetalle"]);
                    detv.IdVenta = Convert.ToInt32(dr["IdVenta"]);
                    detv.IdVentaCredito = Convert.ToInt32(dr["IdVentaCredito"]);
                    detv.Subtotal = Convert.ToDecimal(dr["Subtotal"]);
                    detv.TipoVenta = dr["TipoVenta"].ToString();
                    detv.IdProducto = Convert.ToInt32(dr["IdProducto"]);  
                    detv.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    detv.Observaciones = dr["Observaciones"].ToString();
                    detv.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(detv);
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

        public Boolean InsertarDetalleVenta(ENTDetalleVenta detv)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaDetalleVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", detv.IdVenta);
                cmd.Parameters.AddWithValue("@IdVentaCredito", detv.IdVentaCredito);
                cmd.Parameters.AddWithValue("@Subtotal", detv.Subtotal);
                cmd.Parameters.AddWithValue("@TipoVenta", detv.TipoVenta);
                cmd.Parameters.AddWithValue("@IdProducto", detv.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", detv.Cantidad);
                cmd.Parameters.AddWithValue("@Observaciones", detv.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", detv.FechaRegistro);

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

        public void EliminarDetalleVenta(int idDetalle)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaDetalleVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
