using System;
using System.Collections.Generic;

namespace ActorsMoviesAPI.Models;

public partial class ImgPath
{
    public int ImgPathId { get; set; }

    public string ImgPath1 { get; set; } = null!;

    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
