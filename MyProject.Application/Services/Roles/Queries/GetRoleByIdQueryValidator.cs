using FluentValidation;

namespace MyProject.Application.Services.Roles.Queries;

public sealed class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
{
    public GetRoleByIdQueryValidator()
    {
        RuleFor(p => p.Query.Id).GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}
