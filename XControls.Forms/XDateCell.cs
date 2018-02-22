using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace XControls.Forms
{
    public class XDateCell:XTitleBaseViewCell
    {
        public static readonly BindableProperty DateProperty = XProperties.DateProperty;

        public static readonly BindableProperty FormatProperty = XProperties.FormatProperty;

        public static readonly BindableProperty DateFontSizeProperty = XProperties.DateFontSizeProperty;

        public static readonly BindableProperty DateColorProperty = XProperties.DateColorProperty;
        
        public DateTime Date
        {
            set { SetValue(DateProperty, value); }
            get { return (DateTime)GetValue(XProperties.DateProperty); }
        }
        public string Format
        {
            set { SetValue(FormatProperty, value); }
            get { return (string)GetValue(XProperties.FormatProperty); }
        }
        public double DateFontSize
        {
            set { SetValue(DateFontSizeProperty, value); }
            get { return (double)GetValue(XProperties.DateFontSizeProperty); }
        }
        public Color DateColor
        {
            set { SetValue(DateColorProperty, value); }
            get { return (Color)GetValue(DateColorProperty); }
        }
        XDatePicker datePicker;
        public XDateCell()
        {
            datePicker = new XDatePicker
            {
                Date = Date,
                Format = Format,
                TextColor = DateColor,
                FontSize = DateFontSize
            };
            datePicker.DateSelected += (sender, e) =>
            {
                Date = e.NewDate;
            };
            this.InputHorizontalOptions = LayoutOptions.EndAndExpand;
            this.FormLayout(datePicker);

        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == DateProperty.PropertyName)
            {
                datePicker.Date = Date;
            }
            else if(propertyName == FormatProperty.PropertyName)
            {
                datePicker.Format = Format;
            }
            else if(propertyName == DateColorProperty.PropertyName)
            {
                datePicker.TextColor = DateColor;
            }
            else if(propertyName == DateFontSizeProperty.PropertyName)
            {
                datePicker.FontSize = DateFontSize;
            }
           
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                datePicker.Date = Date;
                datePicker.Format = Format;
                datePicker.TextColor = DateColor;
                datePicker.FontSize = DateFontSize;
            }
        }


        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
