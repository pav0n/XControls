using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XDatePicker), typeof(XDatePickerRenderer))]
namespace XControls.Renderers
{
    public class XDatePickerRenderer:DatePickerRenderer
    {
        public XDatePickerRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            var view = e.NewElement as XDatePicker;
            if (view != null)
            {
                this.updateBorder();
            }
        }
        void updateFontSize()
        {
            var view = Element as XDatePicker;
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
            if (e.PropertyName == XDatePicker.FontSizeProperty.PropertyName)
            {
                this.updateFontSize();
            }
        }
    }
}
