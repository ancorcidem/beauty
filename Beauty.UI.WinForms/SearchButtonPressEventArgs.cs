using System;

namespace Beauty.UI.WinForms
{
    public class SearchButtonPressEventArgs : EventArgs
    {
        public SearchParameters SearchParameters { get; private set; }

        public SearchButtonPressEventArgs(SearchParameters searchParameters)
        {
            SearchParameters = searchParameters;
        }
    }
}