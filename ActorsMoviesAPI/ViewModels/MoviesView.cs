using ActorsMoviesAPI.Models;

namespace ActorsMoviesAPI.ViewModels
{
    public class MoviesView
    {
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public string? MovieDescription { get; set; }

        public IList<String> ImgPaths { get; set; } 
        public IList<Actor> Actors { get; set; }
    }
}
