using System.Collections.Generic;
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

        private readonly List<BeautyViewModel> _shownBeauties = new List<BeautyViewModel>();

        public BeautyMainViewPresenter(IBeautyGroupView groupdView, IFilterView filterView, IBeautyFilter beautyFilter,
                                       IBus bus)
        {
            _groupdView = groupdView;
            _filterView = filterView;
            _beautyFilter = beautyFilter;
            _bus = bus;
            _bus.Subscribe<BeautyFoundMessage>(Handler);

            _filterView.FilterChanged += OnFilterChanged;
        }

        private void OnFilterChanged(object sender, FilterChangeEventArgs eventArgs)
        {
            var beauties2Hide = _shownBeauties.Where(model => !(model.Age.Value <= int.Parse(eventArgs.SearchParameters.AgeTo.Value) && model.Age.Value >= int.Parse(eventArgs.SearchParameters.AgeFrom.Value)));

            _groupdView.Hide(new MainFormViewModel
            {
                Beauties = beauties2Hide
            });

            _beautyFilter.Filter = new Criteria[] { eventArgs.SearchParameters.AgeFrom, eventArgs.SearchParameters.AgeTo };
        }

        private void Handler(BeautyFoundMessage message)
        {
            var beautyViews =
                Mapper.Map<IEnumerable<Business.Beauty>, IEnumerable<BeautyViewModel>>(message.Beauties).ToArray();

            _shownBeauties.AddRange(beautyViews);

            var model = new MainFormViewModel
                {
                    Beauties = beautyViews
                };

            _groupdView.Show(model);
        }
    }
}