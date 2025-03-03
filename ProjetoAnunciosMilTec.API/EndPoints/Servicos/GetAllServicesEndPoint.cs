using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Servicos
{
    public class GetAllServicesEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/all/", HandleAsync)
                .WithName("Services: Get All")
                .WithSummary("Obtém todas os serviços")
                .WithDescription("Obtém todas os serviços")
                .WithOrder(5)
                .Produces<PagedResponse<List<Servico>?>>();

        private static async Task<IResult> HandleAsync
            (IServicoService servicoService,
            int pageNumber = Configuration.DefaultCurrentPage,
            int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllProdutosRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await servicoService.ObterTodosAsync(request.PageNumber, request.PageNumber - 1 * request.PageSize, request.PageSize);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}