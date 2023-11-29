using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ElVegetarianoFurio.Profile;

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

            builder.Services.AddSingleton<IProfileService, ProfileService>();
            builder.Services.AddTransient<ProfilePage, ProfileViewModel>();

            return builder.Build();
        }
    }
}