using MediatR;
using MyProject.SharedService.ModelDto.Users.Queries;
using MyProject.SharedService.Utilities;

namespace MyProject.Application.Services.Users.Queries;

public record GetAllUsersQuery(GetAllUsersRequest Query, CancellationToken CancellationToken) : IRequest<Paginated<GetAllUsersResponse>>;
