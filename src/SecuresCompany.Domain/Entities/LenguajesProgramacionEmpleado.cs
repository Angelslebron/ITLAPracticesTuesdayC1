using System;
using System.Collections.Generic;

namespace SecuresCompany.Domain.Entities;

public partial class LenguajesProgramacionEmpleado
{
    public int LenguajeId { get; set; }

    public int EmpleadoId { get; set; }

    public string NombreLenguaje { get; set; } = null!;

    public string? NivelDominio { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}

