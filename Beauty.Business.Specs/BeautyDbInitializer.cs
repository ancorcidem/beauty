using System.Data.Entity;
using Beauty.Business.Dal;

namespace Beauty.Business.Specs
{
    public class BeautyDbInitializer : DropCreateDatabaseAlways<BeautyDbContext>
    {
    }
}