using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("KodlamaDevsConnectionString")));

        services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
        services.AddScoped<ITechnologyRepository, TechnologyRepository>();
        services.AddScoped<ISocialRepository, SocialRepository>();
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}
