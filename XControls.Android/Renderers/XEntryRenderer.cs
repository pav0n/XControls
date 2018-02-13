using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Text;
using Android.Text.Method;
using Android.Views.InputMethods;
using Android.Widget;
using Xamarin.Forms;
using Android.App;
using Xamarin.Forms.Platform.Android;
using XControls.Enums;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace XControls.Renderers
{
    public class XEntryRenderer : EntryRenderer
    {
        public XEntryRenderer(Context context)
            : base(context)
        { }

        private bool _isPassword;
        private bool _toggledPassword;
        private bool _isDisposed;
        private XEntry _view;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            _view = (XEntry)Element;
            _isPassword = _view.IsPassword;

            if (Control != null)
            {
                Control.SetIncludeFontPadding(false);
                if (e.NewElement != null && e.NewElement.IsPassword)
                {
                    Control.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                    Control.TransformationMethod = new PasswordTransformationMethod();
                }
            }

            SetBorder(_view);
            SetMaxLength(_view);
            SetReturnType(_view);

            // Editor Action is called when the return button is pressed
            Control.EditorAction += Control_EditorAction;

            if (_view.DisableAutocapitalize)
            {
                Control.SetRawInputType(Control.InputType |= InputTypes.TextVariationEmailAddress);
            }

            if (_view.Autocorrect.HasValue)
            {
                Control.SetRawInputType(Control.InputType |= InputTypes.TextFlagNoSuggestions);
            }

            if (_view.IsPassword)
            {
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions | InputTypes.TextVariationVisiblePassword);
            }

            _view.ToggleIsPassword += ToggleIsPassword;

            if (_view.FontFamily == "monospace")
            {
                Control.Typeface = Typeface.Monospace;
            }

            if (_view.HideCursor)
            {
                Control.SetCursorVisible(false);
            }
        }

        private void ToggleIsPassword(object sender, EventArgs e)
        {
            var cursorStart = Control.SelectionStart;
            var cursorEnd = Control.SelectionEnd;

            Control.TransformationMethod = _isPassword ? null : new PasswordTransformationMethod();
            Control.SetRawInputType(InputTypes.TextFlagNoSuggestions | InputTypes.TextVariationVisiblePassword);

            // set focus
            Control.RequestFocus();

            if (_toggledPassword)
            {
                // restore cursor position
                Control.SetSelection(cursorStart, cursorEnd);
            }
            else
            {
                // set cursor to end
                Control.SetSelection(Control.Text.Length);
            }

            // show keyboard
            var activity = Context as Activity;
            var imm = activity.GetSystemService(Context.InputMethodService) as InputMethodManager;
            imm.ShowSoftInput(Control, ShowFlags.Forced);
            imm.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);

            _isPassword = _view.IsPasswordFromToggled = !_isPassword;
            _toggledPassword = true;
        }

        private void Control_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (_view.ReturnType != ReturnType.Next)
            {
                _view.Unfocus();
            }

            // Call all the methods attached to base_entry event handler Completed
            _view.InvokeCompleted();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var view = (XEntry)Element;

            if (e.PropertyName == XEntry.HasBorderProperty.PropertyName
                || e.PropertyName == XEntry.HasOnlyBottomBorderProperty.PropertyName
                || e.PropertyName == XEntry.BottomBorderColorProperty.PropertyName)
            {
                SetBorder(view);
            }
            else
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
                {
                    Control.SetBackgroundColor(view.BackgroundColor.ToAndroid());
                }
            }

            if (view.FontFamily == "monospace")
            {
                Control.Typeface = Typeface.Monospace;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            if (disposing && Control != null)
            {
                _view.ToggleIsPassword -= ToggleIsPassword;
                Control.EditorAction -= Control_EditorAction;
            }

            base.Dispose(disposing);
        }

        private void SetReturnType(XEntry view)
        {
            if (view.ReturnType.HasValue)
            {
                switch (view.ReturnType.Value)
                {
                    case ReturnType.Go:
                        Control.ImeOptions = ImeAction.Go;
                        Control.SetImeActionLabel("Go", ImeAction.Go);
                        break;
                    case ReturnType.Next:
                        Control.ImeOptions = ImeAction.Next;
                        Control.SetImeActionLabel("Next", ImeAction.Next);
                        break;
                    case ReturnType.Search:
                        Control.ImeOptions = ImeAction.Search;
                        Control.SetImeActionLabel("Search", ImeAction.Search);
                        break;
                    case ReturnType.Send:
                        Control.ImeOptions = ImeAction.Send;
                        Control.SetImeActionLabel("Send", ImeAction.Send);
                        break;
                    default:
                        Control.SetImeActionLabel("Done", ImeAction.Done);
                        break;
                }
            }
        }

        private void SetBorder(XEntry view)
        {
            if (!view.HasBorder)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
            else
            {

                //Control.SetBackgroundColor(view.BottomBorderColor.ToAndroid());
                setBackgroundDrawable(view);
            }
        }
        void setBackgroundDrawable(XEntry view)
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(view.BackgroundColor.ToAndroid());
            //gd.SetCornerRadius(10);
            gd.SetStroke(2, view.BottomBorderColor.ToAndroid());
            Control.SetBackground(gd);
        }

        private void SetMaxLength(XEntry view)
        {
            Control.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(view.MaxLength) });
        }
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
    }

}


