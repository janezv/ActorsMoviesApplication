using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActorsMoviesAPI.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? BornDate { get; set; }

    public virtual ICollection<ActorsMovie> ActorsMovies { get; } = new List<ActorsMovie>();
}
