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

    public CarService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellation)
    {
        Car car = new()
        {
            Name = request.Name,
            Model = request.Model,
            EnginePower = request.EnginePower
        };
        await _context.Set<Car>().AddAsync(car, cancellation);
        await _context.SaveChangesAsync(cancellation);

    }
}
