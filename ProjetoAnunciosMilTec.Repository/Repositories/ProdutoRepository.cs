using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ProdutoRepository(AnunciosDbContext context) : AnuncioRepository<Produto>(context), IProdutoRepository
{
}