using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNGrupo
    {
        public static string Grupo_Registrar(string nombreGrupo, string descripcion, string creadoPor)
        {
            DTGrupo dtGrupo = new DTGrupo();
            return dtGrupo.Grupo_Registrar(nombreGrupo, descripcion, creadoPor, DateTime.Now);
        }

        public static string Grupo_Modificar(int idGrupo, string nombreGrupo, string descripcion, string modificadoPor)
        {
            DTGrupo dtGrupo = new DTGrupo();
            return dtGrupo.Grupo_Modificar(idGrupo, nombreGrupo, descripcion, modificadoPor, DateTime.Now);
        }

        public static Grupo Grupo_Leer(int idGrupo, string nombreGrupo)
        {
            DTGrupo dtGrupo = new DTGrupo();
            Grupo DatosGrupo = new Grupo();
            List<Grupo> GrupoLeer = dtGrupo.Grupo_Leer(idGrupo, nombreGrupo);
            foreach (Grupo grupo in GrupoLeer)
            {
                DatosGrupo = grupo;
            }
            return DatosGrupo;
        }

        public static List<Grupo> Grupo_LeerTodo(int idGrupo, string nombreGrupo)
        {
            DTGrupo dtGrupo = new DTGrupo();
            return dtGrupo.Grupo_Leer(idGrupo, nombreGrupo);
        }

        public static string Grupo_Eliminar(int idGrupo)
        {
            DTGrupo dtGrupo = new DTGrupo();
            return dtGrupo.Grupo_Eliminar(idGrupo);
        }

        public static List<Grupo> GrupoRolUsuario_Leer(int idGrupo, string nombreGrupo, string usuario)
        {
            DTGrupo dtGrupo = new DTGrupo();
            return dtGrupo.GrupoRolUsuario_Leer(idGrupo, nombreGrupo, usuario);
        }
    }
}
