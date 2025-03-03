using ProjetoAnunciosMilTec.API.Common.Api;
using ProjetoAnunciosMilTec.API.EndPoints.Produtos;
using ProjetoAnunciosMilTec.API.EndPoints.Servicos;

namespace ProjetoAnunciosMilTec.API.EndPoints;

public static class EndPoint
{
    public static void MapEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/v1/produtos")
            .WithTags("Produtos")
            //.RequireAuthorization()
            .MapEndPoint<CreateProductEndPoint>()
            .MapEndPoint<UpdateProductEndPoint>()
            .MapEndPoint<DeleteProductEndPoint>()
            .MapEndPoint<GetProductByIdEndPoint>()
            .MapEndPoint<GetAllProductsEndPoint>();

        endpoints.MapGroup("/v1/servicos")
            .WithTags("Servicos")
            //.RequireAuthorization()
            .MapEndPoint<CreateServiceEndPoint>()
            .MapEndPoint<UpdateServiceEndPoint>()
            .MapEndPoint<DeleteServiceEndPoint>()
            .MapEndPoint<GetServiceByIdEndPoint>()
            .MapEndPoint<GetAllServicesEndPoint>();
    }

    private static IEndpointRouteBuilder MapEndPoint<TEndPoint>
        (this IEndpointRouteBuilder app)
        where TEndPoint : IEndPoint
    {
        TEndPoint.Map(app);
        return app;
    }
}