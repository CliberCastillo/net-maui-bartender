using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PETS.Model;

namespace PETS.Service
{
    internal class CocktailService : ICocktailService
    {
        private readonly IConfiguration _configuration;
        public CocktailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Drink>> GetCocktailAsync()
        {
            var lstDrink = await CocktailDataAsynsc();
            return lstDrink;
        }

        //public async Task<Cocktail> GetRandomCocktailAsync()
        //{
        //    files();
        //    using var client = new HttpClient();
        //    var response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");

        //    using var stream = await response.Content.ReadAsStreamAsync();
        //    return await System.Text.Json.JsonSerializer.DeserializeAsync<Cocktail>(stream);
        //}
        public async Task<List<Drink>> CocktailDataAsynsc()
        {
            using Stream filestream = await FileSystem.Current.OpenAppPackageFileAsync("MAUI.json");
            using StreamReader streamReader = new StreamReader(filestream);
            string contenidoJson = streamReader.ReadToEnd();
            var lstDrink = JsonConvert.DeserializeObject<List<Drink>>(contenidoJson);
            return lstDrink.ToList();
        }
    }
}
