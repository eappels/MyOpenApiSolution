using MyOpenApiMauiClient.Services.Interfaces;
using OpenApiLib.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MyOpenApiMauiClient.Services;

public class OpenApiConsumerService : IOpenApiConsumerService
{

    private HttpClient client;
    JsonSerializerOptions serializerOptions;
    public List<Movie> Movies { get; private set; }

    public OpenApiConsumerService()
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        client = new HttpClient(handler);
        serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<List<Movie>> GetMovieList()
    {
        Movies = new List<Movie>();
        
        
        try
        {
            var response = await client.GetAsync("https://192.168.10.100:7088/api/movies");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Movies = JsonSerializer.Deserialize<List<Movie>>(content, serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
            Debug.WriteLine(ex.InnerException);
        }


        return Movies;
    }
}