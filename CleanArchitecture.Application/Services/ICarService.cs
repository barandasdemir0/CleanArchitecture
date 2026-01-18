using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellation);
        Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellation);
    }
}
