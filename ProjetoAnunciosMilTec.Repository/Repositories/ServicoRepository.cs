using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ServicoRepository(AnunciosDbContext context) : Repository<Servico>(context)
{
}