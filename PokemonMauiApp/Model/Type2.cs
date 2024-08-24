using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMauiApp.Model
{
    public class Type2
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Color Color => Name switch
        {
            "normal" => Color.Parse("#A8A77A"),
            "fire" => Color.Parse("#EE8130"),
            "water" => Color.Parse("#6390F0"),
            "electric" => Color.Parse("#F7D02C"),
            "grass" => Color.Parse("#7AC74C"),
            "ice" => Color.Parse("#96D9D6"),
            "fighting" => Color.Parse("#C22E28"),
            "poison" => Color.Parse("#A33EA1"),
            "ground" => Color.Parse("#E2BF65"),
            "flying" => Color.Parse("#A98FF3"),
            "psychic" => Color.Parse("#F95587"),
            "bug" => Color.Parse("#A6B91A"),
            "rock" => Color.Parse("#B6A136"),
            "ghost" => Color.Parse("#735797"),
            "dragon" => Color.Parse("#6F35FC"),
            "dark" => Color.Parse("#705746"),
            "steel" => Color.Parse("#B7B7CE"),
            "fairy" => Color.Parse("#D685AD"),
            _ => Color.Parse("#0190FF")
        };
    }
}
