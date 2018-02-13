using Android.Content;
using System.ComponentModel;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using XControls.Forms;
using XControls.Renderers;
using System;
using Android.Widget;

[assembly: ExportRenderer(typeof(XViewCell), typeof(XViewCellRenderer))]
namespace XControls.Renderers
{
    public class XViewCellRenderer : ViewCellRenderer
    {
        protected AView View { get; private set; }
        private Context _context;
        protected override AView GetCellCore(Cell item, AView convertView, ViewGroup parent, Context context)
        {
            this._context = context;
            var View = base.GetCellCore(item, convertView, parent, context);
            var extendedCell = (XViewCell)item;
            if (View != null)
            {
                if (extendedCell.BackgroundColor != Color.White)
                {
                    View.SetBackgroundColor(extendedCell.BackgroundColor.ToAndroid());
                }
                else
                {
                    View.SetBackgroundColor(extendedCell.BackgroundColor.ToAndroid());

                }

            }

            return View;
        }

        /*protected void updareDisclousure(XViewCell cell, BaseCellView bcell)
        {
            if (cell.ShowDisclosure)
            {
                var resourceId = Android.Resource.Drawable.IcMenuSend;
                if (!string.IsNullOrWhiteSpace(cell.DisclousureImage))
                {
                    //Incase someone decides to add the extension to the file name
                    var fileName = System.IO.Path.GetFileNameWithoutExtension(cell.DisclousureImage);
                    resourceId = this._context.Resources.GetIdentifier(fileName, "drawable", this._context.PackageName);
                }

                var image = new ImageView(_context);
                image.SetImageResource(resourceId);
                bcell.SetAccessoryView(image);
            }
        }*/

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {               
            base.OnCellPropertyChanged(sender, args);

            var cell = (XViewCell)Cell;

            if (args.PropertyName == XViewCell.BackgroundColorProperty.PropertyName)
            {
                View.SetBackgroundColor(cell.BackgroundColor.ToAndroid());
            }
        }

        public async static void Init()
        {
            var temp = DateTime.Now;
        }
    }
}
