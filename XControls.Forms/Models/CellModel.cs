using System;
using XControls.Forms.Enums;
namespace XControls.Forms.Models
{
    public class CellModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public CellType Type { get; set; }
        public string Icon { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string SelectorTitle { get; set; }
    }
}
