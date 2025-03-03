using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Produtos;

public class DeleteProductEndPoint : IEndPoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
        .WithName("Products: Delete")
                .WithSummary("Remove um produto")
                .WithDescription("Remove um produto")
                .WithOrder(3)
                .Produces<BaseResponse<Produto?>>();

    private static async Task<IResult> HandleAsync(long id, IProdutoService produtoService)
    {
        var request = new DeleteProdutoRequest { Id = id };

        var result = await produtoService.ExcluirAsync(request.Id);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}