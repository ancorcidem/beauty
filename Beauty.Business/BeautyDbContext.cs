using System.Data.Entity;

namespace Beauty.Business
{
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