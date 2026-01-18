using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public sealed record RegisterCommand(
    string email,
    string UserName,
    string NameLastName,
    string password):IRequest<MessageResponse>;
