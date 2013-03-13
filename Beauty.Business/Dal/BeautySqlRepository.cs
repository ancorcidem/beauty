using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;

namespace Beauty.Business.Dal
{
    public class BeautySqlRepository : IBeautyRepository
    {
        private readonly BeautyDbContext _context = new BeautyDbContext();

        public void Commit()
        {
            lock (_context)
            {
                _context.SaveChanges();
            }
        }

        public IEnumerable<Beauty> Find(IEnumerable<Criteria> criterias)
        {
            lock (_context)
            {
                IQueryable<Beauty> queryable = _context.Beauties;
                criterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));
                return queryable;
            }
        }

        public void Add(Beauty beauty)
        {
            lock (_context)
            {
                _context.Beauties.Add(beauty);
            }
        }
    }
}