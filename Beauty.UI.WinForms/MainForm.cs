using System;
using System.Windows.Forms;

namespace Beauty.UI.WinForms
{
    public partial class MainForm : Form, IMainView
    {
        private readonly SearchParameters _searchParameters;

        public MainForm()
        {
            InitializeComponent();

            _searchParameters = new SearchParameters
                {
                    AgeFrom = 19,
                    AgeTo = 25
                };

            bindingSource1.Add(_searchParameters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SearchButtonPressed == null) return;

            SearchButtonPressed(this, new SearchButtonPressEventArgs(_searchParameters));
        }

        public event EventHandler<SearchButtonPressEventArgs> SearchButtonPressed;

        public void Show(BeautyViewModel beautyViewModel)
        {
        }
    }
}