using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecuresCompany.Domain.Entities;

namespace SecuresCompany.Persistence.EntitiesConfiguration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("empleadoId");
        builder.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Departamento).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Puesto).HasMaxLength(50).IsRequired();
        builder.Property(e => e.SalarioBase).HasColumnType("decimal(18, 2)");
    }
}