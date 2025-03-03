using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public abstract class AnuncioRepository<T>(DbContext context) :
    BaseRepository<T>(context), IAnuncioRepository<T> where T : Anuncio
{
}