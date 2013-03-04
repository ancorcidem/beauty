using System;

namespace Beauty.UI.WinForms
{
    public interface IMainView
    {
        event EventHandler<SearchButtonPressEventArgs> SearchButtonPressed;
    }
}