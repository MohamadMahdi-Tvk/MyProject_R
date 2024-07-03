using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Application.Services.Roles.Commands;
using MyProject.Application.Services.Roles.Queries;
using MyProject.Application.Services.Users.Commands;
using MyProject.Application.Services.Users.Queries;
using MyProject.SharedService.ModelDto.Users.Commands;
using MyProject.SharedService.ModelDto.Users.Queries;

namespace MyProject.MVC.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var model = await _mediator.Send(new GetAllUsersQuery(request, cancellationToken));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.roles = new SelectList(await _mediator.Send(new GetRolesForUserCreateQuery(cancellationToken)), "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var model = await _mediator.Send(new CreateUserCommand(request, cancellationToken));

            return RedirectToAction("GetAll");

        }
    }
}
