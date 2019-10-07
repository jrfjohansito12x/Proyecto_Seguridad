using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class ListaValorController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        public PartialViewResult Index(int idLista, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.ListaValor[] listaValorLista = servicio_Seguridad.ListaValor_LeerTodo(0, idLista, "");
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
            ViewBag.IdLista = idLista;
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
            return PartialView(listaValorLista);
        }

        public ActionResult ListaValorEliminarJson(int idListaValor)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.Grupo_Eliminar(idListaValor);
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
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("ListaValorActualizar", "ListaValor", new { idListaValor = idListaValor, notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ListaValorRegistrar(int idLista)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            ViewBag.IdLista = idLista;
            return View();
        }

        [HttpPost]
        public ActionResult ListaValorRegistrar(Cliente_Seguridad.ServicioSeguridad.ListaValor listaValor, int idLista)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (ModelState.IsValid)
            {
                string errorRegistrar = servicio_Seguridad.ListaValor_Registrar(idLista, listaValor.Valor, listaValor.Descripcion, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("ListaValorModificar", "ListaValor", new { idListaValor = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Lista Creada Correctamente", tipoMensaje = "success" });
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
        public ActionResult ListaValorModificar(int idListaValor, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.ListaValor DatosListaValor = servicio_Seguridad.ListaValor_Leer(idListaValor, 0, "");
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
            ViewBag.IdLista = DatosListaValor.IdLista;
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
            return View(DatosListaValor);
        }

        [HttpPost]
        public ActionResult ListaValorModificar(Cliente_Seguridad.ServicioSeguridad.ListaValor listaValor)
        {

            ServicioSeguridad.ListaValor DatosListaValor = servicio_Seguridad.ListaValor_Leer(listaValor.IdListaValor, 0, "");
            if (ModelState.IsValid)
            {
                string errorModificar = servicio_Seguridad.ListaValor_Modificar(listaValor.IdListaValor, listaValor.IdLista, listaValor.Valor, listaValor.Descripcion, Session["Usuario"].ToString());
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
                ViewBag.IdLista = listaValor.IdListaValor;
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
            return View(DatosListaValor);
        }
    }
}