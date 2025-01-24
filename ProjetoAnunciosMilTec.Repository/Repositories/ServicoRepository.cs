using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Entity.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ServicoRepository(AnunciosDbContext context) : AnuncioRepository<Servico>(context), IServicoRepository
{
}