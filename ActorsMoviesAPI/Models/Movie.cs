using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActorsMoviesAPI.Models;

public partial class Movie
{
    [Key]
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? MovieDescription { get; set; }

    public virtual ICollection<ImgPath> ImgPaths { get; } = new List<ImgPath>();
    public IList<ActorsMovie> ActorsMovies { get; set; }
}
