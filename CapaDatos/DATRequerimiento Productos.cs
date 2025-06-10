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
    public class DATRequerimiento_Productos
    {
        #region singleton
        private static readonly DATRequerimiento_Productos _instancia = new DATRequerimiento_Productos();
        public static DATRequerimiento_Productos Instancia
        {
            get
            {
                return DATRequerimiento_Productos._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTRequerimientoProductos> ListarRequerimientoProducto()
        {
            SqlCommand cmd = null;
            List<ENTRequerimientoProductos> lista = new List<ENTRequerimientoProductos>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaRequerimientoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTRequerimientoProductos req = new ENTRequerimientoProductos();
                    req.IdRequerimiento = Convert.ToInt32(dr["IdRequerimiento"]);
                    req.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                    req.NombreProducto = dr["NombreProducto"].ToString();
                    req.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    req.Subtotal = Convert.ToDecimal(dr["Subtotal"]);
                    req.CantidadRecibida = Convert.ToInt32(dr["CantidadRecibida"]);
                    req.Estado = Convert.ToBoolean(dr["Estado"]);
                    lista.Add(req);

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
        public Boolean InsertarRequerimientoProducto(ENTRequerimientoProductos req)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaRequerimientoProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", req.IdProducto);
                cmd.Parameters.AddWithValue("@Cantidad", req.Cantidad);
                cmd.Parameters.AddWithValue("@Subtotal", req.Subtotal);
                cmd.Parameters.AddWithValue("@CantidadRecibida", req.CantidadRecibida);
                cmd.Parameters.AddWithValue("@Estado", req.Estado);

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

        public void DeshabilitaRequerimientoProducto(int Idrequerimiento)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spDeshabilitaRequerimientoProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRequerimiento", Idrequerimiento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
