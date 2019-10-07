using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SS_Modelo
{
    public class ListaValor
    {
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Lista Valor es requerido")]
        public Int32 IdListaValor { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo ID Lista es requerido")]
        public Int32 IdLista { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Nombre Lista es requerido")]
        public String NombreLista { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Valor es requerido")]
        public String Valor { get; set; }
        [DataMember()]
        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public String Descripcion { get; set; }
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
