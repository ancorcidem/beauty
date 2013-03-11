using Beauty.Business;
using Beauty.Business.Criterias;

namespace Beauty.UI.WinForms
{
    public class BeautyRepositoryPresenter
    {
        private readonly IMainView _view;
        private readonly IBeautyFilter _beautyFilter;
        private readonly IBeautyDataFeed _dataFeed;

        public BeautyRepositoryPresenter(IMainView view, IBeautyFilter beautyFilter, IBeautyDataFeed dataFeed)
        {
            _view = view;
            _beautyFilter = beautyFilter;
            _dataFeed = dataFeed;

            _view.FilterChanged += OnFilterChanged;
            _dataFeed.Found += DataFeedOnFound;
        }

        private void DataFeedOnFound(object sender, BeautyFoundEventArgs beautyFoundEventArgs)
        {
            var model = new BeautyViewModel {Beauties = beautyFoundEventArgs.Beauties};
            _view.Show(model);
        }

        private void OnFilterChanged(object sender, FilterChangeEventArgs eventArgs)
        {
            _beautyFilter.Filter = new Criteria[] {eventArgs.SearchParameters.AgeFrom, eventArgs.SearchParameters.AgeTo};
        }
    }
}