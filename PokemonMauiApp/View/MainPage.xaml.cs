using PokemonMauiApp.ViewModel;

namespace PokemonMauiApp.View;

public partial class MainPage : ContentPage
{
	//injects pokemon main page vm
	public MainPage(PokemonsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}