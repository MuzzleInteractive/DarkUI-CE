using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkPictureBox : PictureBox
    {
        [DefaultValue(InterpolationMode.NearestNeighbor)]
        public InterpolationMode InterpolationMode { get { return _im; } set { _im = value; Refresh(); } }
        private InterpolationMode _im = InterpolationMode.NearestNeighbor;

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(pe);
        }
    }
}
