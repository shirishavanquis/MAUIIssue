using System;
using UIKit;

namespace LibraryTestAppMaui.iOS
{
    static class FontWeightExtensions
    {
        public static UIFontWeight ToUIFontWeight(this FontWeight fontWeight)
        {
            switch (fontWeight)
            {
                case FontWeight.Thin: return UIFontWeight.Thin;
                case FontWeight.Ultralight: return UIFontWeight.UltraLight;
                case FontWeight.Light: return UIFontWeight.Light;
                case FontWeight.Medium: return UIFontWeight.Medium;
                case FontWeight.Semibold: return UIFontWeight.Semibold;
                case FontWeight.Bold: return UIFontWeight.Bold;
                case FontWeight.Heavy: return UIFontWeight.Heavy;
                case FontWeight.Black: return UIFontWeight.Black;
                default: return UIFontWeight.Regular;
            }
        }
    }
}

