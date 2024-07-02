using FluentValidation;

namespace MyProject.Application.Services.Users.Commands;

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(p => p.Command.Id).NotNull().WithMessage("آیدی باید مقدار داشته باشد")
            .GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}
