using System.Collections.Generic;
using System.Linq;
using Beauty.Business;
using Beauty.Business.Dal;
using Beauty.Business.ServiceBus;
using Beauty.Specs.Common;
using Beauty.Specs.Common.Mocks;
using Beauty.UI.WinForms;
using Beauty.UI.WinForms.Models;
using Beauty.UI.WinForms.Views;
using Rhino.Mocks;
using StructureMap.Configuration.DSL;

namespace Beauty.UI.Specs
{
    public class UiMockRegistry : Registry
    {
        public UiMockRegistry()
        {
            For<IBeautyRepository>().Singleton().Use<BeautyMockRepository>();
            Forward<IBeautyRepository, BeautyMockRepository>();

            For<BeautyFactory>().Singleton().Use<BeautyFactory>();

            For<IFilterView>().Singleton().Use(MockRepository.GenerateStub<IFilterView>());

            For<IBeautyGroupView>().Singleton().Use<BeautyGroupViewMock>();
            Forward<IBeautyGroupView, BeautyGroupViewMock>();

            For<IBeautyFilter>().Singleton().Use<BeautyFilterStub>();
            For<IBus>().Singleton().Use<Bus>();
            For<IExecutionEngine>().Singleton().Use<SyncExecutionEngine>();
            For<IImageDownloader>().Singleton().Use<ImageDownloaderMock>();
        }
    }

    public class BeautyGroupViewMock : IBeautyGroupView
    {
        private readonly List<BeautyViewModel> _shownBeauties = new List<BeautyViewModel>();

        public void Show(MainFormViewModel mainFormViewModel)
        {
            _shownBeauties.AddRange(mainFormViewModel.Beauties);
        }

        public void Hide(MainFormViewModel mainFormViewModel)
        {
            var beautiesToHide = mainFormViewModel.Beauties.Select(x => x.Id);
            _shownBeauties.RemoveAll(x => beautiesToHide.Contains(x.Id));
        }

        public BeautyViewModel[] BeautiesOnTheStage
        {
            get { return _shownBeauties.ToArray(); }
        }
    }
}