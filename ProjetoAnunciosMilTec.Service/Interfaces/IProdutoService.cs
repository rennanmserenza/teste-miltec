using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IProdutoService : IAnuncioService<Produto>
{
    Task CriarAsync(CreateProdutoRequest produto);
}