using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XTextCell:XTitleBaseViewCell
    {
        public static readonly BindableProperty TextProperty = XProperties.TextProperty;
        public static readonly BindableProperty TextColorProperty = XProperties.TextColorProperty;
        
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        Label label;

        public XTextCell()
        {
            InputHorizontalOptions = LayoutOptions.FillAndExpand;
            label = new Label
            {
                Text = Text,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = TextColor
            };
            this.FormLayout(label);
        }

        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                label.Text = Text;
            }
            else if (propertyName == TextColorProperty.PropertyName)
            {
                label.TextColor = TextColor;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                label.Text = Text;
                label.TextColor = TextColor;
            }
        }
    }
}
