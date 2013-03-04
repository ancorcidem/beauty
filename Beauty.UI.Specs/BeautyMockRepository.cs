using System.Collections.Generic;
using System.Linq;
using Beauty.Business;

namespace Beauty.UI.Specs
{
    public class BeautyMockRepository : IBeautyRepository
    {
        private readonly List<Business.Beauty> _dbSet = new List<Business.Beauty>();
        private IEnumerable<Criteria> _usedCriterias = Enumerable.Empty<Criteria>();

        public IEnumerable<Criteria> UsedCriterias
        {
            get { return _usedCriterias; }
        }

        public IEnumerable<Business.Beauty> Find(IEnumerable<Criteria> criterias)
        {
            var usedCriterias = criterias.ToArray();

            _usedCriterias = usedCriterias;
            
            var queryable = _dbSet.AsQueryable();
            usedCriterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));
            return queryable.Select(beauty => beauty);
        }

        public void Add(Business.Beauty beauty)
        {
            _dbSet.Add(beauty);
        }
    }
}