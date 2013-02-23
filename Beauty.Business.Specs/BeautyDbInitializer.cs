using System.Data.Entity;
using Beauty.Business;

namespace Beauty.Specs.Business.StepDefinitions
{
    public class BeautyDbInitializer : DropCreateDatabaseAlways<BeautyDbContext>
    {
    }
}