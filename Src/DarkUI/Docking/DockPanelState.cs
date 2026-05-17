using System.Collections.Generic;

namespace DarkUI.Docking
{
    public class DockPanelState
    {
        public List<DockRegionState> Regions { get; set; }

        public DockPanelState()
        {
            Regions = new List<DockRegionState>();
        }
    }
}
