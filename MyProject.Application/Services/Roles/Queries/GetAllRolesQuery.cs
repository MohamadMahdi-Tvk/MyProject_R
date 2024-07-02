using MediatR;
using MyProject.SharedService.ModelDto.Roles.Queries;
using MyProject.SharedService.Utilities;

namespace MyProject.Application.Services.Roles.Queries;

public record GetAllRolesQuery(GetAllRolesRequest Query, CancellationToken CancellationToken) : IRequest<Paginated<GetAllRolesResponse>>;
