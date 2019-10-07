using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class Sesion
    {
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Sesión es requerido")]
        public Int32 IdSesion { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Aplicación es requerido")]
        public Int32 IdAplicacion { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Usuario es requerido")]
        public String Usuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public String NombreUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Apellido es requerido")]
        public String ApellidoUsuario { get; set; }
        [DataMember()]
        public String UltimoPermiso { get; set; }
        [DataMember()]
        public String Token { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Estado Sesion es requerido")]
        public String EstadoSesion { get; set; }
        [DataMember()]
        public String EstadoSesionDesc { get; set; }
    }
}
