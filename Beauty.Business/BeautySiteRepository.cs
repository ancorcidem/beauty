using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beauty.Business
{
    public class BeautySiteRepository : IBeautyRepository
    {
        private readonly ISiteBrowser _browser;

        public BeautySiteRepository(ISiteBrowser browser)
        {
            _browser = browser;
        }

        public IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias)
        {
            var nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            criterias.ToList().ForEach(x => x.ApplyOn(nameValueCollection));

            var beautiesFromSite = _browser.Select(nameValueCollection);
            return beautiesFromSite.Select(x => (Beauty) x);
        }
    }
}