using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XTimePicker), typeof(XTimePickerRenderer))]
namespace XControls.Renderers
{
    public class XTimePickerRenderer:TimePickerRenderer
    {
        public XTimePickerRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            var view = e.NewElement as XTimePicker;
            if (view != null)
            {
                Control.InputView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
                Control.InputAccessoryView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
                //var p = Control.InputView as UIDatePicker;
                //NSString t = (NSString)"ValueChanged";
                this.updateBorder();
            }
        }

        void updateFontSize()
        {
            var view = Element as XTimePicker;
            if (view != null)
            {
                Control.Font = Control.Font.WithSize((float)view.FontSize);
            }

        }

        void updateBorder()
        {

            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == XTimePicker.FontSizeProperty.PropertyName)
            {
                this.updateFontSize();
            }
        }
    }
}
