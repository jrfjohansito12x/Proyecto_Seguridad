using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class GrupoRol
    {
        [DataMember()]
        public Int32 IdGrupoRol { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Grupo es requerido")]
        public Int32 IdGrupo { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Grupo es requerido")]
        public String NombreGrupo { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Rol es requerido")]
        public Int32 IdRol { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Rol es requerido")]
        public String NombreRol { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Estado Grupo es requerido")]
        public String EstadoGrupoRol { get; set; }
        [DataMember()]
        public String EstadoGrupoRolDesc { get; set; }
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
