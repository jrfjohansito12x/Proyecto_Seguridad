using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class RolesController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();

        public ActionResult Index(string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Rol[] listaRol = servicio_Seguridad.Rol_LeerTodo(0, "");
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
            return View(listaRol);
        }

        public ActionResult RolEliminarJson(int idRol)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.Rol_Eliminar(idRol);
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
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("RolesModificar", "Roles", new { idRol = idRol, notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RolesCrear()
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            ViewBag.ListaEstadoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ROL_ESTADO, "");
            ViewBag.TipoPermiso = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_TIPO_ROL_PERMISO, "");
            return View();
        }


        [HttpPost]
        public ActionResult RolesCrear(ServicioSeguridad.Rol rol)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (ModelState.IsValid)
            {
                string errorRegistrar = servicio_Seguridad.Rol_Registrar(rol.NombreRol, rol.DescripcionRol, rol.EstadoRol, rol.TipoPermiso, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("RolesModificar", new { idRol = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Rol Creada Correctamente", tipoMensaje = "success" });
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
            ViewBag.ListaEstadoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ROL_ESTADO, "");
            ViewBag.TipoPermiso = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_TIPO_ROL_PERMISO, "");
            return View();
        }

        [HttpGet]
        public ActionResult RolesModificar(int idRol, string mensaje, string tipoMensaje)
        {
            ViewBag.ListaEstadoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ROL_ESTADO, "");
            ViewBag.TipoPermisos = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_TIPO_ROL_PERMISO, "");
            ServicioSeguridad.Rol DatosRol = servicio_Seguridad.Rol_Leer(idRol, "");
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

            return View(DatosRol);
        }
        [HttpPost]
        public ActionResult RolesModificar(ServicioSeguridad.Rol rol)
        {
            ViewBag.ListaEstadoRol = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ROL_ESTADO, "");
            ViewBag.TipoPermiso = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_TIPO_ROL_PERMISO, "");
            ServicioSeguridad.Rol Datosrol = servicio_Seguridad.Rol_Leer(rol.IdRol, "");

            if (ModelState.IsValid)
            {
                string errorModificar = servicio_Seguridad.Rol_Modificar(rol.IdRol, rol.NombreRol, rol.DescripcionRol, rol.EstadoRol, rol.TipoPermiso, Session["Usuario"].ToString());
                if (errorModificar == "")
                {
                    ViewBag.NotificarGrabado = "Rol Modificado Correctamente";
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
            return View(Datosrol);
        }

    }
}