using PETS.Model;

namespace PETS.Service
{
    public interface ICocktailService
    {
        Task<List<Drink>> GetCocktailAsync();
        //Task<Cocktail> GetRandomCocktailAsync();
    }
}
