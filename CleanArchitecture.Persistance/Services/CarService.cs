using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{

    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        await _context.Set<Car>().AddAsync(car, cancellation);
        await _context.SaveChangesAsync(cancellation);

    }
}
