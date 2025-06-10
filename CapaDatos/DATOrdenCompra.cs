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
    public class DATOrdenCompra
    {
        #region singleton
        private static readonly DATOrdenCompra _instancia = new DATOrdenCompra();
        public static DATOrdenCompra Instancia
        {
            get
            {
                return DATOrdenCompra._instancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<ENTOrdenCompra> ListarOrdenCompra()
        {
            SqlCommand cmd = null;
            List<ENTOrdenCompra> lista = new List<ENTOrdenCompra>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaOrdenCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTOrdenCompra ordC = new ENTOrdenCompra();
                    ordC.IdOrdenCompra = Convert.ToInt32(dr["IdOrdenCompra"]);
                    ordC.IdCotizacion = Convert.ToInt32(dr["IdCotizacion"]);
                    ordC.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                    ordC.FechaOrden = Convert.ToDateTime(dr["FechaOrden"]);
                    ordC.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
                    ordC.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                    ordC.Estado = dr["Estado"].ToString();
                    ordC.Observaciones = dr["Observaciones"].ToString();
                    ordC.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(ordC);
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

        public Boolean InsertarOrdenCompra(ENTOrdenCompra ordC)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaOrdenCompra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCotizacion", ordC.IdCotizacion);
                cmd.Parameters.AddWithValue("@FechaOrden", ordC.FechaOrden);
                cmd.Parameters.AddWithValue("@FechaEntrega", ordC.FechaEntrega);
                cmd.Parameters.AddWithValue("@MontoTotal", ordC.MontoTotal);
                cmd.Parameters.AddWithValue("@Estado", ordC.Estado);
                cmd.Parameters.AddWithValue("@Observaciones", ordC.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", ordC.FechaRegistro);

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

        public void EliminarOrdenCompra(int idOrdencompra)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaOrdenCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenCompra", idOrdencompra);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
