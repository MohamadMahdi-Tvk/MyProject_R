using FluentValidation;
using MediatR;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(p => p.Command.Id).NotNull().WithMessage("آیدی باید مقدار داشته باشد")
            .GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}


public record DeleteUserCommand(DeleteUserRequest Command, CancellationToken CancellationToken) : IRequest<DeleteUserResponse>;
