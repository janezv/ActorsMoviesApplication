using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActorsMoviesAPI.Models;

public partial class Actor
{
    [Key]
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? BornDate { get; set; }

    public IList<ActorsMovie> ActorsMovies { get; set; }

    public static implicit operator int(Actor v)
    {
        throw new NotImplementedException();
    }
}
