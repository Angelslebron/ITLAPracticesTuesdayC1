using System.ComponentModel.DataAnnotations;

namespace SecuresCompany.Domain.Models.Dtos
{
    public class CrearClienteDto
    {
        [Required]
        public string nombreCliente { get; set; }

        [Required]
        public string numeroPoliza { get; set; }

        [Required]
        public string tipoSeguro { get; set; }

        [Required]
        public string tipoCliente { get; set; }

        public string email { get; set; }
        public string telefono { get; set; }
    }
}