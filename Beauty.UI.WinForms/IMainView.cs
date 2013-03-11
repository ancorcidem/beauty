using System;
using System.Collections.Generic;

namespace Beauty.UI.WinForms
{
    public interface IMainView
    {
        event EventHandler<FilterChangeEventArgs> FilterChanged;
        void Show(BeautyViewModel beautyViewModel);
    }

    public class BeautyViewModel
    {
        public IEnumerable<Business.Beauty> Beauties { get; set; }
    }
}