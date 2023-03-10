using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ActorsMoviesAPI.Models;

public partial class Actor
{
    [Key]
    public int ActorId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [InverseProperty("Actor")]
    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
