using Microsoft.Extensions.Configuration;
using PETS.Service;
using PETS.View;
using PETS.ViewModel;
using System.Reflection;

namespace PETS.Extensions
{
    public static class BuilderExtensions
    {
        public static void ConfigureBuilder(this MauiAppBuilder builder)
        {
            #region View

            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<ListCocktailView>();
            #endregion

            #region ViewModel
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<ListCocktailViewModel>();
            #endregion

            #region SERVICES
            builder.Services.AddTransient<ICocktailService, CocktailService>();
            #endregion
        }
    }
}
