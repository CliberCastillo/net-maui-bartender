using PETS.Model;

namespace PETS.Service
{
    public interface ICocktailService
    {
        Task<Cocktail> GetCocktailAsync();
        Task<Cocktail> GetRandomCocktailAsync();
    }
}
