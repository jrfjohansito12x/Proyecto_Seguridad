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
    public class DTSesion
    {
        ConexionDB cn = new ConexionDB();

        public string Sesion_Registrar(int idAplicacion, string usuario, string ultimoPermiso, string token, string estadoSesion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_SesionRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdAplicacion", SqlDbType.Int)).Value = idAplicacion;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@UltimoPermiso", SqlDbType.Text)).Value = ultimoPermiso;
                cmd.Parameters.Add(new SqlParameter("@Token", SqlDbType.Text)).Value = token;
                cmd.Parameters.Add(new SqlParameter("@EstadoSesion", SqlDbType.Text)).Value = estadoSesion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdSesion"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }

        public List<Sesion> Sesion_Leer(int idSesion, string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_SesionLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdSesion", SqlDbType.Int)).Value = idSesion;
            cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Text)).Value = usuario;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Sesion> SesionLeer = new List<Sesion>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sesion sesion = new Sesion();
                sesion.IdSesion = Funciones.ToInt(dt.Rows[i]["IdSesion"]);
                sesion.IdAplicacion = Funciones.ToInt(dt.Rows[i]["IdAplicacion"]);
                sesion.Usuario = Funciones.ToString(dt.Rows[i]["Usuario"]);
                sesion.NombreUsuario = Funciones.ToString(dt.Rows[i]["NombreUsuario"]);
                sesion.ApellidoUsuario = Funciones.ToString(dt.Rows[i]["ApellidoUsuario"]);
                sesion.UltimoPermiso = Funciones.ToString(dt.Rows[i]["UltimoPermiso"]);
                sesion.Token = Funciones.ToString(dt.Rows[i]["Token"]);
                sesion.EstadoSesion = Funciones.ToString(dt.Rows[i]["EstadoSesion"]);
                sesion.EstadoSesionDesc = Funciones.ToString(dt.Rows[i]["EstadoSesionDesc"]);
                SesionLeer.Add(sesion);
            }
            cn.Desconectar();
            return SesionLeer;
        }

        public string Sesion_Activar(int idSesion, string estadoSesion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_SesionActivar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdSesion", SqlDbType.Int)).Value = idSesion;
                cmd.Parameters.Add(new SqlParameter("@EstadoSesion", SqlDbType.Text)).Value = estadoSesion;
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
