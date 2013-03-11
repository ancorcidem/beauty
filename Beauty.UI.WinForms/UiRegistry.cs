using Beauty.Business.Dal;

namespace Beauty.UI.WinForms
{
    public class UiRegistry : ProductionRegistry
    {
        public UiRegistry()
        {
            For<IMainView>().Singleton().Use<MainForm>();
            Forward<IMainView, MainForm>();
        }
    }
}