using Xamarin.Forms;

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
            var nav = new NavigationPage(p);
            this.Navigation.PushModalAsync(nav);
        }
    }
}
