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
    public class DTGrupo
    {
        ConexionDB cn = new ConexionDB();

        public string Grupo_Registrar(string nombreGrupo, string descripcion, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@NombreGrupo", SqlDbType.Text)).Value = nombreGrupo;
                cmd.Parameters.Add(new SqlParameter("@DescripcionGrupo", SqlDbType.Text)).Value = descripcion;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdGrupo"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string Grupo_Modificar(int idGrupo, string nombreGrupo, string descripcion, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
                cmd.Parameters.Add(new SqlParameter("@NombreGrupo", SqlDbType.Text)).Value = nombreGrupo;
                cmd.Parameters.Add(new SqlParameter("@DescripcionGrupo", SqlDbType.Text)).Value = descripcion;
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
        public List<Grupo> Grupo_Leer(int idGrupo, string nombreGrupo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GrupoLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
            cmd.Parameters.Add(new SqlParameter("@NombreGrupo", SqlDbType.Text)).Value = nombreGrupo;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Grupo> GrupoLeer = new List<Grupo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Grupo grupo = new Grupo();
                grupo.IdGrupo = Funciones.ToInt(dt.Rows[i]["IdGrupo"]);
                grupo.NombreGrupo = Funciones.ToString(dt.Rows[i]["NombreGrupo"]);
                grupo.DescripcionGrupo = Funciones.ToString(dt.Rows[i]["DescripcionGrupo"]);
                grupo.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                grupo.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                grupo.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                grupo.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                GrupoLeer.Add(grupo);
            }
            cn.Desconectar();
            return GrupoLeer;
        }

        public string Grupo_Eliminar(int idGrupo)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_GrupoEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
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

        public List<Grupo> GrupoRolUsuario_Leer(int idGrupo, string nombreGrupo, string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GrupoRolUsuarioLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdGrupo", SqlDbType.Int)).Value = idGrupo;
            cmd.Parameters.Add(new SqlParameter("@NombreGrupo", SqlDbType.Text)).Value = nombreGrupo;
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Grupo> GrupoLeer = new List<Grupo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Grupo grupo = new Grupo();
                grupo.IdGrupo = Funciones.ToInt(dt.Rows[i]["IdGrupo"]);
                grupo.NombreGrupo = Funciones.ToString(dt.Rows[i]["NombreGrupo"]);
                grupo.DescripcionGrupo = Funciones.ToString(dt.Rows[i]["DescripcionGrupo"]);
                grupo.NombreRol = Funciones.ToString(dt.Rows[i]["NombreRol"]);
                grupo.EstadoRol = Funciones.ToString(dt.Rows[i]["EstadoRol"]);
                grupo.TipoPermiso = Funciones.ToString(dt.Rows[i]["TipoPermiso"]);
                grupo.TipoPermisoDesc = Funciones.ToString(dt.Rows[i]["TipoPermisoDesc"]);
                grupo.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                grupo.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                grupo.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                grupo.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                GrupoLeer.Add(grupo);
            }
            cn.Desconectar();
            return GrupoLeer;
        }
    }
}
