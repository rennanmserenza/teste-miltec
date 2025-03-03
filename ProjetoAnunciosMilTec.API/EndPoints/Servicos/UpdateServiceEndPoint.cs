using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Servicos;

public class UpdateServiceEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Service: Update")
            .WithSummary("Altera um serviço")
            .WithDescription("Altera um serviço")
            .WithOrder(2)
            .Produces<BaseResponse<Servico?>>();

    private static async Task<IResult> HandleAsync(
        long id, IServicoService servicoService, UpdateServicoRequest request)
    {
        request.Id = id;
        var result = await servicoService.AtualizarAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}