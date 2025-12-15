using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities;

public sealed class Car : Entity
{

    public Car()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Name { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }

}
