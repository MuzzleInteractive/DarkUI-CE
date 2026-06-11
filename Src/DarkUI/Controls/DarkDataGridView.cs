using DarkUI.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkDataGridView : DataGridView
    {
        [Category("Appearance")]
        [Description("Alternate row background colors using the theme.")]
        [DefaultValue(true)]
        public bool AlternatingRowColors
        {
            get { return _alternatingRowColors; }
            set
            {
                if (_alternatingRowColors == value)
                    return;

                _alternatingRowColors = value;
                UpdateAlternatingRowStyle();
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public new bool EnableHeadersVisualStyles
        {
            get => base.EnableHeadersVisualStyles;
            set => base.EnableHeadersVisualStyles = value;
        }

        [Category("Appearance")]
        [DefaultValue(BorderStyle.None)]
        public new BorderStyle BorderStyle
        {
            get => base.BorderStyle;
            set => base.BorderStyle = value;
        }

        [Category("Appearance")]
        [DefaultValue(DataGridViewCellBorderStyle.Single)]
        public new DataGridViewCellBorderStyle CellBorderStyle
        {
            get => base.CellBorderStyle;
            set => base.CellBorderStyle = value;
        }

        [Category("Appearance")]
        [DefaultValue(DataGridViewHeaderBorderStyle.Single)]
        public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
        {
            get => base.ColumnHeadersBorderStyle;
            set => base.ColumnHeadersBorderStyle = value;
        }

        [Category("Appearance")]
        [DefaultValue(DataGridViewHeaderBorderStyle.Single)]
        public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle
        {
            get => base.RowHeadersBorderStyle;
            set => base.RowHeadersBorderStyle = value;
        }

        [RefreshProperties(RefreshProperties.All)]
        [Category("Behavior")]
        [DefaultValue(DataGridViewColumnHeadersHeightSizeMode.DisableResizing)]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get => base.ColumnHeadersHeightSizeMode;
            set => base.ColumnHeadersHeightSizeMode = value;
        }

        [RefreshProperties(RefreshProperties.All)]
        [Category("Behavior")]
        [DefaultValue(DataGridViewRowHeadersWidthSizeMode.DisableResizing)]
        public new DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
        {
            get => base.RowHeadersWidthSizeMode;
            set => base.RowHeadersWidthSizeMode = value;
        }

        [Category("Appearance")]
        [DefaultValue(25)]
        public new int ColumnHeadersHeight
        {
            get => base.ColumnHeadersHeight;
            set => base.ColumnHeadersHeight = value;
        }

        [Category("Appearance")]
        [DefaultValue(25)]
        public new int RowHeadersWidth
        {
            get => base.RowHeadersWidth;
            set => base.RowHeadersWidth = value;
        }

        private DarkScrollBar _vScrollBar = new DarkScrollBar { ScrollOrientation = DarkScrollOrientation.Vertical, Visible = false };
        private DarkScrollBar _hScrollBar = new DarkScrollBar { ScrollOrientation = DarkScrollOrientation.Horizontal, Visible = false };
        private bool _alternatingRowColors = true;

        public DarkDataGridView()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            EnableHeadersVisualStyles = false;
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.Single;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // DataGridViewDesigner is forcing this to AutoSize
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeight = 25;
            RowHeadersWidth = 25;
            RowTemplate.Height = 25;

            UpdateTheme();

            Controls.Add(_vScrollBar);
            Controls.Add(_hScrollBar);
            _vScrollBar.BringToFront();
            _hScrollBar.BringToFront();

            VerticalScrollBar.VisibleChanged += NativeScrollBar_VisibleChanged;
            HorizontalScrollBar.VisibleChanged += NativeScrollBar_VisibleChanged;
        }

        private void UpdateTheme()
        {
            BackgroundColor = ThemeProvider.CurrentTheme.GreyBackground;
            GridColor = ThemeProvider.CurrentTheme.DarkBorder;

            DefaultCellStyle.BackColor = ThemeProvider.CurrentTheme.GreyBackground;
            DefaultCellStyle.ForeColor = ThemeProvider.CurrentTheme.LightText;
            DefaultCellStyle.SelectionBackColor = Focused ? ThemeProvider.CurrentTheme.AccentSelection : ThemeProvider.CurrentTheme.GreySelection;
            DefaultCellStyle.SelectionForeColor = ThemeProvider.CurrentTheme.LightText;

            UpdateAlternatingRowStyle();

            ColumnHeadersDefaultCellStyle.BackColor = ThemeProvider.CurrentTheme.HeaderBackground;
            ColumnHeadersDefaultCellStyle.ForeColor = ThemeProvider.CurrentTheme.LightText;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeProvider.CurrentTheme.AccentBackground;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = ThemeProvider.CurrentTheme.LightText;
            RowHeadersDefaultCellStyle.BackColor = ThemeProvider.CurrentTheme.HeaderBackground;
            RowHeadersDefaultCellStyle.ForeColor = ThemeProvider.CurrentTheme.LightText;
            RowHeadersDefaultCellStyle.SelectionBackColor = ThemeProvider.CurrentTheme.AccentBackground;
            RowHeadersDefaultCellStyle.SelectionForeColor = ThemeProvider.CurrentTheme.LightText;
        }

        private void UpdateAlternatingRowStyle()
        {
            if (_alternatingRowColors)
            {
                AlternatingRowsDefaultCellStyle.BackColor = ThemeProvider.CurrentTheme.HeaderBackground;
                AlternatingRowsDefaultCellStyle.ForeColor = ThemeProvider.CurrentTheme.LightText;
            }
            else
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
        }

        private void UpdateSelectionColors(bool focused)
        {
            DefaultCellStyle.SelectionBackColor = focused ? ThemeProvider.CurrentTheme.AccentSelection : ThemeProvider.CurrentTheme.GreySelection;
            AlternatingRowsDefaultCellStyle.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
        }

        private void SyncScrollBars()
        {
            bool bothVisible = VerticalScrollBar.Visible && HorizontalScrollBar.Visible;
            int offset = bothVisible ? 1 : 2;

            // Layout
            _vScrollBar.Visible = VerticalScrollBar.Visible;
            _vScrollBar.Location = new Point(VerticalScrollBar.Location.X + 1, VerticalScrollBar.Location.Y + 1);
            _vScrollBar.Size = new Size(Consts.ScrollBarSize, VerticalScrollBar.Height - offset);
            _hScrollBar.Visible = HorizontalScrollBar.Visible;
            _hScrollBar.Location = new Point(HorizontalScrollBar.Location.X + 1, HorizontalScrollBar.Location.Y + 1);
            _hScrollBar.Size = new Size(HorizontalScrollBar.Width - offset, Consts.ScrollBarSize);

            // Values
            _vScrollBar.Minimum = VerticalScrollBar.Minimum;
            _vScrollBar.Maximum = VerticalScrollBar.Maximum;
            _vScrollBar.Value = VerticalScrollBar.Value;
            _hScrollBar.Minimum = HorizontalScrollBar.Minimum;
            _hScrollBar.Maximum = HorizontalScrollBar.Maximum;
            _hScrollBar.Value = HorizontalScrollBar.Value;

            _vScrollBar.ViewSize = Height;
            _hScrollBar.ViewSize = Width;
        }

        // Events

        private void NativeScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            SyncScrollBars();
        }

        // Overrides

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            UpdateTheme();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            UpdateSelectionColors(true);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            UpdateSelectionColors(false);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Invalidate();
        }

        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Fill the little square where both scrollbars meet so it matches the theme.
            if (VerticalScrollBar.Visible && HorizontalScrollBar.Visible)
            {
                Rectangle corner = new Rectangle(VerticalScrollBar.Left, HorizontalScrollBar.Top, VerticalScrollBar.Width, HorizontalScrollBar.Height);

                using (SolidBrush b = new SolidBrush(ThemeProvider.CurrentTheme.GreyBackground))
                    e.Graphics.FillRectangle(b, corner);
            }

            using (Pen p = new Pen(ThemeProvider.CurrentTheme.DarkBorder))
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
        }
    }
}
