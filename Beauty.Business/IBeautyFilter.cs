using System;
using System.Collections.Generic;
using Beauty.Business.Criterias;

namespace Beauty.Business
{
    public interface IBeautyFilter
    {
        IEnumerable<Criteria> Filter { get; set; }
        event EventHandler<FilterChangeEventArgs> Changed;
    }

    public class FilterChangeEventArgs : EventArgs
    {
        public IEnumerable<Criteria> NewFilter { get; set; }

        public FilterChangeEventArgs(IEnumerable<Criteria> value)
        {
            NewFilter = value;
        }
    }
}