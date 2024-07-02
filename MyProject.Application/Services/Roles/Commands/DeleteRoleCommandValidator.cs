using FluentValidation;

namespace MyProject.Application.Services.Roles.Commands;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Command.Id).GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}
