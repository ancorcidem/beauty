using System.Windows.Forms;

namespace Beauty.UI.WinForms
{
    public partial class BeautyAvatar : UserControl
    {
        private readonly Business.Beauty _beauty;

        public BeautyAvatar(Business.Beauty beauty)
        {
            InitializeComponent();

            _beauty = beauty;
            avatarPictureBox.Image = _beauty.Avatar;

        }
    }
}