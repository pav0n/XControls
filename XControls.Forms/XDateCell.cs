using System;
using Xamarin.Forms;
namespace XControls.Forms
{
    public class XDateCell:XViewCell
    {

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(XDateCell), default(string));

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create("Date", typeof(DateTime), typeof(XDateCell), default(DateTime), BindingMode.TwoWay);
        
        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create("Format", typeof(string), typeof(XDateCell), "yyyy/MM/dd");

        public string Text
        {
            set {SetValue(TextProperty,value);}
            get{ return (string)GetValue(TextProperty);}
        }

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
        Label label;
        XDatePicker datePicker;
        public XDateCell()
        {
            var formLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            label = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 70,
                Text = Text,
                Margin = new Thickness(12, 0, 0, 0)
            };
            formLayout.Children.Add(label);

            datePicker = new XDatePicker
            {
                Date = Date,
                Format = Format,
                TextColor = Color.Green,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Margin = new Thickness(0, 0, 12, 0)
            };
            formLayout.Children.Add(datePicker);
            Tapped += FormEntryCell_Tapped;
            View = formLayout;
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                label.Text = Text;
            }
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
                label.Text = Text;
                datePicker.Date = Date;
                datePicker.Format = Format;
            }
        }
        private void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
