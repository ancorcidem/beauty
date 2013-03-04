using System;
using System.Windows.Forms;

namespace Beauty.UI.WinForms
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SearchButtonPressed == null) return;

            SearchButtonPressed(this,
                                new SearchButtonPressEventArgs(new SearchParameters
                                    {
                                        AgeFrom = int.Parse(ageFromTextBox.Text),
                                        AgeTo = int.Parse(ageToTextBox.Text)
                                    }));
        }

        public event EventHandler<SearchButtonPressEventArgs> SearchButtonPressed;

        public void Show(BeautyViewModel beautyViewModel)
        {

        }
    }
}