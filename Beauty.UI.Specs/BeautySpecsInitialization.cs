using AutoMapper;
using Beauty.UI.WinForms;
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
            Mapper.Initialize(x => x.AddProfile<AutoMapperProductionProfile>());
        }
    }
}
