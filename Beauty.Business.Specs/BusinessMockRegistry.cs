using StructureMap.Configuration.DSL;

namespace Beauty.Business.Specs
{
    public class BusinessMockRegistry : Registry
    {
        public BusinessMockRegistry()
        {
            For<IBeautyRepository>().Singleton().Use<BeautyRepository>();
        }
    }
}