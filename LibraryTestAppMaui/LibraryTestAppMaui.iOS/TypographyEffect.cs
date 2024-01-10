using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;
using UIKit;
using LibraryTestAppMaui;

namespace LibraryTestAppMaui.iOS
{
    public class TypographyEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            UpdateLineHeightAttributed();
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Label.Text) || e.PropertyName == nameof(Label.FormattedText))
            {
                UpdateLineHeightAttributed();
            }
        }

        UILabel NativeLabel => Control as UILabel;

        void UpdateLineHeightAttributed()
        {
            if (NativeLabel == null)
            {
                return;
            }

            UpdateParagraphStyle();
        }

        void UpdateParagraphStyle()
        {
            var lineHeight = LibraryTestAppMaui.TypographyEffect.GetLineHeight(Element);
            NativeLabel.SetMinimumLineHeight(lineHeight);

            var letterSpacing = LibraryTestAppMaui.TypographyEffect.GetLetterSpacing(Element);
            NativeLabel.SetLetterSpacing(letterSpacing);

            var fontWeight = LibraryTestAppMaui.TypographyEffect.GetFontWeight(Element);

            if (fontWeight != FontWeight.Regular)
            {
                // only apply if we really need to
                NativeLabel.SetFontWeight(fontWeight.ToUIFontWeight());
            }
        }
    }
}

