using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Responses;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IAnuncioService<T> : IBaseService<T> where T : Anuncio
{
    Task<PagedResponse<List<T>?>> ObterTodosAsync(int pageNumber, int skip = 0, int take = 25);

    Task<BaseResponse<T?>> ObterPorIdAsync(long id);

    Task<BaseResponse<T?>> CriarAsync(T anuncio);

    Task<BaseResponse<T?>> AtualizarAsync(T anuncio);

    Task<BaseResponse<T?>> ExcluirAsync(long id);
}