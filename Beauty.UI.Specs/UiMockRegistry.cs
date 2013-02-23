using Beauty.Business;
using Beauty.Specs.Common;
using StructureMap.Configuration.DSL;

namespace Beauty.UI.Specs
{
    public class UiMockRegistry : Registry
    {
        public UiMockRegistry()
        {
            For<IBeautyRepository>().Singleton().Use<BeautyMockRepository>();

            For<BeautyFactory>().Singleton().Use<BeautyFactory>();
        }
    }
}