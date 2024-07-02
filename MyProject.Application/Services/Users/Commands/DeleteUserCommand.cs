using MediatR;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public record DeleteUserCommand(DeleteUserRequest Command, CancellationToken CancellationToken) : IRequest<DeleteUserResponse>;
