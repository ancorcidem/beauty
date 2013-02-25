using System.Data.Entity;
using Beauty.Business;
using Beauty.Specs.Common.FakeDb;


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

        public void Dispose()
        {
            
        }
    }
}