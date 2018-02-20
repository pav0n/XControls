using System;
using forms = Xamarin.Forms;

namespace XControls.Forms
{
    public abstract class XIconBaseViewCell:XViewCell
    {
        public static readonly forms.BindableProperty DetailProperty = XProperties.DetailProperty;
        public static readonly forms.BindableProperty DetailColorProperty = XProperties.DetailColorProperty;
        public static readonly forms.BindableProperty ExtraDetailProperty = XProperties.ExtraDetailProperty;
        public static readonly forms.BindableProperty ExtraDetailColorProperty = XProperties.ExtraDetailColorProperty;
        public static readonly forms.BindableProperty IconProperty =
                                        forms.BindableProperty.Create(nameof(Icon), typeof(forms.ImageSource), typeof(XIconBaseViewCell), null);

        public forms.ImageSource Icon
        {
            set { SetValue(IconProperty, value); }
            get { return (forms.ImageSource)GetValue(IconProperty); }
        }


        public forms.Color DetailColor
        {
            set { SetValue(DetailColorProperty, value); }
            get { return (forms.Color)GetValue(DetailColorProperty); }
        }

        public string ExtraDetail
        {
            set { SetValue(ExtraDetailProperty, value); }
            get { return (string)GetValue(ExtraDetailProperty); }
        }

        public forms.Color ExtraDetailColor
        {
            set { SetValue(ExtraDetailColorProperty, value); }
            get { return (forms.Color)GetValue(ExtraDetailColorProperty); }
        }

        public string Detail
        {
            set { SetValue(DetailProperty, value); }
            get { return (string)GetValue(DetailProperty); }
        }
        public forms.LayoutOptions InputHorizontalOptions = forms.LayoutOptions.FillAndExpand;

        private forms.Image icon;
        private forms.Label detail;
        private forms.Label extraDetail;

     


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
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Auto)
                    },
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Star)
                    },
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Auto)
                    }
                },
                Margin = new forms.Thickness(12, 0, 12, 0),
                RowSpacing = 0
            }; 

            icon = new forms.Image()
            {
                VerticalOptions = forms.LayoutOptions.Center,
                Opacity = 0.5
            };
            icon.WidthRequest = Icon == null ? 0 : 30;

            detail = new forms.Label
            {
                VerticalOptions = forms.LayoutOptions.FillAndExpand,
                Text = Detail,
                FontSize = forms.Device.GetNamedSize(forms.NamedSize.Micro, typeof(forms.Label)),
                LineBreakMode = forms.LineBreakMode.TailTruncation,
                TextColor = DetailColor
            };
            extraDetail = new forms.Label
            {
                VerticalOptions = forms.LayoutOptions.FillAndExpand,
                Text = ExtraDetail ,
                FontSize = forms.Device.GetNamedSize(forms.NamedSize.Micro, typeof(forms.Label)),
                LineBreakMode = forms.LineBreakMode.TailTruncation,
                TextColor = ExtraDetailColor
            };
            v.HorizontalOptions = InputHorizontalOptions;
            v.VerticalOptions = forms.LayoutOptions.CenterAndExpand;
            formLayout.Children.Add(icon, 0, 0);
            formLayout.Children.Add(v, 1, 0);
            formLayout.Children.Add(detail, 1, 1);
            formLayout.Children.Add(extraDetail, 2, 0);
            forms.Grid.SetRowSpan(icon, 2);
            forms.Grid.SetRowSpan(extraDetail, 2);
            Tapped += FormEntryCell_Tapped;
            View = formLayout;
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == IconProperty.PropertyName)
            {
                icon.WidthRequest = Icon == null ? 0 : 30;
                icon.Source = Icon;
            }
            else if (propertyName == DetailProperty.PropertyName)
            {
                detail.Text = Detail;
            }
            else if (propertyName == DetailColorProperty.PropertyName)
            {
                detail.TextColor = DetailColor;
            }
            else if (propertyName == ExtraDetailProperty.PropertyName)
            {
                extraDetail.Text = ExtraDetail;
            }
            else if (propertyName == ExtraDetailColorProperty.PropertyName)
            {
                extraDetail.TextColor = ExtraDetailColor;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                icon.WidthRequest = Icon == null ? 0 : 30;
                icon.Source = Icon;

                detail.Text = Detail;
                detail.TextColor = DetailColor;
                extraDetail.Text = ExtraDetail;
                extraDetail.TextColor = ExtraDetailColor;
            }
        }
    }
}
