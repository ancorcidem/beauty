using System.Data.Entity;
using Beauty.Business;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Specs.UI.StepDefinitions
{
    [Binding]
    public class BeautyDbContextInitalization
    {
        [BeforeScenario]
        public void InitDrop()
        {
            ObjectFactory.Initialize(x => x.For<IBeautyRepository>().Singleton().Use(() =>
                {
                    Database.SetInitializer(new BeautyDbInitializer());

                    return new BeautyMockRepository();
                }));
        }
    }
}