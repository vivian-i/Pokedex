using PokemonMauiApp.Model;
using System.Net.Http.Json;

namespace PokemonMauiApp.Services
{
    /**
     * get pokemon from pokemon api (or from pokemonList if it's not empty)
     */
    public class PokemonService
    {
        HttpClient httpClient;
        //List<Pokemon> pokemonList;
        Pokemon pokemon;

        public PokemonService()
        {
            httpClient = new HttpClient();
        }

        /*
        public async Task<List<Pokemon>> GetPokemons()
        {
            //lightweight data cache if there's a pokemon in the list
            if (pokemonList?.Count > 0)
            {
                return pokemonList;
            }

            //else if pokemonList is null, call pokemon api from the internet
            var url = "https://pokeapi.co/api/v2/pokemon/riolu";
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                pokemonList = await response.Content.ReadFromJsonAsync<List<Pokemon>>();
            }


            return pokemonList;
        }*/

        /**
         * get a pokemon by id
         */
        public async Task<Pokemon> GetPokemonById(int id)
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{id}";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();
            }

            return pokemon;
        }
    }
}
