using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IProdutoRepository : IAnuncioRepository<Produto>
{
    Task<Produto?> InsertAsync(CreateProdutoRequest produto);

    Task<Produto?> UpdateAsync(UpdateProdutoRequest produto);
}