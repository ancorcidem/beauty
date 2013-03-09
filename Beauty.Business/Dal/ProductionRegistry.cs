using StructureMap.Configuration.DSL;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.Dal
{
    public class ProductionRegistry : Registry
    {
        public ProductionRegistry()
        {
            CreatePluginFamilyExpression<IBeautyRepository> createPluginFamilyExpression =
                For<IBeautyRepository>().Singleton();
            
            Configure(createPluginFamilyExpression);
        }

        protected virtual void Configure(CreatePluginFamilyExpression<IBeautyRepository> expression)
        {
            expression.Use<BeautySqlRepository>();
        }
    }
}