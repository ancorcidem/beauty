using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Beauty.Business
{
    public class CriteriaCollection
    {
        private readonly IBeautyRepository _repository;
        private readonly ISiteBrowser _siteBrowser;

        public CriteriaCollection(IBeautyRepository repository, ISiteBrowser siteBrowser)
        {
            _repository = repository;
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
            IQueryable<Beauty> queryable = _repository.Beauties;
            _criterias.ForEach(x => queryable = x.ApplyOn(queryable));

            var queryParams = new NameValueCollection();
            _criterias.ForEach(x => x.ApplyOn(queryParams));
            

            return queryable.Select(beauty => beauty);
        }
    }
}