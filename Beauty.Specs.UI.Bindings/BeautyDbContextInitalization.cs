using System.Data.Entity;
using Beauty.Business;
using StructureMap;
using StructureMap.Configuration.DSL;
using TechTalk.SpecFlow;

namespace Beauty.Specs.UI.StepDefinitions
{
    [Binding]
    public class BeautyDbContextInitalization
    {
        [BeforeScenario]
        public void InitDrop()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<UiMockRegistry>());
        }
    }

    public class UiMockRegistry : Registry
    {
        public UiMockRegistry()
        {
            For<IBeautyRepository>().Singleton().Use(() =>
                {
                    Database.SetInitializer(new BeautyDbInitializer());

                    return new BeautyMockRepository();
                });

            For<BeautyFactory>().Singleton().Use<BeautyFactory>();
        }
    }
}