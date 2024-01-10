using System;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Hosting;
namespace LibraryTestAppMaui.iOS
{
    public static class MauiProgram
    {
        public static MauiAppBuilder builder;
        public static MauiAppBuilder Builder
        {
            get
            {
                if (builder == null)
                {
                    builder = MauiApp.CreateBuilder();
                }
                builder.ConfigureEffects(effects =>
                {
                    effects.Add<LibraryTestAppMaui.TypographyEffect, TypographyEffect>();
                });
                return builder;
            }
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = Builder;
            builder.UseMauiCompatibility().UseMauiApp<App>().UseMauiCommunityToolkit();

            builder.Services.AddTransient<MainPage>();
           // builder.Services.AddScoped<UILabelExtensions>();

            return builder.Build();
        }
    }
}