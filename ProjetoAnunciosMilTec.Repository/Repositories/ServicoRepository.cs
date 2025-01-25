using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ServicoRepository(AnunciosDbContext context) : AnuncioRepository<Servico>(context), IServicoRepository
{
}