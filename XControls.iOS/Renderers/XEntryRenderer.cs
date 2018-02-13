using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XControls.Enums;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace XControls.Renderers
{
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = e.NewElement as XEntry;
            if (view != null)
            {
                SetBorder(view);
                SetMaxLength(view);
                UpdateKeyboard();
                UpdateFont();

                if (view.AllowClear)
                {
                    Control.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                }

                if (view.DisableAutocapitalize)
                {
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
                }

                if (view.Autocorrect.HasValue)
                {
                    Control.AutocorrectionType = view.Autocorrect.Value ? UITextAutocorrectionType.Yes : UITextAutocorrectionType.No;
                }
                if (view.HideCursor)
                {
                    Control.TintColor = UIColor.Clear;
                }

                if (view.ReturnType.HasValue)
                {
                    switch (view.ReturnType.Value)
                    {
                        case ReturnType.Done:
                            Control.ReturnKeyType = UIReturnKeyType.Done;
                            break;
                        case ReturnType.Go:
                            Control.ReturnKeyType = UIReturnKeyType.Go;
                            break;
                        case ReturnType.Next:
                            Control.ReturnKeyType = UIReturnKeyType.Next;
                            break;
                        case ReturnType.Search:
                            Control.ReturnKeyType = UIReturnKeyType.Search;
                            break;
                        case ReturnType.Send:
                            Control.ReturnKeyType = UIReturnKeyType.Send;
                            break;
                        default:
                            Control.ReturnKeyType = UIReturnKeyType.Default;
                            break;
                    }
                }

                Control.ShouldReturn += (UITextField tf) =>
                {
                    view.InvokeCompleted();
                    return true;
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (XEntry)Element;

            if (e.PropertyName == XEntry.HasBorderProperty.PropertyName
                || e.PropertyName == XEntry.HasOnlyBottomBorderProperty.PropertyName
                || e.PropertyName == XEntry.BottomBorderColorProperty.PropertyName)
            {
                SetBorder(view);
            }
            else if (e.PropertyName == Xamarin.Forms.InputView.KeyboardProperty.PropertyName)
            {
                UpdateKeyboard();
            }
            else if (e.PropertyName == Entry.FontAttributesProperty.PropertyName)
            {
                UpdateFont();
            }
            else if (e.PropertyName == Entry.FontFamilyProperty.PropertyName)
            {
                UpdateFont();
            }
            else if (e.PropertyName == Entry.FontSizeProperty.PropertyName)
            {
                UpdateFont();
            }
        }

        private void UpdateFont()
        {
            var descriptor = UIFontDescriptor.PreferredBody;
            var pointSize = descriptor.PointSize;

            var size = Element.FontSize;
            if (Math.Abs(size - Device.GetNamedSize(NamedSize.Large, typeof(XEntry))) < double.Epsilon)
            {
                pointSize *= 1.3f;
            }
            else if (Math.Abs(size - Device.GetNamedSize(NamedSize.Small, typeof(XEntry))) < double.Epsilon)
            {
                pointSize *= .8f;
            }
            else if (Math.Abs(size - Device.GetNamedSize(NamedSize.Micro, typeof(XEntry))) < double.Epsilon)
            {
                pointSize *= .6f;
            }
            else if (Math.Abs(size - Device.GetNamedSize(NamedSize.Default, typeof(XEntry))) > double.Epsilon)
            {
                // not using dynamic font sizes, return
                return;
            }

            if (!string.IsNullOrWhiteSpace(Element.FontFamily))
            {
                Control.Font = UIFont.FromName(Element.FontFamily, pointSize);
            }
            else
            {
                Control.Font = UIFont.FromDescriptor(descriptor, pointSize);
            }
        }

        private void SetBorder(XEntry view)
        {
            if (view.HasOnlyBottomBorder)
            {
                var borderLayer = new CALayer();
                borderLayer.MasksToBounds = true;
                borderLayer.Frame = new CGRect(0f, Frame.Height / 2, Frame.Width * 2, 1f);
                borderLayer.BorderColor = view.BottomBorderColor.ToCGColor();
                borderLayer.BorderWidth = 1f;

                Control.Layer.AddSublayer(borderLayer);
                Control.BorderStyle = UITextBorderStyle.None;
            }
            else if (view.HasBorder)
            {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
            }
            else
            {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }

        private void SetMaxLength(XEntry view)
        {
            Control.ShouldChangeCharacters = (textField, range, replacementString) =>
            {
                var newLength = textField.Text.Length + replacementString.Length - range.Length;
                return newLength <= view.MaxLength;
            };
        }

        private void UpdateKeyboard()
        {
            if (Element.Keyboard == Keyboard.Numeric)
            {
                Control.KeyboardType = UIKeyboardType.NumberPad;
            }
            else
            {
                Control.ApplyKeyboard(Element.Keyboard);
            }
        }
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
    }

}
