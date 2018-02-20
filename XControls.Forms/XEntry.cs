using System;
using Xamarin.Forms;
using XControls.Enums;
namespace XControls.Forms
{
    public class XEntry:Entry
    {
        public XEntry()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                PlaceholderColor = Color.FromHex("c7c7cd");
            }

            IsPasswordFromToggled = IsPassword;
        }

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(XEntry), true);

        public static readonly BindableProperty HasOnlyBottomBorderProperty =
            BindableProperty.Create(nameof(HasOnlyBottomBorder), typeof(bool), typeof(XEntry), false);

        public static readonly BindableProperty BottomBorderColorProperty =
            BindableProperty.Create(nameof(BottomBorderColor), typeof(Color), typeof(XEntry), Color.Default);

        public static readonly BindableProperty MaxLengthProperty = XProperties.MaxLengthProperty;

        //public static readonly BindableProperty HideCursorProperty =
        //    BindableProperty.Create(nameof(HideCursor), typeof(bool), typeof(XEntry), false);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public bool HasOnlyBottomBorder
        {
            get { return (bool)GetValue(HasOnlyBottomBorderProperty); }
            set { SetValue(HasOnlyBottomBorderProperty, value); }
        }

        public Color BottomBorderColor
        {
            get { return (Color)GetValue(BottomBorderColorProperty); }
            set { SetValue(BottomBorderColorProperty, value); }
        }

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public bool HideCursor {
            //get { return (bool)GetValue(HideCursorProperty); } 
            //set { SetValue(HideCursorProperty, value); }
            get; set;
        }


        public ReturnType? ReturnType { get; set; }
        public bool? Autocorrect { get; set; }
        public bool DisableAutocapitalize { get; set; }
        public bool AllowClear { get; set; }

        // Need to overwrite default handler because we cant Invoke otherwise
        public new event EventHandler Completed;

        public void InvokeCompleted()
        {
            Completed?.Invoke(this, null);
        }

        public virtual void InvokeToggleIsPassword()
        {
            if (ToggleIsPassword == null)
            {
                IsPassword = IsPasswordFromToggled = !IsPassword;
                Focus();
            }
            else
            {
                ToggleIsPassword.Invoke(this, null);
            }
        }

        public event EventHandler ToggleIsPassword;
        public bool IsPasswordFromToggled { get; set; } = false;

    }
}
