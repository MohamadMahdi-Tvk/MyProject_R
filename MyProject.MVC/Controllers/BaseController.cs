﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}