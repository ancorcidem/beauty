using Beauty.Business;
using Beauty.Business.Criterias;
using Beauty.Business.Dal;

namespace Beauty.UI.WinForms
{
    public class MainFormController
    {
        private readonly IMainView _view;
        private readonly IBeautyRepository _repository;

        public MainFormController(IMainView view, IBeautyRepository repository)
        {
            _view = view;
            _repository = repository;
            _view.SearchButtonPressed += ViewOnSearchButtonPressed;
        }

        private void ViewOnSearchButtonPressed(object sender, SearchButtonPressEventArgs eventArgs)
        {
            var searchParameters = eventArgs.SearchParameters;

            var result =
                _repository.Find(new Criteria[] {searchParameters.AgeFrom, searchParameters.AgeTo});

            _view.Show(new BeautyViewModel {Beauties = result});
        }
    }
}