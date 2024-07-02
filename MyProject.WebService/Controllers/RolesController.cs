using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Roles.Commands;
using MyProject.Application.Services.Roles.Queries;
using MyProject.SharedService.ModelDto.Roles.Commands;
using MyProject.SharedService.ModelDto.Roles.Queries;
using MyProject.SharedService.Utilities;

namespace MyProject.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route(nameof(GetAll))]
        public async Task<Paginated<GetAllRolesResponse>> GetAll(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllRolesQuery(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Get))]
        public async Task<GetRoleByIdResponse> Get(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetRoleByIdQuery(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<CreateRoleResponse> Create(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateRoleCommand(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public async Task<UpdateRoleResponse> Update(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateRoleCommand(request, cancellationToken));
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public async Task<DeleteRoleResponse> Delete(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteRoleCommand(request, cancellationToken));
        }
    }
}
