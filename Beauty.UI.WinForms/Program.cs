using System;
using System.Windows.Forms;
using AutoMapper;
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
            Mapper.Initialize(x => x.AddProfile<AutomapperProductionProfile>());

            ObjectFactory.GetInstance<BeautyRepositoryPresenter>();
            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}