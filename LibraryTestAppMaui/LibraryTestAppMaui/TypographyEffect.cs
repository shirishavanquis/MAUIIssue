using System;
namespace LibraryTestAppMaui
{
    public enum FontWeight
    {
        Thin,
        Ultralight,
        Light,
        Regular,
        Medium,
        Semibold,
        Bold,
        Heavy,
        Black
    }

    public class TypographyEffect : BaseEffect
    {
        public TypographyEffect() : base(FULL_NAME)
        {
        }

        public const string EFFECT_NAME = nameof(TypographyEffect);
        public const string FULL_NAME = RESOLUTION_GROUP_NAME + "." + EFFECT_NAME;

        public static readonly BindableProperty LineHeightProperty = BindableProperty.Create("LineHeight", typeof(double), typeof(Label), default(double), propertyChanged: UpdateEffect);

        public static double GetLineHeight(BindableObject bindable)
        {
            return (double)bindable.GetValue(LineHeightProperty);
        }

        public static void SetLineHeight(BindableObject bindable, double value)
        {
            bindable.SetValue(LineHeightProperty, value);
        }

        public static readonly BindableProperty LetterSpacingProperty = BindableProperty.Create("LetterSpacing", typeof(double), typeof(Label), default(double), propertyChanged: UpdateEffect);

        public static double GetLetterSpacing(BindableObject bindable)
        {
            return (double)bindable.GetValue(LetterSpacingProperty);
        }

        public static void SetLetterSpacing(BindableObject bindable, double value)
        {
            bindable.SetValue(LetterSpacingProperty, value);
        }

        public static readonly BindableProperty FontWeightProperty = BindableProperty.Create("FontWeight", typeof(FontWeight), typeof(Label), FontWeight.Regular, propertyChanged: UpdateEffect);

        public static FontWeight GetFontWeight(BindableObject bindable)
        {
            return (FontWeight)bindable.GetValue(FontWeightProperty);
        }

        public static void SetFontWeight(BindableObject bindable, FontWeight value)
        {
            bindable.SetValue(FontWeightProperty, value);
        }

        static void UpdateEffect(BindableObject bindable, object oldValue, object newValue)
        {
            CheckAddEffect<View, TypographyEffect>(
                bindable as View,
                FULL_NAME,
                () => (double)bindable.GetValue(LetterSpacingProperty) != default(double)
                      || (double)bindable.GetValue(LineHeightProperty) != default(double)
                      || (FontWeight)bindable.GetValue(FontWeightProperty) != FontWeight.Regular
            );
        }
    }
}

