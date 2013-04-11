using System.Collections.Generic;

namespace Beauty.UI.WinForms.Models
{
    public class MainFormViewModel
    {
        public IEnumerable<BeautyViewModel> Beauties { get; set; }
    }
}