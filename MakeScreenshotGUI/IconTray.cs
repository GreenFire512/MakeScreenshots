using MakeScreenshot;
using System;
using System.Windows.Forms;

namespace MakeScreenshotGUI
{
    class IconTray
    {
        NotifyIcon ni;
        static MenuItem[] menuList = new MenuItem[] { new MenuItem("FullScreen"), new MenuItem("ActiveScreen"), new MenuItem("ClipScreen"), new MenuItem("Test"), new MenuItem("Settings"), new MenuItem("Exit") };
        ContextMenu clickMenu = new ContextMenu(menuList);

        public void Start()
        {
            ni = new NotifyIcon
            {
                Icon = Properties.Resources.Icon,
                Visible = true,
                ContextMenu = clickMenu
            };

            //ni.Click += new System.EventHandler(NotifyIcon_Click);


            menuList[0].Click += new EventHandler(MenuFullScreen_Click);
            menuList[1].Click += new EventHandler(MenuActiveScreen_Click);
            menuList[2].Click += new EventHandler(MenuClipScreen_Click);
            menuList[3].Click += new EventHandler(MenuTest_Click);
            menuList[4].Click += new EventHandler(MenuSettings_Click);
            menuList[5].Click += new EventHandler(MenuExit_Click);
        }

        public void Dispose()
        {
            ni.Dispose();
        }

        private void MenuFullScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void MenuActiveScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeActiveScreen();
        }

        private void MenuClipScreen_Click(object sender, EventArgs e)
        {
            Screenshot.TakeFullScreen();
        }

        private void MenuTest_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.Show();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
