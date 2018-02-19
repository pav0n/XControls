using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XControlsTest.ViewModels;

namespace XControlsTest.Pages
{
    public partial class XActionSheetCellPage : ContentPage
    {
        public XActionSheetCellPage()
        {
            InitializeComponent();
            BindingContext = new XActionSheetCellViewModel();
        }
    }
}
