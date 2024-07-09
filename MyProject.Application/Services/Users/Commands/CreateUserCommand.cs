using FluentValidation;
using MediatR;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;


public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Command.FirstName).NotNull().WithMessage("First Name must have a value")
            .MinimumLength(2).WithMessage("First Name must greater than 2 character");

        RuleFor(p => p.Command.LastName).NotNull().WithMessage("Last Name must have a value")
            .MinimumLength(2).WithMessage("Last Name must greater than 2 character");
    }
}

public record CreateUserCommand(CreateUserRequest Command, CancellationToken CancellationToken) : IRequest<CreateUserResponse>;
