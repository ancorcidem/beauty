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
    }
}