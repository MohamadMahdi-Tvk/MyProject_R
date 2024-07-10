using MediatR;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.Application.Services.Users.Queries;

public record GetUserBySearchQuery(GetUserBySearchRequest Query, CancellationToken CancellationToken) : IRequest<List<GetUserBySearchResponse>>;
