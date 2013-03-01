using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Beauty.Business
{
    public class CriteriaCollection
    {
        private readonly ISiteBrowser _siteBrowser;

        public CriteriaCollection(ISiteBrowser siteBrowser)
        {
            _siteBrowser = siteBrowser;
        }

        private readonly List<Criteria> _criterias =
            new List<Criteria>();

        public void Add(Criteria criteria)
        {
            _criterias.Add(criteria);
        }

        public IEnumerable<Beauty> Find()
        {
            var nameValuePair = new NameValueCollection();
            _criterias.ForEach(x => x.ApplyOn(nameValuePair));

            return _siteBrowser.Select(nameValuePair).Select(x => (Beauty)x);
            //IQueryable<Beauty> queryable = _repository.Beauties;
            //_criterias.ForEach(x => queryable = x.ApplyOn(queryable));

            //var beautiesFromSite = _siteBrowser.Select(_criterias);
            

            //return queryable.Select(beauty => beauty);
        }
    }
}