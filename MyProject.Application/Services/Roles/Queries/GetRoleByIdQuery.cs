using MediatR;
using MyProject.SharedService.ModelDto.Roles.Queries;

namespace MyProject.Application.Services.Roles.Queries;

public record GetRoleByIdQuery(GetRoleByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetRoleByIdResponse>;