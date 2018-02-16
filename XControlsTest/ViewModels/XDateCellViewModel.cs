using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XControlsTest.ViewModels
{
    public class XDateCellViewModel:BaseViewModel
    {

        public DateTime Date1
        {
            get
            {
                return date1;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Undate Date1 {0}", value);
                SetProperty(ref date1, value, nameof(Date1));
            }
        }

        public DateTime Date2
        {
            get
            {
                return date2;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Undate Date2 {0}", value);
                SetProperty(ref date2, value, nameof(Date2));
            }
        }

        DateTime date1;
        DateTime date2;
        public XDateCellViewModel()
        {
            Date1 = DateTime.Now;
        }

    }
}
