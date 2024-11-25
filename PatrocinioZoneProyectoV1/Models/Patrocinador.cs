using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Patrocinador: Usuario
    {
        [Display(Name = "Presupuesto")]
        [Required(ErrorMessage = "Por favor cargar el Presupuesto, es obligatorio!")]
        [Range(1, 1000000, ErrorMessage = "El Presupuesto debe ser entre 1 y 1,000,000")]
        public double Presupuesto { get; set; }

      
    }
}
