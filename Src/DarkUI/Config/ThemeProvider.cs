using DarkUI.Extensions;
using DarkUI.Forms;
using DarkUI.Win32;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DarkUI.Config
{
    public static class ThemeProvider
    {
        public static Dictionary<string, ITheme> Themes { get; private set; } = new Dictionary<string, ITheme>(StringComparer.OrdinalIgnoreCase);
        public static ITheme CurrentTheme
        {
            get
            {
                if (_currentTheme is null)
                    _currentTheme = new DarkTheme();

                return _currentTheme;
            }
            set
            {
                if (value is null)
                    _currentTheme = new DarkTheme();
                else
                    _currentTheme = value;
            }
        }

        private static ITheme _currentTheme = null;

        static ThemeProvider()
        {
            ITheme system = GetSystemAwareTheme();
            ITheme light = new LightTheme();
            ITheme dark = new DarkTheme();

            Themes.Add("System", system);
            Themes.Add(light.Name, new LightTheme());
            Themes.Add(dark.Name, new DarkTheme());

            _currentTheme = system;
        }

        public static ITheme GetSystemAwareTheme()
        {
            object value = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
            bool appsUseLightTheme = value is int intValue ? intValue != 0 : true;

            if (appsUseLightTheme)
                return new LightTheme();
            else
                return new DarkTheme();
        }

        public static void ApplyTheme()
        {
            IEnumerable<DarkForm> openForms = Application.OpenForms.OfType<DarkForm>();

            foreach (DarkForm frm in openForms)
            {
                frm.RefreshRecursive();
                EnableImmersiveDarkMode(frm.Handle, _currentTheme.DarkMode);
            }
        }

        public static void ApplyTheme(Form frm)
        {
            EnableImmersiveDarkMode(frm.Handle, _currentTheme.DarkMode);
            frm.RefreshRecursive();
        }

        private static void EnableImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            int useDarkMode = enabled ? 1 : 0;
            int result = Native.DwmSetWindowAttribute(handle, (int)WM.DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, sizeof(int));

            if (result != 0)
                Native.DwmSetWindowAttribute(handle, (int)WM.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1, ref useDarkMode, sizeof(int));
        }
    }
}
