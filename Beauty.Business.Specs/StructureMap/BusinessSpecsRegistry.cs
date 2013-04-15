using Beauty.Business.Dal;
using Beauty.Business.Dal.StructureMap;
using Beauty.Specs.Common;
using Beauty.Specs.Common.Mocks;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.StructureMap
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

        protected override void ConfigureImageDownloader(
            CreatePluginFamilyExpression<IImageDownloader> createPluginFamilyExpression)
        {
            createPluginFamilyExpression.Use<ImageDownloaderMock>();
        }
    }
}