using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Context.Mappings;

public abstract class AnuncioMapping<T> : IEntityTypeConfiguration<T> where T : Anuncio
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(nameof(T));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasAnnotation("MinLength", 5);

        builder.Property(a => a.DataPublicacao)
            .IsRequired()
            .HasAnnotation("Validation", new { MinDate = DateTime.Now });

        builder.Property(a => a.Valor)
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasAnnotation("MinValue", 1);

        builder.Property(a => a.Cidade)
            .IsRequired()
            .HasColumnType("varchar(50)");
    }
}