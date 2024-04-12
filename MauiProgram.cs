using GobezTalenTrade.Services;
using CommunityToolkit.Maui;

namespace GobezTalenTrade;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        //Services
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<SkillsService>();
        //Pages
        builder.Services.AddSingleton<SigninViewModel>();
        builder.Services.AddSingleton<SigninPage>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<PostSkillViewModel>();
        builder.Services.AddSingleton<PostSkillPage>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<SettingsPage>();
        return builder.Build();
    }
}