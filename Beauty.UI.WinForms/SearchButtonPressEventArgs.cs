using System;

namespace Beauty.UI.WinForms
{
    public class SearchButtonPressEventArgs : EventArgs
    {
        public ViewModel ViewModel { get; private set; }

        public SearchButtonPressEventArgs(ViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}