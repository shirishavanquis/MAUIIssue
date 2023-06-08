using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using AndroidPlatform = Microsoft.Maui.Controls.Compatibility.Platform.Android.Platform;

namespace LibraryTestAppMaui.Android
{
    public class KeyboardWrapperPageRenderer : Microsoft.Maui.Controls.Handlers.Compatibility.VisualElementRenderer<KeyboardWrapperPage>
    {
        bool disposed;
        FrameLayout pageContainer;
        IPageController PageController => Element;

        int KEYBOARD_HEIGHT => (int)Context.Resources.GetDimension(260);

        public KeyboardWrapperPageRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<KeyboardWrapperPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var bottomBarPage = e.NewElement;

                if (pageContainer == null)
                {
                    pageContainer = CreatePageContainer(Context);
                    AddView(pageContainer);

                    RequestLayout();
                }

                UpdateContent();
            }
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            PageController.SendAppearing();
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            PageController.SendDisappearing();
        }

        void UpdateContent()
        {
            pageContainer.RemoveAllViews();

            var page = Element?.CurrentPage;
            if (page != null)
            {
                pageContainer.AddView(GetRenderer(page, Context).View);
               // AddView(Keyboard.KeyboardView);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;

                RemoveAllViews();

                var pageRenderer = AndroidPlatform.GetRenderer(Element.CurrentPage);

                if (pageRenderer != null)
                {
                    pageRenderer.View.RemoveFromParent();
                    pageRenderer.Dispose();
                }

                pageContainer?.Dispose();
            }

            base.Dispose(disposing);
        }

        static FrameLayout CreatePageContainer(Context context)
        {
            return new FrameLayout(context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, GravityFlags.Fill)
            };
        }

        static IVisualElementRenderer GetRenderer(VisualElement element, Context context)
        {
            var renderer = AndroidPlatform.GetRenderer(element);
            if (renderer == null)
            {
                renderer = AndroidPlatform.CreateRendererWithContext(element, context);
                AndroidPlatform.SetRenderer(element, renderer);
            }

            return renderer;
        }
    }
}