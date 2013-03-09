using System.Collections.Generic;
using Beauty.Business.Criterias;

namespace Beauty.Business.Dal
{
    public interface IBeautyRepository
    {
        IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias);
    }
}