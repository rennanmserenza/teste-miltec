using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Context.Mappings;

// Configuração do Produto
public class ProdutoMapping : AnuncioMapping<Produto>
{
    public override void Configure(EntityTypeBuilder<Produto> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Categoria)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(p => p.Modelo)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Condicao)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder.Property(p => p.Quantidade)
            .IsRequired()
            .HasAnnotation("MinValue", 1);
    }
}