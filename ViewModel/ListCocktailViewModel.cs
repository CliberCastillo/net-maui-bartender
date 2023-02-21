using PETS.Model;
using PETS.Service;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
        });
        public ICommand AlertCommand => new Command(async () =>
        {
            await ShowCocktails();
        });
        public ICommand GoHome => new Command(async () =>
        {
            await ShowCocktails();
        });
        public ObservableCollection<Drink> cocktails
        {
            set; get;
        } = new ObservableCollection<Drink>();

        public async Task ShowCocktails()
        {
            var lstCocktails = await _cocktailService.GetCocktailAsync();
            foreach (var item in lstCocktails)
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
    }
}
