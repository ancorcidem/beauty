using System;
using System.Linq;
using System.Windows.Forms;
using Beauty.Business;
using Beauty.UI.WinForms.Extensions;
using Beauty.UI.WinForms.Models;

namespace Beauty.UI.WinForms.Views
{
    public partial class MainForm : Form, IFilterView, IBeautyGroupView
    {
        private readonly SearchParameters _searchParams;

        public MainForm()
        {
            InitializeComponent();

            _searchParams = new SearchParameters();

            ageFromTextBox.Text = _searchParams.AgeFrom.Value;
            ageToTextBox.Text = _searchParams.AgeTo.Value;

            ageToTextBox.TextChanged +=
                (sender, args) => ageToTextBox.Text.ParseToIntAndStoreTo(x => _searchParams.AgeTo = x);

            ageFromTextBox.TextChanged +=
                (sender, args) => ageFromTextBox.Text.ParseToIntAndStoreTo(x => _searchParams.AgeFrom = x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterChanged.Raise(this, new FilterChangeEventArgs(_searchParams));
        }

        public event EventHandler<FilterChangeEventArgs> FilterChanged;

        private delegate void ShowCallback(MainFormViewModel mainFormViewModel);

        public void Show(MainFormViewModel mainFormViewModel)
        {
            this.InvokeSafe(() =>
                {
                    foreach (var view in mainFormViewModel.Beauties.Select(beauty => new BeautyAvatar(beauty)))
                    {
                        view.Draggable(true);
                        panel2.Controls.Add(view);
                    }
                });
        }

        public void Hide(MainFormViewModel mainFormViewModel)
        {
            this.InvokeSafe(() =>
                {
                    if (InvokeRequired)
                    {
                        Invoke(new ShowCallback(Hide), mainFormViewModel);
                        return;
                    }

                    var shownBeauties = mainFormViewModel.Beauties.Select(x => x.Id);
                    var viewsToHide = from beautyAvatar in panel2.Controls.Cast<BeautyAvatar>()
                                      where shownBeauties.Contains(beautyAvatar.Model.Id)
                                      select beautyAvatar;

                    viewsToHide.ToList().ForEach(x =>
                        {
                            panel2.Controls.Remove(x);
                            x.Dispose();
                        });
                });
        }
    }
}