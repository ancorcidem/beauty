using System.Collections.Generic;
using System.Collections.Specialized;

namespace Beauty.Business
{
    public interface ISiteBrowser
    {
        IEnumerable<BeautyProfile> Select(NameValueCollection queryParams);
    }
}