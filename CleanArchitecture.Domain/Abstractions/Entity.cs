using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity
{

    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    //public string Id { get; set; } = Guid.NewGuid().ToString();
    //public DateTime CreatedDate { get; set; }
    //public DateTime UpdatedDate { get; set; }
}
