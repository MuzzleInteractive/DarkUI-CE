using Microsoft.Win32;
using System.Drawing;
using static DarkUI.Win32.Native;

namespace DarkUI.Config
{
    public class SystemTheme : ITheme
    {
        internal const string ThemeName = "System";

        public string Name => ThemeName;
        public bool UseImmersiveDarkMode => _inner.UseImmersiveDarkMode;
        public WindowCornerPreference CornerPreference => _inner.CornerPreference;
        public SystemBackdropType BackdropType => _inner.BackdropType;
        public Color GreyBackground => _inner.GreyBackground;
        public Color HeaderBackground => _inner.HeaderBackground;
        public Color AccentBackground => _inner.AccentBackground;
        public Color DarkAccentBackground => _inner.DarkAccentBackground;
        public Color DarkBackground => _inner.DarkBackground;
        public Color MediumBackground => _inner.MediumBackground;
        public Color LightBackground => _inner.LightBackground;
        public Color LighterBackground => _inner.LighterBackground;
        public Color LightestBackground => _inner.LightestBackground;
        public Color LightBorder => _inner.LightBorder;
        public Color DarkBorder => _inner.DarkBorder;
        public Color LightText => _inner.LightText;
        public Color DisabledText => _inner.DisabledText;
        public Color AccentHighlight => _inner.AccentHighlight;
        public Color AccentSelection => _inner.AccentSelection;
        public Color GreyHighlight => _inner.GreyHighlight;
        public Color GreySelection => _inner.GreySelection;
        public Color DarkGreySelection => _inner.DarkGreySelection;
        public Color DarkAccentBorder => _inner.DarkAccentBorder;
        public Color LightAccentBorder => _inner.LightAccentBorder;
        public Color ActiveControl => _inner.ActiveControl;

        private ITheme _inner;

        public SystemTheme()
        {
            Refresh();
        }

        internal bool Refresh()
        {
            bool isLight = SystemAppsUseLightTheme();
            bool changed = _inner is null || _inner.UseImmersiveDarkMode && isLight;

            if (isLight)
                _inner = new LightTheme();
            else
                _inner = new DarkTheme();

            return changed;
        }

        public static bool SystemAppsUseLightTheme()
        {
            bool appsUseLightTheme = false;

            try
            {
                object value = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1);
                appsUseLightTheme = value is int intValue ? intValue != 0 : true;
            }
            catch { }

            return appsUseLightTheme;
        }
    }
}
