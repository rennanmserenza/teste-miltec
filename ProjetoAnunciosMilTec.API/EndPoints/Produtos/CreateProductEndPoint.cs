using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Produtos;

public class CreateProductEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", InvokeAsync)
        .WithName("Products: Create")
        .WithSummary("Cria um novo produto")
        .WithDescription("Cria um novo produto")
        .WithOrder(1)
        .Produces<BaseResponse<Produto?>>();

    private static async Task<IResult> InvokeAsync(
        IProdutoService produtoService, CreateProdutoRequest request)
    {
        var result = await produtoService.CriarAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}