using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XControlsTest.ViewModels;

namespace XControlsTest.Pages
{
    public partial class XSwitchCellPage : ContentPage
    {
        public XSwitchCellPage()
        {
            InitializeComponent();
            BindingContext = new XSwitchCellViewModel();
        }
    }
}
