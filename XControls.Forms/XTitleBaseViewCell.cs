using System;
using forms = Xamarin.Forms;
namespace XControls.Forms
{
    public  abstract class XTitleBaseViewCell:XViewCell
    {
        public static readonly forms.BindableProperty TitleProperty =
                                        forms.BindableProperty.Create(nameof(forms.Label), typeof(string), typeof(XTitleBaseViewCell), default(string));

        public string Title
        {
            set { SetValue(TitleProperty, value); }
            get { return (string)GetValue(TitleProperty); }
        }
        
        private forms.Label label;
        protected abstract void FormEntryCell_Tapped(object sender, EventArgs e);

        public void FormLayout(forms.View v)
        {
            var formLayout = new forms.StackLayout
            {
                Orientation = forms.StackOrientation.Horizontal,
                HorizontalOptions = forms.LayoutOptions.FillAndExpand,
                VerticalOptions = forms.LayoutOptions.CenterAndExpand,
            };

            label = new Xamarin.Forms.Label
            {
                VerticalOptions = forms.LayoutOptions.Center,
                WidthRequest = 100,
                Text = Title,
                Margin = new forms.Thickness(12, 0, 0, 0),
                FontSize = forms.Device.GetNamedSize(forms.NamedSize.Medium, typeof(forms.Label)),
                LineBreakMode = forms.LineBreakMode.TailTruncation
            };
            formLayout.Children.Add(label);

            v.HorizontalOptions = forms.LayoutOptions.EndAndExpand;
            v.Margin = new forms.Thickness(0, 0, 12, 0);
            formLayout.Children.Add(v);
            Tapped += FormEntryCell_Tapped;
            View = formLayout;
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TitleProperty.PropertyName)
            {
                label.Text = Title;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                label.Text = Title;
            }
        }
    }
}
