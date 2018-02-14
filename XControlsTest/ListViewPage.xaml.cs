using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XControls.Forms.Models;
namespace XControlsTest
{
    public partial class ListViewPage : ContentPage
    {
        public IList<CellModel> lista
        {
            get;
            set;
        }
        public ListViewPage()
        {
            InitializeComponent();
            lista = new List<CellModel>
            {
                new CellModel(){
                    Type = XControls.Forms.Enums.CellType.XDateCell,
                    Title = "Fecha",
                    Detail = "Selecciona una fecha",
                    Text = "2015/05/24",
                    Date = DateTime.Now,
                },
                new CellModel(){
                    Type = XControls.Forms.Enums.CellType.XActionSheetCell,
                    Title = "Selecciona algo",
                    Detail = "Selecciona una fecha",
                    Text = "uno",
                    Date = DateTime.Now,
                    SelectorTitle = "Seleccione una opción"

                }
            };
            milista.ItemTemplate = new XControls.Forms.TypeCellDataTemplateSelector();
            BindingContext = this;
        }
    }
}
