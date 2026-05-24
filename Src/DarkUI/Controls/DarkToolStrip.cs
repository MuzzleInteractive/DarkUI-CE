using DarkUI.Config;
using DarkUI.Renderers;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkToolStrip : ToolStrip
    {
        [Category("Appearance")]
        [Description("Defines if the border is drawn.")]
        [DefaultValue(true)]
        public bool DrawBorder
        {
            get { return _drawBorder; }
            set
            {
                _drawBorder = value;
                Invalidate();
            }
        }

        private bool _drawBorder;

        public DarkToolStrip()
        {
            Renderer = new DarkToolStripRenderer();
            Padding = new Padding(5, 0, 1, 0);
            AutoSize = false;
            Size = new Size(1, 28);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;

            using (var b = new SolidBrush(ThemeProvider.CurrentTheme.GreyBackground))
                g.FillRectangle(b, ClientRectangle);

            if (!DrawBorder)
                return;

            using (var p = new Pen(ThemeProvider.CurrentTheme.DarkBorder))
                g.DrawLine(p, ClientRectangle.Left, (ClientSize.Height - 2), ClientRectangle.Right, (ClientSize.Height - 2));

            using (var p = new Pen(ThemeProvider.CurrentTheme.LightBorder))
                g.DrawLine(p, ClientRectangle.Left, (ClientSize.Height - 2) + 1, ClientRectangle.Right, (ClientSize.Height - 2) + 1);
        }
    }
}
