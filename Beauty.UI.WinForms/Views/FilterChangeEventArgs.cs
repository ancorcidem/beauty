using System;
using Beauty.UI.WinForms.Models;

namespace Beauty.UI.WinForms.Views
{
    public class FilterChangeEventArgs : EventArgs
    {
        public SearchParameters SearchParameters { get; private set; }

        public FilterChangeEventArgs(SearchParameters searchParameters)
        {
            SearchParameters = searchParameters;
        }
    }
}