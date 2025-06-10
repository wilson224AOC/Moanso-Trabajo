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
    public class DATNotaEntrada
    {
        #region singleton
        private static readonly DATNotaEntrada _instancia = new DATNotaEntrada();
        public static DATNotaEntrada Instancia
        {
            get
            {
                return DATNotaEntrada._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTNotaEntrada> ListarNotaIngreso()
        {
            SqlCommand cmd = null;
            List<ENTNotaEntrada> lista = new List<ENTNotaEntrada>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaNotaIngreso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTNotaEntrada notE = new ENTNotaEntrada();
                    notE.IdNotaIngreso = Convert.ToInt32(dr["IdNotaIngreso"]);
                    notE.IdOrdenCompra = Convert.ToInt32(dr["IdOrdenCompra"]);
                    notE.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    notE.TipoIngreso = dr["TipoIngreso"].ToString();
                    notE.Observaciones = dr["Observaciones"].ToString();
                    notE.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

                    lista.Add(notE);
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

        public Boolean InsertarNotaIngreso(ENTNotaEntrada notE)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaNotaIngreso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOrdenCompra", notE.IdOrdenCompra);
                cmd.Parameters.AddWithValue("@FechaIngreso", notE.FechaIngreso);
                cmd.Parameters.AddWithValue("@TipoIngreso", notE.TipoIngreso);
                cmd.Parameters.AddWithValue("@Observaciones", notE.Observaciones);
                cmd.Parameters.AddWithValue("@FechaRegistro", notE.FechaRegistro);

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

        public void EliminarNotaIngreso(int idNotaentrada)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaNotaIngreso", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdNotaIngreso", idNotaentrada);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion metodos
    }
}
