using System;
using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XDatePicker), typeof(XDatePickerRenderer))]
namespace XControls.Renderers
{
    public class XDatePickerRenderer:DatePickerRenderer
    {
        public XDatePickerRenderer(Context context):base(context)
        {
            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.updateBorder();
                this.updateFontSize();
            }
        }

        void updateFontSize()
        {
            var view = Element as XDatePicker;
            if(view != null)
            {
                Control.TextSize = (float)view.FontSize;  
            }

        }
        void updateBorder()
        {
            
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == XDatePicker.FontSizeProperty.PropertyName)
            {
                this.updateFontSize();
            }
        }

    }
}
