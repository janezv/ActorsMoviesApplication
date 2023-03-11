using System;
using System.Collections.Generic;

namespace ActorsMoviesAPI.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? MovieDescription { get; set; }

    public virtual ICollection<Actor> Actors { get; } = new List<Actor>();

    public virtual ICollection<ImgPath> ImgPaths { get; } = new List<ImgPath>();
}
