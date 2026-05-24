using DarkUI.Config;
using DarkUI.Win32;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkTextBox : TextBox
    {
        [Category("Appearance")]
        [Description("Specifies the PlaceholderText of the TextBox control. The PlaceholderText is displayed in the control when the Text property is null or empty and can be used to guide the user what input is expected by the control.")]
        [DefaultValue("")]
        public string NewPlaceholderText
        {
            get
            {
                return _newPlaceholderText;
            }
            set
            {
                _newPlaceholderText = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color BackColor { get; set; }

        private string _newPlaceholderText = "";

        public DarkTextBox()
        {
            Padding = new Padding(2, 2, 2, 2);
            BorderStyle = BorderStyle.FixedSingle;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw, true);

            base.ForeColor = ThemeProvider.CurrentTheme.LightText;
            base.BackColor = ThemeProvider.CurrentTheme.LightBackground;
        }

        public override void Refresh()
        {
            base.ForeColor = ThemeProvider.CurrentTheme.LightText;
            base.BackColor = ThemeProvider.CurrentTheme.LightBackground;
            base.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case (int)WM.PAINT:
                    if (!Focused && string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(NewPlaceholderText))
                    {
                        using (var g = Graphics.FromHwnd(Handle))
                        {
                            DrawPlaceholderText(g);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void DrawPlaceholderText(Graphics g)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
            Rectangle rectangle = ClientRectangle;

            rectangle.Offset(Padding.Left - 1, Padding.Top - 1);

            if (RightToLeft == RightToLeft.Yes)
            {
                flags |= TextFormatFlags.RightToLeft;
                switch (TextAlign)
                {
                    case HorizontalAlignment.Center:
                        flags |= TextFormatFlags.HorizontalCenter;
                        rectangle.Offset(0, 1);
                        break;
                    case HorizontalAlignment.Left:
                        flags |= TextFormatFlags.Right;
                        rectangle.Offset(1, 1);
                        break;
                    case HorizontalAlignment.Right:
                        flags |= TextFormatFlags.Left;
                        rectangle.Offset(0, 1);
                        break;
                }
            }
            else
            {
                flags &= ~TextFormatFlags.RightToLeft;
                switch (TextAlign)
                {
                    case HorizontalAlignment.Center:
                        flags |= TextFormatFlags.HorizontalCenter;
                        rectangle.Offset(0, 1);
                        break;
                    case HorizontalAlignment.Left:
                        flags |= TextFormatFlags.Left;
                        rectangle.Offset(1, 1);
                        break;
                    case HorizontalAlignment.Right:
                        flags |= TextFormatFlags.Right;
                        rectangle.Offset(0, 1);
                        break;
                }
            }

            TextRenderer.DrawText(g, NewPlaceholderText, Font, rectangle, ThemeProvider.CurrentTheme.DisabledText, ThemeProvider.CurrentTheme.LightBackground, flags);
        }
    }
}
