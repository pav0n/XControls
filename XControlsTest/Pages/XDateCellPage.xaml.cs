using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using XControlsTest.ViewModels;

namespace XControlsTest.Pages
{
    public partial class XDateCellPage : ContentPage
    {

        public XDateCellPage()
        {
            InitializeComponent();
            BindingContext = new XDateCellViewModel();
        }


    }
}
