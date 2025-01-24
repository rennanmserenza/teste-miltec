using ProjetoAnunciosMilTec.Repository.Interfaces;
using ProjetoAnunciosMilTec.Repository.Repositories;
using ProjetoAnunciosMilTec.Service.Interfaces;
using ProjetoAnunciosMilTec.Service.Services;

namespace ProjetoAnunciosMilTec.API.Archietecture
{
    public static class BuilderConfigurations
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            builder.DependencyInjectionConfiguration();
            builder.OpenApiConfiguration();

            return builder;
        }

        #region DI Configuration

        private static WebApplicationBuilder DependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            builder.RepositoryConfiguration();
            builder.ServiceConfiguration();

            return builder;
        }

        private static WebApplicationBuilder RepositoryConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IAnuncioRepository<>), typeof(AnuncioRepository<>));
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

            return builder;
        }

        private static WebApplicationBuilder ServiceConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IAnuncioService<>), typeof(AnuncioService<>));
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<IServicoService, ServicoService>();

            return builder;
        }

        #endregion DI Configuration

        #region Swagger

        private static WebApplicationBuilder OpenApiConfiguration(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        #endregion Swagger
    }
}