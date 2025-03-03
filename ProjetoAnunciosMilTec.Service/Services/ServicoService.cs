using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.Service.Services;

public class ServicoService(IServicoRepository servicoRepository, AnunciosDbContext context)
    : AnuncioService<Servico>(context), IServicoService
{
    private readonly IServicoRepository _servicoRepository = servicoRepository;

    public async Task<BaseResponse<Servico?>> CriarAsync(CreateServicoRequest servico)
    {
        // Regra de negócio: exemplo, validar dados
        if (servico.Valor < 1)
            return new BaseResponse<Servico?>(null, 500, "O valor deve ser maior ou igual a R$ 1,00.");

        try
        {
            var obj = await _servicoRepository.InsertAsync(servico);
            return new BaseResponse<Servico?>(obj, 201, "Anuncio criado com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<Servico?>(null, 500, "Não foi possível criar um novo anuncio.");
        }
    }

    public async Task<BaseResponse<Servico?>> AtualizarAsync(UpdateServicoRequest servico)
    {
        try
        {
            var obj = await _servicoRepository.UpdateAsync(servico);
            return new BaseResponse<Servico?>(obj, message: "Servico alterado com sucesso.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex.Message);
            return new BaseResponse<Servico?>(null, 500, "Não foi possível anterar o anuncio.");
        }
    }
}