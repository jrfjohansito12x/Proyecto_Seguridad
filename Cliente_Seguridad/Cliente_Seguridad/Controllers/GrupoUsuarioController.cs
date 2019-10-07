using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cliente_Seguridad.Controllers
{
    public class GrupoUsuarioController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();
        public PartialViewResult Index(string usuario, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.GrupoUsuario[] grupoUsuarioLista = servicio_Seguridad.GrupoUsuario_LeerTodo(0, 0, usuario);
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
            return PartialView(grupoUsuarioLista);
        }


        public ActionResult GrupoUsuarioEliminarJson(int idGrupoUsuario, string usuario)
        {
            string mensajeError = string.Empty;
            bool blnSuccess = false;
            //if (ViewBag.PermisoEliminar.ToString().Substring(0, 3) == Constantes.PERMISO_OTORGADO)
            //{
            mensajeError = servicio_Seguridad.GrupoUsuario_Eliminar(idGrupoUsuario);
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
            return Json(new { success = blnSuccess, message = mensajeError, redirectUrl = Url.Action("UsuarioModificar", "Usuario", new { usuario = usuario, notificaGrabado = "", tipoNotificacion = "" }) }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GrupoUsuarioRegistrar(string usuario)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            ViewBag.Usuario = usuario;
            ViewBag.ListaGrupos = util.DropDownGrupoListar(0, "");
            ViewBag.ListaEstadoGrupoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_USUARIO, "");
            return View();
        }

        [HttpPost]
        public ActionResult GrupoUsuarioRegistrar(Cliente_Seguridad.ServicioSeguridad.GrupoUsuario grupoUsuario, string idUsuario)
        {
            ViewBag.NotificarGrabado = string.Empty;
            ViewBag.TipoNotificacion = string.Empty;
            if (ModelState.IsValid)
            {
                string errorRegistrar = servicio_Seguridad.GrupoUsuario_Registrar(grupoUsuario.IdGrupo, idUsuario, grupoUsuario.EstadoGrupoUsuario, Session["Usuario"].ToString());
                if (errorRegistrar.Substring(0, 6) == "[CREO]")
                {
                    return RedirectToAction("GrupoUsuarioModificar", "GrupoUsuario", new { idGrupoUsuario = Convert.ToInt32(errorRegistrar.Substring(6)), mensaje = "Grupo Usuario Creada Correctamente", tipoMensaje = "success" });
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
            ViewBag.ListaGrupos = util.DropDownGrupoListar(0, "");
            ViewBag.ListaEstadoGrupoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_USUARIO, "");
            return View();
        }

        [HttpGet]
        public ActionResult GrupoUsuarioModificar(int idGrupoUsuario, string mensaje, string tipoMensaje)
        {
            ServicioSeguridad.GrupoUsuario DatosGrupoUsuario = servicio_Seguridad.GrupoUsuario_Leer(idGrupoUsuario, 0, "");
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
            ViewBag.IdGrupoUsuario = DatosGrupoUsuario.IdGrupoUsuario;
            ViewBag.ListaGrupos = util.DropDownGrupoListar(0, "");
            ViewBag.ListaEstadoGrupoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_USUARIO, "");

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
            return View(DatosGrupoUsuario);
        }

        [HttpPost]
        public ActionResult GrupoUsuarioModificar(Cliente_Seguridad.ServicioSeguridad.GrupoUsuario grupoUsuario)
        {

            ServicioSeguridad.GrupoUsuario DatosGrupoUsuario = servicio_Seguridad.GrupoUsuario_Leer(grupoUsuario.IdGrupoUsuario, 0, "");
            if (ModelState.IsValid)
            {
                string errorModificar = servicio_Seguridad.GrupoUsuario_Modificar(grupoUsuario.IdGrupoUsuario, grupoUsuario.IdGrupo, grupoUsuario.Usuario, grupoUsuario.EstadoGrupoUsuario, Session["Usuario"].ToString());
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
                ViewBag.IdGrupoUsuario = DatosGrupoUsuario.IdGrupoUsuario;
            }
            else
            {
                ViewBag.NotificarGrabado = "[ERROR]: No se pudo modificar";
                ViewBag.TipoNotificacion = "success";
            }
            ViewBag.ListaGrupos = util.DropDownGrupoListar(0, "");
            ViewBag.ListaEstadoGrupoUsuario = util.DropDownListaValorListar(0, Constantes.LISTA_VALOR_ESTADO_GRUPO_USUARIO, "");

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
            return View(DatosGrupoUsuario);
        }
    }
}