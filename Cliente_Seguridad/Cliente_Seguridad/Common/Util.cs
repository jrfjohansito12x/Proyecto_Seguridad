using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Common
{
    public class Util
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();

        public List<SelectListItem> DropDownListaValorListar(int idListaValor, int idLista, string valor)
        {
            ServicioSeguridad.ListaValor[] ListaValorLeer = servicio_Seguridad.ListaValor_LeerTodo(idListaValor, idLista, valor);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();
            foreach (ServicioSeguridad.ListaValor ListaValor in ListaValorLeer)
            {
                SelectListItem item = new SelectListItem();
                item.Text = ListaValor.Descripcion.ToString();
                item.Value = ListaValor.Valor.ToString();
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }

        public List<SelectListItem> DropDownRolListar(int idRol, string nombreRol)
        {
            ServicioSeguridad.Rol[] RolLeer = servicio_Seguridad.Rol_LeerTodo(idRol,nombreRol);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();
            foreach (ServicioSeguridad.Rol Rol in RolLeer)
            {
                SelectListItem item = new SelectListItem();
                item.Text = Rol.NombreRol.ToString();
                item.Value = Rol.IdRol.ToString();
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }

        public List<SelectListItem> DropDownGrupoListar(int idGrupo, string nombreGrupo)
        {
            ServicioSeguridad.Grupo[] GrupoLeer = servicio_Seguridad.Grupo_LeerTodo(idGrupo, nombreGrupo);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();
            foreach (ServicioSeguridad.Grupo Grupo in GrupoLeer)
            {
                SelectListItem item = new SelectListItem();
                item.Text = Grupo.NombreGrupo.ToString();
                item.Value = Grupo.IdGrupo.ToString();
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }
    }
}