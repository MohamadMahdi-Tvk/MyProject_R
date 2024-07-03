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

            return RedirectToAction(nameof(GetAll));

        }

        [HttpGet]
        public async Task<IActionResult> Update(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var model = await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));
            ViewBag.roles = new SelectList(await _mediator.Send(new GetRolesForUserCreateQuery(cancellationToken)), "Id", "Title");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> Info(GetUserInfoByIdRequest request, CancellationToken cancellationToken)
        {
            return View(await _mediator.Send(new GetUserInfoByIdQuery(request, cancellationToken)));
        }
    }
}
