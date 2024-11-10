using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Club : Usuario
    {

        [EnumDataType(typeof(Deporte))]
        public Deporte DeporteFavorito { get; set; }
    }
}
