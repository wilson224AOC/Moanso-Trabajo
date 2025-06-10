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
    public class DATEmpleado
    {
        #region singleton
        private static readonly DATEmpleado _instancia = new DATEmpleado();
        public static DATEmpleado Instancia
        {
            get
            {
                return DATEmpleado._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTEmpleado> ListarEmpleado()
        {
            SqlCommand cmd = null;
            List<ENTEmpleado> lista = new List<ENTEmpleado>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTEmpleado emp = new ENTEmpleado();
                    emp.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                    emp.NombreEmpleado = dr["NombreEmpleado"].ToString();
                    emp.NumeroDocumento = dr["NumeroDocumento"].ToString();
                    emp.CargoEmpleado = dr["CargoEmpleado"].ToString();
                    emp.Telefono = Convert.ToInt32(dr["Telefono"]);
                    emp.Gmail = dr["Gmail"].ToString();
                    emp.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(emp);
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

        public Boolean InsertarEmpleado(ENTEmpleado emp)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreEmpleado", emp.NombreEmpleado);
                cmd.Parameters.AddWithValue("@NumeroDocumento", emp.NumeroDocumento);
                cmd.Parameters.AddWithValue("@CargoEmpleado", emp.CargoEmpleado);
                cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", emp.Gmail);
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

        public Boolean EditarEmpleado(ENTEmpleado emp)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", emp.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreEmpleado", emp.NombreEmpleado);
                cmd.Parameters.AddWithValue("@NumeroDocumento", emp.NumeroDocumento);
                cmd.Parameters.AddWithValue("@CargoEmpleado", emp.CargoEmpleado);
                cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
                cmd.Parameters.AddWithValue("@Gmail", emp.Gmail);
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

        public void DeshabilitarEmpleado(int idEmpleado)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
