using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class Grupo
    {
        [DataMember()]
        public Int32 IdGrupo { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Grupo es requerido")]
        public String NombreGrupo { get; set; }
        [DataMember()]
        public String DescripcionGrupo { get; set; }
        [DataMember()]
        public String NombreRol { get; set; }
        [DataMember()]
        public String EstadoRol { get; set; }
        [DataMember()]
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
