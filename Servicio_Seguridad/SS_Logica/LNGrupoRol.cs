using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNGrupoRol
    {
        public static string GrupoRol_Registrar(int idGrupo, int idRol, string estadoGrupoRol, string creadoPor)
        {
            DTGrupoRol dtGrupoRol = new DTGrupoRol();
            return dtGrupoRol.GrupoRol_Registrar(idGrupo, idRol, estadoGrupoRol, creadoPor, DateTime.Now);
        }


        public static string GrupoRol_Modificar(int idGrupoRol, int idGrupo, int idRol, string estadoGrupoRol, string modificadoPor)
        {
            DTGrupoRol dtGrupoRol = new DTGrupoRol();
            return dtGrupoRol.GrupoRol_Modificar(idGrupoRol, idGrupo, idRol, estadoGrupoRol, modificadoPor, DateTime.Now); ;
        }

        public static GrupoRol GrupoRol_Leer(int idGrupoRol, int idGrupo, int idRol)
        {
            DTGrupoRol dtGrupoRol = new DTGrupoRol();
            GrupoRol DatosGrupoRol = new GrupoRol();
            List<GrupoRol> GrupoRolLeer = dtGrupoRol.GrupoRol_Leer(idGrupoRol, idGrupo, idRol);
            foreach (GrupoRol grupoRol in GrupoRolLeer)
            {
                DatosGrupoRol = grupoRol;
            }
            return DatosGrupoRol;
        }

        public static List<GrupoRol> GrupoRol_LeerTodo(int idGrupoRol, int idGrupo, int idRol)
        {
            DTGrupoRol dtGrupoRol = new DTGrupoRol();
            return dtGrupoRol.GrupoRol_Leer(idGrupoRol, idGrupo, idRol);
        }

        public static string GrupoRol_Eliminar(int idGrupo)
        {
            DTGrupoRol dtGrupoRol = new DTGrupoRol();
            return dtGrupoRol.GrupoRol_Eliminar(idGrupo);
        }
    }
}
