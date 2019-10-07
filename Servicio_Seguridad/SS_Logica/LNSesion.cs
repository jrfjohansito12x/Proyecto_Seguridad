using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNSesion
    {
        public static string Sesion_Registrar(int idAplicacion, string usuario, string ultimoPermiso, string token, string estadoSesion)
        {
            DTSesion dtSesion = new DTSesion();
            return dtSesion.Sesion_Registrar(idAplicacion, usuario, ultimoPermiso, token, estadoSesion);
        }

        public static Sesion Sesion_Leer(int idSesion, string usuario)
        {
            DTSesion dtSesion = new DTSesion();
            Sesion DatosSesion = new Sesion();
            List<Sesion> SesionLeer = dtSesion.Sesion_Leer(idSesion, usuario);
            foreach (Sesion sesion in SesionLeer)
            {
                DatosSesion = sesion;
            }
            return DatosSesion;
        }

        public static List<Sesion> Sesion_LeerTodo(int idSesion, string usuario)
        {
            DTSesion dtSesion = new DTSesion();
            return dtSesion.Sesion_Leer(idSesion, usuario);
        }

        public static string Sesion_Activar(int idSesion, string estadoSesion)
        {
            DTSesion dtSesion = new DTSesion();
            return dtSesion.Sesion_Activar(idSesion, estadoSesion);
        }
    }
}
