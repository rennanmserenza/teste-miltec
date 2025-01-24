using ProjetoAnunciosMilTec.Entity.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public class ProdutoService(IProdutoRepository produtoRepository)
    : AnuncioService<Produto>(produtoRepository), IProdutoService
{
    public new async Task CriarAsync(Produto produto)
    {
        // Regra de negócio: exemplo, validar dados
        if (produto.Valor < 1)
        {
            throw new ArgumentException("O valor deve ser maior ou igual a R$ 1,00.");
        }
        await base.CriarAsync(produto);
    }
}