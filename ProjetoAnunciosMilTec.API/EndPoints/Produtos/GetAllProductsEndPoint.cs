using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Produtos
{
    public class GetAllProductsEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/all/", HandleAsync)
                .WithName("Products: Get All")
                .WithSummary("Obtém todas os produtos")
                .WithDescription("Obtém todas os produtos")
                .WithOrder(5)
                .Produces<PagedResponse<List<Produto>?>>();

        private static async Task<IResult> HandleAsync
            (IProdutoService produtoService,
            int pageNumber = Configuration.DefaultCurrentPage,
            int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllProdutosRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await produtoService.ObterTodosAsync(request);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}