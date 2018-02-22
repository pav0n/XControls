using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XIconSwitchCell : XIconBaseViewCell
    {
        public static readonly BindableProperty IsToggledProperty = XProperties.IsToggledProperty;
        public static readonly BindableProperty TintColorProperty = XProperties.TintColorProperty;
        public static readonly BindableProperty OnTintColorProperty = XProperties.OnTintColorProperty;
        public static readonly BindableProperty ThumbTintColorProperty = XProperties.ThumbTintColorProperty;

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public Color OnTintColor
        {
            get { return (Color)GetValue(OnTintColorProperty); }
            set { SetValue(OnTintColorProperty, value); }
        }

        public Color ThumbTintColor
        {
            get { return (Color)GetValue(ThumbTintColorProperty); }
            set { SetValue(ThumbTintColorProperty, value); }
        }

        public bool IsToggled
        {
            get
            {
                return (bool)GetValue(IsToggledProperty);
            }
            set
            {
                SetValue(IsToggledProperty, value);
            }
        }
        XSwitch xSwitch;
        public XIconSwitchCell()
        {
            InputHorizontalOptions = LayoutOptions.EndAndExpand;
            xSwitch = new XSwitch
            {
                IsToggled = IsToggled

            };
            xSwitch.SetBinding(Switch.IsToggledProperty, IsToggledProperty.PropertyName);
            xSwitch.BindingContext = this;
            this.FormLayout(xSwitch);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TintColorProperty.PropertyName)
            {
                xSwitch.TintColor = TintColor;
            }
            else if (propertyName == OnTintColorProperty.PropertyName)
            {
                xSwitch.OnTintColor = OnTintColor;
            }
            else if (propertyName == ThumbTintColorProperty.PropertyName)
            {
                xSwitch.ThumbTintColor = ThumbTintColor;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                xSwitch.TintColor = TintColor;
                xSwitch.OnTintColor = OnTintColor;
                xSwitch.ThumbTintColor = ThumbTintColor;
            }
        }
        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            IsToggled = !IsToggled;
        }
    }
}
