using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XIconEntryCell:XIconBaseViewCell
    {
        public static readonly BindableProperty PlaceHolderProperty = XProperties.PlaceHolderProperty;
        public static readonly BindableProperty TextProperty = XProperties.TextProperty;
        public static readonly BindableProperty IsPasswordProperty = XProperties.IsPasswordProperty;
        public static readonly BindableProperty KeyboardTypeProperty = XProperties.KeyboardTypeProperty;
        public static readonly BindableProperty MaxLengthProperty = XProperties.MaxLengthProperty;
        
        XEntry entry;

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
        public XIconEntryCell():base()
        {
            entry = new XEntry()
            {
                Text = Text,
                Placeholder = PlaceHolder,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasBorder = false,
                AllowClear = true,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry))
            };

            entry.TextChanged += (s, e) => Text = e.NewTextValue;
            this.FormLayout(entry);
        }


        protected override void OnPropertyChanging(string propertyName = null)
        {
            base.OnPropertyChanging(propertyName);
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == PlaceHolderProperty.PropertyName)
            {
                entry.Placeholder = PlaceHolder;
            }
            if (propertyName == TextProperty.PropertyName)
            {
                entry.Text = Text;
            }
            if (propertyName == IsPasswordProperty.PropertyName)
            {
                entry.IsPassword = IsPassword;
            }
            if (propertyName == KeyboardTypeProperty.PropertyName)
            {
                entry.Keyboard = KeyboardType;
            }
            if(propertyName == MaxLengthProperty.PropertyName)
            {
                entry.MaxLength = MaxLength;
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


        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            entry.Focus();
        }
    }

}
