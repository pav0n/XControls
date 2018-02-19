using System;
using System.Collections.Generic;

namespace XControlsTest.ViewModels
{
    public class XActionSheetCellViewModel:BaseViewModel
    {
        string []listNumbers;
        public string [] ListNumbers
        {
            get
            {
                return listNumbers;
            }
            set
            {
                SetProperty(ref listNumbers, value, nameof(ListNumbers));
            }
        }
        IList<string> listColors;
        public IList<string> ListColors
        {
            get
            {
                return listColors;
            }
            set
            {
                SetProperty(ref listColors, value, nameof(ListColors));
            }
            
        }

        IList<string> listAnimals;
        public IList<string> ListAnimals
        {
            get
            {
                return listAnimals;
            }
            set
            {
                SetProperty(ref listAnimals, value, nameof(ListAnimals));
            }

        }

        string number = "one";
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                SetProperty(ref number, value, nameof(Number));
            }
        }

        string color = "red";
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                SetProperty(ref color, value, nameof(Color));
            }
        }
        string animal = "dog";
        public string Animal
        {
            get
            {
                return animal;
            }
            set
            {
                SetProperty(ref animal, value, nameof(Animal));
            }
        }
        public XActionSheetCellViewModel()
        {
            ListNumbers = new string []{
                "one", "two", "three", "for", "five"
            };
            ListColors = new List<string>
            {
                "red", "green", "blue", "black", "white", "silver", "brown"
            };

            ListAnimals = new List<string>
            {
                "dog", "cat", "duck", "fish", "dolphi"
            }; 
        }
    }
}
