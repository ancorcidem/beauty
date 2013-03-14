using System.Collections.Specialized;

namespace Beauty.Business.Dal
{
    public interface ISiteBrowser
    {
        void Select(NameValueCollection queryParams);
    }

    public class BeautyProfileFoundMessage
    {
        public BeautyProfile Profile { get; set; }
    }
}