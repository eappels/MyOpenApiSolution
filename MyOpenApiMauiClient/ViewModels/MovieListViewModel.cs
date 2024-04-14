using MyOpenApiMauiClient.Services.Interfaces;
using OpenApiLib.Models;
using System.Diagnostics;
using System.Windows.Input;

namespace MyOpenApiMauiClient.ViewModels;

public class MovieListViewModel : ViewModel
{

    private readonly IOpenApiConsumerService apiConsumerService;
    public ICommand GetMovieListCommand { get; private set; }
    
    public MovieListViewModel(IOpenApiConsumerService apiConsumerService)
    {
        this.apiConsumerService = apiConsumerService;        
        GetMovieListCommand = new Command(async () => await GetMovieList());
    }

    private async Task GetMovieList()
    {
        MovieList = new List<Movie>();
        MovieList = await apiConsumerService.GetMovieList();
    }

    private List<Movie> movieList;
    public List<Movie> MovieList
    {
        get => movieList;
        set
        {
            SetProperty(ref movieList, value);
            movieList.ForEach(m => Debug.WriteLine($"Id: {m.Id} Title: {m.Title} Genre: {m.Genre} ReleaseDate: {m.ReleaseDate} "));
        }
    }
}