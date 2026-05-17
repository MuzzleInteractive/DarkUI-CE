using DarkUI.Renderers;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkContextMenu : ContextMenuStrip
    {
        public DarkContextMenu()
        {
            Renderer = new DarkMenuRenderer();
        }
    }
}
