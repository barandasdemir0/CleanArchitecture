using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CarService(AppDbContext context, IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _context = context;
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellation)
    {
        //Car car = new()
        //{
        //    Name = request.Name,
        //    Model = request.Model,
        //    EnginePower = request.EnginePower
        //};
        Car car = _mapper.Map<Car>(request);
        //await _context.Set<Car>().AddAsync(car, cancellation);
        //await _context.SaveChangesAsync(cancellation);

        await _carRepository.AddAsync(car, cancellation);
        await _unitOfWork.SaveChangesAsync(cancellation);

    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellation)
    {
        PaginationResult<Car> cars = 
            await _carRepository
            .Where(p=>p.Name.ToLower().Contains(request.search.ToLower()))
            .ToPagedListAsync(request.pageSize,request.pageNumber,cancellation);
        return cars;
    }
}
