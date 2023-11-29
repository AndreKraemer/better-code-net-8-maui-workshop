using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ElVegetarianoFurio.Profile;
using ElVegetarianoFurio.Data;
using ElVegetarianoFurio.Menu;
using ElVegetarianoFurio.Core;

namespace ElVegetarianoFurio
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IProfileService, ProfileService>();
            builder.Services.AddTransient<ProfilePage, ProfileViewModel>();

            builder.Services.AddSingleton<IDataService, DummyDataService>();
            builder.Services.AddTransient<MainPage, MainViewModel>();

            builder.Services.AddTransientWithShellRoute<CategoryPage, CategoryViewModel>(nameof(CategoryPage));

            return builder.Build();
        }
    }
}