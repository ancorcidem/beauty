using System.Data.Entity;
using Beauty.Business;

namespace Beauty.Specs.UI.StepDefinitions
{
    public class BeautyDbInitializer : DropCreateDatabaseAlways<BeautyDbContext>
    {
    }
}