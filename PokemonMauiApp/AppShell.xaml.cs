using PokemonMauiApp.View;

namespace PokemonMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //register route for pookemon details page
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}