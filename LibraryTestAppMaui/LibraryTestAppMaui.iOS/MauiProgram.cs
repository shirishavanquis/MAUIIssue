using System;
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

                return builder;
            }
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = Builder;
            builder.UseMauiCompatibility().UseMauiApp<App>();

               

            return builder.Build();
        }
    }
}