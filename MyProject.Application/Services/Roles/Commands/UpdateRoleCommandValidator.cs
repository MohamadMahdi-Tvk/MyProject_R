using FluentValidation;

namespace MyProject.Application.Services.Roles.Commands;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Command.Title).NotEmpty().WithMessage("عنوان نباید خالی بماند")
            .Length(2, 10).WithMessage("تعداد کارکتر های مجاز بین 2 و 10 کاراکتر می باشد");
    }
}
