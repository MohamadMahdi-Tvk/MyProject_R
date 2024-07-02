using MediatR;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.Application.Services.Users.Queries;

public record GetUserByIdQuery(GetUserByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetUserByIdResponse>;
