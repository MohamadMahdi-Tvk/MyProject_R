using MediatR;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public record CreateRoleCommand(CreateRoleRequest Query, CancellationToken CancellationToken) : IRequest<CreateRoleResponse>;
