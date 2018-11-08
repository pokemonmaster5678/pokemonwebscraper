using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace PokemonWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://pokemondb.net/pokedex/national
            var client = new HttpClient();

            var html = client
                .GetStringAsync("https://pokemondb.net/pokedex/national")
                .Result;

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var divs = doc
                .DocumentNode
                .SelectNodes("html/body/main/div");

            var generations = divs
                .Skip(2)
                .Take(7);

            foreach (var gen in generations)
            {
                var pokemonDivs = gen.SelectNodes("div");

                foreach (var pokemonDiv in pokemonDivs)
                {
                    var name = pokemonDivs
                        .SelectSingleNode("spab[2]/br/a")
                        .InnerText;
                }
            }
        }

        //<div/span[2]/
        
        //div/span[2]/small[2]/a

        //div/span[1]/1/span(@data-src)
    }

    class PokemonData
    {
        public string Name { get; }
        public string[] Types { get; }
        public string ImageLink { get; }

        public PokemonData(string name, string[] types, string imageLink)
        {
            Name = name;
            Types = types;
            ImageLink = imageLink;
        }
    }
}
