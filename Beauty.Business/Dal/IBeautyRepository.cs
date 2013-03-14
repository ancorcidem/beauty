using System.Collections.Generic;
using Beauty.Business.Criterias;

namespace Beauty.Business.Dal
{
    public interface IBeautyRepository
    {
        void Find(IEnumerable<Criteria> criterias);
    }
}