using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Users.Commands;
using MyProject.Application.Services.Users.Queries;
using MyProject.SharedService.ModelDto.Users.Commands;
using MyProject.SharedService.ModelDto.Users.Queries;
using MyProject.SharedService.Utilities;

namespace MyProject.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }


        [HttpPost]
        [Route(nameof(GetUserBySearch))]
        public async Task<List<GetUserBySearchResponse>> GetUserBySearch(GetUserBySearchRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetUserBySearchQuery(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        public async Task<Paginated<GetAllUsersResponse>> GetAll(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllUsersQuery(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Get))]
        public async Task<GetUserByIdResponse> Get(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<CreateUserResponse> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateUserCommand(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<UpdateUserResponse> Update(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateUserCommand(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<DeleteUserResponse> Delete(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteUserCommand(request, cancellationToken));
        }
    }
}
