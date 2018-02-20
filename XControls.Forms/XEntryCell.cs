using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XEntryCell:XTitleBaseViewCell
    {
        public static readonly BindableProperty PlaceHolderProperty = XProperties.PlaceHolderProperty;
        public static readonly BindableProperty TextProperty = XProperties.TextProperty;
        public static readonly BindableProperty IsPasswordProperty = XProperties.IsPasswordProperty;
        public static readonly BindableProperty KeyboardTypeProperty = XProperties.KeyboardTypeProperty;
        public static readonly BindableProperty MaxLengthProperty = XProperties.MaxLengthProperty;
        public static readonly BindableProperty TextColorProperty = XProperties.TextColorProperty;
        public static readonly BindableProperty PlaceHolderColorProperty = XProperties.PlaceHolderColorProperty;
        
        public Keyboard KeyboardType
        {
            get { return (Keyboard)GetValue(KeyboardTypeProperty); }
            set { SetValue(KeyboardTypeProperty, value); }
        }

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public Color PlaceHolderColor
        {
            get { return (Color)GetValue(PlaceHolderColorProperty); }
            set { SetValue(PlaceHolderColorProperty, value); }
        }
        XEntry entry;
        public XEntryCell()
        {
            InputHorizontalOptions = LayoutOptions.FillAndExpand;
            entry = new XEntry()
            {
                Text = Text,
                Placeholder = PlaceHolder,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasBorder = false,
                AllowClear = true,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                PlaceholderColor = PlaceHolderColor,
                TextColor = TextColor
            };

            entry.TextChanged += (s, e) => Text = e.NewTextValue;
            this.FormLayout(entry);
        }

        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            entry.Focus();
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == PlaceHolderProperty.PropertyName)
            {
                entry.Placeholder = PlaceHolder;
            }
            else if (propertyName == TextProperty.PropertyName)
            {
                entry.Text = Text;
            }
            else if (propertyName == IsPasswordProperty.PropertyName)
            {
                entry.IsPassword = IsPassword;
            }
            else if (propertyName == KeyboardTypeProperty.PropertyName)
            {
                entry.Keyboard = KeyboardType;
            }
            else if (propertyName == MaxLengthProperty.PropertyName)
            {
                entry.MaxLength = MaxLength;
            }
            else if (propertyName == PlaceHolderColorProperty.PropertyName)
            {
                entry.PlaceholderColor = PlaceHolderColor;
            }
            else if(propertyName == TextColorProperty.PropertyName)
            {
                entry.TextColor = TextColor;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                entry.Placeholder = PlaceHolder;
                entry.Text = Text;
                entry.IsPassword = IsPassword;
                entry.MaxLength = MaxLength;
            }
        }
    }
}
