using System.Collections.Generic;

namespace Beauty.Business
{
    public interface IBeautyRepository
    {
        IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias);
    }
}