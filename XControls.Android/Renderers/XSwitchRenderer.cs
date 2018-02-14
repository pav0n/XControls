using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XControls.Forms;
using XControls.Renderers;
[assembly: ExportRenderer(typeof(XSwitch), typeof(XSwitchRenderer))]
namespace XControls.Renderers
{
    public class XSwitchRenderer:SwitchRenderer
    {
        public XSwitchRenderer(Context context): base(context)
        {
            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                Control.CheckedChange -= OnCheckedChange;
            
            if(e.NewElement != null)
            {
                
                Control.CheckedChange += OnCheckedChange;
                if (e.NewElement.IsToggled) updateOnTintColor();
                if (!e.NewElement.IsToggled)updateTintColor();
                updateThumbTintColor();
            }

        }
        void updateTintColor()
        {
            var view = Element as XSwitch;
            if (view.TintColor == default(Xamarin.Forms.Color))  Control.TrackDrawable.ClearColorFilter();
            else Control.TrackDrawable.SetColorFilter(view.TintColor.ToAndroid(),  PorterDuff.Mode.Multiply);

        }
        void updateOnTintColor()
        {
            var view = Element as XSwitch;
            if (view.OnTintColor == default(Xamarin.Forms.Color)) Control.TrackDrawable.ClearColorFilter();
            else Control.TrackDrawable.SetColorFilter(view.OnTintColor.ToAndroid(), PorterDuff.Mode.Multiply);
        }
        void updateThumbTintColor()
        {
            var view = Element as XSwitch;
            if (view.ThumbTintColor == default(Xamarin.Forms.Color)) Control.ThumbDrawable.ClearColorFilter();
            else 
            {
                Control.ThumbDrawable.SetColorFilter(view.ThumbTintColor.ToAndroid(), PorterDuff.Mode.Multiply);
            } 
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs checkedChangeEventArgs)
        {
            var view = Element as XSwitch;
            if (checkedChangeEventArgs.IsChecked)
            {
                updateOnTintColor();
            }
            else
            {
                updateTintColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (XSwitch.TintColorProperty.PropertyName == e.PropertyName)
            {
                updateTintColor();
            }
            if (XSwitch.OnTintColorProperty.PropertyName == e.PropertyName)
            {
                updateOnTintColor();
            }
            if (XSwitch.ThumbTintColorProperty.PropertyName == e.PropertyName)
            {
                updateThumbTintColor();
            }
        }
    }
}
