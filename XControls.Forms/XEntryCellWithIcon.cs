﻿using System;
using Xamarin.Forms;

namespace XControls.Forms
{
    public class XEntryCellWithIcon:XIconBaseViewCell
    {
        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create("PlaceHolder", typeof(string), typeof(XEntryCellWithIcon), "PlaceHolder");
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(XEntryCellWithIcon), default(string), BindingMode.TwoWay);
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(XEntryCellWithIcon), false);
        public static readonly BindableProperty KeyboardTypeProperty =
            BindableProperty.Create(nameof(KeyboardType), typeof(Keyboard), typeof(XEntryCellWithIcon), null);
        public static readonly BindableProperty MaxLengthProperty =
           BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(XEntry), int.MaxValue);
        
        XEntry entry;

        public Keyboard KeyboardType
        {
            get { return (Keyboard)GetValue(KeyboardTypeProperty); }
            set { SetValue(KeyboardTypeProperty, value); }
        }

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

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        public XEntryCellWithIcon():base()
        {
            entry = new XEntry()
            {
                Text = Text,
                Placeholder = PlaceHolder,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasBorder = false,
                AllowClear = true,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Entry))
            };

            entry.TextChanged += (s, e) => Text = e.NewTextValue;
            this.FormLayout(entry);
        }


        protected override void OnPropertyChanging(string propertyName = null)
        {
            base.OnPropertyChanging(propertyName);
        }
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == PlaceHolderProperty.PropertyName)
            {
                entry.Placeholder = PlaceHolder;
            }
            if (propertyName == TextProperty.PropertyName)
            {
                entry.Text = Text;
            }
            if (propertyName == IsPasswordProperty.PropertyName)
            {
                entry.IsPassword = IsPassword;
            }
            if (propertyName == KeyboardTypeProperty.PropertyName)
            {
                entry.Keyboard = KeyboardType;
            }
            if(propertyName == MaxLengthProperty.PropertyName)
            {
                entry.MaxLength = MaxLength;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                entry.Placeholder = PlaceHolder;
                entry.Text = Text;
                entry.IsPassword = IsPassword;
                entry.MaxLength = MaxLength;
            }
        }


        protected override void FormEntryCell_Tapped(object sender, EventArgs e)
        {
            entry.Focus();
        }
    }

}
