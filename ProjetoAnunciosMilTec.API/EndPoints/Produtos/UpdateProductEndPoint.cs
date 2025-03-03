using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Produtos;

public class UpdateProductEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Product: Update")
            .WithSummary("Altera um produto")
            .WithDescription("Altera um produto")
            .WithOrder(2)
            .Produces<BaseResponse<Produto?>>();

    private static async Task<IResult> HandleAsync(
        long id, IProdutoService produtoService, UpdateProdutoRequest request)
    {
        request.Id = id;
        var result = await produtoService.AtualizarAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}