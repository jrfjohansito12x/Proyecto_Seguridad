using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SS_Logica;
using SS_Modelo;


namespace Servicio_Seguridad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSeguridad" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioSeguridad.svc o ServicioSeguridad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioSeguridad : IServicioSeguridad
    {
        Utiles util = new Utiles();
        public string GrupoRol_Eliminar(int idGrupo)
        {
            return LNGrupoRol.GrupoRol_Eliminar(idGrupo);
        }

        public GrupoRol GrupoRol_Leer(int idGrupoRol, int idGrupo, int idRol)
        {
            return LNGrupoRol.GrupoRol_Leer(idGrupoRol, idGrupo, idRol);
        }

        public List<GrupoRol> GrupoRol_LeerTodo(int idGrupoRol, int idGrupo, int idRol)
        {
            return LNGrupoRol.GrupoRol_LeerTodo(idGrupoRol, idGrupo, idRol);
        }

        public string GrupoRol_Modificar(int idGrupoRol, int idGrupo, int idRol, string estadoGrupoRol, string modificadoPor)
        {
            return LNGrupoRol.GrupoRol_Modificar(idGrupoRol, idGrupo, idRol, estadoGrupoRol, modificadoPor);
        }

        public string GrupoRol_Registrar(int idGrupo, int idRol, string estadoGrupoRol, string creadoPor)
        {
            return LNGrupoRol.GrupoRol_Registrar(idGrupo, idRol, estadoGrupoRol, creadoPor);
        }

        public string GrupoUsuario_Eliminar(int idGrupoUsuario)
        {
            return LNGrupoUsuario.GrupoUsuario_Eliminar(idGrupoUsuario);
        }

        public GrupoUsuario GrupoUsuario_Leer(int idGrupoUsuario, int idGrupo, string usuario)
        {
            return LNGrupoUsuario.GrupoUsuario_Leer(idGrupoUsuario, idGrupo, usuario);
        }

        public List<GrupoUsuario> GrupoUsuario_LeerTodo(int idGrupoUsuario, int idGrupo, string usuario)
        {
            return LNGrupoUsuario.GrupoUsuario_LeerTodo(idGrupoUsuario, idGrupo, usuario);
        }

        public string GrupoUsuario_Modificar(int idGrupoUsuario, int idGrupo, string usuario, string estadoGrupoUsuario, string modificadoPor)
        {
            return LNGrupoUsuario.GrupoUsuario_Modificar(idGrupoUsuario, idGrupo, usuario, estadoGrupoUsuario, modificadoPor);
        }

        public string GrupoUsuario_Registrar(int idGrupo, string usuario, string estadoGrupoUsuario, string creadoPor)
        {
            return LNGrupoUsuario.GrupoUsuario_Registrar(idGrupo, usuario, estadoGrupoUsuario, creadoPor);
        }

        public string Grupo_Eliminar(int idGrupo)
        {
            return LNGrupo.Grupo_Eliminar(idGrupo);
        }

        public Grupo Grupo_Leer(int idGrupo, string nombreGrupo)
        {
            return LNGrupo.Grupo_Leer(idGrupo, nombreGrupo);
        }

        public List<Grupo> Grupo_LeerTodo(int idGrupo, string nombreGrupo)
        {
            return LNGrupo.Grupo_LeerTodo(idGrupo, nombreGrupo);
        }

        public string Grupo_Modificar(int idGrupo, string nombreGrupo, string descripcion, string modificadoPor)
        {
            return LNGrupo.Grupo_Modificar(idGrupo, nombreGrupo, descripcion, modificadoPor);
        }

        public string Grupo_Registrar(string nombreGrupo, string descripcion, string creadoPor)
        {
            return LNGrupo.Grupo_Registrar(nombreGrupo, descripcion, creadoPor);
        }

        public string ListaValor_Eliminar(int idListaValor)
        {
            return LNListaValor.ListaValor_Eliminar(idListaValor);
        }

        public ListaValor ListaValor_Leer(int idListaValor, int idLista, string valor)
        {
            return LNListaValor.ListaValor_Leer(idListaValor, idLista, valor);
        }

        public List<ListaValor> ListaValor_LeerTodo(int idListaValor, int idLista, string valor)
        {
            return LNListaValor.ListaValor_LeerTodo(idListaValor, idLista, valor);
        }

        public string ListaValor_Modificar(int idListaValor, int idLista, string valor, string descripcionLista, string modificadoPor)
        {
            return LNListaValor.ListaValor_Modificar(idListaValor, idLista, valor, descripcionLista, modificadoPor);
        }

        public string ListaValor_Registrar(int idLista, string valor, string descripcionLista, string creadoPor)
        {
            return LNListaValor.ListaValor_Registrar(idLista, valor, descripcionLista, creadoPor);
        }

        public string Lista_Eliminar(int idLista)
        {
            return LNLista.Lista_Eliminar(idLista);
        }

        public Lista Lista_Leer(int idLista, string nombreLista)
        {
            return LNLista.Lista_Leer(idLista, nombreLista);
        }

        public List<Lista> Lista_LeerTodo(int idLista, string nombreLista)
        {
            return LNLista.Lista_LeerTodo(idLista, nombreLista);
        }

        public string Lista_Modificar(int idLista, string nombreLista, string descripcionLista, string modificadoPor)
        {
            return LNLista.Lista_Modificar(idLista, nombreLista, descripcionLista, modificadoPor);
        }

        public string Lista_Registrar(string nombreLista, string descripcionLista, string creadoPor)
        {
            return LNLista.Lista_Registrar(nombreLista, descripcionLista, creadoPor);
        }

        public string Rol_Eliminar(int idRol)
        {
            return LNRol.Rol_Eliminar(idRol);
        }

        public Rol Rol_Leer(int idRol, string nombreRol)
        {
            return LNRol.Rol_Leer(idRol, nombreRol);
        }

        public List<Rol> Rol_LeerTodo(int idRol, string nombreRol)
        {
            return LNRol.Rol_LeerTodo(idRol, nombreRol);
        }

        public string Rol_Modificar(int idRol, string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string modificadoPor)
        {
            return LNRol.Rol_Modificar(idRol, nombreRol, descripcionRol, estadoRol, tipoPermiso, modificadoPor);
        }

        public string Rol_Registrar(string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string creadoPor)
        {
            return LNRol.Rol_Registrar(nombreRol, descripcionRol, estadoRol, tipoPermiso, creadoPor);
        }

        public string Sesion_Activar(int idSesion, string estadoSesion)
        {
            return LNSesion.Sesion_Activar(idSesion, estadoSesion);
        }

        public Sesion Sesion_Leer(int idSesion, string usuario)
        {
            return LNSesion.Sesion_Leer(idSesion, usuario);
        }

        public List<Sesion> Sesion_LeerTodo(int idSesion, string usuario)
        {
            return LNSesion.Sesion_LeerTodo(idSesion, usuario);
        }

        public string Sesion_Registrar(int idAplicacion, string usuario, string ultimoPermiso, string token, string estadoSesion)
        {
            return LNSesion.Sesion_Registrar(idAplicacion, usuario, ultimoPermiso, token, estadoSesion);
        }

        public string Usuario_Eliminar(string usuario)
        {
            return LNUsuario.Usuario_Eliminar(usuario);
        }

        public Usuario Usuario_Leer(string usuario, string estadoUsuario)
        {
            return LNUsuario.Usuario_Leer(usuario, estadoUsuario);
        }

        public List<Usuario> Usuario_LeerTodo(string usuario, string estadoUsuario)
        {
            return LNUsuario.Usuario_LeerTodo(usuario, estadoUsuario);
        }

        public Usuario Usuario_Iniciar_Sesion(string usuario, string clave)
        {
            AppLogger.Iniciar();
            AppLogger.LogInfo("Servico Usuario_Iniciar_Sesion");
            return LNUsuario.Usuario_Iniciar_Sesion(usuario, clave);
        }

        public string Usuario_Modificar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string modificadoPor)
        {
            return LNUsuario.Usuario_Modificar(usuario, nombre, apellido, claveAcceso, email, estadoUsuario, modificadoPor);
        }

        public string Usuario_Registrar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string creadoPor)
        {
            return LNUsuario.Usuario_Registrar(usuario, nombre, apellido, claveAcceso, email, estadoUsuario, creadoPor);
        }

        public List<Grupo> GrupoRolUsuario_Leer(int idGrupo, string nombreGrupo, string usuario)
        {
            return LNGrupo.GrupoRolUsuario_Leer(idGrupo, nombreGrupo, usuario);
        }

        public string Usuario_Registrar_Grupo_MinpaoHome(string usuario, string nombre, string apellido, string claveAcceso, string email)
        {
            return LNUsuario.Usuario_Registrar_Grupo_1(usuario, nombre, apellido, claveAcceso, email);
        }

        public string Usuario_Registrar_Grupo_2(string usuario, string nombre, string apellido, string claveAcceso, string email)
        {
            return LNUsuario.Usuario_Registrar_Grupo_2(usuario, nombre, apellido, claveAcceso, email);
        }

        public DataTable Usuario_LeerTodo2()
        {

            return LNUsuario.Usuario_LeerTodoDT();
        }
    }
}
