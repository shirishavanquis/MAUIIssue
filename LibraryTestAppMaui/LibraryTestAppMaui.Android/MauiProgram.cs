using System;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace LibraryTestAppMaui.Android
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

                return builder;
            }
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = Builder;
            builder
                .UseMauiCompatibility()
                .UseMauiApp<App>();

            builder.ConfigureMauiHandlers(handlers => {
#if ANDROID
                handlers.AddHandler(typeof(KeyboardWrapperPage), typeof(KeyboardWrapperPageRenderer));
#endif
            });
            builder.Services.AddTransient<MainPage>();
            return builder.Build();
        }
    }
}

