using System.Windows.Forms;
using Beauty.UI.WinForms.Extensions;

namespace Beauty.UI.WinForms
{
    public partial class BeautyAvatar : UserControl
    {
        private readonly BeautyViewModel _beauty;

        public BeautyAvatar(BeautyViewModel beauty)
        {
            InitializeComponent();

            _beauty = beauty;
            avatarPictureBox.Image = _beauty.Avatar.Scale(avatarPictureBox.Size);
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