using ProjetoAnunciosMilTec.Core.Models;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IAnuncioRepository<T> : IBaseRepository<T> where T : Anuncio
{
}