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
    public class DATCategoria
    {
        #region singleton
        private static readonly DATCategoria _instancia = new DATCategoria();
        public static DATCategoria Instancia
        {
            get
            {
                return DATCategoria._instancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<ENTCategoria> ListarCategoria()
        {
            SqlCommand cmd = null;
            List<ENTCategoria> lista = new List<ENTCategoria>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTCategoria cat = new ENTCategoria();
                    cat.IdCategoria = Convert.ToInt32(dr["IdCategoria"]);
                    cat.NombreCategoria = dr["NombreCategoria"].ToString();
                    cat.Descripcion = dr["Descripcion"].ToString();
                    cat.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                    cat.Estado = Convert.ToBoolean(dr["Estado"]);;
                    cat.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(cat);
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

        public Boolean InsertarCategoria(ENTCategoria cat)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreCategoria", cat.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);
                cmd.Parameters.AddWithValue("@FechaCreacion", cat.FechaCreacion);
                cmd.Parameters.AddWithValue("@Estado", cat.Estado);
                cmd.Parameters.AddWithValue("@FechaRegistro", cat.FechaRegistro);
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

        public Boolean EditarCategoria(ENTCategoria cat)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaCategoria", cn);
                cmd.Parameters.AddWithValue("@NombreCategoria", cat.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);
                cmd.Parameters.AddWithValue("@FechaCreacion", cat.FechaCreacion);
                cmd.Parameters.AddWithValue("@Estado", cat.Estado);
                cmd.Parameters.AddWithValue("@FechaRegistro", cat.FechaRegistro);
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

        public void EliminarCategoria(int idCategoria)
        {
            using (SqlConnection con = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaCategoria", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion metodos
    }
}
