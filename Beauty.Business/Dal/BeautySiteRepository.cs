using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beauty.Business.Criterias;

namespace Beauty.Business.Dal
{
    public class BeautySiteRepository
    {
        private readonly ISiteBrowser _browser;

        public BeautySiteRepository(ISiteBrowser browser)
        {
            _browser = browser;
        }

        public void Find(IEnumerable<Criteria> criterias)
        {
            var nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            criterias.ToList().ForEach(x => x.ApplyOn(nameValueCollection));

            _browser.Select(nameValueCollection);
        }
    }
}