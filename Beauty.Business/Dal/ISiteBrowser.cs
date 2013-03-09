using System.Collections.Generic;
using System.Collections.Specialized;

namespace Beauty.Business.Dal
{
    public interface ISiteBrowser
    {
        IEnumerable<BeautyProfile> Select(NameValueCollection queryParams);
    }
}