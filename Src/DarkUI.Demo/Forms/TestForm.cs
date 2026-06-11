using DarkUI.Config;
using DarkUI.Forms;
using System;

namespace DarkUI.Demo.Forms
{
    public partial class TestForm : DarkForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void BTNOpenMainForm_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
        }

        private void BTNSystemTheme_Click(object sender, EventArgs e)
        {
            ThemeProvider.CurrentTheme = ThemeProvider.Themes["System"];
        }

        private void BTNLightTheme_Click(object sender, EventArgs e)
        {
            ThemeProvider.CurrentTheme = ThemeProvider.Themes["Light"];
        }

        private void BTNDarkTheme_Click(object sender, EventArgs e)
        {
            ThemeProvider.CurrentTheme = ThemeProvider.Themes["Dark"];
        }
    }
}
