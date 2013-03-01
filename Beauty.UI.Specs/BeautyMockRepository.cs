using System.Collections.Generic;
using System.Linq;
using Beauty.Business;

namespace Beauty.UI.Specs
{
    public class BeautyMockRepository : IBeautyRepository
    {
        private readonly List<Business.Beauty> _dbSet = new List<Business.Beauty>();

        public IEnumerable<Business.Beauty> Find(IEnumerable<Criteria> criterias)
        {
            IQueryable<Business.Beauty> queryable = _dbSet.AsQueryable();
            criterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));
            return queryable.Select(beauty => beauty);
        }

        public void Add(Business.Beauty beauty)
        {
            _dbSet.Add(beauty);
        }
    }
}