using MediatR;
using MyProject.SharedService.ModelDto.Users.Commands;

namespace MyProject.Application.Services.Users.Commands;

public record CreateUserCommand(CreateUserRequest Command, CancellationToken CancellationToken) : IRequest<CreateUserResponse>;
