using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Club : Usuario
    {
        [Display(Name = "Deporte")]
        [Required(ErrorMessage = "Por favor cargar el Deporte, es obligatorio!")]
        [EnumDataType(typeof(Deporte))]
        public Deporte DeporteFavorito { get; set; }
    }
}
