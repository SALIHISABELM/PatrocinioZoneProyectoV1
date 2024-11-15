using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatrocinioZoneProyectoV1.Models
{
    public class ZonaPatrocinio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Tamanio { get; set; }
        public bool EstadoReservado { get; set; }

        [EnumDataType(typeof(Ubicacion))]
        public Ubicacion Ubicacion { get; set; }
    }
}
