using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class ListaController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();
        public ActionResult Index(string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Lista[] listaLista = servicio_Seguridad.Lista_LeerTodo(0, "");
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
            return View(listaLista);
        }

        public ActionResult ListaEliminarJson(int idLista)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.Grupo_Eliminar(idLista);
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
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("ListaModificar", "Lista", new { idLista = idLista, notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaRegistrar()
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult ListaRegistrar(Cliente_Seguridad.ServicioSeguridad.Lista lista)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (lista.NombreLista != null && lista.DescripcionLista != null && lista.NombreLista != "" && lista.DescripcionLista != "")
            {
                string errorRegistrar = servicio_Seguridad.Lista_Registrar(lista.NombreLista, lista.DescripcionLista, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("ListaModificar", new { idLista = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Lista Creada Correctamente", tipoMensaje = "success" });
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: No se pudo registrar" + errorRegistrar;
                    ViewBag.TipoNotificacion = "error";
                }
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: Todos los campos con (*) son obligatorios";
                ViewBag.TipoNotificacion = "error";
            }
            return View();
        }

        [HttpGet]
        public ActionResult ListaModificar(int idLista, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Lista DatosLista = servicio_Seguridad.Lista_Leer(idLista, "");
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
            ViewBag.IdLista = DatosLista.IdLista;
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
            return View(DatosLista);
        }

        [HttpPost]
        public ActionResult ListaModificar(Cliente_Seguridad.ServicioSeguridad.Lista lista)
        {

            ServicioSeguridad.Lista DatosLista = servicio_Seguridad.Lista_Leer(lista.IdLista, "");
            if (lista.NombreLista != null && lista.DescripcionLista != null && lista.NombreLista != "" && lista.DescripcionLista != "")
            {
                string errorModificar = servicio_Seguridad.Lista_Modificar(lista.IdLista, lista.NombreLista, lista.DescripcionLista, Session["Usuario"].ToString());
                if (errorModificar == "")
                {
                    ViewBag.NotificarGrabado = "Lista Modificado Correctamente";
                    ViewBag.TipoNotificacion = "success";
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: [Servicio] No se pudo modificar" + errorModificar;
                    ViewBag.TipoNotificacion = "success";
                }
                ViewBag.IdLista = lista.IdLista;
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: Todos los campos con (*) son obligatorios";
                ViewBag.TipoNotificacion = "error";
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
            return View(DatosLista);
        }
    }
}