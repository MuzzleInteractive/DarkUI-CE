using DarkUI.Config;
using System.ComponentModel;

namespace DarkUI.Docking
{
    [ToolboxItem(false)]
    public class DarkDocument : DarkDockContent
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DarkDockArea DefaultDockArea
        {
            get { return base.DefaultDockArea; }
        }

        public DarkDocument()
        {
            BackColor = ThemeProvider.CurrentTheme.GreyBackground;
            base.DefaultDockArea = DarkDockArea.Document;
        }
    }
}
