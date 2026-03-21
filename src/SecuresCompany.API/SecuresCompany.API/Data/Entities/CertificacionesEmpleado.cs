using System;
using System.Collections.Generic;

namespace SecuresCompany.API.Data.Entities;

public partial class CertificacionesEmpleado
{
    public int CertificacionId { get; set; }

    public int EmpleadoId { get; set; }

    public string NombreCertificacion { get; set; } = null!;

    public DateOnly? FechaObtencion { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}
