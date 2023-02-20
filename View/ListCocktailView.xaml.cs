using PETS.ViewModel;

namespace PETS.View;

public partial class ListCocktailView : ContentPage
{
	public ListCocktailView(ListCocktailViewModel listCocktailViewModel)
	{
		InitializeComponent();
		this.BindingContext = listCocktailViewModel;
	}
}