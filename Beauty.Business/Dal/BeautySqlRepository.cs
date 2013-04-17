using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;

namespace Beauty.Business.Dal
{
    public class BeautySqlRepository : IBeautyRepository
    {
        private readonly IBus _bus;
        private readonly BeautyDbContext _context = new BeautyDbContext();

        public BeautySqlRepository(IBus bus)
        {
            _bus = bus;
            _bus.Subscribe<BeautyProfileFoundMessage>(NewProfileFound);
        }

        private void NewProfileFound(BeautyProfileFoundMessage msg)
        {

            lock (_context)
            {
                var beauty = Mapper.Map<BeautyProfile, Beauty>(msg.Profile);

                if (_context.Beauties.Any(x => x.Url == beauty.Url)) return;
                Add(beauty);

                _bus.Publish(new BeautyFoundMessage { Beauties = new[] { beauty }, Criterias = new Criteria[] { } });
            }
        }

        public void Commit()
        {
            lock (_context)
            {
                _context.SaveChanges();
            }
        }

        public void Find(IEnumerable<Criteria> criterias)
        {
            lock (_context)
            {
                IQueryable<Beauty> queryable = _context.Beauties;
                criterias.ToList().ForEach(x => queryable = x.ApplyOn(queryable));


                _bus.Publish(new BeautyFoundMessage {Beauties = queryable.ToArray(), Criterias = criterias.ToArray()});
            }
        }

        public void Add(params Beauty[] beauties)
        {
            lock (_context)
            {
                foreach (var beauty in beauties)
                {
                    _context.Beauties.Add(beauty);
                }
                Commit();
            }
        }
    }
}