using System.Data.Entity;

namespace Beauty.Business.Dal
{
    public class BeautyDbInitializer : DropCreateDatabaseIfModelChanges<BeautyDbContext>
    {
    }
}