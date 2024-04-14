using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOpenApiApp.Models;
using OpenApiLib.Models;

namespace MyOpenApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly MovieContext movieContext;

    public MoviesController(MovieContext movieContext)
    {
        this.movieContext = movieContext;
    }

    //GET: api/movies
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
    {
        if (movieContext.Movies == null)
        {
            return NotFound();
        }
        return await movieContext.Movies.ToListAsync();
    }

    //GET: api/movies/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        if (movieContext.Movies == null)
        {
            return NotFound();
        }
        var movie = await movieContext.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return movie;
    }

    //POST: api/movies
    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    {
        movieContext.Movies.Add(movie);
        await movieContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }
}