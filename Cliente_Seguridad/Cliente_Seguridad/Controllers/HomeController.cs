using Cliente_Seguridad.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cliente_Seguridad.Controllers
{
    public class HomeController : Controller
    {
        ServicioSeguridad.ServicioSeguridadClient servicio_Seguridad = new ServicioSeguridad.ServicioSeguridadClient();
        Util util = new Util();
        public ActionResult Index(string mensaje, string tipoNotificacion)
        {
            if (mensaje != "" && mensaje != null)
            {
                ViewBag.NotificarGrabado = mensaje;
                ViewBag.TipoNotificacion = tipoNotificacion;
            }
            else
            {
                ViewBag.NotificarGrabado = "";
                ViewBag.TipoNotificacion = "";
            }
            return View();
        }

        [HttpGet]
        public ActionResult IniciarSesion(string paginaFinal, string controllerFinal, string parametrosFinal, string mensaje, string tipoNotificacion)
        {

            ViewBag.PaginaFinal = paginaFinal;
            ViewBag.ControllerFinal = controllerFinal;
            ViewBag.ParametrosFinal = Server.UrlEncode(parametrosFinal);
            ViewBag.NotificarGrabado = mensaje;
            ViewBag.TipoNotificacion = tipoNotificacion;
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(string idUsuario, string ClaveAcceso, string paginaFinal, string controllerFinal)
        {
            if (idUsuario != "" && idUsuario != null && ClaveAcceso != "" && ClaveAcceso != null)
            {
                ServicioSeguridad.Usuario DatosUsuario = servicio_Seguridad.Usuario_Iniciar_Sesion(idUsuario, ClaveAcceso);
                if (DatosUsuario.IdUsuario != null)
                {
                    if (DatosUsuario.EstadoUsuario == Constantes.ESTADO_CUENTA_USUARIO_ACTIVO)
                    {
                        Session["Usuario"] = DatosUsuario.IdUsuario;
                        Session["NombreUsuario"] = DatosUsuario.NombreUsuario;
                        Session["ApellidoUsuario"] = DatosUsuario.ApellidoUsuario;

                        ServicioSeguridad.Grupo[] DatosGrupo = servicio_Seguridad.GrupoRolUsuario_Leer(0, "", DatosUsuario.IdUsuario);

                        foreach (ServicioSeguridad.Grupo Grupo in DatosGrupo)
                        {
                            if(Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_CREACION)
                                Session["PermisoCreacion"] = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_EJECUCION)
                                Session["PermisoEjecucion"] = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_ELIMINACION)
                                Session["PermisoEliminacion"] = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_MODIFICACION)
                                Session["PermisoModificacion"] = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_VISIBILIDAD)
                                Session["PermisoVisibilidad"] = Grupo.TipoPermiso;
                        }

                        string varPagina = paginaFinal != "" && paginaFinal != null ? paginaFinal : "Index";
                        string varController = controllerFinal != "" && controllerFinal != null ? controllerFinal : "Home";
                        var routeValues = new RouteValueDictionary();
                        return RedirectToAction(varPagina, varController, routeValues);
                    }
                    else
                    {
                        return RedirectToAction("IniciarSesion", "Home", new { mensaje = "Usuario Deshabilitado", tipoNotificacion = "warning" });
                    }
                }
                else
                {
                    return RedirectToAction("IniciarSesion", "Home", new { mensaje = "Usuario no Encontrado ", tipoNotificacion = "warning" });
                }
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Home", new { mensaje = "Ingrese Usuario y Clave", tipoNotificacion = "warning" });
            }
        }
    }
}