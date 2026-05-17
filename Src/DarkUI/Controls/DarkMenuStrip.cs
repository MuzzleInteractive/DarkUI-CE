using DarkUI.Renderers;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkMenuStrip : MenuStrip
    {
        public DarkMenuStrip()
        {
            Renderer = new DarkMenuRenderer();
            Padding = new Padding(3, 2, 0, 2);
        }
    }
}
