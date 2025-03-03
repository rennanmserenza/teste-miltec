using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Core.Responses;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IServicoService : IAnuncioService<Servico>
{
    Task<BaseResponse<Servico?>> CriarAsync(CreateServicoRequest servico);

    Task<BaseResponse<Servico?>> AtualizarAsync(UpdateServicoRequest servico);
}