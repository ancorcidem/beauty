using System;

namespace Beauty.UI.WinForms
{
    public interface IFilterView
    {
        event EventHandler<FilterChangeEventArgs> FilterChanged;
    }
}