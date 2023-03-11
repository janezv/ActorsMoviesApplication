using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActorsMoviesAPI.Models;

public partial class Movie
{

    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? MovieDescription { get; set; }

    public virtual ICollection<ActorsMovie> ActorsMovies { get; } = new List<ActorsMovie>();

    public virtual ICollection<ImgPath> ImgPaths { get; } = new List<ImgPath>();
}
