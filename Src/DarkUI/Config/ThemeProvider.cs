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
        public static Dictionary<string, ITheme> Themes { get; set; } = new Dictionary<string, ITheme>(StringComparer.OrdinalIgnoreCase);
        public static ITheme CurrentTheme
        {
            get
            {
                if (_currentTheme is null)
                    _currentTheme = Themes[DarkTheme.ThemeName];

                return _currentTheme;
            }
            set
            {
                ITheme newTheme = value ?? Themes[DarkTheme.ThemeName];

                if (newTheme is SystemTheme system)
                    system.Refresh();

                if (ReferenceEquals(_currentTheme, newTheme))
                    return;

                _currentTheme = newTheme;
                OnThemeChanged();
            }
        }

        private static ITheme _currentTheme = null;

        public static event EventHandler ThemeChanged;

        static ThemeProvider()
        {
            ITheme system = new SystemTheme();
            ITheme light = new LightTheme();
            ITheme dark = new DarkTheme();

            Themes.Add(system.Name, system);
            Themes.Add(light.Name, light);
            Themes.Add(dark.Name, dark);

            _currentTheme = dark;

            // Detect OS light/dark theme changes
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        private static void OnThemeChanged()
        {
            ApplyTheme();
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void ApplyTheme()
        {
            List<DarkForm> openForms = Application.OpenForms.OfType<DarkForm>().ToList();

            foreach (DarkForm frm in openForms)
                ApplyTheme(frm);
        }

        public static void ApplyTheme(Form frm)
        {
            if (frm is null)
                throw new ArgumentNullException(nameof(frm));

            // Always (re)subscribe: DWM attributes are per-HWND and are lost whenever WinForms recreates the handle (ShowInTaskbar, RightToLeft, ...)
            frm.HandleCreated -= OnFormHandleCreated;
            frm.HandleCreated += OnFormHandleCreated;

            if (!frm.IsHandleCreated)
                return;

            Native.EnableImmersiveDarkMode(frm.Handle, _currentTheme.UseImmersiveDarkMode);
            Native.SetCornerPreference(frm.Handle, _currentTheme.CornerPreference);
            Native.SetBackdrop(frm.Handle, _currentTheme.BackdropType);
            //Native.ExtendFrameFully(frm.Handle);
            frm.RefreshRecursive();
        }

        // Events

        private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category != UserPreferenceCategory.General)
                return;

            if (!(Themes[SystemTheme.ThemeName] is SystemTheme system))
                return;

            if (system.Refresh() || ReferenceEquals(_currentTheme, system))
                OnThemeChanged();
        }

        private static void OnFormHandleCreated(object sender, EventArgs e)
        {
            if (sender is Form frm)
                ApplyTheme(frm);
        }
    }
}
