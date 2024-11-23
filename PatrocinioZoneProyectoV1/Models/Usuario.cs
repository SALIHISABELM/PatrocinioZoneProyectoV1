using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PatrocinioZoneProyectoV1.Validators;

namespace PatrocinioZoneProyectoV1.Models
    {
        public class Usuario
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "Por favor cargar el Nombre, es obligatorio!")]
            [StringLength(50, ErrorMessage = "El Nombre no puede tener más de 50 caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "Por favor cargar el Email, es obligatorio!")]
            [EmailAddress(ErrorMessage = "El Email ingresado no es válido")]
            public string Email { get; set; }

            [Display(Name = "Fecha de ingreso")]
            [Required(ErrorMessage = "Por favor cargar la Fecha de Ingreso, es obligatoria!")]
            [DataType(DataType.Date, ErrorMessage = "Debe ser una Fecha Válida")]
            [FechaIngresoValida(ErrorMessage = "La fecha de ingreso no puede ser una fecha futura.")]
            public DateTime FechaIngreso { get; set; }
      


    }
    }
