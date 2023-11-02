using Cliente.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Models.Cliente>
{
    public void Configure(EntityTypeBuilder<Models.Cliente> builder)
    {
        builder.Property(c => c.Id)
                .HasColumnName("Id");

        builder.Property(c => c.Nome)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(a => a.Endereco)
            .WithOne(b => b.Cliente)
            .HasForeignKey<Models.Endereco>(b => b.ClienteRefId)
            .IsRequired();
    }
}