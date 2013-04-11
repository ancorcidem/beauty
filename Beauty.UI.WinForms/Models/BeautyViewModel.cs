using System;
using System.Drawing;
using Beauty.Business;

namespace Beauty.UI.WinForms.Models
{
    public class BeautyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Age Age { get; set; }
        public Uri Profile { get; set; }
        public Image Avatar { get; set; }
    }
}