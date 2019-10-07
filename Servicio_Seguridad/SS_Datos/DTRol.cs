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
    public class DTRol
    {
        ConexionDB cn = new ConexionDB();

        public string Rol_Registrar(string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RolRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@NombreRol", SqlDbType.Text)).Value = nombreRol;
                cmd.Parameters.Add(new SqlParameter("@DescripcionRol", SqlDbType.Text)).Value = descripcionRol;
                cmd.Parameters.Add(new SqlParameter("@EstadoRol", SqlDbType.Text)).Value = estadoRol;
                cmd.Parameters.Add(new SqlParameter("@TipoPermiso", SqlDbType.Text)).Value = tipoPermiso;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdRol"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string Rol_Modificar(int idRol, string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RolModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
                cmd.Parameters.Add(new SqlParameter("@NombreRol", SqlDbType.Text)).Value = nombreRol;
                cmd.Parameters.Add(new SqlParameter("@DescripcionRol", SqlDbType.Text)).Value = descripcionRol;
                cmd.Parameters.Add(new SqlParameter("@EstadoRol", SqlDbType.Text)).Value = estadoRol;
                cmd.Parameters.Add(new SqlParameter("@TipoPermiso", SqlDbType.Text)).Value = tipoPermiso;
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
        public List<Rol> Rol_Leer(int idRol, string nombreRol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_RolLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
            cmd.Parameters.Add(new SqlParameter("@NombreRol", SqlDbType.Text)).Value = nombreRol;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Rol> RolLeer = new List<Rol>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Rol rol = new Rol();
                rol.IdRol = Funciones.ToInt(dt.Rows[i]["IdRol"]);
                rol.NombreRol = Funciones.ToString(dt.Rows[i]["NombreRol"]);
                rol.DescripcionRol = Funciones.ToString(dt.Rows[i]["DescripcionRol"]);
                rol.EstadoRol = Funciones.ToString(dt.Rows[i]["EstadoRol"]);
                rol.EstadoRolDesc = Funciones.ToString(dt.Rows[i]["EstadoRolDesc"]);
                rol.TipoPermiso = Funciones.ToString(dt.Rows[i]["TipoPermiso"]);
                rol.TipoPermisoDesc = Funciones.ToString(dt.Rows[i]["TipoPermisoDesc"]);
                rol.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                rol.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                rol.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                rol.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                RolLeer.Add(rol);
            }
            cn.Desconectar();
            return RolLeer;
        }

        public string Rol_Eliminar(int idRol)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RolEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdRol", SqlDbType.Int)).Value = idRol;
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
