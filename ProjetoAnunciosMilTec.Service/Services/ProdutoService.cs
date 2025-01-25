using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public class ProdutoService(IProdutoRepository produtoRepository)
    : AnuncioService<Produto>(produtoRepository), IProdutoService
{
    public async Task CriarAsync(CreateProdutoRequest produto)
    {
        // Regra de negócio: exemplo, validar dados
        if (produto.Valor < 1)
        {
            throw new ArgumentException("O valor deve ser maior ou igual a R$ 1,00.");
        }

        var obj = new Produto
        {
            Nome = produto.Nome,
            Valor = produto.Valor,
            Categoria = produto.Categoria,
            Cidade = produto.Cidade,
            Condicao = produto.Condicao,
            DataPublicacao = produto.DataPublicacao,
            Modelo = produto.Modelo,
            Quantidade = produto.Quantidade,
        };

        await CriarAsync(obj);
    }
}