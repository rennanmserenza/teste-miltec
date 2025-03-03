using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Servicos;

public class DeleteServiceEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
        .WithName("Services: Delete")
                .WithSummary("Remove um serviço")
                .WithDescription("Remove um serviço")
                .WithOrder(3)
                .Produces<BaseResponse<Servico?>>();

    private static async Task<IResult> HandleAsync(long id, IServicoService servicoService)
    {
        var request = new DeleteServicoRequest { Id = id };

        var result = await servicoService.ExcluirAsync(request.Id);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}