using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNLista
    {
        public static string Lista_Registrar(string nombreLista, string descripcionLista, string creadoPor)
        {
            DTLista dtLista = new DTLista();
            return dtLista.Lista_Registrar(nombreLista, descripcionLista, creadoPor, DateTime.Now);
        }


        public static string Lista_Modificar(int idLista, string nombreLista, string descripcionLista, string modificadoPor)
        {
            DTLista dtLista = new DTLista();
            return dtLista.Lista_Modificar(idLista, nombreLista, descripcionLista, modificadoPor, DateTime.Now);
        }
        public static Lista Lista_Leer(int idLista, string nombreLista)
        {
            DTLista dtLista = new DTLista();
            Lista DatosLista = new Lista();
            List<Lista> ListaLeer = dtLista.Lista_Leer(idLista, nombreLista);
            foreach (Lista lista in ListaLeer)
            {
                DatosLista = lista;
            }
            return DatosLista;
        }

        public static List<Lista> Lista_LeerTodo(int idLista, string nombreLista)
        {
            DTLista dtLista = new DTLista();
            return dtLista.Lista_Leer(idLista, nombreLista);
        }

        public static string Lista_Eliminar(int idLista)
        {
            DTLista dtLista = new DTLista();
            return dtLista.Lista_Eliminar(idLista);
        }
    }
}
