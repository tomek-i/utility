using System;
using System.Drawing;
using System.Windows.Forms;

namespace TIUtilities.Logic
{
    public static class ControlExtensions
    {
        [Flags]
        public enum AlignMode
        {
           Vertical=1,
           Horizontal,
           Center = Vertical|Horizontal
        }
        //centet
        public static Control Align(this Control control, AlignMode mode)
        {
            return control.Align(control.Parent, mode);
           }
        public static Control Align(this Control control, Control container, AlignMode mode)
        {
            var width = control.Width;
            var ehight = control.Height;
                var midW = width / 2;
            var midH = ehight / 2;

            switch (mode)
            {
                case AlignMode.Vertical:
                    control.Location = new Point(control.Location.X,container.Height/2-midH);
                    break;
                case AlignMode.Horizontal:
                    control.Location = new Point(container.Width / 2 - midW, control.Location.Y);
                    break;
                case AlignMode.Center:
                default:
                    control.Location = new Point(container.Width/2-midW,container.Height/2-midH);
                    break;
            }
            container.Invalidate();
            return control;
        }
    }
}