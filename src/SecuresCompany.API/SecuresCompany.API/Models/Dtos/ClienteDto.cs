namespace SecuresCompany.API.Models.Dtos
{
    public class ClienteDto
    {
        public int clienteID { get; set; }
        public string nombreCliente { get; set; }
        public string numeroPoliza { get; set; }
        public string tipoSeguro { get; set; }
        public string tipoCliente { get; set; }
        public decimal saldoPendiente { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}