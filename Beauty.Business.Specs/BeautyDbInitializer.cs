using System.Data.Entity;

namespace Beauty.Business.Specs
{
    public class BeautyDbInitializer : DropCreateDatabaseAlways<BeautyDbContext>
    {
    }
}