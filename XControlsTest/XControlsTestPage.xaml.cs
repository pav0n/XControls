using Xamarin.Forms;
using XControlsTest.Pages;

namespace XControlsTest
{
    public partial class XControlsTestPage : ContentPage
    {
        public string[] options { get; set; }
        public XControlsTestPage()
        {
            InitializeComponent();
            options = new string[] { "uno", "dos" };
            BindingContext = this;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var p = new ListViewPage();
            this.Navigation.PushAsync(p);
        }

        void TappedXEntry(object sender, System.EventArgs e)
        {
            var p = new XEntryPage();
            this.Navigation.PushAsync(p);
        }

        void TappedXDateCell(object sender, System.EventArgs e)
        {
            var p = new XDateCellPage();
            this.Navigation.PushAsync(p);
        }

        void TappedXActionSheetCell(object sender, System.EventArgs e)
        {
            var p = new XActionSheetCellPage();
            this.Navigation.PushAsync(p);
        }

        void TappedXEntryCell(object sender, System.EventArgs e)
        {
            var p = new XEntryCellPage();
            this.Navigation.PushAsync(p);
        }
    }
}
