using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IProdutoService : IAnuncioService<Produto>
{
    Task<BaseResponse<Produto?>> CriarAsync(CreateProdutoRequest produto);

    Task<BaseResponse<Produto?>> AtualizarAsync(UpdateProdutoRequest produto);

    Task<PagedResponse<List<Produto>?>> ObterTodosAsync(GetAllProdutosRequest request);
}