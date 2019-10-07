using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class GrupoRolController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();
        public PartialViewResult Index(int idGrupo, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.GrupoRol[] grupoRolLista = servicio_Seguridad.GrupoRol_LeerTodo(0, idGrupo, 0);
            if (mensaje != "" && mensaje != null && tipoMensaje != "" && tipoMensaje != null)
            {
                ViewBag.NotificarGrabado = mensaje;
                ViewBag.TipoNotificacion = tipoMensaje;
            }
            else
            {
                ViewBag.NotificarGrabado = string.Empty;
                ViewBag.TipoNotificacion = string.Empty;
            }
            if (Session["PermisoCreacion"] != null && Session["PermisoEliminacion"] != null /*|| Session["PermisoEjecucion"] != null || Session["PermisoEliminacion"] != null || Session["PermisoModificacion"] != null || Session["PermisoVisibilidad"] != null*/)
            {
                ViewBag.PermisoCreacion = Session["PermisoCreacion"].ToString();
                ViewBag.PermisoEliminacion = Session["PermisoEliminacion"].ToString();
            }
            else
            {
                ViewBag.PermisoCreacion = "";
                ViewBag.PermisoEliminacion = "";
            }
            ViewBag.IdGrupo = idGrupo;
            return PartialView(grupoRolLista);
        }

        public ActionResult GrupoRolEliminarJson(int idGrupoRol, int idGrupo)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.GrupoRol_Eliminar(idGrupoRol);
            if (mensajeError == string.Empty)
            {
                blnSuccess = true;
            }
            else
            {
                blnSuccess = false;
                mensajeError = "ERROR al Eliminar Valor: " + mensajeError;
            }
            //}
            //else
            //{
            //    blnSuccess = false;
            //    mensajeError = "Error UB.Safe: " + util.MensajeError(ViewBag.PermisoEliminar.ToString().Substring(0, 3));
            //}
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("GruposModificar", "Grupos", new { idGrupo = idGrupo, notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GrupoRolCrear(int idGrupo)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            ViewBag.ListaRol = util.DropDownRolListar(0, "");
            ViewBag.ListaEstadoGrupoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_ROL, "");
            ViewBag.IdGrupo = idGrupo;
            return View();
        }


        [HttpPost]
        public ActionResult GrupoRolCrear(ServicioSeguridad.GrupoRol grupoRol, int idGrupo)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (idGrupo != 0 && grupoRol.IdRol != 0 && grupoRol.EstadoGrupoRol != null)
            {
                string errorRegistrar = servicio_Seguridad.GrupoRol_Registrar(idGrupo, grupoRol.IdRol, grupoRol.EstadoGrupoRol, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("GrupoRolModificar", new { idGrupoRol = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Grupo Creada Correctamente", tipoMensaje = "success" });
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: No se pudo registrar" + errorRegistrar;
                    ViewBag.TipoNotificacion = "error";
                }
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: Ingrese todos los campos con (*)";
                ViewBag.TipoNotificacion = "error";
            }
            ViewBag.ListaRol = util.DropDownRolListar(0, "");
            ViewBag.ListaEstadoGrupoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_ROL, "");
            return View();
        }

        [HttpGet]
        public ActionResult GrupoRolModificar(int idGrupoRol, string mensaje, string tipoMensaje)
        {

            ServicioSeguridad.GrupoRol DatosGrupoRol = servicio_Seguridad.GrupoRol_Leer(idGrupoRol, 0, 0);
            if (mensaje != "" && mensaje != null)
            {
                ViewBag.NotificarGrabado = mensaje;
                ViewBag.TipoNotificacion = tipoMensaje;
            }
            else
            {
                ViewBag.NotificarGrabado = string.Empty;
                ViewBag.TipoNotificacion = string.Empty;
            }
            ViewBag.ListaRol = util.DropDownRolListar(0, "");
            ViewBag.ListaEstadoGrupoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_ROL, "");
            if (Session["PermisoCreacion"] != null && Session["PermisoEliminacion"] != null && Session["PermisoModificacion"] != null/*|| Session["PermisoEjecucion"] != null || Session["PermisoEliminacion"] != null || Session["PermisoModificacion"] != null || Session["PermisoVisibilidad"] != null*/)
            {
                ViewBag.PermisoCreacion = Session["PermisoCreacion"].ToString();
                ViewBag.PermisoEliminacion = Session["PermisoEliminacion"].ToString();
                ViewBag.PermisoModificacion = Session["PermisoModificacion"].ToString();
            }
            else
            {
                ViewBag.PermisoCreacion = "";
                ViewBag.PermisoEliminacion = "";
                ViewBag.PermisoModificacion = "";
            }
            return View(DatosGrupoRol);
        }
        [HttpPost]
        public ActionResult GrupoRolModificar(ServicioSeguridad.GrupoRol grupoRol)
        {
            ServicioSeguridad.GrupoRol DatosGrupoRol = servicio_Seguridad.GrupoRol_Leer(grupoRol.IdGrupoRol, 0, 0);

            if (grupoRol.IdGrupoRol != 0 && grupoRol.IdGrupo != 0 && grupoRol.IdRol != 0 && grupoRol.EstadoGrupoRol != null)
            {
                string errorModificar = servicio_Seguridad.GrupoRol_Modificar(grupoRol.IdGrupoRol, grupoRol.IdGrupo, grupoRol.IdRol, grupoRol.EstadoGrupoRol, Session["Usuario"].ToString());
                if (errorModificar == "")
                {
                    ViewBag.NotificarGrabado = "Grupo Rol Modificado Correctamente";
                    ViewBag.TipoNotificacion = "success";
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: [Servicio] No se pudo modificar" + errorModificar;
                    ViewBag.TipoNotificacion = "success";
                }
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: Ingrese todos los campos con (*)";
                ViewBag.TipoNotificacion = "error";
            }
            ViewBag.ListaRol = util.DropDownRolListar(0, "");
            ViewBag.ListaEstadoGrupoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_ROL, "");
            if (Session["PermisoCreacion"] != null && Session["PermisoEliminacion"] != null && Session["PermisoModificacion"] != null/*|| Session["PermisoEjecucion"] != null || Session["PermisoEliminacion"] != null || Session["PermisoModificacion"] != null || Session["PermisoVisibilidad"] != null*/)
            {
                ViewBag.PermisoCreacion = Session["PermisoCreacion"].ToString();
                ViewBag.PermisoEliminacion = Session["PermisoEliminacion"].ToString();
                ViewBag.PermisoModificacion = Session["PermisoModificacion"].ToString();
            }
            else
            {
                ViewBag.PermisoCreacion = "";
                ViewBag.PermisoEliminacion = "";
                ViewBag.PermisoModificacion = "";
            }
            return View(DatosGrupoRol);
        }
    }
}