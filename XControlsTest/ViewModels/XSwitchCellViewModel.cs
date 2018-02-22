using System;

using Xamarin.Forms;

namespace XControlsTest.ViewModels
{
    public class XSwitchCellViewModel : BaseViewModel
    {
        bool isToggled;
        public bool IsToggled
        {
            get
            {
                return isToggled;
            }
            set
            {
                SetProperty(ref isToggled, value, nameof(IsToggled));
            }
        }
    }
}

