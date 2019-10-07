using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class Usuario
    {
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Usuario es requerido")]
        public String IdUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Usuario es requerido")]
        public String NombreUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Apellido Usuario es requerido")]
        public String ApellidoUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Clave es requerido")]
        public String ClaveAcceso { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Email es requerido")]
        public String Email { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Estado Usuario es requerido")]
        public String EstadoUsuario { get; set; }
        [DataMember()]
        public String EstadoUsuarioDesc { get; set; }
        [DataMember()]
        public String CreadoPor { get; set; }
        [DataMember()]
        public DateTime FechaCreacion { get; set; }
        [DataMember()]
        public String ModificadoPor { get; set; }
        [DataMember()]
        public DateTime FechaModificacion { get; set; }
    }
}
