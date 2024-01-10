using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace LibraryTestAppMaui
{
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

        public App (MainPage mainPage)
        {
            InitializeComponent();

             MainPage = mainPage;
        }

        private Page CreateMainPage(NavigationPage navigationPage)
        {
            return new KeyboardWrapperPage(navigationPage);

        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
       
    }
}

