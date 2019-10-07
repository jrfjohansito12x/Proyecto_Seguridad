using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class GruposController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        public ActionResult Index(string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Grupo[] gruposListar = servicio_Seguridad.Grupo_LeerTodo(0, "");
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
            return View(gruposListar);
        }

        public ActionResult GrupoEliminarJson(int idGrupo)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.Grupo_Eliminar(idGrupo);
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
        public ActionResult GruposCrear()
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            return View();
        }


        [HttpPost]
        public ActionResult GruposCrear(ServicioSeguridad.Grupo grupo)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (grupo.NombreGrupo != null && grupo.NombreGrupo != "")
            {
                string errorRegistrar = servicio_Seguridad.Grupo_Registrar(grupo.NombreGrupo, grupo.DescripcionGrupo, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("GruposModificar", new { idGrupo = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Grupo Creada Correctamente", tipoMensaje = "success" });
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: No se pudo registrar" + errorRegistrar;
                    ViewBag.TipoNotificacion = "error";
                }
            }
            else
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult GruposModificar(int idGrupo, string mensaje, string tipoMensaje)
        {

            ServicioSeguridad.Grupo DatosGrupo = servicio_Seguridad.Grupo_Leer(idGrupo, "");
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

            return View(DatosGrupo);
        }
        [HttpPost]
        public ActionResult GruposModificar(ServicioSeguridad.Grupo grupo)
        {
            ServicioSeguridad.Grupo DatosGrupo = servicio_Seguridad.Grupo_Leer(grupo.IdGrupo, "");

            if (ModelState.IsValid)
            {
                string errorModificar = servicio_Seguridad.Grupo_Modificar(grupo.IdGrupo, grupo.NombreGrupo, grupo.DescripcionGrupo, Session["Usuario"].ToString());
                if (errorModificar == "")
                {
                    ViewBag.NotificarGrabado = "Grupo Modificado Correctamente";
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
                ViewBag.NotificarGrabado = "[ERROR]: No se pudo modificar";
                ViewBag.TipoNotificacion = "success";
            }
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
            return View(DatosGrupo);
        }

    }
}