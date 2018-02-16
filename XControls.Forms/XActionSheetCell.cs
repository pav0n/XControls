using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XActionSheetCell : XTextCell
    {
        
        public static readonly BindableProperty SelectorTitleProperty =
            BindableProperty.Create(nameof(SelectorTitle), typeof(string), typeof(XActionSheetCell), default(string));

        public static readonly BindableProperty CancelTitleProperty =
            BindableProperty.Create(nameof(CancelTitle), typeof(string), typeof(XActionSheetCell), "Cancel");
        
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(XActionSheetCell), new List<string>());



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
        string[] internalItemsSource;
        public XActionSheetCell():base()
        {
           
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
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                internalItemsSource = ItemsSource.ToArray();
            }
        }
    }
}
