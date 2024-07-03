using MediatR;
using MyProject.SharedService.ModelDto.Roles.Queries;

namespace MyProject.Application.Services.Roles.Commands;

public record GetRolesForUserCreateQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<GetRolesForUserCreateResponse>>;