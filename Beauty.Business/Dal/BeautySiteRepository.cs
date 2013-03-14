using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;

namespace Beauty.Business.Dal
{
    public class BeautySiteRepository
    {
        private readonly ISiteBrowser _browser;
        private readonly IBus _bus;

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