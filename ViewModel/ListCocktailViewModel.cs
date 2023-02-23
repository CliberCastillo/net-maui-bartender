using PETS.Model;
using PETS.Service;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PETS.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public partial class ListCocktailViewModel
    {
        private readonly ICocktailService _cocktailService;
        public ListCocktailViewModel(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
            Task.Run(async () =>
            {
                await ShowCocktails();
            });
        }
        public ICommand LoadMoreCommand => new Command(async () =>
        {
            await RefreshCocktails(cocktails.Count());
        });
        public ICommand RefreshCommand => new Command(async () =>
        {
            IsRefreshing = true;
            cocktails.Clear();
            await ShowCocktails();
            IsRefreshing = false;
        });

        public ObservableCollection<Drink> cocktails
        {
            set; get;
        } = new ObservableCollection<Drink>();
        public bool IsRefreshing { get; set; }

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

        private async Task RefreshCocktails(int index)
        {
            var listado = await _cocktailService.GetCocktailAsync();
            var pageItems = listado.Skip(index).Take(10).ToList();
            foreach (var item in pageItems)
            {
                item.like = Like();
                cocktails.Add(item);
            }
        }
    }
}
