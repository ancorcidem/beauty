using System;
using Beauty.Business.Dal;
using StructureMap.Configuration.DSL.Expressions;

namespace Beauty.Business.Specs
{
    public class BusinessSpecsRegistry : ProductionRegistry
    {
        public BusinessSpecsRegistry()
        {
            For<ISiteBrowser>().Singleton().Use<SiteBrowserMock>();
            Forward<ISiteBrowser, SiteBrowserMock>();

            For<BeautyFactory>().Singleton().Use<BeautyFactory>();
        }

        protected override void ConfigureExecutionEngine(
            CreatePluginFamilyExpression<IExecutionEngine> executionEngineExpression)
        {
            executionEngineExpression.Use<SyncExecutionEngine>();
        }
    }

    public class SyncExecutionEngine : IExecutionEngine
    {
        public void Execute(Action action)
        {
            action();
        }
    }
}