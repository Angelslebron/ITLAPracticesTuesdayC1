using System.ComponentModel.DataAnnotations;

namespace SecuresCompany.API.Models.Dtos
{
    public class CrearEmpleadoDto
    {
        [Required]
        public string idEmpleado { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string departamento { get; set; }

        [Required]
        public string puesto { get; set; }

        public decimal salarioBase { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}