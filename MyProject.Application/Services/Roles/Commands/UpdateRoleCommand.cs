using MediatR;
using MyProject.SharedService.ModelDto.Roles.Commands;

namespace MyProject.Application.Services.Roles.Commands;

public record UpdateRoleCommand(UpdateRoleRequest Command, CancellationToken CancellationToken) : IRequest<UpdateRoleResponse>;
