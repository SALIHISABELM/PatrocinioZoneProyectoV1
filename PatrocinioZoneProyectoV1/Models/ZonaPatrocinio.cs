using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Models
{
    public class ZonaPatrocinio
    {
        public double tamanio { get; set; }
        public bool estadoReservado { get; set; }

        [EnumDataType(typeof(Ubicacion))]
        public Ubicacion Ubicacion { get; set; }
    }
}
