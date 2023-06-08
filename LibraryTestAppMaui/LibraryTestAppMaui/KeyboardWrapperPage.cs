using System;
namespace LibraryTestAppMaui
{
    public class KeyboardWrapperPage : Page, IPageContainer<Page>
    {
        public KeyboardWrapperPage(NavigationPage innerPage)
        {
            BackgroundColor = Colors.White;

            CurrentPage = innerPage;
            InternalChildren.Add(innerPage);
        }

        public Page CurrentPage { get; }

        protected override bool OnBackButtonPressed()
        {
            return CurrentPage.SendBackButtonPressed();
        }
    }
}