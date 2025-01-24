using ProjetoAnunciosMilTec.Entity.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services
{
    public abstract class AnuncioService<T>(IAnuncioRepository<T> baseRepository)
        : IAnuncioService<T> where T : Anuncio
    {
        private readonly IAnuncioRepository<T> _baseRepository = baseRepository;

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T?> ObterPorIdAsync(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task CriarAsync(T anuncio)
        {
            await _baseRepository.AddAsync(anuncio);
        }

        public async Task AtualizarAsync(T anuncio)
        {
            await _baseRepository.UpdateAsync(anuncio);
        }

        public async Task ExcluirAsync(long id)
        {
            await _baseRepository.DeleteAsync(id);
        }
    }
}