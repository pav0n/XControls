using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XViewCell:ViewCell
    {
        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(XViewCell), Color.White);

        public static readonly BindableProperty ShowDisclosureProperty =
            BindableProperty.Create(nameof(ShowDisclosure), typeof(bool), typeof(XViewCell), false);

        /*public static readonly BindableProperty DisclousureImageProperty =
            BindableProperty.Create(nameof(DisclousureImage), typeof(string), typeof(XViewCell), null);*/
        
        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public bool ShowDisclosure
        {
            get { return (bool)GetValue(ShowDisclosureProperty); }
            set { SetValue(ShowDisclosureProperty, value); }
        }

        /*public string DisclousureImage
        {
            get { return (string)GetValue(DisclousureImageProperty); }
            set { SetValue(DisclousureImageProperty, value); }
        }*/


    }
}
