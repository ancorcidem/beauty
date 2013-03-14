using StructureMap.Configuration.DSL;

namespace Beauty.UI.WinForms.StructureMapRegistries
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            For<IMainView>().Singleton().Use<MainForm>();
            Forward<IMainView, MainForm>();
        }
    }
}