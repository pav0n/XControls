using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XDatePicker:DatePicker
    {
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(XDateCell), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));
        public double FontSize
        {
            get{ return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
    }
}
