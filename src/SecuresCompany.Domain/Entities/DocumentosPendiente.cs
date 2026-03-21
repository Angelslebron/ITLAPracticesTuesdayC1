using System;
using System.Collections.Generic;

namespace SecuresCompany.Domain.Entities;

public partial class DocumentosPendiente
{
    public int DocumentoId { get; set; }

    public int ClienteId { get; set; }

    public string NombreDocumento { get; set; } = null!;

    public virtual Client Cliente { get; set; } = null!;
}
