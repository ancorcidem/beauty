using System.Data.Entity;
using Beauty.Business.Dal;

namespace Beauty.Business
{
    public class BeautyDbInitializer : DropCreateDatabaseAlways<BeautyDbContext>
    {
    }
}