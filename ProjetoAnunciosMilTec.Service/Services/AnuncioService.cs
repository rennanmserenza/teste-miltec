using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public abstract class AnuncioService<T>(AnunciosDbContext context)
    : BaseService<T>(context), IAnuncioService<T> where T : Anuncio
{
    public async Task<PagedResponse<List<T>?>> ObterTodosAsync
        (int pageNumber, int skip = 0, int take = 25)
    {
        try
        {
            var query = base.ObterTodos();

            var values = await query.Skip(skip).Take(take).ToListAsync();

            int total = await query.CountAsync();

            return new PagedResponse<List<T>?>(values, total, pageNumber, take);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new PagedResponse<List<T>?>(null, 500, "Erro ao tentar consultar os dados da tabela.");
        }
    }

    public async Task<BaseResponse<T?>> ObterPorIdAsync(long id)
    {
        var obj = await base.ObterPorIdAsync(id);

        return obj is not null
            ? new BaseResponse<T?>(obj)
            : new BaseResponse<T?>(null, 404, "O anuncio não foi encontrado.");
    }

    public new async Task<BaseResponse<T?>> CriarAsync(T anuncio)
    {
        try
        {
            var obj = await base.CriarAsync(anuncio);
            return new BaseResponse<T?>(obj, 201, "Anuncio criado com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<T?>(null, 500, "Não foi possível criar um novo anuncio.");
        }
    }

    public new async Task<BaseResponse<T?>> AtualizarAsync(T anuncio)
    {
        try
        {
            var obj = await base.ObterPorIdAsync(anuncio.Id);

            if (obj is null)
                return new BaseResponse<T?>(null, 404, "O anuncio não foi encontrado.");

            obj.Nome = anuncio.Nome;
            obj.Valor = anuncio.Valor;
            obj.Cidade = anuncio.Cidade;
            obj.DataPublicacao = anuncio.DataPublicacao;

            await base.AtualizarAsync(obj);

            return new BaseResponse<T?>(obj, message: "Categoria alterada com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<T?>(null, 500, "Não foi possível anterar o anuncio.");
        }
    }

    public async Task<BaseResponse<T?>> ExcluirAsync(long id)
    {
        try
        {
            var entity = await base.ObterPorIdAsync(id);

            if (entity is null)
                return new BaseResponse<T?>(null, 404, "Anuncio não encontrado.");

            await base.ExcluirAsync(entity);

            return new BaseResponse<T?>(entity, message: "Anuncio removido com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<T?>(null, 500, "Não foi possível remover o anuncio.");
        }
    }
}