using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XControlsTest.ViewModels
{
    public class XDateCellViewModel : BaseViewModel
    {
        DateTime date1;
        public DateTime Date1
        {
            get
            {
                return date1;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Update Date1 {0}", value);
                SetProperty(ref date1, value, nameof(Date1));
            }
        }
        DateTime date2;
        public DateTime Date2
        {
            get
            {
                return date2;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Update Date2 {0}", value);
                SetProperty(ref date2, value, nameof(Date2));
            }
        }
        TimeSpan time1;
        public TimeSpan Time1
        {
            get
            {
                return time1;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Update Time1 {0}", value);
                SetProperty(ref time1, value, nameof(Time1));
            }
        }
        Color timeColor;
        public Color TimeColor
        {
            get
            {
                return timeColor;
            }
            set
            {
                SetProperty(ref timeColor, value, nameof(TimeColor));
            }
        }
        public XDateCellViewModel()
        {
            Date1 = DateTime.Now;
            Date2 = DateTime.Now;
            Time1 = new TimeSpan();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeColor = randomColor();
                return true;
            });
        }
        Color randomColor()
        {
            Random randonGen = new Random();
            Color randomColor = Color.FromRgb(randonGen.Next(255), randonGen.Next(255),
            randonGen.Next(255));
            return randomColor;
        }

    }
}
