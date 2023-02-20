using PETS.ViewModel;

namespace PETS.View;

public partial class HomeView : ContentPage
{
    public readonly ListCocktailView _listCocktailView;
    public HomeView(HomeViewModel homeViewModel, ListCocktailView listCocktailView)
    {
        InitializeComponent();
        this.BindingContext = homeViewModel;
        _listCocktailView = listCocktailView;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(_listCocktailView, true);
    }
}