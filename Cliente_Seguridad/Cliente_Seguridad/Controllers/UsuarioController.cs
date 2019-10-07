using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class UsuarioController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();
        public ActionResult Index(string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Usuario[] UsuarioLista = servicio_Seguridad.Usuario_LeerTodo("", "");
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
            return View(UsuarioLista);
        }

        public ActionResult UsuarioEliminarJson(string usuario)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.Usuario_Eliminar(usuario);
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
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("Index", "Usuario", new { notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UsuarioRegistrar()
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            ViewBag.ListaEstadoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_USUARIO, "");
            return View();
        }

        [HttpPost]
        public ActionResult UsuarioRegistrar(Cliente_Seguridad.ServicioSeguridad.Usuario usuario)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (usuario.IdUsuario != null && usuario.NombreUsuario != null && usuario.ApellidoUsuario != null && usuario.ClaveAcceso != null && usuario.Email != null && usuario.EstadoUsuario != null &&
                usuario.IdUsuario != null && usuario.NombreUsuario != "" && usuario.ApellidoUsuario != "" && usuario.ClaveAcceso != "" && usuario.Email != "" && usuario.EstadoUsuario != "")
            {
                string errorRegistrar = servicio_Seguridad.Usuario_Registrar(usuario.IdUsuario, usuario.NombreUsuario, usuario.ApellidoUsuario, usuario.ClaveAcceso, usuario.Email, usuario.EstadoUsuario, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("UsuarioModificar", new { usuario = errorRegistrar.Substring(6), mensaje = "Usuario Creado Correctamente", tipoMensaje = "success" });
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
            ViewBag.ListaEstadoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_USUARIO, "");
            return View();
        }

        [HttpGet]
        public ActionResult UsuarioModificar(string usuario, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.Usuario DatosUsario = servicio_Seguridad.Usuario_Leer(usuario, "");
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
            ViewBag.ListaEstadoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_USUARIO, "");
            ViewBag.IdLista = DatosUsario.IdUsuario;
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
            return View(DatosUsario);
        }

        [HttpPost]
        public ActionResult UsuarioModificar(Cliente_Seguridad.ServicioSeguridad.Usuario usuario, string claveAcceso)
        {

            ServicioSeguridad.Usuario DatosUsuario = servicio_Seguridad.Usuario_Leer(usuario.IdUsuario, "");
            if (usuario.IdUsuario != null && usuario.NombreUsuario != null && usuario.ApellidoUsuario != null && claveAcceso != null  && usuario.Email != null && usuario.EstadoUsuario != null &&
                usuario.IdUsuario != null && usuario.NombreUsuario != "" && usuario.ApellidoUsuario != "" && claveAcceso != "" && usuario.Email != "" && usuario.EstadoUsuario != "")
            {
                string errorModificar = servicio_Seguridad.Usuario_Modificar(usuario.IdUsuario, usuario.NombreUsuario, usuario.ApellidoUsuario, claveAcceso, usuario.Email, usuario.EstadoUsuario, Session["Usuario"].ToString());
                if (errorModificar == "")
                {
                    ViewBag.NotificarGrabado = "Usuario Modificado Correctamente";
                    ViewBag.TipoNotificacion = "success";
                }
                else
                {
                    ViewBag.NotificarGrabado = "[ERROR]: [Servicio] No se pudo modificar" + errorModificar;
                    ViewBag.TipoNotificacion = "error";
                }
                ViewBag.idUsuario = usuario.IdUsuario;
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: Todos los campos con (*) son obligatorios";
                ViewBag.TipoNotificacion = "error";
            }
            ViewBag.ListaEstadoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_USUARIO, "");
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
            return View(DatosUsuario);
        }
    }
}