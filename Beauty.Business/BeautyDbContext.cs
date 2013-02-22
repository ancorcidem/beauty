using System.Data.Entity;

namespace Beauty.Business
{
    public class BeautyRepository : IBeautyRepository
    {
        private readonly BeautyDbContext _context = new BeautyDbContext();

        public IDbSet<Beauty> Beauties
        {
            get { return _context.Beauties; }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public class BeautyDbContext : DbContext
    {
        public BeautyDbContext()
            : base("name=BeautyDbContext")
        {
        }

        public IDbSet<Beauty> Beauties
        {
            get { return Set<Beauty>(); }
        }
    }
}