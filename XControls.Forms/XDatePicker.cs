using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XDatePicker:DatePicker
    {
        public static readonly BindableProperty ShowBorderProperty =
            BindableProperty.Create(nameof(ShowBorder), typeof(bool), typeof(XViewCell), false);

        /*public static readonly BindableProperty DisclousureImageProperty =
            BindableProperty.Create(nameof(DisclousureImage), typeof(string), typeof(XViewCell), null);*/
      
        public bool ShowBorder
        {
            get { return (bool)GetValue(ShowBorderProperty); }
            set { SetValue(ShowBorderProperty, value); }
        }
    }
}
