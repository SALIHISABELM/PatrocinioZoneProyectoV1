using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrocinioZoneProyectoV1.Models
{
    public class ZonaPatrocinio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Tamaño")]
        [Required(ErrorMessage = "Por favor cargar el Tamaño del patrocinio, es obligatorio!")]
        [StringLength(10, ErrorMessage = "El Tamaño no puede tener más de 10 caracteres")]
        public String Tamanio { get; set; }

        [Display(Name = "Reserva")]
        [Required(ErrorMessage = "Por favor cargar si está reservado o no!")]
        public bool EstadoReservado { get; set; }

        [Display(Name = "Ubicación de la Zona de Patrocinio")]
        [Required(ErrorMessage = "Por favor cargar la Ubicación de la Zona del Patrocinio, es obligatorio!")]
        [EnumDataType(typeof(Ubicacion))]
        public Ubicacion Ubicacion { get; set; }
    }
}
