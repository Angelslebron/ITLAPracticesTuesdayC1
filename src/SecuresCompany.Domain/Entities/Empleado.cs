using SecuresCompany.Domain.Core;

namespace SecuresCompany.Domain.Entities;

public partial class Empleado : Person
{
    public string IdEmpleado { get; set; } = null!;
    public DateTime fechaIngreso { get; set; }
    public decimal SalarioBase { get; set; }
    public string Departamento { get; set; } = null!;
    public string Puesto { get; set; } = null!;
    public int? GerenteId { get; set; }
    public string? AreaEspecializacion { get; set; }
    public decimal? PresupuestoAnual { get; set; }
    public int? NumeroSubordinados { get; set; }
    public decimal? BonoGerencial { get; set; }
    public int? ProyectosAsignados { get; set; }
    public string? NivelExperiencia { get; set; }
    public string? NivelTecnico { get; set; }
    public int? TareasPendientes { get; set; }
    public int? LineasCodigoMes { get; set; }
    public int? ProyectosTi { get; set; }
    public int? EquipoDesarrollo { get; set; }
    public decimal? BonoTecnico { get; set; }
    public int? EmpleadosAcargo { get; set; }
    public string? EspecialidadRrhh { get; set; }
    public int? VacantesActivas { get; set; }
    public int? ContratacionesMes { get; set; }
    public int? DepartamentosSupervisa { get; set; }
    public decimal? BonoGestion { get; set; }
    public virtual ICollection<CertificacionesEmpleado> CertificacionesEmpleados { get; set; } = new List<CertificacionesEmpleado>();
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    public virtual Empleado? Gerente { get; set; }
    public virtual ICollection<Empleado> InverseGerente { get; set; } = new List<Empleado>();
    public virtual ICollection<LenguajesProgramacionEmpleado> LenguajesProgramacionEmpleados { get; set; } = new List<LenguajesProgramacionEmpleado>();
}