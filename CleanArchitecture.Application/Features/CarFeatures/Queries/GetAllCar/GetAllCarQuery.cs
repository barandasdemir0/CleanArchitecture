using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar
{
    public sealed record GetAllCarQuery(int pageNumber = 1,
        int pageSize = 10,
        string search = "") : IRequest<PaginationResult<Car>>;

}
