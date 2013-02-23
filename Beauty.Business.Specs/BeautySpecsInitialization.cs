using Beauty.Specs.Business.StepDefinitions;
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
            ObjectFactory.Initialize(x => x.AddRegistry<BusinessMockRegistry>());
        }
    }
}