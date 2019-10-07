using SS_Datos;
using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Logica
{
    public class LNListaValor
    {
        public static string ListaValor_Registrar(int idLista, string valor, string descripcionLista, string creadoPor)
        {
            DTListaValor dtListaValor = new DTListaValor();
            return dtListaValor.ListaValor_Registrar(idLista, valor, descripcionLista, creadoPor, DateTime.Now);
        }


        public static string ListaValor_Modificar(int idListaValor, int idLista, string valor, string descripcionLista, string modificadoPor)
        {
            DTListaValor dtListaValor = new DTListaValor();
            return dtListaValor.ListaValor_Modificar(idListaValor, idLista, valor, descripcionLista, modificadoPor, DateTime.Now);
        }
        public static ListaValor ListaValor_Leer(int idListaValor, int idLista, string valor)
        {
            DTListaValor dtListaValor = new DTListaValor();
            ListaValor DatosListaValor = new ListaValor();
            List<ListaValor> ListaValorLeer = dtListaValor.ListaValor_Leer(idListaValor, idLista, valor);
            foreach (ListaValor listaValor in ListaValorLeer)
            {
                DatosListaValor = listaValor;
            }
            return DatosListaValor;
        }
        public static List<ListaValor> ListaValor_LeerTodo(int idListaValor, int idLista, string valor)
        {
            DTListaValor dtListaValor = new DTListaValor();
            return dtListaValor.ListaValor_Leer(idListaValor, idLista, valor);
        }

        public static string ListaValor_Eliminar(int idListaValor)
        {
            DTListaValor dtListaValor = new DTListaValor();
            return dtListaValor.ListaValor_Eliminar(idListaValor);
        }
    }
}
