using StructureMap.Configuration.DSL;

namespace Beauty.Business
{
    public class ProductionRegistry : Registry
    {
        public ProductionRegistry()
        {
            For<IBeautyRepository>().Singleton().Use<BeautyRepository>();
        }
    }
}