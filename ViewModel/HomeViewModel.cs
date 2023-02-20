using PETS.Model;
using PETS.Service;
using PropertyChanged;
using System.Windows.Input;

namespace PETS.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public partial class HomeViewModel
    {
        private readonly ICocktailService _cocktailService;
        public HomeViewModel(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
            Task.Run(async () =>
            {
                loading = true;
                await ShowCocktail();
                loading = false;
            });
        }
        public string image { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string like { get; set; }
        public bool loading { get; set; }

        public ICommand UpdateRandomCocktail => new Command(async () =>
        {
            loading = true;
            await ShowCocktail();
            loading = false;
        });
        public ICommand ShareCocktail => new Command(async () =>
        {
            string text = $"¡Hola! El Cocktel {name} de categoria {category} se prepara siguiendo los pasos siguientes:\r\n\r\n {description}";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Compartir Cocktel"
            });
        });
        public async Task ShowCocktail()
        {
            var randomCocktail = await _cocktailService.GetRandomCocktailAsync();
            var drink = randomCocktail.drinks.FirstOrDefault();
            image = drink.strDrinkThumb;
            category = drink.strCategory;
            name = drink.strDrink;
            var descriptionLanguage = drink.strInstructionsES == null ? drink.strInstructions : drink.strInstructionsES;
            description = SliceDescription(descriptionLanguage);
            like = Like();
        }

        public string Like()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 6);
            var like = string.Empty;

            switch (randomNumber)
            {
                case 1:
                    like = "★";
                    break;
                case 2:
                    like = "★★";
                    break;
                case 3:
                    like = "★★★";
                    break;
                case 4:
                    like = "★★★★";
                    break;
                case 5:
                    like = "★★★★★";
                    break;
                default:
                    like = string.Empty;
                    break;
            }
            return like;
        }
        public string SliceDescription(string param)
        {
            int count = 1;
            description = string.Empty;
            var descriptions = param.Split('.');
            foreach (string item in descriptions)
            {
                var countSteps = descriptions.Length - count;
                if (countSteps < 1)
                    break;
                if (count != descriptions.Length)
                {
                    description = description + $"● {item.TrimStart()} \r\n\r\n";
                    count++;
                }
            }
            return description;
        }
    }
}
