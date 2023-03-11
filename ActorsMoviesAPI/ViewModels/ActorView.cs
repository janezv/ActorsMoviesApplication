using ActorsMoviesAPI.Models;

namespace ActorsMoviesAPI.ViewModels
{
    public class ActorView
    {

        public int ActorId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? BornDate { get; set; }

        public IList<Movie>? Movies { get; set; }
    }

}
