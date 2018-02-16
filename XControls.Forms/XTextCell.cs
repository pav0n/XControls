using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XTextCell:XTitleBaseViewCell
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(XTextCell), default(string), BindingMode.TwoWay);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        Label label;
        public XTextCell()
        {
            label = new Label
            {
                Text = Text,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.DarkGray
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

        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                label.Text = Text;
            }
        }
    }
}
