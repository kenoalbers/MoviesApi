using Kenoalbers.Movies.Api.Generic;

namespace Kenoalbers.Movies.Api.Entities;

public class Movie : Entity
{ 
    public required string Name { get; set; }
}