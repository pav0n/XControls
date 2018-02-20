using System;
using Xamarin.Forms;
using XControls.Forms.Enums;
using XControls.Forms.Models;

namespace XControls.Forms
{
    public class TypeCellDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate XActionSheetCellTemplate { get; set; }
        public DataTemplate XDateCellTemplate { get; set; }

        //public TypeCellDataTemplateSelector instance = new TypeCellDataTemplateSelector();

        public TypeCellDataTemplateSelector()
        {
            XActionSheetCellTemplate = new DataTemplate(typeof(XActionSheetCell));
            XActionSheetCellTemplate.SetBinding(XTitleBaseViewCell.TitleProperty, XTitleBaseViewCell.TitleProperty.PropertyName);
            XActionSheetCellTemplate.SetBinding(XTitleBaseViewCell.TitleColorProperty, XTitleBaseViewCell.TitleColorProperty.PropertyName);
            XActionSheetCellTemplate.SetBinding(XTitleBaseViewCell.TitleFontSizeProperty, XTitleBaseViewCell.TitleFontSizeProperty.PropertyName);
            XActionSheetCellTemplate.SetBinding(XTitleBaseViewCell.DetailProperty, XTitleBaseViewCell.DetailProperty.PropertyName);

            XActionSheetCellTemplate.SetBinding(XActionSheetCell.TextProperty, XActionSheetCell.TextProperty.PropertyName);
            XActionSheetCellTemplate.SetBinding(XActionSheetCell.SelectorTitleProperty, XActionSheetCell.SelectorTitleProperty.PropertyName);
            XActionSheetCellTemplate.SetBinding(XActionSheetCell.CancelTitleProperty, XActionSheetCell.CancelTitleProperty.PropertyName);

            XDateCellTemplate = new DataTemplate(typeof(XDateCell));
            XDateCellTemplate.SetBinding(XTitleBaseViewCell.DetailProperty, XTitleBaseViewCell.DetailProperty.PropertyName);
            XDateCellTemplate.SetBinding(XTitleBaseViewCell.TitleProperty, XTitleBaseViewCell.TitleProperty.PropertyName);
            XDateCellTemplate.SetBinding(XTitleBaseViewCell.TitleColorProperty, XTitleBaseViewCell.TitleColorProperty.PropertyName);
            XDateCellTemplate.SetBinding(XTitleBaseViewCell.TitleFontSizeProperty, XTitleBaseViewCell.TitleFontSizeProperty.PropertyName);
            XDateCellTemplate.SetBinding(XProperties.DateProperty, XProperties.DateProperty.PropertyName);
            XDateCellTemplate.SetBinding(XProperties.FormatProperty, XProperties.FormatProperty.PropertyName);

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CellType Type = ((CellModel)item).Type;
            var Item = item as CellModel;
            if (Type == CellType.XActionSheetCell)
            {
                //XActionSheetCellTemplate.SetValue(XTitleBaseViewCell.TitleProperty,Item.Title);
                return XActionSheetCellTemplate;
            }
            else if (Type == CellType.XDateCell)
            {
                XActionSheetCellTemplate.SetValue(XTitleBaseViewCell.TitleProperty, Item.Title);
                return XDateCellTemplate;
            }
            return XActionSheetCellTemplate;
        }
    }
}
