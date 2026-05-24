namespace DarkUI.Docking
{
    public class DockContentRemovingEventArgs : DockContentEventArgs
    {
        public bool Cancel { get; set; } = false;

        public DockContentRemovingEventArgs(DarkDockContent content, bool cancel) : base(content)
        {
            Cancel = cancel;
        }
    }
}
