using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XTimePicker:TimePicker
    {
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(XTimePicker), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
    }
}
