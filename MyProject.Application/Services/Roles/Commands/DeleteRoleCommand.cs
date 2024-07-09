using FluentValidation;
using MediatR;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Command.Id).GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}


public record DeleteRoleCommand(DeleteRoleRequest Command, CancellationToken CancellationToken) : IRequest<DeleteRoleResponse>;
