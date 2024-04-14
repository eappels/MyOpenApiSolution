using MyOpenApiMauiClient.ViewModels;

namespace MyOpenApiMauiClient.Views;

public partial class MovieListView : ContentPage
{
	public MovieListView(MovieListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}