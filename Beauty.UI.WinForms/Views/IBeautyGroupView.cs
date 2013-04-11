using Beauty.UI.WinForms.Models;

namespace Beauty.UI.WinForms.Views
{
    public interface IBeautyGroupView
    {
        void Show(MainFormViewModel mainFormViewModel);
        void Hide(MainFormViewModel mainFormViewModel);
    }
}