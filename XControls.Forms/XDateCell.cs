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

        XDatePicker datePicker;
        public XDateCell()
        {
            datePicker = new XDatePicker
            {
                Date = Date,
                Format = Format,
                TextColor = Color.Green
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
            if(propertyName == FormatProperty.PropertyName)
            {
                datePicker.Format = Format;
            }
           
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                datePicker.Date = Date;
                datePicker.Format = Format;
            }
        }


        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
