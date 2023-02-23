using PETS.Model;
using PETS.Service;
using PropertyChanged;
using System.Collections.ObjectModel;
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
                await ShowCocktails();
                loading = false;
            });
        }
        public string image { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string like { get; set; }
        public bool loading { get; set; }
        public ObservableCollection<Drink> cocktails
        {
            set; get;
        } = new ObservableCollection<Drink>();

        public async Task ShowCocktails()
        {
            var lstCocktails = await _cocktailService.GetCocktailAsync();
            var itemsCocktail = lstCocktails.Take(10).ToList();
            foreach (var item in itemsCocktail)
            {
                item.like = Like();
                cocktails.Add(item);
            }
        }
        public ICommand UpdateRandomCocktail => new Command(async () =>
        {
            loading = true;
            await ShowCocktail();
            loading = false;
        });
        public ICommand ShareCocktail => new Command(async () =>
        {
            string text = $"¡Hola! El Cocktel {name} en base a Ron se prepara siguiendo los pasos siguientes:\r\n\r\n{description}";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Compartir Cocktel"
            });
        });
        public async Task ShowCocktail()
        {
            var randomCocktail = await _cocktailService.GetCocktailAsync();
            var drink = randomCocktail.FirstOrDefault();
            image = drink.image;
            category = drink.con;
            name = drink.nombre;
            description = SliceDescription(drink.pasos_preparacion);
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
            description = string.Empty;
            var preparations = param.Split('|');
            foreach (string item in preparations)
            {
                description = description + $"● {item.TrimStart()} \r\n\r\n";
            }
            return description;
        }
    }
}
