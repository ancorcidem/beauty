using System;

namespace Beauty.UI.WinForms.Views
{
    public interface IFilterView
    {
        event EventHandler<FilterChangeEventArgs> FilterChanged;
    }
}