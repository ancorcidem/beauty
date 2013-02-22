using System.Data.Entity;
using Beauty.Business;

namespace Beauty.Specs.UI.StepDefinitions
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