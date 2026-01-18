using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommand request,CancellationToken cancellation)
        {
            MessageResponse response = await _mediator.Send(request, cancellation);
            return Ok(response);
        }
    }
}
