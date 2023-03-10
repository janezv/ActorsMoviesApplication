using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ActorsMoviesAPI.Models;

public partial class Movie
{
    [Key]
    public int MovieId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string MovieTitle { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime? MovieDate { get; set; }

    public int ActorId { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("Movies")]
    public virtual Actor Actor { get; set; } = null!;
}
