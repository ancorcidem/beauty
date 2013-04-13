// taken from here: http://www.codeproject.com/Tips/178587/Draggable-WinForms-Controls

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Beauty.UI.WinForms.Extensions
{
    public static class ThreadSafeExtension
    {
        public static void InvokeSafe(this Control theControl, Action actionToInvoke)
        {
            if (theControl.InvokeRequired)
            {
                theControl.Invoke(actionToInvoke);
            }
        }
    }

    public static class DraggableExtension
    {
        // TKey is control to drag, TValue is a flag used while dragging
        private static readonly Dictionary<Control, bool> Draggables =
            new Dictionary<Control, bool>();

        private static Size _mouseOffset;

        /// <summary>
        /// Enabling/disabling dragging for control
        /// </summary>
        public static void Draggable(this Control control, bool enable)
        {
            if (enable)
            {
                // enable drag feature
                if (Draggables.ContainsKey(control))
                {
                    // return if control is already draggable
                    return;
                }
                // 'false' - initial state is 'not dragging'
                Draggables.Add(control, false);

                // assign required event handlersnnn
                control.MouseDown += control_MouseDown;
                control.MouseUp += control_MouseUp;
                control.MouseMove += control_MouseMove;
            }
            else
            {
                // disable drag feature
                if (!Draggables.ContainsKey(control))
                {
                    // return if control is not draggable
                    return;
                }
                // remove event handlers
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                Draggables.Remove(control);
            }
        }

        private static void control_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOffset = new Size(e.Location);
            // turning on dragging
            Draggables[(Control) sender] = true;
        }

        private static void control_MouseUp(object sender, MouseEventArgs e)
        {
            // turning off dragging
            Draggables[(Control) sender] = false;
        }

        private static void control_MouseMove(object sender, MouseEventArgs e)
        {
            // only if dragging is turned on
            if (!Draggables[(Control) sender]) return;

            // calculations of control's new position
            Point newLocationOffset = e.Location - _mouseOffset;
            ((Control) sender).Left += newLocationOffset.X;
            ((Control) sender).Top += newLocationOffset.Y;
        }

        /// <summary>
        /// Resize image to max dimensions
        /// </summary>
        /// <param name="img">Current Image</param>
        /// <param name="maxWidth">Max width</param>
        /// <param name="maxHeight">Max height</param>
        /// <returns>Scaled image</returns>
        public static Image Scale(this Image img, int maxWidth, int maxHeight)
        {
            double scale = 1;

            if (img.Width > maxWidth || img.Height > maxHeight)
            {
                double scaleW = maxWidth/(double) img.Width;
                double scaleH = maxHeight/(double) img.Height;

                scale = scaleW < scaleH ? scaleW : scaleH;
            }

            return img.Resize((int) (img.Width*scale), (int) (img.Height*scale));
        }

        /// <summary>
        /// Resize the image to the given Size
        /// </summary>
        /// <param name="img">Current Image</param>
        /// <param name="width">Width size</param>
        /// <param name="height">Height size</param>
        /// <returns>Resized Image</returns>
        public static Image Resize(this Image img, int width, int height)
        {
            return img.GetThumbnailImage(width, height, null, IntPtr.Zero);
        }

        /// <summary>
        /// Resize image to max dimensions
        /// </summary>
        /// <param name="img">Current Image</param>
        /// <param name="maxDimensions">Max image size</param>
        /// <returns>Scaled image</returns>
        public static Image Scale(this Image img, Size maxDimensions)
        {
            return img.Scale(maxDimensions.Width, maxDimensions.Height);
        }
    }
}