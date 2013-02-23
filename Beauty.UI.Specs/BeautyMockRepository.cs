using System.Data.Entity;
using Beauty.Business;
using Beauty.UI.Specs.FakeDb;


namespace Beauty.UI.Specs
{
    public class BeautyMockRepository : IBeautyRepository
    {
        private readonly IDbSet<Business.Beauty> _dbSet = new InMemoryDbSet<Business.Beauty>();

        public IDbSet<Business.Beauty> Beauties
        {
            get { return _dbSet; }
        }

        public void SaveChanges()
        {
        }
    }
}