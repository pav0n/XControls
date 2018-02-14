using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XControls.Forms;
using XControls.Renderers;
[assembly: ExportRenderer(typeof(XSwitch), typeof(XSwitchRenderer))]
namespace XControls.Renderers
{
    public class XSwitchRenderer:SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);
            var view = e.NewElement as XSwitch;
            if (view != null)
            {
                updateTintColor();
                updayeOnTintColor();
                updateThumbTintColor();
            }
        }

        void updateTintColor()
        {
            var view = Element as XSwitch;
            Control.TintColor = view.TintColor == default(Xamarin.Forms.Color) ? UISwitch.Appearance.OnTintColor : view.TintColor.ToUIColor();

        }
        void updayeOnTintColor()
        {
            var view = Element as XSwitch;
            Control.OnTintColor = view.OnTintColor == default(Xamarin.Forms.Color) ? UISwitch.Appearance.OnTintColor : view.OnTintColor.ToUIColor();
        }
        void updateThumbTintColor()
        {
            var view = Element as XSwitch;
            Control.ThumbTintColor = view.ThumbTintColor == default(Xamarin.Forms.Color) ?  UISwitch.Appearance.ThumbTintColor : view.ThumbTintColor.ToUIColor();
        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(XSwitch.TintColorProperty.PropertyName == e.PropertyName)
            {
                updateTintColor();
            }
            if (XSwitch.OnTintColorProperty.PropertyName == e.PropertyName)
            {
                updayeOnTintColor();
            }
            if (XSwitch.ThumbTintColorProperty.PropertyName == e.PropertyName)
            {
                updateThumbTintColor();
            }
        }
    }
}
