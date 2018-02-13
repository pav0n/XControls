using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XTextCellWithIcon:XViewCell
    {
        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create("PlaceHolder", typeof(string), typeof(XTextCellWithIcon), "PlaceHolder");
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(XTextCellWithIcon), default(string), BindingMode.TwoWay);
        public static readonly BindableProperty TextDetailProperty =
           BindableProperty.Create("TextDetail", typeof(string), typeof(XTextCellWithIcon), default(string), BindingMode.TwoWay);
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create("Icon", typeof(string), typeof(XTextCellWithIcon), "");

        Label label;
        Label labelDetail;
        Image image;

       

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

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string TextDetail
        {
            get { return (string)GetValue(TextDetailProperty); }
            set { SetValue(TextDetailProperty, value); }
        }


        public XTextCellWithIcon():base()
        {

            var formLayout = new Grid(){
                RowDefinitions = {
                    new RowDefinition(){
                        Height = new GridLength(1, GridUnitType.Star)
                    },
                    new RowDefinition(){
                        Height = new GridLength(1, GridUnitType.Star)
                    }
                },
                ColumnDefinitions = {
                    new ColumnDefinition(){
                        Width = new GridLength(30, GridUnitType.Absolute)
                    },
                    new ColumnDefinition { 
                        Width = new GridLength(1, GridUnitType.Star) 
                    }
                }
            };
            label = new Label()
            {
                Text = Text,
                LineBreakMode = LineBreakMode.TailTruncation,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            labelDetail = new Label()
            {
                Text = TextDetail,
                LineBreakMode = LineBreakMode.TailTruncation,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };
            image = new Image()
            {
                WidthRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                Opacity = 0.5
            };

            formLayout.Children.Add(image, 0, 0);
            formLayout.Children.Add(label, 1, 0);
            formLayout.Children.Add(labelDetail, 1, 1);
            Grid.SetRowSpan(image,2);
            View = formLayout;

        }


        protected override void OnPropertyChanging(string propertyName = null)
        {
            base.OnPropertyChanging(propertyName);
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                label.Text = Text;
            }
            if (propertyName == TextDetailProperty.PropertyName)
            {
                labelDetail.Text = TextDetail;
            }
            if (propertyName == IconProperty.PropertyName)
            {
                image.Source = Icon;
            }

        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                label.Text = Text;
                image.Source = Icon;
                labelDetail.Text = TextDetail;
            }
        }



    }
}
