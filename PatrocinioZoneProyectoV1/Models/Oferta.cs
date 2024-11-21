using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Oferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaId { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Por favor cargar el nombre!")]
        public string Nombre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Por favor cargar el email!")]
        public string Email { get; set; }

        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }


    }
}
