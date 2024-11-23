using System.ComponentModel.DataAnnotations;

namespace PatrocinioZoneProyectoV1.Validators
{
    public class FechaIngresoValidaAttribute : ValidationAttribute
    {

        // Sobrecargamos el método IsValid para validar si la fecha es futura
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Permitimos valores nulos si no es obligatorio
            }

            DateTime fechaIngreso = (DateTime)value;

            // Verificamos si la fecha de ingreso es mayor que la fecha actual
            if (fechaIngreso.Date > DateTime.Now.Date)
            {
                return new ValidationResult("La fecha de ingreso no puede ser una fecha futura.");
            }

            return ValidationResult.Success; // Fecha válida
        }
    }
}