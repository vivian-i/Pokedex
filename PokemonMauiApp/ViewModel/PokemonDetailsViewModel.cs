using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonMauiApp.Model;
using PokemonMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMauiApp.ViewModel
{
    /**
     * pokemon details vm.
     * from main vm (GoToDetailsAsync() method) -> this detail vm
     */
    [QueryProperty("Pokemon", "Pokemon")]
    public partial class PokemonDetailsViewModel : BaseViewModel
    {
        IMap map;

        public PokemonDetailsViewModel(IMap map) 
        {
            this.map = map;
        }

        [ObservableProperty]
        Pokemon pokemon;

        [RelayCommand]
        async Task OpenMapAsync()
        {
            try
            {
                //open map based on pokemon lat and long
                await map.OpenAsync(Pokemon.Latitude, Pokemon.Longitude,
                    new MapLaunchOptions
                    {
                        Name = Pokemon.Name,
                        NavigationMode = NavigationMode.None
                    });

            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to open map: {ex.Message}", "OK");
            }
        }
    }
} 
