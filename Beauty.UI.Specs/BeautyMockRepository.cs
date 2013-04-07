using System.Collections.Generic;
using System.Linq;
using Beauty.Business;
using Beauty.Business.Criterias;
using Beauty.Business.Dal;
using Beauty.Business.ServiceBus;

namespace Beauty.UI.Specs
{
    public class BeautyMockRepository : IBeautyRepository
    {
        private readonly IBus _bus;
        private readonly List<Business.Beauty> _dbSet = new List<Business.Beauty>();
        private IEnumerable<Criteria> _usedCriterias = Enumerable.Empty<Criteria>();

        public BeautyMockRepository(IBus bus)
        {
            _bus = bus;
        }

        public void Find(IEnumerable<Criteria> criterias)
        {
            var usedCriterias = criterias.ToArray();

            _usedCriterias = usedCriterias;

            var queryable = _dbSet.AsQueryable();
            usedCriterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));
            _bus.Publish(new BeautyFoundMessage {Beauties = queryable.ToArray(), Criterias = criterias.ToArray()});
        }

        public void Add(params Business.Beauty[] beauties)
        {
            _dbSet.AddRange(beauties);
        }

        public void SendBeautyFoundMessageBasedOnUsedCriterias()
        {
            Find(_usedCriterias);
        }
    }
}