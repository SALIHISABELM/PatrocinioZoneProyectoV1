using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Club : Usuario
    {

        [EnumDataType(typeof(Deporte))]
        public Deporte DeporteFavorito { get; set; }
    }
}
