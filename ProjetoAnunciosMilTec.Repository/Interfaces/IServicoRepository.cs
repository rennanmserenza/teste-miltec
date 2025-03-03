using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IServicoRepository : IAnuncioRepository<Servico>
{
    Task<Servico?> InsertAsync(CreateServicoRequest servico);

    Task<Servico?> UpdateAsync(UpdateServicoRequest servico);
}