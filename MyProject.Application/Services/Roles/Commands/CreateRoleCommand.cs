using FluentValidation;
using MediatR;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Query.Title).NotEmpty().WithMessage("عنوان نباید خالی بماند")
            .Length(2, 10).WithMessage("تعداد کارکتر های مجاز بین 2 و 10 کاراکتر می باشد");
    }
}


public record CreateRoleCommand(CreateRoleRequest Query, CancellationToken CancellationToken) : IRequest<CreateRoleResponse>;
