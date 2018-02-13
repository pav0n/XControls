﻿using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XActionSheetCell : XTitleBaseViewCell
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(XActionSheetCell), default(string), BindingMode.TwoWay);
        
        public static readonly BindableProperty SelectorTitleProperty =
            BindableProperty.Create(nameof(SelectorTitle), typeof(string), typeof(XActionSheetCell), default(string));

        public static readonly BindableProperty CancelTitleProperty =
            BindableProperty.Create(nameof(CancelTitle), typeof(string), typeof(XActionSheetCell), "Cancel");
        
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

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

        Label lText;
        public XActionSheetCell()
        {
            lText = new Label
            {
                Text = Text,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.DarkGray
            };
            this.FormLayout(lText);
        }


        protected override async void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            var result = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet(SelectorTitle, CancelTitle, null, new string[] { "uno", "dos" });
            if(result != null)
            {
                Text = result;
            }
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                lText.Text = Text;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                lText.Text = Text;
            }
        }
    }
}