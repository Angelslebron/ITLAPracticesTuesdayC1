using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuresCompany.Domain.Entities
{
    public class Client
    {

    public int ClienteId { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string NumeroPoliza { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public decimal SaldoPendiente { get; set; }

    public string TipoSeguro { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string TipoCliente { get; set; } = null!;

    public DateOnly? UltimoPago { get; set; }

    public decimal? DescuentoFidelidad { get; set; }

    public int? MesesConsecutivosAlDia { get; set; }

    public int? DiasMora { get; set; }

    public decimal? MontoMora { get; set; }

    public decimal? RecargoPorMora { get; set; }

    public DateOnly? FechaUltimoAtraso { get; set; }

    public bool? EnProcesoCobro { get; set; }

    public string? MotivoMora { get; set; }

    public bool? VerificacionCompletada { get; set; }

    public DateOnly? FechaProximaRevision { get; set; }

    public int? PorcentajeCompletado { get; set; }

    public bool? AprobacionPendiente { get; set; }

    public int? EmpleadoAsignadoId { get; set; }

    public virtual ICollection<DocumentosPendiente> DocumentosPendientes { get; set; } = new List<DocumentosPendiente>();

    public virtual Employees? EmpleadoAsignado { get; set; }

    }
}
