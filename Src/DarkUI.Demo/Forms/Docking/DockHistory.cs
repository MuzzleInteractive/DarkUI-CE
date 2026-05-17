using DarkUI.Controls;
using DarkUI.Docking;

namespace DarkUI.Demo.Forms.Docking
{
    public partial class DockHistory : DarkToolWindow
    {
        public DockHistory()
        {
            InitializeComponent();

            // Build dummy list data
            for (var i = 0; i < 100; i++)
            {
                var item = new DarkListItem($"List item #{i}");
                lstHistory.Items.Add(item);
            }
        }
    }
}
