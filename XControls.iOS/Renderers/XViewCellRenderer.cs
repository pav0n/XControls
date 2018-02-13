using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XControls.Forms;
using XControls.Renderers;

[assembly: ExportRenderer(typeof(XViewCell), typeof(XViewCellRenderer))]
namespace XControls.Renderers
{
    public class XViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var extendedCell = (XViewCell)item;
            var cell = base.GetCell(item, reusableCell, tv);

            if (cell != null)
            {
                cell.BackgroundColor = extendedCell.BackgroundColor.ToUIColor();
                if (extendedCell.ShowDisclosure)
                {
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                }
            }

            WireUpForceUpdateSizeRequested(item, cell, tv);

            return cell;
        }

    }
}
