using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XControlsTest.ViewModels;

namespace XControlsTest.Pages
{
    public partial class XIconDataCellPage : ContentPage
    {
        public XIconDataCellPage()
        {
            InitializeComponent();
            BindingContext = new XDateCellViewModel();

        }
    }
}
