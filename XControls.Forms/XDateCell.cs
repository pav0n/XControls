using System;
using Xamarin.Forms;
namespace XControls.Forms
{
    public class XDateCell:XTitleBaseViewCell
    {

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(XDateCell), default(DateTime), BindingMode.TwoWay);
        
        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(XDateCell), "yyyy/MM/dd");

        public static readonly BindableProperty DateFontSizeProperty =
            BindableProperty.Create(nameof(DateFontSize), typeof(double), typeof(XDateCell), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public static readonly BindableProperty DateColorProperty =
            BindableProperty.Create(nameof(DateColor), typeof(Color), typeof(XDateCell), Color.Black);

        public DateTime Date
        {
            set { SetValue(DateProperty, value); }
            get { return (DateTime)GetValue(DateProperty); }
        }
        public string Format
        {
            set { SetValue(FormatProperty, value); }
            get { return (string)GetValue(FormatProperty); }
        }
        public double DateFontSize
        {
            set { SetValue(DateFontSizeProperty, value); }
            get { return (double)GetValue(DateFontSizeProperty); }
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
