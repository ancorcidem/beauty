using System.Collections.Generic;
using System.Linq;

namespace Beauty.Business
{
    public class BeautySqlRepository : IBeautyRepository
    {
        private readonly BeautyDbContext _context = new BeautyDbContext();

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias)
        {
            IQueryable<Beauty> queryable = _context.Beauties;
            criterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));
            return queryable.Select(beauty => beauty);
        }

        public void Add(Beauty beauty)
        {
            _context.Beauties.Add(beauty);
        }
    }
}