using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XActionSheetCell : XTitleBaseViewCell
    {
        
        public static readonly BindableProperty SelectorTitleProperty =
            BindableProperty.Create(nameof(SelectorTitle), typeof(string), typeof(XActionSheetCell), default(string));

        public static readonly BindableProperty CancelTitleProperty =
            BindableProperty.Create(nameof(CancelTitle), typeof(string), typeof(XActionSheetCell), "Cancel");
        
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(XActionSheetCell), new List<string>());
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(XTextCell), default(string), BindingMode.TwoWay);


        public string SelectorTitle
        {
            get { return (string)GetValue(SelectorTitleProperty); }
            set { SetValue(SelectorTitleProperty, value); }
        }
        public string CancelTitle
        {
            get { return (string)GetValue(CancelTitleProperty); }
            set { SetValue(CancelTitleProperty, value); }
        }

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        Label label;
        string[] internalItemsSource;
        public XActionSheetCell():base()
        {  
            InputHorizontalOptions = LayoutOptions.FillAndExpand;
            label = new Label
            {
                Text = Text,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.DarkGray
            };
            this.FormLayout(label);
        }


        protected override async void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            var result = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet(SelectorTitle, CancelTitle, null, internalItemsSource);
            if(result != null)
            {
                Text = result;
            }
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == ItemsSourceProperty.PropertyName)
            {
                internalItemsSource = ItemsSource.ToArray();
            }else if (propertyName == TextProperty.PropertyName)
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
                internalItemsSource = ItemsSource.ToArray();
            }
        }
    }
}
