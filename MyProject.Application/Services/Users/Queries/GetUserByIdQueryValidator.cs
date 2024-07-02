﻿using FluentValidation;

namespace MyProject.Application.Services.Users.Queries;

public sealed class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(p => p.Query.Id).GreaterThan(0).WithMessage("آیدی باید بزرگتر از صفر باشد");
    }
}