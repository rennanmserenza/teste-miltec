using ProjetoAnunciosMilTec.Entity.Models;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public class ServicoService(IServicoRepository servicoRepository)
    : AnuncioService<Servico>(servicoRepository), IServicoService
{
}