using System.Data.Entity;

namespace Beauty.Business
{
    public interface IBeautyRepository
    {
        IDbSet<Beauty> Beauties { get; }
        void SaveChanges();
    }
}