using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request);
}
