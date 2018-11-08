using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace PokemonWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://pokemondb.net/pokedex/national
            var client = new HttpClient();

            var result = client.GetStringAsync("https://pokemondb.net/pokedex/national").Result;
        }
    }
}
