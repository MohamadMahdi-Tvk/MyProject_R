using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Connections;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.DomainRepository;
using MyProject.DataAccess.UnitOfWork;
using System.Reflection;

namespace MyProject.Application;

public static class MediatorEntryPoint
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(typeof(DataBaseContext));
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILogger<UserRepository>>();
        services.AddSingleton(typeof(ILogger), logger);

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();

        services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;

    }
}
