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
    public class DTGrupoUsuario
    {
        ConexionDB cn = new ConexionDB();

        public string GrupoUsuario_Registrar(int idGrupo, string usuario, string estadoGrupoUsuario, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoUsuarioRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@EstadoGrupoUsuario", SqlDbType.Text)).Value = estadoGrupoUsuario;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdGrupoUsuario"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string GrupoUsuario_Modificar(int idGrupoUsuario, int idGrupo, string usuario, string estadoGrupoUsuario, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoUsuarioModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupoUsuario", SqlDbType.Int)).Value = idGrupoUsuario;
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@EstadoGrupoUsuario", SqlDbType.Text)).Value = estadoGrupoUsuario;
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
        public List<GrupoUsuario> GrupoUsuario_Leer(int idGrupoUsuario, int idGrupo, string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GrupoUsuarioLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdGrupoUsuario", SqlDbType.Int)).Value = idGrupoUsuario;
            cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<GrupoUsuario> GrupoUsuarioLeer = new List<GrupoUsuario>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GrupoUsuario grupoUsuario = new GrupoUsuario();
                grupoUsuario.IdGrupoUsuario = Funciones.ToInt(dt.Rows[i]["IdGrupoUsuario"]);
                grupoUsuario.IdGrupo = Funciones.ToInt(dt.Rows[i]["IdGrupo"]);
                grupoUsuario.NombreGrupo = Funciones.ToString(dt.Rows[i]["NombreGrupo"]);
                grupoUsuario.Usuario = Funciones.ToString(dt.Rows[i]["IDUsuario"]);
                grupoUsuario.NombreUsuario = Funciones.ToString(dt.Rows[i]["NombreUsuario"]);
                grupoUsuario.ApellidoUsuario = Funciones.ToString(dt.Rows[i]["ApellidoUsuario"]);
                grupoUsuario.EstadoGrupoUsuario = Funciones.ToString(dt.Rows[i]["EstadoGrupoUsuario"]);
                grupoUsuario.EstadoGrupoUsuarioDesc = Funciones.ToString(dt.Rows[i]["EstadoGrupoUsuarioDesc"]);
                grupoUsuario.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                grupoUsuario.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                grupoUsuario.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                grupoUsuario.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                GrupoUsuarioLeer.Add(grupoUsuario);
            }
            cn.Desconectar();
            return GrupoUsuarioLeer;
        }

        public string GrupoUsuario_Eliminar(int idGrupoUsuario)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoUsuarioEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupoUsuario", SqlDbType.Int)).Value = idGrupoUsuario;
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
