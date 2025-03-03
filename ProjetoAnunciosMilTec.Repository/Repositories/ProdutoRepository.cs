using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ProdutoRepository(AnunciosDbContext context) : AnuncioRepository<Produto>(context), IProdutoRepository
{
    public async Task<Produto?> InsertAsync(CreateProdutoRequest produto)
    {
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

        return await AddAsync(obj);
    }

    public async Task<Produto?> UpdateAsync(UpdateProdutoRequest produto)
    {
        var obj = await GetFirstOrDefaultAsync(x => x.Id == produto.Id);

        if (obj is null)
            return null;

        obj.Nome = produto.Nome;
        obj.Valor = produto.Valor;
        obj.Quantidade = produto.Quantidade;
        obj.Modelo = produto.Modelo;
        obj.Condicao = produto.Condicao;
        obj.Categoria = produto.Categoria;
        obj.Cidade = produto.Cidade;
        obj.DataPublicacao = produto.DataPublicacao;

        await UpdateAsync(obj);

        return obj;
    }
}