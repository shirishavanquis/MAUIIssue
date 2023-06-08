using System;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;

namespace LibraryTestAppMaui
{

    public static class MauiProgram
    {
        public static MauiAppBuilder builder;
        public static MauiApp CreateMauiApp()
        {
             builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCompatibility();




            return builder.Build();
        }
    
    }
    
}