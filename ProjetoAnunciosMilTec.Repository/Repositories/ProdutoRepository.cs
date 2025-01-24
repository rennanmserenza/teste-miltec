using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ProdutoRepository(AnunciosDbContext context) : Repository<Produto>(context)
{
}