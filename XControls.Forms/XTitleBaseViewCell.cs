using System;
using forms = Xamarin.Forms;
namespace XControls.Forms
{
    public  abstract class XTitleBaseViewCell:XViewCell
    {
        public static readonly forms.BindableProperty TitleProperty = XProperties.TitleProperty;
        public static readonly forms.BindableProperty TitleFontSizeProperty = XProperties.TitleFontSizeProperty;
        public static readonly forms.BindableProperty TitleColorProperty = XProperties.TitleColorProperty;
        public static readonly forms.BindableProperty DetailProperty = XProperties.DetailProperty;
        public static readonly forms.BindableProperty DetailColorProperty = XProperties.DetailColorProperty;
        public static readonly forms.BindableProperty ExtraDetailProperty = XProperties.ExtraDetailProperty;
        public static readonly forms.BindableProperty ExtraDetailColorProperty = XProperties.ExtraDetailColorProperty;

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
        protected forms.LayoutOptions InputHorizontalOptions;
        
        private forms.Label label;
        private forms.Label detail;
        private forms.Label extraDetail;

        private forms.GridLength titleColumnWidth = new forms.GridLength(100, forms.GridUnitType.Absolute);
        private forms.ColumnDefinition titleColumn;

        protected abstract void FormEntryCell_Tapped(object sender, EventArgs e);
        forms.View v;
        public void FormLayout(forms.View v)
        {
            this.v = v;
            titleColumn = new forms.ColumnDefinition()
            {
                Width = titleColumnWidth
            };
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
                    titleColumn,
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Star)
                    },
                    new forms.ColumnDefinition {
                        Width = new forms.GridLength(1, forms.GridUnitType.Auto)
                    }
                },
                Margin = new forms.Thickness(12, 0, 9, 0),
                RowSpacing = 0
            };titleColumn.Width = string.IsNullOrEmpty(Title) ? 0 : titleColumnWidth;
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
                TextColor = DetailColor,
                HorizontalOptions = InputHorizontalOptions

            };
            extraDetail = new forms.Label
            {
                VerticalOptions = forms.LayoutOptions.CenterAndExpand,
                Text = ExtraDetail,
                FontSize = forms.Device.GetNamedSize(forms.NamedSize.Micro, typeof(forms.Label)),
                LineBreakMode = forms.LineBreakMode.TailTruncation,
                TextColor = ExtraDetailColor
            };
            v.HorizontalOptions = InputHorizontalOptions;
            v.VerticalOptions = forms.LayoutOptions.CenterAndExpand;
            formLayout.Children.Add(label, 0, 0);
            formLayout.Children.Add(v, 1, 0);

            formLayout.Children.Add(detail, 1, 1);
            formLayout.Children.Add(extraDetail,2,0);
            forms.Grid.SetRowSpan(label, 2);
            forms.Grid.SetRowSpan(extraDetail, 2);
            Tapped += FormEntryCell_Tapped;
            View = formLayout;
            //formLayout.ForceLayout();
        }


        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TitleProperty.PropertyName)
            {
                titleColumn.Width = string.IsNullOrEmpty(Title) ? 0 : titleColumnWidth;
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
                titleColumn.Width = string.IsNullOrEmpty(Title) ? 0 : titleColumnWidth;
                label.Text = Title;
                label.FontSize = TitleFontSize;
                label.TextColor = TitleColor;
                detail.Text = Detail;
                detail.TextColor = DetailColor;
                extraDetail.Text = ExtraDetail;
                extraDetail.TextColor = ExtraDetailColor;

            }
        }
    }
}
