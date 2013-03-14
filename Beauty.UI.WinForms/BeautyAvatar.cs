using System.Windows.Forms;
using Beauty.UI.WinForms.Extensions;

namespace Beauty.UI.WinForms
{
    public partial class BeautyAvatar : UserControl
    {
        private readonly BeautyMainFormViewModel _beauty;

        public BeautyAvatar(BeautyMainFormViewModel beauty)
        {
            InitializeComponent();

            _beauty = beauty;
            avatarPictureBox.Image = _beauty.Avatar.Scale(avatarPictureBox.Size);
        }
    }
}