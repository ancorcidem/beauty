using System;
using System.Windows.Forms;
using StructureMap;

namespace Beauty.UI.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ObjectFactory.Initialize(x => x.AddRegistry<UiRegistry>());

            ObjectFactory.GetInstance<MainFormController>();
            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}