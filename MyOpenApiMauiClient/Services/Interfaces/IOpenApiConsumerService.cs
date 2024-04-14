using OpenApiLib.Models;

namespace MyOpenApiMauiClient.Services.Interfaces;

public interface IOpenApiConsumerService
{
    Task<List<Movie>> GetMovieList();
}