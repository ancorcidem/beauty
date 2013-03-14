using System;
using System.Collections.Generic;
using AutoMapper;
using Beauty.Business;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;

namespace Beauty.UI.WinForms
{
    public class BeautyMainViewPresenter
    {
        private readonly IMainView _view;
        private readonly IBeautyFilter _beautyFilter;
        private readonly IBus _bus;

        public BeautyMainViewPresenter(IMainView view, IBeautyFilter beautyFilter, IBus bus)
        {
            _view = view;
            _beautyFilter = beautyFilter;
            _bus = bus;
            _bus.Subscribe<BeautyFoundMessage>(Handler);

            _view.FilterChanged += OnFilterChanged;

        }

        private void OnFilterChanged(object sender, FilterChangeEventArgs eventArgs)
        {
            _beautyFilter.Filter = new Criteria[] {eventArgs.SearchParameters.AgeFrom, eventArgs.SearchParameters.AgeTo};
        }

        private void Handler(BeautyFoundMessage message)
        {
            var beautyViews =
                Mapper.Map<IEnumerable<Business.Beauty>, IEnumerable<BeautyMainFormViewModel>>(message.Beauties);

            var model = new MainFormViewModel
            {
                Beauties =
                    beautyViews
            };
            _view.Show(model);
        }
    }
}