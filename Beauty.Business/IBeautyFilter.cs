using System.Collections.Generic;
using Beauty.Business.Criterias;

namespace Beauty.Business
{
    public interface IBeautyFilter
    {
        IEnumerable<Criteria> Filter { get; set; }
    }
}