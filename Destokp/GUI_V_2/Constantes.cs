using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_V_2
{
    public  class Constantes
    {
        #region ID Listas
        public static int LISTA_VALOR_ROL_ESTADO = 1;
        public static int LISTA_VALOR_TIPO_ROL_PERMISO = 2;
        public static int LISTA_VALOR_ESTADO_GRUPO_USUARIO = 3;
        public static int LISTA_VALOR_ESTADO_USUARIO = 4;
        public static int LISTA_VALOR_ESTADO_GRUPO_ROL = 5;
        #endregion

        #region Usuario
        public static string ESTADO_CUENTA_USUARIO_ACTIVO = "ESUSAC";
        public static string ESTADO_CUENTA_USUARIO_NO_ACTIVO = "ESUSNA";
        #endregion

        #region Rol Tipo de Permiso
        public static string ROL_TIPO_PERMISO_EJECUCION = "TPEJEC";
        public static string ROL_TIPO_PERMISO_ELIMINACION = "TPELIM";
        public static string ROL_TIPO_PERMISO_VISIBILIDAD = "TPVISI";
        public static string ROL_TIPO_PERMISO_MODIFICACION = "TPMODI";
        public static string ROL_TIPO_PERMISO_CREACION = "TPCREA";
        #endregion
    }
}
