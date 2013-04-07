using System;
using System.Windows.Forms;
using Beauty.Business;
using Beauty.UI.WinForms.Extensions;

namespace Beauty.UI.WinForms
{
    public partial class MainForm : Form, IFilterView
    {
        private readonly SearchParameters _searchParams;

        public MainForm()
        {
            InitializeComponent();

            _searchParams = new SearchParameters
                {
                    AgeFrom = 19,
                    AgeTo = 25
                };

            ageFromTextBox.Text = _searchParams.AgeFrom.Value;
            ageToTextBox.Text = _searchParams.AgeTo.Value;

            ageToTextBox.TextChanged += (sender, args) => _searchParams.AgeTo = int.Parse(ageToTextBox.Text);
            ageFromTextBox.TextChanged += (sender, args) => _searchParams.AgeFrom = int.Parse(ageFromTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterChanged.Raise(this, new FilterChangeEventArgs(_searchParams));
        }

        public event EventHandler<FilterChangeEventArgs> FilterChanged;

        private delegate void ShowCallback(MainFormViewModel mainFormViewModel);

        public void Show(MainFormViewModel mainFormViewModel)
        {
            if (InvokeRequired)
            {
                Invoke(new ShowCallback(Show), mainFormViewModel);
                return;
            }

            //panel2.Controls.Clear();
            foreach (var beauty in mainFormViewModel.Beauties)
            {
                var view = new BeautyAvatar(beauty);
                view.Draggable(true);
                panel2.Controls.Add(view);
            }
        }
    }
}