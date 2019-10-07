using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Datos
{
    public class DTGrupoRol
    {
        ConexionDB cn = new ConexionDB();

        public string GrupoRol_Registrar(int idGrupo, int idRol, string estadoGrupoRol, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoRolRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
                cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
                cmd.Parameters.Add(new SqlParameter("@EstadoGrupoRol", SqlDbType.Text)).Value = estadoGrupoRol;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdGrupoRol"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string GrupoRol_Modificar(int idGrupoRol, int idGrupo, int idRol, string estadoGrupoRol, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoRolModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupoRol", SqlDbType.Int)).Value = idGrupoRol;
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
                cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
                cmd.Parameters.Add(new SqlParameter("@EstadoGrupoRol", SqlDbType.Text)).Value = estadoGrupoRol;
                cmd.Parameters.Add(new SqlParameter("@ModificadoPor", SqlDbType.Text)).Value = modificadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime)).Value = fechaModificacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }
        public List<GrupoRol> GrupoRol_Leer(int idGrupoRol, int idGrupo, int idRol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GrupoRolLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdGrupoRol", SqlDbType.Int)).Value = idGrupoRol;
            cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
            cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<GrupoRol> GrupoRolLeer = new List<GrupoRol>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GrupoRol grupoRol = new GrupoRol();
                grupoRol.IdGrupoRol = Funciones.ToInt(dt.Rows[i]["IdGrupoRol"]);
                grupoRol.IdGrupo = Funciones.ToInt(dt.Rows[i]["IdGrupo"]);
                grupoRol.NombreGrupo = Funciones.ToString(dt.Rows[i]["NombreGrupo"]);
                grupoRol.IdRol = Funciones.ToInt(dt.Rows[i]["IdRol"]);
                grupoRol.NombreRol = Funciones.ToString(dt.Rows[i]["NombreRol"]);
                grupoRol.EstadoGrupoRol = Funciones.ToString(dt.Rows[i]["EstadoGrupoRol"]);
                grupoRol.EstadoGrupoRolDesc = Funciones.ToString(dt.Rows[i]["EstadoGrupoRolDesc"]);
                grupoRol.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                grupoRol.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                grupoRol.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                grupoRol.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                GrupoRolLeer.Add(grupoRol);
            }
            cn.Desconectar();
            return GrupoRolLeer;
        }

        public string GrupoRol_Eliminar(int idGrupo)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoRolEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupoRol", SqlDbType.Int)).Value = idGrupo;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }
    }
}
