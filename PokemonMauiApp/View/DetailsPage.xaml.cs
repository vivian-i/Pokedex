using PokemonMauiApp.ViewModel;

namespace PokemonMauiApp.View;

public partial class DetailsPage : ContentPage
{
	//injects pokemon details vm
	public DetailsPage(PokemonDetailsViewModel viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;
	}

    //mainpage -> detailpage
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}