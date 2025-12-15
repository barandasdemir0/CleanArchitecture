using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreteCar
{
    public sealed record CreateCarCommand(
        string Name,
        string Model,
        int EnginePower) : IRequest<MessageResponse>;
}
