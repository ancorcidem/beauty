using System;
using System.Data.Entity;
using System.Windows.Forms;
using Beauty.Business.Dal;
using Beauty.UI.WinForms.Presenters;
using Beauty.UI.WinForms.Views;
using Bootstrap;
using Bootstrap.AutoMapper;
using Bootstrap.StructureMap;
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
            Database.SetInitializer(new BeautyDbInitializer());

            Bootstrapper.With.AutoMapper().And.StructureMap().UsingObjectFactory().Start();

            ObjectFactory.GetInstance<BeautyMainViewPresenter>();
            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}