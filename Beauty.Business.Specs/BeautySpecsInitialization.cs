using System.Data.Entity;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business.Specs
{
    [Binding]
    public class BeautySpecsInitialization
    {
        [BeforeScenario]
        public void InitOnline()
        {
            Database.SetInitializer(new BeautyDbInitializer());
            
            var context = new BeautyDbContext();
            context.Database.Initialize(true);

            ObjectFactory.Initialize(x => x.AddRegistry<BusinessSpecsRegistry>());
        }
    }
}