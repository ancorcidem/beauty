using System;
using System.Collections.Generic;

namespace Beauty.UI.WinForms
{
    public interface IMainView
    {
        event EventHandler<SearchButtonPressEventArgs> SearchButtonPressed;
        void Show(BeautyViewModel beautyViewModel);
    }

    public class BeautyViewModel
    {
        public IEnumerable<Business.Beauty> Beauties { get; set; }
    }
}