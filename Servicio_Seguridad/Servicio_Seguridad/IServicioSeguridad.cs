using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicio_Seguridad
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioSeguridad" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSeguridad
    {
        /*Servicio Grupo*/

        [OperationContract]
        string Grupo_Registrar(string nombreGrupo, string descripcion, string creadoPor);

        [OperationContract]
        string Grupo_Modificar(int idGrupo, string nombreGrupo, string descripcion, string modificadoPor);

        [OperationContract]
        Grupo Grupo_Leer(int idGrupo, string nombreGrupo);

        [OperationContract]
        List<Grupo> Grupo_LeerTodo(int idGrupo, string nombreGrupo);

        [OperationContract]
        string Grupo_Eliminar(int idGrupo);

        [OperationContract]
        List<Grupo> GrupoRolUsuario_Leer(int idGrupo, string nombreGrupo, string usuario);



        /*Servicio Grupo Rol*/
        [OperationContract]
        string GrupoRol_Registrar(int idGrupo, int idRol, string estadoGrupoRol, string creadoPor);

        [OperationContract]
        string GrupoRol_Modificar(int idGrupoRol, int idGrupo, int idRol, string estadoGrupoRol, string modificadoPor);

        [OperationContract]
        GrupoRol GrupoRol_Leer(int idGrupoRol, int idGrupo, int idRol);

        [OperationContract]
        List<GrupoRol> GrupoRol_LeerTodo(int idGrupoRol, int idGrupo, int idRol);

        [OperationContract]
        string GrupoRol_Eliminar(int idGrupo);



        /*Servicio Grupo Usuario*/
        [OperationContract]
        string GrupoUsuario_Registrar(int idGrupo, string usuario, string estadoGrupoUsuario, string creadoPor);

        [OperationContract]
        string GrupoUsuario_Modificar(int idGrupoUsuario, int idGrupo, string usuario, string estadoGrupoUsuario, string modificadoPor);

        [OperationContract]
        GrupoUsuario GrupoUsuario_Leer(int idGrupoUsuario, int idGrupo, string usuario);

        [OperationContract]
        List<GrupoUsuario> GrupoUsuario_LeerTodo(int idGrupoUsuario, int idGrupo, string usuario);

        [OperationContract]
        string GrupoUsuario_Eliminar(int idGrupoUsuario);



        /*Servicio Lista*/
        [OperationContract]
        string Lista_Registrar(string nombreLista, string descripcionLista, string creadoPor);

        [OperationContract]
        string Lista_Modificar(int idLista, string nombreLista, string descripcionLista, string modificadoPor);

        [OperationContract]
        Lista Lista_Leer(int idLista, string nombreLista);

        [OperationContract]
        List<Lista> Lista_LeerTodo(int idLista, string nombreLista);

        [OperationContract]
        string Lista_Eliminar(int idLista);


        /*Servicio Lista Valor*/
        [OperationContract]
        string ListaValor_Registrar(int idLista, string valor, string descripcionLista, string creadoPor);

        [OperationContract]
        string ListaValor_Modificar(int idListaValor, int idLista, string valor, string descripcionLista, string modificadoPor);

        [OperationContract]
        ListaValor ListaValor_Leer(int idListaValor, int idLista, string valor);

        [OperationContract]
        List<ListaValor> ListaValor_LeerTodo(int idListaValor, int idLista, string valor);

        [OperationContract]
        string ListaValor_Eliminar(int idListaValor);


        /*Servicio Rol*/
        [OperationContract]
        string Rol_Registrar(string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string creadoPor);

        [OperationContract]
        string Rol_Modificar(int idRol, string nombreRol, string descripcionRol, string estadoRol, string tipoPermiso, string modificadoPor);

        [OperationContract]
        Rol Rol_Leer(int idRol, string nombreRol);

        [OperationContract]
        List<Rol> Rol_LeerTodo(int idRol, string nombreRol);

        [OperationContract]
        string Rol_Eliminar(int idRol);


        /*Servicio Sesion*/
        [OperationContract]
        string Sesion_Registrar(int idAplicacion, string usuario, string ultimoPermiso, string token, string estadoSesion);

        [OperationContract]
        Sesion Sesion_Leer(int idSesion, string usuario);

        [OperationContract]
        List<Sesion> Sesion_LeerTodo(int idSesion, string usuario);

        [OperationContract]
        string Sesion_Activar(int idSesion, string estadoSesion);


        /*Servicio Usuario*/
        [OperationContract]
        string Usuario_Registrar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string creadoPor);

        [OperationContract]
        string Usuario_Modificar(string usuario, string nombre, string apellido, string claveAcceso, string email, string estadoUsuario, string modificadoPor);

        [OperationContract]
        Usuario Usuario_Leer(string usuario, string estadoUsuario);

        [OperationContract]
        List<Usuario> Usuario_LeerTodo(string usuario, string estadoUsuario);
        [OperationContract]
        DataTable Usuario_LeerTodo2();

        [OperationContract]
        Usuario Usuario_Iniciar_Sesion(string usuario, string clave);

        [OperationContract]
        string Usuario_Eliminar(string usuario);

        [OperationContract]
        string Usuario_Registrar_Grupo_MinpaoHome(string usuario, string nombre, string apellido, string claveAcceso, string email);

        [OperationContract]
        string Usuario_Registrar_Grupo_2(string usuario, string nombre, string apellido, string claveAcceso, string email);

    }

}
