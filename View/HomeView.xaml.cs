using PETS.Service;
using PETS.ViewModel;

namespace PETS.View;

public partial class HomeView : ContentPage
{
    private readonly ICocktailService cocktailService;

    public HomeView(ICocktailService cocktailService)
    {
        InitializeComponent();
        this.BindingContext = new HomeViewModel(cocktailService);
        this.cocktailService = cocktailService;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListCocktailView(this.cocktailService), true);
    }
}