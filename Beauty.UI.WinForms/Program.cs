using System;
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
            new BeautyDbInitializer().InitializeDatabase(new BeautyDbContext());

            //ObjectFactory.Initialize(x =>
            //    {
            //        x.AddRegistry<UiRegistry>();
            //        x.AddRegistry<ProductionRegistry>();
            //    });

            Bootstrapper.With.AutoMapper().And.StructureMap().UsingObjectFactory().Start();

            //Mapper.Initialize(x => x.AddProfile<AutoMapperProductionProfile>());

            ObjectFactory.GetInstance<BeautyMainViewPresenter>();
            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}