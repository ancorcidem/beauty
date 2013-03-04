using Beauty.Business;
using Beauty.UI.WinForms;
using StructureMap.Configuration.DSL;

namespace Beauty.UI.Specs
{
    public class UiMockRegistry : Registry
    {
        public UiMockRegistry()
        {
            For<IBeautyRepository>().Singleton().Use<BeautyMockRepository>();
            Forward<IBeautyRepository, BeautyMockRepository>();

            For<BeautyFactory>().Singleton().Use<BeautyFactory>();

            For<IMainView>().Singleton().Use(Rhino.Mocks.MockRepository.GenerateStub<IMainView>());
            For<MainScreenController>().Singleton().Use<MainScreenController>();
        }
    }
}