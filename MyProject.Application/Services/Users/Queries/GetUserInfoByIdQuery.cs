using MediatR;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.Application.Services.Users.Queries;

public record GetUserInfoByIdQuery(GetUserInfoByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetUserInfoByIdResponse>;
