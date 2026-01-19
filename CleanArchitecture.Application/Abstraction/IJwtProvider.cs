using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Abstraction
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}
