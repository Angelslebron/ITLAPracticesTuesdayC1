using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecuresCompany.Domain.Entities;

namespace SecuresCompany.Persistence.EntitiesConfiguration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("clienteId");
        builder.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
        builder.Property(e => e.NumeroPoliza).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Telefono).HasMaxLength(20);
        builder.Property(e => e.SaldoPendiente).HasColumnType("decimal(18, 2)");
    }
}