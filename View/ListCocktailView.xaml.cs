using PETS.ViewModel;

namespace PETS.View;

public partial class ListCocktailView : ContentPage
{
	public ListCocktailView(ListCocktailViewModel listCocktailViewModel)
	{
		InitializeComponent();
		this.BindingContext = listCocktailViewModel;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}