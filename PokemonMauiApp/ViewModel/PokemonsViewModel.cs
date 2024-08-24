using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using PokemonMauiApp.Model;
using PokemonMauiApp.Services;
using PokemonMauiApp.View;
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
     *  main vm
     */
    public partial class PokemonsViewModel : BaseViewModel
    {
        PokemonService pokemonService;
        public ObservableCollection<Pokemon> Pokemons { get; } = new();

        IConnectivity connectivity;
        IGeolocation geolocation;
        IMap map;

        [ObservableProperty]
        bool isRefreshing;

        //injects PokemonService to PokemonViewModel
        public PokemonsViewModel(PokemonService pokemonService, IConnectivity connectivity, IGeolocation geolocation, IMap map) 
        {
            Title = "Poke";
            this.pokemonService = pokemonService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
            this.map = map;
        }

        /** 
         * get the closest pokemon
         */
        [RelayCommand]
        async Task GetClosestPokemonAsync()
        {
            if(IsBusy || Pokemons.Count == 0)
            {
                return;
            }

            try
            {
                //cache geolocation
                var location = await geolocation.GetLastKnownLocationAsync();
                //if location is null, get user current location
                if(location is null)
                { 
                    location = await geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(20)
                        });
                }

                if (location is null) return;

                //get the closest monkey based on user's location
                Pokemon closestPokemon = Pokemons.OrderBy(p =>
                location.CalculateDistance(p.Latitude, p.Longitude, DistanceUnits.Miles)
                ).FirstOrDefault();

                if(closestPokemon is null) return;

                //
                await Shell.Current.DisplayAlert("Closest Pokemon",
                    $"{closestPokemon.Name} in {location}({closestPokemon.Latitude},{closestPokemon.Longitude})", "OK");

            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    "Unable to get closest pokemon. " + ex.Message, "OK");
            }
        }

        /*
        [RelayCommand]
        async Task GetPokemonsAsync()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;
                //get pokemons from cache memory / internet
                var pokemons = await pokemonService.GetPokemons();
              
                if(Pokemons.Count != 0)
                {
                    Pokemons.Clear();
                }

                //add pokemon to the list
                foreach(var pokemon in pokemons)
                {
                    Pokemons.Add(pokemon);
                }
            }
            catch(Exception ex) 
            { 
                Debug.WriteLine(ex);
                //tbc : create stg like an interface and then inject this so not directly accesing ui in viewmodel
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to get pokemons: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }*/

        /**
         * get all pokemons by id
         */
        [RelayCommand]
        async Task GetPokemonsByIdAsync() 
        {
            if (IsBusy) return;

            try
            {
                if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Connection Issue", 
                        "Check your internet connection and try again", "OK");
                    return;
                }

                IsBusy = true;

                if (Pokemons.Count != 0)
                {
                    Pokemons.Clear();
                }

                for (int i=0; i<20; i++)
                {
                    //get pokemons from poke api
                    Pokemon pokemon = await pokemonService.GetPokemonById(i);
                    Pokemons.Add(pokemon);
                }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to get pokemon by id: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        /**
         * go to pokemon details page
         */
        [RelayCommand]
        async Task GoToDetailsAsync(Pokemon pokemon)
        {
            if(pokemon is null) return;

            //go to details page
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {"Pokemon", pokemon}
                });
            
        }

    }
}
