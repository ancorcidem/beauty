using Beauty.Business.Criterias;

namespace Beauty.Business
{
    public interface IBeautyFilter
    {
        Criteria[] Filter { get; set; }
    }
}