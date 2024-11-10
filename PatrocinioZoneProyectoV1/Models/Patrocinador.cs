using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Patrocinador: Usuario
    {
        
        public double Presupuesto { get; set; }



    }
}
