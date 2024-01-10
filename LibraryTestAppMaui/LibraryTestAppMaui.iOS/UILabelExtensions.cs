using System;
using Foundation;
using UIKit;

namespace LibraryTestAppMaui.iOS
{
    public static class UILabelExtensions
    {
        public static void SetUnderlineStyle(this UILabel label, NSUnderlineStyle underlineStyle)
        {
            label.SetAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)underlineStyle));
        }

        public static void SetMinimumLineHeight(this UILabel label, double minimumLineHeight)
        {
            UpdateParagraphStyle(label, x => x.MinimumLineHeight = (nfloat)minimumLineHeight);
        }

        public static void SetLetterSpacing(this UILabel label, double letterSpacing)
        {
            label.SetAttribute(UIStringAttributeKey.KerningAdjustment, NSNumber.FromFloat((float)letterSpacing));
        }

        public static void SetFontWeight(this UILabel label, UIFontWeight fontWeight)
        {
            label.Font = UIFont.SystemFontOfSize(label.Font.PointSize, fontWeight);
        }

        static void UpdateParagraphStyle(UILabel label, Action<NSMutableParagraphStyle> action)
        {
            if (label.Text == null && label.AttributedText == null)
            {
                return;
            }

            if (label.AttributedText == null)
            {
                label.AttributedText = new NSAttributedString(label.Text);
            }

            if (label.AttributedText.Length == 0)
            {
                return;
            }

            action(GetMutableParagraphStyle(label));
        }

        static NSMutableParagraphStyle GetMutableParagraphStyle(UILabel label)
        {
            NSRange outRange;
            var currentParagraphStyle = (NSMutableParagraphStyle)label.AttributedText.GetAttribute(UIStringAttributeKey.ParagraphStyle, 0, out outRange);

            if (currentParagraphStyle != null)
            {
                return currentParagraphStyle;
            }

            // No current paragraph style, create a new one
            var paragraphStyle = new NSMutableParagraphStyle
            {
                Alignment = label.TextAlignment
            };

            label.SetAttribute(UIStringAttributeKey.ParagraphStyle, paragraphStyle);
            return paragraphStyle;
        }

        public static void SetAttribute(this UILabel label, NSString attributeName, NSObject value)
        {
            var attrString = GetMutableAttributedString(label);
            attrString.AddAttribute(attributeName, value, new NSRange(0, attrString.Length));
            label.AttributedText = attrString;
        }

        static NSMutableAttributedString GetMutableAttributedString(UILabel label)
        {
            if (label.AttributedText != null)
            {
                return new NSMutableAttributedString(label.AttributedText);
            }

            if (label.Text != null)
            {
                return new NSMutableAttributedString(label.Text);
            }

            return new NSMutableAttributedString();
        }
    }
}

