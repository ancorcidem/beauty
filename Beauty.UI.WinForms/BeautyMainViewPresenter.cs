﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Beauty.Business;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;

namespace Beauty.UI.WinForms
{
    public class BeautyMainViewPresenter
    {
        private readonly IBeautyGroupView _groupdView;
        private readonly IFilterView _filterView;
        private readonly IBeautyFilter _beautyFilter;
        private readonly IBus _bus;

        private readonly Dictionary<Business.Beauty, BeautyViewModel> _shownBeauties =
            new Dictionary<Business.Beauty, BeautyViewModel>();

        public BeautyMainViewPresenter(IBeautyGroupView groupdView, IFilterView filterView, IBeautyFilter beautyFilter,
                                       IBus bus)
        {
            _groupdView = groupdView;
            _filterView = filterView;
            _beautyFilter = beautyFilter;
            _bus = bus;
            _bus.Subscribe<BeautyFoundMessage>(Handler);

            _filterView.FilterChanged += OnFilterViewChanged;
            _beautyFilter.Changed += OnBeautyFilterChanged;
        }

        private void OnBeautyFilterChanged(object sender, Business.FilterChangeEventArgs eventArgs)
        {
            var beauties2Hide = SelectBeauties2Hide(eventArgs.NewFilter);

            var views2Hide = new List<BeautyViewModel>();

            foreach (var beauty in beauties2Hide)
            {
                views2Hide.Add(_shownBeauties[beauty]);
                _shownBeauties.Remove(beauty);
            }

            _groupdView.Hide(new MainFormViewModel
                {
                    Beauties = views2Hide
                });
        }

        private IEnumerable<Business.Beauty> SelectBeauties2Hide(IEnumerable<Criteria> newFilter)
        {
            var beautiesThatWillBeShown = _shownBeauties.Keys.AsQueryable();
            newFilter.ToList().ForEach(x => beautiesThatWillBeShown = x.ApplyOn(beautiesThatWillBeShown));

            var beauties2Hide = _shownBeauties.Keys.Where(beauty => !beautiesThatWillBeShown.Contains(beauty)).ToArray();
            return beauties2Hide;
        }

        private void OnFilterViewChanged(object sender, FilterChangeEventArgs eventArgs)
        {
            _beautyFilter.Filter = new Criteria[] {eventArgs.SearchParameters.AgeFrom, eventArgs.SearchParameters.AgeTo};
        }

        private void Handler(BeautyFoundMessage message)
        {
            foreach (var beauty in message.Beauties)
            {
                var beautyView = Mapper.Map<Business.Beauty, BeautyViewModel>(beauty);
                if (!_shownBeauties.ContainsKey(beauty))
                {
                    _shownBeauties[beauty] = beautyView;
                }
            }

            var model = new MainFormViewModel
                {
                    Beauties = _shownBeauties.Values
                };

            _groupdView.Show(model);
        }
    }
}