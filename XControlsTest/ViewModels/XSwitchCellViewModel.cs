using System;

using Xamarin.Forms;

namespace XControlsTest.ViewModels
{
    public class XSwitchCellViewModel : ContentPage
    {
        public XSwitchCellViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

