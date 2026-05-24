using DarkUI.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkLabel : Label
    {
        [Category("Layout")]
        [Description("Enables automatic height sizing based on the contents of the label.")]
        [DefaultValue(false)]
        public bool AutoUpdateHeight
        {
            get { return _autoUpdateHeight; }
            set
            {
                _autoUpdateHeight = value;

                if (_autoUpdateHeight)
                {
                    AutoSize = false;
                    ResizeLabel();
                }
            }
        }

        [Category("Layout")]
        [Description("Enables automatic resizing based on font size. Note that this is only valid for label controls that do not wrap text.")]
        [DefaultValue(true)]
        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                base.AutoSize = value;

                if (AutoSize)
                    AutoUpdateHeight = false;
            }
        }

        [Category("Behavior")]
        [Description("Indicates whether the user can use the TAB key to give focus to the control.")]
        [DefaultValue(false)]
        [Browsable(true)]
        public new bool TabStop
        {
            get => base.TabStop;
            set => base.TabStop = value;
        }

        private bool _autoUpdateHeight;
        private bool _isGrowing;

        public DarkLabel()
        {
            SetStyle(ControlStyles.Selectable, true);
            ForeColor = ThemeProvider.CurrentTheme.LightText;
        }

        private void ResizeLabel()
        {
            if (!_autoUpdateHeight || _isGrowing)
                return;

            try
            {
                _isGrowing = true;
                var sz = new Size(Width, int.MaxValue);
                sz = TextRenderer.MeasureText(Text, Font, sz, TextFormatFlags.WordBreak);
                Height = sz.Height + Padding.Vertical;
            }
            finally
            {
                _isGrowing = false;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ResizeLabel();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResizeLabel();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeLabel();
        }
    }
}
