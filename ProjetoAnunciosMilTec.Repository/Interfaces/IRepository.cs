using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IRepository<T> where T : Anuncio
{
    Task<T?> GetByIdAsync(long id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(long id);
}