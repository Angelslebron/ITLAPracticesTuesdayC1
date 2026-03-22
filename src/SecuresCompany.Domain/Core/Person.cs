using System;
namespace SecuresCompany.Domain.Core;

public abstract class Person : BaseEntity
{
    public string Nombre { get; set; } = null!;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
}
