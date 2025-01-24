using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IAnuncioRepository<T> where T : Anuncio
{
    Task<T?> GetByIdAsync(long id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(long id);
}