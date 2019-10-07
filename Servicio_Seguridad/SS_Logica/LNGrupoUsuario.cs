using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNGrupoUsuario
    {
        public static string GrupoUsuario_Registrar(int idGrupo, string usuario, string estadoGrupoUsuario, string creadoPor)
        {
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            return dtGrupoUsuario.GrupoUsuario_Registrar(idGrupo, usuario, estadoGrupoUsuario, creadoPor, DateTime.Now);
        }


        public static string GrupoUsuario_Modificar(int idGrupoUsuario, int idGrupo, string usuario, string estadoGrupoUsuario, string modificadoPor)
        {
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            return dtGrupoUsuario.GrupoUsuario_Modificar(idGrupoUsuario, idGrupo, usuario, estadoGrupoUsuario, modificadoPor, DateTime.Now);
        }

        public static GrupoUsuario GrupoUsuario_Leer(int idGrupoUsuario, int idGrupo, string usuario)
        {
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            GrupoUsuario DatosGrupoUsuario = new GrupoUsuario();
            List<GrupoUsuario> GrupoUsuarioLeer = dtGrupoUsuario.GrupoUsuario_Leer(idGrupoUsuario, idGrupo, usuario);
            foreach (GrupoUsuario grupoUsuario in GrupoUsuarioLeer)
            {
                DatosGrupoUsuario = grupoUsuario;
            }
            return DatosGrupoUsuario;
        }

        public static List<GrupoUsuario> GrupoUsuario_LeerTodo(int idGrupoUsuario, int idGrupo, string usuario)
        {
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            return dtGrupoUsuario.GrupoUsuario_Leer(idGrupoUsuario, idGrupo, usuario);
        }

        public static string GrupoUsuario_Eliminar(int idGrupoUsuario)
        {
            DTGrupoUsuario dtGrupoUsuario = new DTGrupoUsuario();
            return dtGrupoUsuario.GrupoUsuario_Eliminar(idGrupoUsuario);
        }
    }
}
