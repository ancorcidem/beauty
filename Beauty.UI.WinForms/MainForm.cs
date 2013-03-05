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

            ageFromTextBox.DataBindings.Add("Text", _searchParams, "AgeFrom", true);
            ageToTextBox.DataBindings.Add("Text", _searchParams, "AgeTo", true);
            //(new System.Windows.Forms.Binding("Text", this.entityObjectBindingSource, "NullableInt", true));
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