using Microsoft.Extensions.Configuration;
using PETS.Model;
using System.Text.Json;

namespace PETS.Service
{
    internal class CocktailService : ICocktailService
    {
        private readonly IConfiguration _configuration;
        public CocktailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Cocktail> GetCocktailAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://thecocktaildb.com/api/json/v1/1/search.php?s=");

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Cocktail>(stream);
        }

        public async Task<Cocktail> GetRandomCocktailAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");

            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Cocktail>(stream);
        }
    }
}
