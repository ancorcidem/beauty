using Beauty.Business.Dal;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.Specs
{
    public class BusinessSpecsRegistry : ProductionRegistry
    {
        public BusinessSpecsRegistry()
        {
            For<BeautyFactory>().Singleton().Use<BeautyFactory>();
        }

        protected override void ConfigureSiteBrowser(CreatePluginFamilyExpression<ISiteBrowser> siteBrowserExpression)
        {
            siteBrowserExpression.Singleton().Use<SiteBrowserMock>();
            Forward<ISiteBrowser, SiteBrowserMock>();
        }

        protected override void ConfigureExecutionEngine(
            CreatePluginFamilyExpression<IExecutionEngine> executionEngineExpression)
        {
            executionEngineExpression.Use<SyncExecutionEngine>();
        }
    }
}