using Beauty.Business;
using Beauty.Business.Dal;
using Beauty.UI.WinForms;
using Rhino.Mocks;
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

            For<IMainView>().Singleton().Use(MockRepository.GenerateStub<IMainView>());
            For<IBeautyFilter>().Singleton().Use<BeautyFilterStub>();
            For<IBeautyDataFeed>().Singleton().Use(MockRepository.GenerateStub<IBeautyDataFeed>());
        }
    }
}