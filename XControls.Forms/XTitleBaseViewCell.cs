using System;
using forms = Xamarin.Forms;
namespace XControls.Forms
{
    public  abstract class XTitleBaseViewCell:XViewCell
    {
        public static readonly forms.BindableProperty TitleProperty =
                                        forms.BindableProperty.Create(nameof(Title), typeof(string), typeof(XTitleBaseViewCell), default(string));
        
        public static readonly forms.BindableProperty TitleFontSizeProperty =
                                        forms.BindableProperty.Create(nameof(TitleFontSize), typeof(double), typeof(XTitleBaseViewCell), forms.Device.GetNamedSize(forms.NamedSize.Medium, typeof(forms.Label)));

        public static readonly forms.BindableProperty TitleColorProperty =
                                        forms.BindableProperty.Create(nameof(TitleColor), typeof(forms.Color), typeof(XTitleBaseViewCell), forms.Color.Black);
        public static readonly forms.BindableProperty DetailProperty =
                                        forms.BindableProperty.Create(nameof(Detail), typeof(string), typeof(XTitleBaseViewCell), default(string));
        public static readonly forms.BindableProperty DetailColorProperty =
                                        forms.BindableProperty.Create(nameof(DetailColor), typeof(forms.Color), typeof(XTitleBaseViewCell), forms.Color.DarkGray);
        public string Title
        {
            set { SetValue(TitleProperty, value); }
            get { return (string)GetValue(TitleProperty); }
        }

        public double TitleFontSize
        {
            set { SetValue(TitleFontSizeProperty, value); }
            get { return (double)GetValue(TitleFontSizeProperty); }
        }
        public forms.Color TitleColor
        {
            set { SetValue(TitleColorProperty, value); }
            get { return (forms.Color)GetValue(TitleColorProperty); }
        }
        public forms.Color DetailColor
        {
            set { SetValue(DetailColorProperty, value); }
            get { return (forms.Color)GetValue(DetailColorProperty); }
        }

        public string Detail
        {
            set { SetValue(DetailProperty, value); }
            get { return (string)GetValue(DetailProperty); }
        }
        
        private forms.Label label;
        private forms.Label detail;

        protected abstract void FormEntryCell_Tapped(object sender, EventArgs e);

        public void FormLayout(forms.View v)
        {
            var formLayout = new forms.Grid()
            {
                RowDefinitions = {
                    new forms.RowDefinition(){
                        Height = new forms.GridLength(1, forms.GridUnitType.Star)
                    },
                    new forms.RowDefinition(){
                        Height = new forms.GridLength(1, forms.GridUnitType.Auto)
                    }
                },
                ColumnDefinitions = {
                    new forms.ColumnDefinition(){
                        Width = new forms.GridLength(120, forms.GridUnitType.Absolute)
                    },
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Star)
                    }
                },
                Margin = new forms.Thickness(12, 0, 12, 0),
                RowSpacing = 0
            };

            label = new forms.Label
            {
                VerticalOptions = forms.LayoutOptions.CenterAndExpand,
                Text = Title,
                FontSize = TitleFontSize,
                LineBreakMode = forms.LineBreakMode.TailTruncation,
                TextColor = TitleColor,
                HorizontalOptions = forms.LayoutOptions.FillAndExpand,
            };

            detail = new forms.Label
            {
                VerticalOptions = forms.LayoutOptions.FillAndExpand,
                Text = Detail,
                FontSize = forms.Device.GetNamedSize(forms.NamedSize.Micro, typeof(forms.Label)),
                LineBreakMode = forms.LineBreakMode.TailTruncation,
                TextColor = DetailColor
            };
            v.HorizontalOptions = forms.LayoutOptions.EndAndExpand;
            v.VerticalOptions = forms.LayoutOptions.CenterAndExpand;
            formLayout.Children.Add(label, 0, 0);
            formLayout.Children.Add(v, 1, 0);
            formLayout.Children.Add(detail, 1, 1);
            forms.Grid.SetRowSpan(label, 2);
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
            else if (propertyName == TitleColorProperty.PropertyName)
            {
                label.TextColor = TitleColor;
            }
            else if (propertyName == TitleFontSizeProperty.PropertyName)
            {
                label.FontSize = TitleFontSize;
            }
            else if(propertyName == DetailProperty.PropertyName)
            {
                detail.Text = Detail;
            }
            else if (propertyName == DetailColorProperty.PropertyName)
            {
                detail.TextColor = DetailColor;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                label.Text = Title;
                label.FontSize = TitleFontSize;
                label.TextColor = TitleColor;
                detail.Text = Detail;
                detail.TextColor = DetailColor;
            }
        }
    }
}
