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
    public class DTUsuario
    {
        ConexionDB cn = new ConexionDB();

        public string Usuario_Registrar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UsuarioRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.Text)).Value = nombre;
                cmd.Parameters.Add(new SqlParameter("@ApellidoUsuario", SqlDbType.Text)).Value = apellido;
                cmd.Parameters.Add(new SqlParameter("@ClaveAcceso", SqlDbType.Text)).Value = claveAcceso;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.Text)).Value = email;
                cmd.Parameters.Add(new SqlParameter("@EstadoUsuario", SqlDbType.Text)).Value = estadoUsuario;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToString(dt.Rows[0]["IDUsuario"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string Usuario_Modificar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UsuarioModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                if (usuario != "") cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.Text)).Value = nombre;
                cmd.Parameters.Add(new SqlParameter("@ApellidoUsuario", SqlDbType.Text)).Value = apellido;
                cmd.Parameters.Add(new SqlParameter("@ClaveAcceso", SqlDbType.Text)).Value = claveAcceso;
                cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.Text)).Value = email;
                cmd.Parameters.Add(new SqlParameter("@EstadoUsuario", SqlDbType.Text)).Value = estadoUsuario;
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
        public List<Usuario> Usuario_Leer(string usuario, string estadoUsuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_UsuarioLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
            cmd.Parameters.Add(new SqlParameter("@EstadoUsuario", SqlDbType.Text)).Value = estadoUsuario;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Usuario> UsuarioLeer = new List<Usuario>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuario datosusuario = new Usuario();
                datosusuario.IdUsuario = Funciones.ToString(dt.Rows[i]["IDUsuario"]);
                datosusuario.NombreUsuario = Funciones.ToString(dt.Rows[i]["NombreUsuario"]);
                datosusuario.ApellidoUsuario = Funciones.ToString(dt.Rows[i]["ApellidoUsuario"]);
                datosusuario.ClaveAcceso = Funciones.ToString(dt.Rows[i]["ClaveAcceso"]);
                datosusuario.Email = Funciones.ToString(dt.Rows[i]["Email"]);
                datosusuario.EstadoUsuario = Funciones.ToString(dt.Rows[i]["EstadoUsuario"]);
                datosusuario.EstadoUsuarioDesc = Funciones.ToString(dt.Rows[i]["EstadoUsuarioDesc"]);
                datosusuario.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                datosusuario.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                datosusuario.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                datosusuario.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                UsuarioLeer.Add(datosusuario);
            }
            cn.Desconectar();
            return UsuarioLeer;
        }

        public List<Usuario> Usuario_Iniciar_Sesion(string usuario, string clave)
        {
            List<Usuario> UsuarioLeer = new List<Usuario>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Usuario_Iniciar_Sesion";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@Clave", SqlDbType.Text)).Value = clave;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario datosusuario = new Usuario();
                    datosusuario.IdUsuario = Funciones.ToString(dt.Rows[i]["IDUsuario"]);
                    datosusuario.NombreUsuario = Funciones.ToString(dt.Rows[i]["NombreUsuario"]);
                    datosusuario.ApellidoUsuario = Funciones.ToString(dt.Rows[i]["ApellidoUsuario"]);
                    datosusuario.EstadoUsuario = Funciones.ToString(dt.Rows[i]["EstadoUsuario"]);
                    datosusuario.EstadoUsuarioDesc = Funciones.ToString(dt.Rows[i]["EstadoUsuarioDesc"]);
                    datosusuario.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                    datosusuario.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                    datosusuario.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                    datosusuario.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                    UsuarioLeer.Add(datosusuario);
                }
                cn.Desconectar();
            }
            catch (Exception ex)
            {

                AppLogger.LogError("Error : Usuario_Iniciar_Sesion (Datos)", ex); ;
            }
            
            return UsuarioLeer;
        }

        public string Usuario_Eliminar(string usuario)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UsuarioEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
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


        public DataTable Usuario_LeerDT()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UsuarioLeer";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = "";
                cmd.Parameters.Add(new SqlParameter("@EstadoUsuario", SqlDbType.Text)).Value = "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                cn.Desconectar();
            }
            catch (Exception e)
            {

            }


            return dt;
        }


    }
}
