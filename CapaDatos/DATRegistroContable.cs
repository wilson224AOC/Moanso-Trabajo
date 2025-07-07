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
    public class DATRegistroContable
    {
        #region singleton
        private static readonly DATRegistroContable _instancia = new DATRegistroContable();
        public static DATRegistroContable Instancia
        {
            get
            {
                return _instancia;
            }
        }
        #endregion singleton

        #region métodos

        public List<ENTRegistroContable> ListarRegistrosContables()
        {
            SqlCommand cmd = null;
            List<ENTRegistroContable> lista = new List<ENTRegistroContable>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaRegistroContable", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ENTRegistroContable reg = new ENTRegistroContable();
                    reg.IdRegistro = Convert.ToInt32(dr["IdRegistro"]);
                    reg.IdIngreso = dr["IdIngreso"] != DBNull.Value ? Convert.ToInt32(dr["IdIngreso"]) : 0;
                    reg.IdEgreso = dr["IdEgreso"] != DBNull.Value ? Convert.ToInt32(dr["IdEgreso"]) : 0;
                    reg.TipoMovimiento = dr["TipoMovimiento"].ToString();
                    reg.Descripcion = dr["Descripcion"].ToString();
                    reg.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    reg.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    lista.Add(reg);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
            return lista;
        }

        public bool InsertarRegistroContable(ENTRegistroContable reg)
        {
            SqlCommand cmd = null;
            bool inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spRegistrarMovimientoContable", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdIngreso", reg.IdIngreso != 0 ? (object)reg.IdIngreso : DBNull.Value);
                cmd.Parameters.AddWithValue("@IdEgreso", reg.IdEgreso != 0 ? (object)reg.IdEgreso : DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", reg.Fecha);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                inserta = i > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null) cmd.Connection.Close();
            }
            return inserta;
        }

        public void EliminarRegistroContable(int idRegistro)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                SqlCommand cmd = new SqlCommand("spEliminaRegistroContable", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRegistro", idRegistro);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion métodos
    }
}
