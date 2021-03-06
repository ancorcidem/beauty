using System.Windows.Forms;
using Beauty.UI.WinForms.Extensions;
using Beauty.UI.WinForms.Models;

namespace Beauty.UI.WinForms.Views
{
    public partial class BeautyAvatar : UserControl
    {
        private readonly BeautyViewModel _beauty;

        public BeautyAvatar(BeautyViewModel beauty)
        {
            InitializeComponent();

            _beauty = beauty;
            avatarPictureBox.Image = _beauty.Avatar.Scale(avatarPictureBox.Size);
            toolTip1.SetToolTip(avatarPictureBox, _beauty.Name);
        }

        public BeautyViewModel Model
        {
            get { return _beauty; }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.MouseDown += (sender, args) => OnMouseDown(args);
            e.Control.MouseMove += (sender, args) => OnMouseMove(args);
            e.Control.MouseUp += (sender, args) => OnMouseUp(args);
        }
    }
}