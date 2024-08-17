using Ecommerce.Application.Models.Token;
using Ecommerce.Application.Persistence;
using Ecommerce.Persistence.Repositories;
using Ecommerce.Persistence.Repostories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Persistence;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>),typeof(RepositoryBase<>));

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        return services;
    }
}