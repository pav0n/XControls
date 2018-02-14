using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XSwitch:Switch
    {
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(XViewCell), default(Color));
        public static readonly BindableProperty OnTintColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(XViewCell), default(Color));
        public static readonly BindableProperty ThumbTintColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(XViewCell), default(Color));

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set {SetValue(TintColorProperty, value);}
        }

        public Color OnTintColor
        {
            get { return (Color)GetValue(OnTintColorProperty); }
            set { SetValue(OnTintColorProperty, value); }
        }

        public Color ThumbTintColor
        {
            get { return (Color)GetValue(ThumbTintColorProperty); }
            set { SetValue(ThumbTintColorProperty, value); }
        }


    }
}
