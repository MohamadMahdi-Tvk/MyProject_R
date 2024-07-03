using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Users.Queries;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.MVC.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        public async Task<IActionResult> GetAll(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var model = await _mediator.Send(new GetAllUsersQuery(request, cancellationToken));
            return View(model);
        }

    }
}
