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
    public class DATProductos
    {
        #region singleton
        private static readonly DATProductos _instancia = new DATProductos();
        public static DATProductos Instancia
        {
            get
            {
                return DATProductos._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTProductos> ListarProducto()
        {
            SqlCommand cmd = null;
            List<ENTProductos> lista = new List<ENTProductos>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTProductos prod = new ENTProductos();
                    prod.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    prod.Nombre = dr["Nombre"].ToString();
                    prod.Descripcion = dr["Descripcion"].ToString();
                    prod.Codigo = dr["Codigo"].ToString();
                    prod.PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]);
                    prod.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                    prod.Stock = Convert.ToInt32(dr["Stock"]);
                    prod.StockMinimo = Convert.ToInt32(dr["StockMinimo"]);
                    prod.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(prod);
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

        public Boolean InsertarProducto(ENTProductos prod)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", prod.Descripcion);
                cmd.Parameters.AddWithValue("@Codigo", prod.Codigo);
                cmd.Parameters.AddWithValue("@PrecioCompra", prod.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", prod.Stock);
                cmd.Parameters.AddWithValue("@StockMinimo", prod.StockMinimo);
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

        public Boolean EditarProducto(ENTProductos prod)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", prod.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", prod.Descripcion);
                cmd.Parameters.AddWithValue("@Codigo", prod.Codigo);
                cmd.Parameters.AddWithValue("@PrecioCompra", prod.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@Stock", prod.Stock);
                cmd.Parameters.AddWithValue("@StockMinimo", prod.StockMinimo);
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

        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
