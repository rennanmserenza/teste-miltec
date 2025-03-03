using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Servicos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Servicos;

public class CreateServiceEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
        .WithName("Services: Create")
        .WithSummary("Cria um novo serviço")
        .WithDescription("Cria um novo serviço")
        .WithOrder(1)
        .Produces<BaseResponse<Servico?>>();

    private static async Task<IResult> HandleAsync(
        IServicoService servicoService, CreateServicoRequest request)
    {
        var result = await servicoService.CriarAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}