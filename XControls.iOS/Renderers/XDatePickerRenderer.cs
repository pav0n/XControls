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
                this.UpdateBorder();
            }
        }

        void UpdateBorder()
        {
            
           Control.BorderStyle = UIKit.UITextBorderStyle.None; 
        }
    }
}
