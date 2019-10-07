using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class Rol
    {
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Rol es requerido")]
        public Int32 IdRol { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Rol es requerido")]
        public String NombreRol { get; set; }
        [DataMember()]
        public String DescripcionRol { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Estado Rol es requerido")]
        public String EstadoRol { get; set; }
        [DataMember()]
        public String EstadoRolDesc { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Tipo de Permiso es requerido")]
        public String TipoPermiso { get; set; }
        [DataMember()]
        public String TipoPermisoDesc { get; set; }
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
