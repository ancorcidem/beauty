using System;

namespace Beauty.UI.WinForms
{
    public interface IMainView
    {
        event EventHandler<FilterChangeEventArgs> FilterChanged;
        void Show(MainFormViewModel mainFormViewModel);
    }
}