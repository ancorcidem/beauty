using Beauty.Business.Dal;
using StructureMap.Configuration.DSL;

namespace Beauty.UI.WinForms
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            For<IMainView>().Singleton().Use<MainForm>();
            Forward<IMainView, MainForm>();
            For<IBeautyRepository>().Use<BeautyRepository>();
            For<ISiteBrowser>().Use<SiteBrowser>();
        }
    }
}