using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, MessageResponse>
{

    private readonly ICarService _carService;

    public CreateCarCommandHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
       // işlemler
       await _carService.CreateAsync(request, cancellationToken);
        return new("Araç Başarıyla Üretildi.");
    }
}
