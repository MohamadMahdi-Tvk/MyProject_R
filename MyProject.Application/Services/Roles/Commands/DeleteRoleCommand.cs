using MediatR;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public record DeleteRoleCommand(DeleteRoleRequest Command, CancellationToken CancellationToken) : IRequest<DeleteRoleResponse>;
