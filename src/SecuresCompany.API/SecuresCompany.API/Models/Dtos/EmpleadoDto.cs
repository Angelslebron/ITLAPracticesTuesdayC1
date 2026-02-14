namespace SecuresCompany.API.Models.Dtos
{
    public class EmpleadoDto
    {
        internal int empleadoId;

        public int empleadoID { get; set; }
        public string idEmpleado { get; set; }
        public string nombre { get; set; }
        public string departamento { get; set; }
        public string puesto { get; set; }
        public decimal salarioBase { get; set; }
        public DateTime fechaIngreso { get; set; }

    }
}
