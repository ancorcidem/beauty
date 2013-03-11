using System;

namespace Beauty.UI.WinForms
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