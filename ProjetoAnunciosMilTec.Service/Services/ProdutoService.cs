using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public class ProdutoService(IProdutoRepository produtoRepository, AnunciosDbContext context)
    : AnuncioService<Produto>(context), IProdutoService
{
    private readonly IProdutoRepository _produtoRepository = produtoRepository;

    public async Task<BaseResponse<Produto?>> CriarAsync(CreateProdutoRequest produto)
    {
        // Regra de negócio: exemplo, validar dados
        if (produto.Valor < 1)
            return new BaseResponse<Produto?>(null, 500, "O valor deve ser maior ou igual a R$ 1,00.");

        try
        {
            var obj = await _produtoRepository.InsertAsync(produto);
            return new BaseResponse<Produto?>(obj, 201, "Anuncio criado com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<Produto?>(null, 500, "Não foi possível criar um novo anuncio.");
        }
    }

    public async Task<BaseResponse<Produto?>> AtualizarAsync(UpdateProdutoRequest produto)
    {
        try
        {
            var obj = await _produtoRepository.UpdateAsync(produto);
            return new BaseResponse<Produto?>(obj, message: "Categoria alterada com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<Produto?>(null, 500, "Não foi possível anterar o anuncio.");
        }
    }

    public async Task<PagedResponse<List<Produto>?>> ObterTodosAsync(GetAllProdutosRequest request)
    {
        try
        {
            var result = await base
                .ObterTodosAsync(request.PageNumber, request.PageNumber - 1 * request.PageSize, request.PageSize);

            if (result is null)
            {
                return new PagedResponse<List<Produto>?>(null, 200, "Não foram encontrados registros.");
            }

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<List<Produto>?>(null, 500, "Erro ao tentar consultar os dados da tabela.");
        }
    }
}