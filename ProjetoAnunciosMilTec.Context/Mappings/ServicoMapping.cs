using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Context.Mappings;

public class ServicoMapping : AnuncioMapping<Servico>
{
    public override void Configure(EntityTypeBuilder<Servico> builder) => base.Configure(builder);
}