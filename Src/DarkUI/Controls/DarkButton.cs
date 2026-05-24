using DarkUI.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    public class DarkButton : Button
    {
        [Category("Appearance")]
        [Description("The text associated with the control.")]
        [DefaultValue("")]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [Description("Indicates whether the control is enabled.")]
        [DefaultValue(true)]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines the style of the button.")]
        [DefaultValue(DarkButtonStyle.Normal)]
        public DarkButtonStyle ButtonStyle
        {
            get { return _style; }
            set
            {
                _style = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines the amount of padding between the image and text.")]
        [DefaultValue(5)]
        public int TextImagePadding
        {
            get { return _textImagePadding; }
            set
            {
                _textImagePadding = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The alignment of the text that will be displayed on the control. TextImageRelation must be overlay.")]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public new ContentAlignment TextAlign
        {
            get { return base.TextAlign; }
            set
            {
                base.TextAlign = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The alignment of the image that will be displayed on the control. TextImageRelation must be overlay.")]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public new ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
            set
            {
                base.ImageAlign = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The alignment of the text and image that will be displayed on the control. TextImageRelation must not be overlay.")]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment TextImageAlign
        {
            get { return _textImageAlign; }
            set
            {
                _textImageAlign = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoEllipsis
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DarkControlState ButtonState
        {
            get { return _buttonState; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool FlatAppearance
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseCompatibleTextRendering
        {
            get { return false; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseVisualStyleBackColor
        {
            get { return false; }
        }

        private DarkButtonStyle _style = DarkButtonStyle.Normal;
        private DarkControlState _buttonState = DarkControlState.Normal;
        private bool _isDefault;
        private bool _spacePressed;
        private int _padding = Consts.Padding / 2;
        private int _textImagePadding = Consts.Padding / 2;
        private ContentAlignment _textImageAlign = ContentAlignment.MiddleCenter;

        public DarkButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            base.UseVisualStyleBackColor = false;
            base.UseCompatibleTextRendering = false;

            SetButtonState(DarkControlState.Normal);
            Padding = new Padding(_padding);
        }

        private void SetButtonState(DarkControlState buttonState)
        {
            if (_buttonState != buttonState)
            {
                _buttonState = buttonState;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            var form = FindForm();
            if (form != null)
            {
                if (form.AcceptButton == this)
                    _isDefault = true;
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_spacePressed)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                    SetButtonState(DarkControlState.Pressed);
                else
                    SetButtonState(DarkControlState.Hover);
            }
            else
            {
                SetButtonState(DarkControlState.Hover);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ClientRectangle.Contains(e.Location))
                return;

            SetButtonState(DarkControlState.Pressed);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (_spacePressed)
                return;

            SetButtonState(DarkControlState.Normal);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (_spacePressed)
                return;

            SetButtonState(DarkControlState.Normal);
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);

            if (_spacePressed)
                return;

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(DarkControlState.Normal);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            _spacePressed = false;

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(DarkControlState.Normal);
            else
                SetButtonState(DarkControlState.Hover);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space)
            {
                _spacePressed = true;
                SetButtonState(DarkControlState.Pressed);
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Space)
            {
                _spacePressed = false;

                var location = Cursor.Position;

                if (!ClientRectangle.Contains(location))
                    SetButtonState(DarkControlState.Normal);
                else
                    SetButtonState(DarkControlState.Hover);
            }
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(value);

            if (!DesignMode)
                return;

            _isDefault = value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            var textColor = ThemeProvider.CurrentTheme.LightText;
            var borderColor = ThemeProvider.CurrentTheme.GreySelection;
            var fillColor = _isDefault ? ThemeProvider.CurrentTheme.DarkAccentBackground : ThemeProvider.CurrentTheme.LightBackground;

            if (Enabled)
            {
                if (ButtonStyle == DarkButtonStyle.Normal)
                {
                    if (Focused && TabStop)
                        borderColor = ThemeProvider.CurrentTheme.AccentHighlight;

                    switch (ButtonState)
                    {
                        case DarkControlState.Hover:
                            fillColor = _isDefault ? ThemeProvider.CurrentTheme.AccentBackground : ThemeProvider.CurrentTheme.LighterBackground;
                            break;
                        case DarkControlState.Pressed:
                            fillColor = _isDefault ? ThemeProvider.CurrentTheme.DarkBackground : ThemeProvider.CurrentTheme.DarkBackground;
                            break;
                    }
                }
                else if (ButtonStyle == DarkButtonStyle.Flat)
                {
                    switch (ButtonState)
                    {
                        case DarkControlState.Normal:
                            fillColor = ThemeProvider.CurrentTheme.GreyBackground;
                            break;
                        case DarkControlState.Hover:
                            fillColor = ThemeProvider.CurrentTheme.MediumBackground;
                            break;
                        case DarkControlState.Pressed:
                            fillColor = ThemeProvider.CurrentTheme.DarkBackground;
                            break;
                    }
                }
            }
            else
            {
                textColor = ThemeProvider.CurrentTheme.DisabledText;
                fillColor = ThemeProvider.CurrentTheme.DarkGreySelection;
            }

            using (var b = new SolidBrush(fillColor))
                g.FillRectangle(b, rect);

            if (ButtonStyle == DarkButtonStyle.Normal)
            {
                using (var p = new Pen(borderColor, 1))
                    g.DrawRectangle(p, new Rectangle(rect.Left, rect.Top, rect.Width - 1, rect.Height - 1));
            }

            ContentAlignment anyLeft = ContentAlignment.TopLeft | ContentAlignment.MiddleLeft | ContentAlignment.BottomLeft;
            ContentAlignment anyRight = ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight;
            ContentAlignment anyTop = ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight;
            ContentAlignment anyBottom = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
            ContentAlignment anyCenter = ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter;
            ContentAlignment anyMiddle = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;
            Rectangle modRect = new Rectangle(
                    rect.Left + Padding.Left,
                    rect.Top + Padding.Top,
                    rect.Width - Padding.Horizontal,
                    rect.Height - Padding.Vertical);

            if (TextImageRelation == TextImageRelation.Overlay)
            {
                // Image

                if (Image != null)
                {
                    int x;
                    int y;
                    ContentAlignment imageAlignment = ImageAlign;

                    imageAlignment = RtlTranslateContent(imageAlignment);

                    switch (ImageAlign) // Horizontal
                    {
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.BottomCenter:
                            x = modRect.X + (modRect.Width - Image.Width) / 2;
                            break;
                        case ContentAlignment.TopRight:
                        case ContentAlignment.MiddleRight:
                        case ContentAlignment.BottomRight:
                            x = modRect.Right - Image.Width;
                            break;
                        default: // Left
                            x = modRect.X;
                            break;
                    }

                    switch (ImageAlign) // Vertical
                    {
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.MiddleRight:
                            y = modRect.Y + (modRect.Height - Image.Height) / 2;
                            break;
                        case ContentAlignment.BottomLeft:
                        case ContentAlignment.BottomCenter:
                        case ContentAlignment.BottomRight:
                            y = modRect.Bottom - Image.Height;
                            break;
                        default: // Top
                            y = modRect.Y;
                            break;
                    }

                    if ((imageAlignment & anyLeft) != 0)
                        x += Padding.Left;
                    else if ((imageAlignment & anyRight) != 0)
                        x -= Padding.Right;

                    if ((imageAlignment & anyTop) != 0)
                        y += Padding.Top;
                    else if ((imageAlignment & anyBottom) != 0)
                        y -= Padding.Bottom;

                    if (Enabled)
                        g.DrawImage(Image, new Rectangle(x, y, Image.Width, Image.Height), new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                    else
                        ControlPaint.DrawImageDisabled(g, Image, x, y, fillColor);
                }

                // Text - Code from .NET WinForms Git - Adjusted

                bool showEllipsis = false;
                ContentAlignment textAlignment = TextAlign;

                if (AutoEllipsis)
                {
                    Size preferredSize = PreferredSize;
                    showEllipsis = (ClientRectangle.Width < preferredSize.Width || ClientRectangle.Height < preferredSize.Height);
                }

                textAlignment = RtlTranslateContent(textAlignment);
                TextFormatFlags flags = TextFormatFlags.Top | TextFormatFlags.Left;

                if ((textAlignment & anyBottom) != 0)
                    flags |= TextFormatFlags.Bottom;
                else if ((textAlignment & anyMiddle) != 0)
                    flags |= TextFormatFlags.VerticalCenter;

                if ((textAlignment & anyRight) != 0)
                    flags |= TextFormatFlags.Right;
                else if ((textAlignment & anyCenter) != 0)
                    flags |= TextFormatFlags.HorizontalCenter;

                flags |= TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;

                if (showEllipsis)
                    flags |= TextFormatFlags.EndEllipsis;

                if (RightToLeft == RightToLeft.Yes)
                    flags |= TextFormatFlags.RightToLeft;

                if (!UseMnemonic)
                    flags |= TextFormatFlags.NoPrefix;
                else if (!ShowKeyboardCues)
                    flags |= TextFormatFlags.HidePrefix;

                //TextFormatFlags flags = ControlPaint.CreateTextFormatFlags(this, TextAlign, showEllipsis, UseMnemonic);
                TextRenderer.DrawText(g, Text, Font, modRect, textColor, flags);
            }
            else
            {
                SizeF textSize = g.MeasureString(Text, Font, rect.Size);
                RectangleF textImageRect = new RectangleF(new Point(0, 0), textSize);
                Point locationText = new Point(0, 0);
                Point locationImage = new Point(0, 0);
                bool above = false;
                ContentAlignment textImageAlignment = TextImageAlign;

                textImageAlignment = RtlTranslateContent(textImageAlignment);

                // Calculate the rect size (Image + TextImagePadding + Text)

                if (TextImageRelation == TextImageRelation.ImageAboveText
                    || TextImageRelation == TextImageRelation.TextAboveImage)
                {
                    textImageRect.Width = Math.Max(textImageRect.Width, Image is null ? 0 : Image.Width);
                    textImageRect.Height += Image is null ? 0 : TextImagePadding + Image.Height;
                    above = true;
                }
                else if (TextImageRelation == TextImageRelation.ImageBeforeText
                    || TextImageRelation == TextImageRelation.TextBeforeImage)
                {
                    textImageRect.Width += Image is null ? 0 : TextImagePadding + Image.Width;
                    textImageRect.Height = Math.Max(textImageRect.Height, Image is null ? 0 : Image.Height);
                }

                // Calculate the rect location

                switch (textImageAlignment) // Horizontal
                {
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        textImageRect.X = modRect.X + (modRect.Width - textImageRect.Width) / 2;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        textImageRect.X = modRect.Right - textImageRect.Width;
                        break;
                    default: // Left
                        textImageRect.X = modRect.X;
                        break;
                }

                switch (textImageAlignment) // Vertical
                {
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                        textImageRect.Y = modRect.Y + (modRect.Height - textImageRect.Height) / 2;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        textImageRect.Y = modRect.Bottom - textImageRect.Height;
                        break;
                    default: // Top
                        textImageRect.Y = modRect.Y;
                        break;
                }

                if ((textImageAlignment & anyLeft) != 0)
                    textImageRect.X += Padding.Left;
                else if ((textImageAlignment & anyRight) != 0)
                    textImageRect.X -= Padding.Right;

                if ((textImageAlignment & anyTop) != 0)
                    textImageRect.Y += Padding.Top;
                else if ((textImageAlignment & anyBottom) != 0)
                    textImageRect.Y -= Padding.Bottom;

                // Calculate image and text individual locations
                // This calculations need tweaking, we should not take into account invisible space
                // We should calculate always for the visible rect
                if (TextImageRelation == TextImageRelation.ImageAboveText)
                {
                    locationText.X = (int)(textImageRect.X + (textImageRect.Width - textSize.Width) / 2);
                    locationText.Y = (int)textImageRect.Y + (Image is null ? 0 : Image.Height + TextImagePadding);
                    locationImage.X = (int)(textImageRect.X + (textImageRect.Width - Image.Width) / 2);
                    locationImage.Y = (int)textImageRect.Y;
                }
                else if (TextImageRelation == TextImageRelation.TextAboveImage)
                {
                    locationText.X = (int)(textImageRect.X + (textImageRect.Width - textSize.Width) / 2);
                    locationText.Y = (int)textImageRect.Y;
                    locationImage.X = (int)textImageRect.X + ((int)textImageRect.Width - Image.Width) / 2;
                    locationImage.Y = (int)textImageRect.Y + (int)textSize.Height + TextImagePadding;
                }
                else if (TextImageRelation == TextImageRelation.ImageBeforeText)
                {
                    locationText.X = (int)textImageRect.X + (Image is null ? 0 : Image.Width + TextImagePadding);
                    locationText.Y = (int)(textImageRect.Y + (textImageRect.Height - textSize.Height) / 2) + 2; // +2 to offset text
                    locationImage.X = (int)textImageRect.X;
                    locationImage.Y = (int)(textImageRect.Y + (textImageRect.Height - (Image is null ? 0 : Image.Height)) / 2);
                }
                else if (TextImageRelation == TextImageRelation.TextBeforeImage)
                {
                    locationText.X = (int)textImageRect.X;
                    locationText.Y = (int)(textImageRect.Y + (textImageRect.Height - (Image is null ? 0 : textSize.Height)) / 2) + 2;
                    locationImage.X = (int)textImageRect.X + (Image is null ? 0 : (int)textSize.Width + TextImagePadding);
                    locationImage.Y = (int)(textImageRect.Y + (textImageRect.Height - Image.Height) / 2);
                }

                if (Image != null)
                {
                    if (Enabled)
                        g.DrawImage(Image, new Rectangle(locationImage.X, locationImage.Y, Image.Width, Image.Height), new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                    else
                        ControlPaint.DrawImageDisabled(g, Image, locationImage.X, locationImage.Y, fillColor);
                }

                // We need to handle ellipsis char -- Currently missing
                using (var b = new SolidBrush(textColor))
                    g.DrawString(Text, Font, b, locationText);
            }
        }
    }
}
