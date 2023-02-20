using PETS.View;

namespace PETS;

public partial class App : Application
{
    public App(AppShell appShell)
    {
        InitializeComponent();
        MainPage = appShell;
    }
}
