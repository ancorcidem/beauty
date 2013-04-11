using Beauty.UI.WinForms.Views;
using StructureMap.Configuration.DSL;

namespace Beauty.UI.WinForms.StructureMapRegistries
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            For<IFilterView>().Singleton().Use<MainForm>();
            Forward<IFilterView, MainForm>();
        }
    }
}