using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XTimeCell:XTitleBaseViewCell
    {

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(TimeSpan), typeof(XTimeCell), default(TimeSpan), BindingMode.TwoWay);

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(XTimeCell), "HH:mm:ss");

        public static readonly BindableProperty TimeFontSizeProperty =
            BindableProperty.Create(nameof(TimeFontSize), typeof(double), typeof(XTimeCell), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public static readonly BindableProperty TimeColorProperty =
            BindableProperty.Create(nameof(TimeColor), typeof(Color), typeof(XTimeCell), Color.Black);

        public TimeSpan Time
        {
            set { SetValue(TimeProperty, value); }
            get { return (TimeSpan)GetValue(TimeProperty); }
        }
        public string Format
        {
            set { SetValue(FormatProperty, value); }
            get { return (string)GetValue(FormatProperty); }
        }
        public double TimeFontSize
        {
            set { SetValue(TimeFontSizeProperty, value); }
            get { return (double)GetValue(TimeFontSizeProperty); }
        }
        public Color TimeColor
        {
            set { SetValue(TimeColorProperty, value); }
            get { return (Color)GetValue(TimeColorProperty); }
        }
        XTimePicker timePicker;

        public XTimeCell()
        {
            timePicker = new XTimePicker
            {
                Format = Format,
                TextColor = TimeColor
            };
            timePicker.SetBinding(TimePicker.TimeProperty, TimeProperty.PropertyName);

            timePicker.BindingContext = this;
            this.InputHorizontalOptions = LayoutOptions.EndAndExpand;
            this.FormLayout(timePicker);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == TimeColorProperty.PropertyName)
            {
                timePicker.TextColor = TimeColor;
            }
            else if(propertyName == TimeFontSizeProperty.PropertyName)
            {
                timePicker.FontSize = TimeFontSize;
            }
            else if(propertyName == FormatProperty.PropertyName)
            {
                timePicker.Format = Format;
            }


        }

        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            timePicker.Focus();
        }
    }
}
