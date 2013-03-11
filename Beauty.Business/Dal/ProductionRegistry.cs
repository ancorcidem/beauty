using StructureMap.Configuration.DSL;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.Dal
{
    public class ProductionRegistry : Registry
    {
        public ProductionRegistry()
        {
            CreatePluginFamilyExpression<IBeautyDataFeed> createPluginFamilyExpression = For<IBeautyDataFeed>();
            ConfigureBeautyDataFeed(createPluginFamilyExpression);
            ConfigureBeautyFilter();

            For<IBeautyFilter>().Use<BeautyRepository>();

            var executionEngineExpression = For<IExecutionEngine>().Singleton();
            ConfigureExecutionEngine(executionEngineExpression);

            CreatePluginFamilyExpression<ISiteBrowser> pluginFamilyExpression = For<ISiteBrowser>();
            ConfigureSiteBrowser(pluginFamilyExpression);
        }

        protected virtual void ConfigureSiteBrowser(CreatePluginFamilyExpression<ISiteBrowser> pluginFamilyExpression)
        {
            pluginFamilyExpression.Use<SiteBrowser>();
        }

        protected virtual void ConfigureBeautyFilter()
        {
            Forward<IBeautyDataFeed, IBeautyFilter>();
        }

        protected virtual void ConfigureBeautyDataFeed(
            CreatePluginFamilyExpression<IBeautyDataFeed> createPluginFamilyExpression)
        {
            createPluginFamilyExpression.Singleton().Use<BeautyRepository>();
        }

        protected virtual void ConfigureExecutionEngine(
            CreatePluginFamilyExpression<IExecutionEngine> executionEngineExpression)
        {
            executionEngineExpression.Use<AsyncExecutionEngine>();
        }
    }
}