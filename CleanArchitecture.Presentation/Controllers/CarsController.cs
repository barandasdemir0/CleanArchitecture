using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiController
    {
        public CarsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCar(CreateCarCommand request , CancellationToken cancellation)
        {
            MessageResponse response =  await _mediator.Send(request, cancellation);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return Ok(10 / int.Parse("0"));
            
        }

    }
}
