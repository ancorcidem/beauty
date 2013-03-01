using Beauty.Business;
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
        }
    }
}