using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Models.Endereco>
{
    public void Configure(EntityTypeBuilder<Models.Endereco> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("Id");

        builder.Property(c => c.Cep)
            .HasColumnType("varchar(10)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Logradouro)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Complemento)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Bairro)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Localidade)
            .HasColumnType("varchar(50)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Uf)
            .HasColumnType("varchar(4)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Ibge)
            .HasColumnType("varchar(20)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Gia)
            .HasColumnType("varchar(20)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Ddd)
            .HasColumnType("varchar(4)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Gia)
            .HasColumnType("varchar(20)")
            .HasMaxLength(100)
            .IsRequired();
    }
}
