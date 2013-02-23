using System.Collections.Generic;
using System.Linq;

namespace Beauty.Business
{
    public class CriteriaCollection
    {
        private readonly IBeautyRepository _repository;

        public CriteriaCollection(IBeautyRepository repository)
        {
            _repository = repository;
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
            return queryable.Select(beauty => beauty);
        }
    }
}