using System;
using System.Windows.Forms;

namespace Beauty.UI.WinForms
{
    public partial class MainForm : Form, IMainView
    {
        private SearchParameters _searchParams;

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
            if (SearchButtonPressed == null) return;

            SearchButtonPressed(this, new SearchButtonPressEventArgs(_searchParams));
        }

        public event EventHandler<SearchButtonPressEventArgs> SearchButtonPressed;

        public void Show(BeautyViewModel beautyViewModel)
        {
        }
    }
}