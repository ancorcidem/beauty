using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.UI.Specs
{
    [Binding]
    public class BeautySpecsInitialization
    {
        [BeforeScenario]
        public void InitDrop()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<UiMockRegistry>());
        }
    }
}
