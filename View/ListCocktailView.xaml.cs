using PETS.Service;
using PETS.ViewModel;

namespace PETS.View;

public partial class ListCocktailView : ContentPage
{
    private readonly ICocktailService cocktailService;

    public ListCocktailView(ICocktailService cocktailService)
	{
		InitializeComponent();
		this.BindingContext = new ListCocktailViewModel(cocktailService);
        this.cocktailService = cocktailService;
    }

    private async Task Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomeView(this.cocktailService), true);
    }
}