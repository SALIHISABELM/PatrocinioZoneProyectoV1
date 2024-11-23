using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Models
{
    public class Oferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfertaId { get; set; }

        [Display(Name = "Seleccione el Patrocinador")]
        public int PatrocinadorID { get; set; }

        [Display(Name = "Seleccione el Patrocinador")]
        [Required(ErrorMessage = "No olvide seleccionar el Patrocinador!")]
        public virtual Patrocinador? Patrocinador { get; set; }

        [Display(Name = "Ingrese el presupuesto")]
        //Validar con le presupuesto que fue creado ese patrocinador y una vez hecho esto restarlo
        public double Costo { get; set; }

        [Display(Name = "Seleccione el club")]
        public int ClubID { get; set; }

        [Display(Name = "Seleccione el club")]
        [Required(ErrorMessage = "No olvide seleccionar el Club!")]
        public virtual Club? Club { get; set; }

        [Display(Name = "Elija la zona a patrocinar")]
        public int ZonaDePatrocinioID { get; set; }

        [Display(Name = "Elija la zona a patrocinar")]
        [Required(ErrorMessage = "No olvide seleccionar la zona a patrocinar!")]
        public virtual ZonaPatrocinio? ZonaDePatrocinio { get; set; }

    }
}
