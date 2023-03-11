using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActorsMoviesAPI.Models;
using ActorsMoviesAPI.ViewModels;

namespace ActorsMoviesAPI.Contorllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ActorMoviesSrcContext _context;

        public MoviesController(ActorMoviesSrcContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int page, int pageSize)
        {
            // Zaščita pred inexom izven meja
            int numberOfrow = await _context.Actors.CountAsync();
            if (pageSize > numberOfrow) pageSize = numberOfrow;
            if (page + pageSize > numberOfrow) page = 0;

            return await _context.Movies.Skip(page).Take(pageSize).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoviesView>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            MoviesView moviesView = new MoviesView();
            moviesView.MovieId = movie.MovieId;
            moviesView.Title = movie.Title;
            moviesView.MovieDescription = movie.MovieDescription;
            moviesView.ImgPaths = new List<String>();
            List<int>  ImgPathsId= await _context.ImgPaths
                .Where(x=>x.MovieId == id)
                .Select(x=>x.ImgPathId)
                .ToListAsync();
            foreach(int imgPathId in ImgPathsId)
            {
                String imgPath = await _context.ImgPaths.Where(x=>x.ImgPathId == imgPathId).Select(x=>x.ImgPath1).FirstOrDefaultAsync();
                moviesView.ImgPaths.Add(imgPath);
            }
            moviesView.Actors=new List<Actor>();
            List<int> ActorsId=await _context.ActorsMovies
                .Where(x=>x.MovieId == id)
                .Select(x=>x.ActorId)
                .ToListAsync();
            foreach(var actorId in ActorsId)
            {
                Actor actor = await _context.Actors.FindAsync(actorId);
                moviesView.Actors.Add(actor);
            }

            return moviesView;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieExists(movie.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
