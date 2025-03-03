using ProjetoAnunciosMilTec.Context;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Repository.Interfaces;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class ServicoRepository(AnunciosDbContext context)
    : AnuncioRepository<Servico>(context), IServicoRepository
{
    public async Task<Servico?> InsertAsync(CreateServicoRequest servico)
    {
        var obj = new Servico
        {
            Nome = servico.Nome,
            Valor = servico.Valor,
            Cidade = servico.Cidade,
            DataPublicacao = servico.DataPublicacao,
        };

        return await AddAsync(obj);
    }

    public async Task<Servico?> UpdateAsync(UpdateServicoRequest servico)
    {
        var obj = await GetFirstOrDefaultAsync(x => x.Id == servico.Id);

        if (obj is null)
            return null;

        obj.Nome = servico.Nome;
        obj.Valor = servico.Valor;
        obj.Cidade = servico.Cidade;
        obj.DataPublicacao = servico.DataPublicacao;

        await UpdateAsync(obj);

        return obj;
    }
}