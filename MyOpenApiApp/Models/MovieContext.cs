using Microsoft.EntityFrameworkCore;
using OpenApiLib.Models;

namespace MyOpenApiApp.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
}