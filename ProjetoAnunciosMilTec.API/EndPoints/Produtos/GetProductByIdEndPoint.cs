using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Produtos
{
    public class GetProductByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Transactions: Get")
                .WithSummary("Obtém uma transação pelo seu Id")
                .WithDescription("Obtém uma transação pelo seu Id")
                .WithOrder(4)
                .Produces<BaseResponse<Produto?>>();

        private static async Task<IResult> HandleAsync
            (long id, IProdutoService produtoService)
        {
            var request = new GetProdutoByIdRequest
            {
                Id = id,
            };

            var result = await produtoService.ObterPorIdAsync(request.Id);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}