using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellation);
    }
}
