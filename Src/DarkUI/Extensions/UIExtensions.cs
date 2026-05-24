using DarkUI.Win32;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DarkUI.Extensions
{
    public static class UIExtensions
    {
        public static void ShowAndFocus(this Form form)
        {
            form.Show();
            form.Focus();
        }

        public static void EnableDoubleBufferFlagRecursive(this Control c, bool value)
        {
            c.EnableDoubleBufferFlag(value);

            foreach (Control child in c.Controls)
                child.EnableDoubleBufferFlagRecursive(value);
        }

        public static void EnableDoubleBufferFlag(this Control c, bool value)
        {
            PropertyInfo pi = c.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);

            if (pi is null)
                return;

            pi.SetValue(c, value, null);
        }

        public static void RefreshRecursive(this Control c)
        {
            c.Refresh();

            foreach (Control child in c.Controls)
                child.RefreshRecursive();
        }

        public static void InvokeIfRequired(this Control c, Action action)
        {
            if (c.InvokeRequired)
                c.Invoke(new System.Windows.Forms.MethodInvoker(() =>
                {
                    action();
                }));
            else
                action();
        }

        public static void InvokeIfRequiredAsync(this Control c, Action action)
        {
            if (c.InvokeRequired)
                c.BeginInvoke(new System.Windows.Forms.MethodInvoker(() =>
                {
                    action();
                }));
            else
                action();
        }

        public static void SetState(this ProgressBar pgb, int state)
        {
            // 1 = normal (green); 2 = error (red); 3 = warning (yellow);
            Native.SendMessage(pgb.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
