using System.Data.Entity;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business.Specs
{
    [Binding]
    public class BeautySpecsInitialization
    {
        [BeforeScenario]
        public void InitDrop()
        {
            Database.SetInitializer(new BeautyDbInitializer());
            ObjectFactory.Initialize(x => x.AddRegistry<BusinessMockRegistry>());
        }
    }
}