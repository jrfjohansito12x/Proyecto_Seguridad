using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class GrupoUsuario
    {
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Grupo Usuario es requerido")]
        public Int32 IdGrupoUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Grupo es requerido")]
        public Int32 IdGrupo { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo  Nombre Grupo es requerido")]
        public String NombreGrupo { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Usuario es requerido")]
        public String Usuario { get; set; }
        [DataMember()]
        public String NombreUsuario { get; set; }
        [DataMember()]
        public String ApellidoUsuario { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Estado Grupo Usuario es requerido")]
        public String EstadoGrupoUsuario { get; set; }
        [DataMember()]
        public String EstadoGrupoUsuarioDesc { get; set; }
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
