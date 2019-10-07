using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNRol
    {
        public static string Rol_Registrar(string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string creadoPor)
        {
            DTRol dtRol = new DTRol();
            return dtRol.Rol_Registrar(nombreRol, descripcionRol, estadoRol, tipoPermiso, creadoPor, DateTime.Now);
        }


        public static string Rol_Modificar(int idRol, string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string modificadoPor)
        {
            DTRol dtRol = new DTRol();
            return dtRol.Rol_Modificar(idRol, nombreRol, descripcionRol, estadoRol, tipoPermiso, modificadoPor, DateTime.Now);
        }

        public static Rol Rol_Leer(int idRol, string nombreRol)
        {
            DTRol dtRol = new DTRol();
            Rol DatosRol = new Rol();
            List<Rol> RolLeer = dtRol.Rol_Leer(idRol, nombreRol);
            foreach (Rol rol in RolLeer)
            {
                DatosRol = rol;
            }
            return DatosRol;
        }

        public static List<Rol> Rol_LeerTodo(int idRol, string nombreRol)
        {
            DTRol dtRol = new DTRol();
            return dtRol.Rol_Leer(idRol, nombreRol);
        }

        public static string Rol_Eliminar(int idRol)
        {
            DTRol dtRol = new DTRol();
            return dtRol.Rol_Eliminar(idRol);
        }
    }
}
