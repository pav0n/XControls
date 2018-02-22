using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XControls.Forms
{
    public static class XProperties
    {
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create("Date", typeof(DateTime), typeof(XProperties), default(DateTime), BindingMode.TwoWay);

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create("Format", typeof(string), typeof(XProperties), "yyyy/MM/dd");

        public static readonly BindableProperty DateFontSizeProperty =
            BindableProperty.Create("DateFontSize", typeof(double), typeof(XProperties), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public static readonly BindableProperty DateColorProperty =
            BindableProperty.Create("DateColor", typeof(Color), typeof(XProperties), Color.Black);

        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create("PlaceHolder", typeof(string), typeof(XProperties), default(string));

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(XProperties), default(string), BindingMode.TwoWay);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(bool), typeof(XProperties), false);

        public static readonly BindableProperty KeyboardTypeProperty =
            BindableProperty.Create("KeyboardType", typeof(Keyboard), typeof(XProperties), null);

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create("MaxLength", typeof(int), typeof(XProperties), int.MaxValue);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(XProperties), Color.Black);

        public static readonly BindableProperty PlaceHolderColorProperty =
            BindableProperty.Create("PlaceHolderColor", typeof(Color), typeof(XProperties), Color.Black);

        public static readonly BindableProperty SelectorTitleProperty =
            BindableProperty.Create("SelectorTitle", typeof(string), typeof(XProperties), default(string));

        public static readonly BindableProperty CancelTitleProperty =
            BindableProperty.Create("CancelTitle", typeof(string), typeof(XProperties), "Cancel");

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable<string>), typeof(XProperties), new List<string>());

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(XProperties), default(string));

        public static readonly BindableProperty TitleFontSizeProperty =
            BindableProperty.Create("TitleFontSize", typeof(double), typeof(XProperties), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public static readonly BindableProperty TitleColorProperty =
            BindableProperty.Create("TitleColor", typeof(Color), typeof(XProperties), Color.Black);

        public static readonly BindableProperty DetailProperty =
            BindableProperty.Create("Detail", typeof(string), typeof(XProperties), default(string));

        public static readonly BindableProperty DetailColorProperty =
            BindableProperty.Create("DetailColor", typeof(Color), typeof(XProperties), Color.DarkGray);

        public static readonly BindableProperty ExtraDetailProperty =
            BindableProperty.Create("ExtraDetail", typeof(string), typeof(XProperties), default(string));

        public static readonly BindableProperty ExtraDetailColorProperty =
            BindableProperty.Create("ExtraDetailColor", typeof(Color), typeof(XProperties), Color.DarkGray);

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(XProperties), false, defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create("TintColor", typeof(Color), typeof(XProperties), default(Color));
        
        public static readonly BindableProperty OnTintColorProperty =
            BindableProperty.Create("OnTintColor", typeof(Color), typeof(XProperties), default(Color));
        
        public static readonly BindableProperty ThumbTintColorProperty =
            BindableProperty.Create("ThumbTintColor", typeof(Color), typeof(XProperties), default(Color));


    }
}
