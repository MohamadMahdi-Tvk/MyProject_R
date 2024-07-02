using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Application.Services.Users.Commands;

namespace MyProject.Application;

public static class ValidatorEntryPoint
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

        return services;
    }
}
