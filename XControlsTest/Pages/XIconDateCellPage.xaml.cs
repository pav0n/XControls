using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XControlsTest.ViewModels;

namespace XControlsTest.Pages
{
    public partial class XIconDateCellPage : ContentPage
    {
        public XIconDateCellPage()
        {
            InitializeComponent();
            BindingContext = new XDateCellViewModel();

        }
    }
}
