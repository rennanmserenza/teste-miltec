using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.Core.Models;
using ProjetoAnunciosMilTec.Core.Request.Produtos;
using ProjetoAnunciosMilTec.Core.Responses;
using ProjetoAnunciosMilTec.Service.Interfaces;

namespace ProjetoAnunciosMilTec.API.EndPoints.Servicos
{
    public class GetServiceByIdEndPoint : IEndPoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Services: Get")
                .WithSummary("Obtém um serviço pelo seu Id")
                .WithDescription("Obtém um serviço pelo seu Id")
                .WithOrder(4)
                .Produces<BaseResponse<Servico?>>();

        private static async Task<IResult> HandleAsync
            (long id, IServicoService servicoService)
        {
            var request = new GetProdutoByIdRequest
            {
                Id = id,
            };

            var result = await servicoService.ObterPorIdAsync(request.Id);

            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}