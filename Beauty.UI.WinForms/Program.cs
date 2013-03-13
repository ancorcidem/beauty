using System;
using System.Windows.Forms;
using AutoMapper;
using Beauty.Business.Dal;
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

            ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry<UiRegistry>();
                    x.AddRegistry<ProductionRegistry>();
                });

            //Bootstrapper.With.AutoMapper().And.StructureMap().Start();

            Mapper.Initialize(x => x.AddProfile<AutoMapperProductionProfile>());

            ObjectFactory.GetInstance<BeautyRepositoryPresenter>();
            Application.Run(ObjectFactory.GetInstance<MainForm>());
        }
    }
}