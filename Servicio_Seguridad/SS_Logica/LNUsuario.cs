using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNUsuario
    {
        public static string Usuario_Registrar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string creadoPor)
        {
            DTUsuario dtUsuario = new DTUsuario();
            return dtUsuario.Usuario_Registrar(usuario, nombre, apellido, claveAcceso, email, estadoUsuario, creadoPor, DateTime.Now);
        }


        public static string Usuario_Modificar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string modificadoPor)
        {
            DTUsuario dtUsuario = new DTUsuario();
            return dtUsuario.Usuario_Modificar(usuario, nombre, apellido, claveAcceso, email, estadoUsuario, modificadoPor, DateTime.Now);
        }

        public static Usuario Usuario_Leer(string usuario, string estadoUsuario)
        {
            DTUsuario dtUsuario = new DTUsuario();
            Usuario DatosUsuario = new Usuario();
            List<Usuario> UsuarioLeer = dtUsuario.Usuario_Leer(usuario, estadoUsuario);
            foreach (Usuario usuarios in UsuarioLeer)
            {
                DatosUsuario = usuarios;
            }
            return DatosUsuario;
        }

        public static List<Usuario> Usuario_LeerTodo(string usuario, string estadoUsuario)
        {
            DTUsuario dtUsuario = new DTUsuario();
            return dtUsuario.Usuario_Leer(usuario, estadoUsuario);
        }

        public static DataTable Usuario_LeerTodoDT()
        {
            DTUsuario dtUsuario = new DTUsuario();
            return dtUsuario.Usuario_LeerDT();
        }


        public static Usuario Usuario_Iniciar_Sesion(string usuario, string clave)
        {
            AppLogger.LogInfo("Servico Usuario_Iniciar_Sesion Logica");
            DTUsuario dtUsuario = new DTUsuario();
            Usuario DatosUsuario = new Usuario();
            List<Usuario> UsuarioLeer = dtUsuario.Usuario_Iniciar_Sesion(usuario, clave);
            foreach (Usuario usuarios in UsuarioLeer)
            {
                DatosUsuario = usuarios;
            }
            return DatosUsuario;
        }

        public static string Usuario_Eliminar(string usuario)
        {
            DTUsuario dtUsuario = new DTUsuario();
            return dtUsuario.Usuario_Eliminar(usuario);
        }


        public static string Usuario_Registrar_Grupo_1(string usuario, string nombre, string apellido, string claveAcceso, string email)
        {
            DTUsuario dtUsuario = new DTUsuario();
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            string errorRegistrar = dtUsuario.Usuario_Registrar(usuario, nombre, apellido, claveAcceso, email, "ESUSAC", "MinpaoHome", DateTime.Now);
            if (errorRegistrar.Substring(0, 6) == "[CREO]")
            {
                dtGrupoUsuario.GrupoUsuario_Registrar(2, usuario, "ESGUAC", "MinpaoHome", DateTime.Now);
                return "Usuario Creado Correctamente";
            }
            else
            {
                return errorRegistrar;
            }
        }

        public static string Usuario_Registrar_Grupo_2(string usuario, string nombre, string apellido, string claveAcceso, string email)
        {
            DTUsuario dtUsuario = new DTUsuario();
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            string errorRegistrar = dtUsuario.Usuario_Registrar(usuario, nombre, apellido, claveAcceso, email, "ESUSAC", "Grupo2", DateTime.Now);
            if (errorRegistrar.Substring(0, 6) == "[CREO]")
            {
                dtGrupoUsuario.GrupoUsuario_Registrar(2, usuario, "ESGUAC", "Grupo2", DateTime.Now);
                return "Usuario Creado Correctamente";
            }
            else
            {
                return errorRegistrar;
            }
        }
    }
}
