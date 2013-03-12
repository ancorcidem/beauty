using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using StructureMap.Configuration.DSL;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.Dal
{
    public class ProductionRegistry : Registry
    {
        public ProductionRegistry()
        {
            For<IBeautyFilter>().Singleton().Use<BeautyRepository>();
            Forward<IBeautyFilter, IBeautyDataFeed>();

            var executionEngineExpression = For<IExecutionEngine>().Singleton();
            ConfigureExecutionEngine(executionEngineExpression);

            CreatePluginFamilyExpression<ISiteBrowser> pluginFamilyExpression = For<ISiteBrowser>();
            ConfigureSiteBrowser(pluginFamilyExpression);

            CreatePluginFamilyExpression<IImageDownloader> createPluginFamilyExpression = For<IImageDownloader>().Singleton();
            ConfigureImageDownloader(createPluginFamilyExpression);
        }

        protected virtual void ConfigureImageDownloader(CreatePluginFamilyExpression<IImageDownloader> createPluginFamilyExpression)
        {
            createPluginFamilyExpression.Use<ImageDownloader>();
        }

        protected virtual void ConfigureSiteBrowser(CreatePluginFamilyExpression<ISiteBrowser> siteBrowserExpression)
        {
            siteBrowserExpression.Use<SiteBrowser>();
        }

        protected virtual void ConfigureExecutionEngine(
            CreatePluginFamilyExpression<IExecutionEngine> executionEngineExpression)
        {
            executionEngineExpression.Use<AsyncExecutionEngine>();
        }
    }

    public class ImageDownloader : IImageDownloader
    {
        public byte[] Download(Uri address)
        {
            return new WebClient().DownloadData(address);
        }
    }
}